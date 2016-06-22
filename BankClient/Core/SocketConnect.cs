using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankClient
{
    class DataEnclose
    {
        public ClientAction clientBank;
        public byte[] data;
        public Socket handle;

        public void SetDataToPeerData()
        {
            clientBank.SetDataRead(data);
        }
    }

    class SocketConnect
    {

        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        public static ManualResetEvent sendingDone = new ManualResetEvent(false);
        public static frmClient mainThread;

        public static void SetFormInstance(frmClient pMainThread)
        {
            mainThread = pMainThread;
        }

        public static void ConnectServer(string pIp, int pPort)
        {
            IPEndPoint IpToConnect = new IPEndPoint(IPAddress.Parse(pIp), pPort);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.BeginConnect(IpToConnect, new AsyncCallback(ConnectingServer), client);
            connectDone.WaitOne();

            mainThread.CreateClient(client);
        }

        public static void ConnectingServer(IAsyncResult ar)
        {

            Socket client = (Socket)ar.AsyncState;

            try
            {
                client.EndConnect(ar);
                connectDone.Set();
            }
            catch
            {
                mainThread.ChangeStatusLabel("Error");
            }

        }

        public static void ReceiveFromServer(ClientAction pClientBank)
        {
            Socket newSocket = pClientBank.GetClientSocket();
            DataEnclose dataTransfer = new DataEnclose();
            dataTransfer.clientBank = pClientBank;
            dataTransfer.data = new byte[PeerClient.totalByteRead];
            dataTransfer.handle = pClientBank.GetClientSocket();

            newSocket.BeginReceive(dataTransfer.data, 0, PeerClient.totalByteRead, SocketFlags.None, new AsyncCallback(ReceivingFromServer), dataTransfer);
        }

        public static void ReceivingFromServer(IAsyncResult ar)
        {
            DataEnclose dataTransfer = (DataEnclose)ar.AsyncState;
            Socket client = dataTransfer.handle;

            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                dataTransfer.data = dataTransfer.data.Take(bytesRead).ToArray();
                dataTransfer.SetDataToPeerData();
                dataTransfer.data = new byte[PeerClient.totalByteRead];
                client.BeginReceive(dataTransfer.data, 0, PeerClient.totalByteRead, SocketFlags.None, new AsyncCallback(ReceivingFromServer), dataTransfer);
            }
        }

        public static void SendToServer(ClientAction pClientBank)
        {
            try
            { 
                //Generating packet (DataEnclose) to send to sever.
                DataEnclose dataTransfer = new DataEnclose();
                Socket newSocket = pClientBank.GetClientSocket();
                dataTransfer.clientBank = pClientBank;
                dataTransfer.handle = newSocket;
                dataTransfer.data = pClientBank.GetDataSend();

                mainThread.ChangeContacting("Connecting...", true);
                newSocket.BeginSend(dataTransfer.data, 0, dataTransfer.data.Length, SocketFlags.None, new AsyncCallback(SendingToServer), dataTransfer);
                sendingDone.WaitOne(); //Wait until all the information was sent;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                frmClient.ShowMessageClient(e.Message);
                //mainThread.ChangeContacting("Error!", true);
            }

        }

        private static void SendingToServer(IAsyncResult ar)
        {
            DataEnclose client = (DataEnclose)ar.AsyncState;
            int bytesSent = client.handle.EndSend(ar);

            if (bytesSent > 0)
            {
                mainThread.ChangeContacting("[...]", false);
            }
            sendingDone.Set();
        }

    }
}
