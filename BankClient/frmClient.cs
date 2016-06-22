using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class frmClient : Form
    {
        private ClientAction clientBank;
        private TabPage tpConnTemp;

        delegate void SetTabsPageDelegate();
        delegate void FuncDelegatedStringParam(string pParam);

        public frmClient()
        {
            InitializeComponent();
            tpConnTemp = tpConnected;
            tbControl.TabPages.Remove(tpConnected);
        }

        private void smConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendInfo();
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientBank != null)
            {
                clientBank.DisconnectMe();
            }
        }

        private void ConnectToServer()
        {
            SocketConnect.SetFormInstance(this);
            SocketConnect.ConnectServer(txtIp.Text, Convert.ToInt16(txtPort.Text));
        }

        private void SendInfo()
        {
            byte[] dataSend = ASCIIEncoding.ASCII.GetBytes("Testing...");
            clientBank.SetDataSend(dataSend);

            SocketConnect.SendToServer(clientBank);
        }

        public void RefreshBalance(string pAmount)
        {
            if (lbAccAmount.InvokeRequired)
            {
                FuncDelegatedStringParam func = new FuncDelegatedStringParam(RefreshBalance);
                Invoke(func, new object[] { pAmount });
            }
            else
            {
                lbAccAmount.Text = "$ " + pAmount;
            }
        }

        public void ChangeStatusLabel(string pStatus)
        {
            ssConnected.Text = pStatus;
        }

        public void ChangeContacting(string pMsg, bool pVisible)
        {
            ssContacting.Text = pMsg;
            ssContacting.Visible = pVisible;
        }

        public void CreateClient(Socket pClientSocket)
        {
            if (clientBank == null)
            {
                //Create client bound to server
                clientBank = new ClientAction(pClientSocket, this);
                smConnect.Enabled = false;
                ssConnected.Text = "Connected";

                //Start receive from server
                SocketConnect.ReceiveFromServer(clientBank);
            }
        }

        private void SetTabsPage()
        {
            //Removing tabs from tabcontrol after login is done
            tbControl.TabPages.Remove(tpConfig);
            tbControl.TabPages.Remove(tpConnecting);
            tbControl.TabPages.Add(tpConnected); //Adding account page

            tpConnected.Focus();
        }

        public void SetAccountClient(string pName, string pAmount)
        {
            lbNameAcc.Text = pName;
            lbAccAmount.Text = "$ " + pAmount;

            //UI Thread can't be accessed from other threads.
            if (tbControl.InvokeRequired)
            {
                SetTabsPageDelegate setTabs = new SetTabsPageDelegate(SetTabsPage);
                Invoke(setTabs);
            } else
            {
                SetTabsPage();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            clientBank.LoginAccount(txtAccount.Text, txtPassword.Text);
        }

        public static void ShowMessageClient(string pMsg)
        {
            MessageBox.Show(pMsg);
        }

        private void btnTransferToAccount_Click(object sender, EventArgs e)
        {
            frmTransfer frmTransferAmount = new frmTransfer(clientBank);
            frmTransferAmount.ShowDialog(this);
        }

        private void frmClient_Enter(object sender, EventArgs e)
        {
            tpConnected.Hide();
        }

    }

}
