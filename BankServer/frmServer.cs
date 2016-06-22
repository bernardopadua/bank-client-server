using BankServer.Peer;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace BankServer
{
    public partial class frmServer : Form
    {
        delegate void AddNewPeerCallBack(Socket pPeerSocket);

        private ManualResetEvent coreDone = new ManualResetEvent(false);
        private Thread startServer;

        private ServerAction svrAction;

        public frmServer()
        {
            InitializeComponent();
        }

        private void StartServer()
        {
            //Start socket communication;
            SocketConnect.SetFormInstance(this);
            SocketConnect.StartServer();
        }

        private void StartCoreServer()
        {
            svrAction = new ServerAction();
            svrAction.LoadAccounts();

            startServer = new Thread(StartServer);
            // .NET Framework kills all threads alive with this opt (IsBackground) set, when application exits
            startServer.IsBackground = true;
            startServer.Start();
        }

        private void btnStartListening_Click(object sender, System.EventArgs e)
        {
            if (startServer == null)
            {
                StartCoreServer();
            }
        }

        public void AddNewPeer(Socket pPeerSocket)
        {
            PeerAction NewPeer = new PeerAction(pPeerSocket, this);

            //Other threads can't access control from the main thread, then we need to delegate a function to do so.
            if (InvokeRequired)
            {
                AddNewPeerCallBack NewPeerCallBack = new AddNewPeerCallBack(AddNewPeer);
                this.Invoke(NewPeerCallBack, new object[] { pPeerSocket });
            } else
            {
                //Adding to ListBox
                NewPeer.listBoxSelectedIndex = lsbConnectedPeers.Items.Add(NewPeer.GetPeerSocket().RemoteEndPoint.ToString());
                NewPeer.StartToListenPeer(NewPeer); //Start receiving data.
            }
            
        }

        public ServerAction GetServerAction()
        {
            return svrAction;
        }

        public void ChangeStatusLabel(string status)
        {
            stStatus.Text = status;
        }

        public void RemovePeerFromServer(PeerConnected pPeer)
        {
            if (lsbConnectedPeers.InvokeRequired)
            {
                lsbConnectedPeers.Invoke(new MethodInvoker(delegate { lsbConnectedPeers.Items.RemoveAt(pPeer.listBoxSelectedIndex); }));
            }
        }

        public static void ShowMessageServer(string pMsg)
        {
            MessageBox.Show(pMsg);
        }
    }
}
