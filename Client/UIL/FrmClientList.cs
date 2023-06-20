using Client.Communication;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UIL
{
    public partial class FrmClientList : DevExpress.XtraEditors.XtraForm
    {
        private ClientSocket clientSocket = new ClientSocket();
        public ClientSocket ClientSocket { get => clientSocket; set => clientSocket = value; }

        public FrmClientList()
        {
            InitializeComponent();
        }

    }
}