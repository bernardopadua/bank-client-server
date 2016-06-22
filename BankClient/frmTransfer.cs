using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class frmTransfer : Form
    {
        private ClientAction clientAction;

        public frmTransfer(ClientAction pClientAction)
        {
            clientAction = pClientAction;
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            clientAction.Transfer(mTxtAccount.Text, mTxtValue.Text);
            this.Close();
        }
    }
}
