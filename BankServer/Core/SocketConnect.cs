using BankServer.Peer;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace BankServer
{
    //Class that is holding the buffer to set on PeerConnected later;
    class DataEnclose
    {
        public PeerAction peer;
        public byte[] data;
        public Socket handle;

        public void SetDataToPeerData()
        {
            peer.SetDataRead(data);
        }
    }

    public class SocketConnect
    {

        public static ManualResetEvent newSocketWaiting = new ManualResetEvent(false);
        public static frmServer MainThread;

        public static void SetFormInstance(frmServer pMainThread)
        {
            MainThread = pMainThread;
        }

        //Method that starts do listen new incoming peers (users).
        public static void StartServer()
        {
            IPAddress IpLocal = Array.Find(Dns.GetHostEntry(Dns.GetHostName()).AddressList, delegate (IPAddress addr) { return addr.AddressFamily == AddressFamily.InterNetwork; });
            IPEndPoint IpConnect = new IPEndPoint(IpLocal, 9898);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(IpConnect);
                listener.Listen(100);

                while (true)
                {
                    newSocketWaiting.Reset();

                    MainThread.ChangeStatusLabel("Waiting Connections...");
                    listener.BeginAccept(new AsyncCallback(AcceptingConnection), listener);

                    newSocketWaiting.WaitOne();
                }

            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Method that do Async accepting new connections releasing the main thread on .Set();
        public static void AcceptingConnection(IAsyncResult ar)
        {
            newSocketWaiting.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handle = listener.EndAccept(ar);

            MainThread.AddNewPeer(handle);
        }

        public static void ReceiveNewData(PeerAction pPeerConnected)
        {
            Socket newSocket = pPeerConnected.GetPeerSocket();
            DataEnclose dataHandle = new DataEnclose();
            dataHandle.data = new byte[PeerConnected.totalByteRead];
            dataHandle.peer = pPeerConnected;
            dataHandle.handle = newSocket;

            newSocket.BeginReceive(dataHandle.data, 0, PeerConnected.totalByteRead, SocketFlags.None, new AsyncCallback(ReceivingData), dataHandle);
        }

        public static void ReceivingData(IAsyncResult ar)
        {
            DataEnclose dataHandle = (DataEnclose)ar.AsyncState;
            Socket newSocket = dataHandle.handle;

            int bytesRead = newSocket.EndReceive(ar);

            if (bytesRead > 0)
            {
                //Method from DataEnclose class that transfer data from "packet" to Peer's data.
                //Then keep reading
                dataHandle.data = dataHandle.data.Take(bytesRead).ToArray();
                dataHandle.SetDataToPeerData();
                dataHandle.data = new byte[PeerConnected.totalByteRead];
                newSocket.BeginReceive(dataHandle.data, 0, PeerConnected.totalByteRead, SocketFlags.None, new AsyncCallback(ReceivingData), dataHandle);
            }
            else if (bytesRead == 0 && newSocket.Available == 0)
            {
                newSocket.Close();
                dataHandle.peer.RemoveMe();
            }
        }

        public static void SendToPeer(Socket pSocket, byte[] Data)
        {
            pSocket.BeginSend(Data, 0, Data.Length, SocketFlags.None, new AsyncCallback(SentToPeer), pSocket);
        }

        public static void SentToPeer(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;

                int bytesSent = socket.EndSend(ar);
            }
            catch
            {
                throw;
            }
        }
    }
}