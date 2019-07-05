using Digitalna_Forenzika.Plugins;
using Digitalna_Forenzika.Processor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Digitalna_Forenzika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormListView();
        }

        private void FormListView()
        {
			CreateAndAddEncryptionView();
		}

		private void Form1_Load(object sender, EventArgs e)
        {

        }

		private void CreateAndAddEncryptionView()
		{
			EncryptionView ev = new EncryptionView();
			this.cryptoPanel.Controls.Clear();

			ev.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.cryptoPanel.Controls.Add(ev);
		}

		private void CreateAndAddDecryptionView()
		{
			DecryptionView dv = new DecryptionView();
			this.cryptoPanel.Controls.Clear();

			dv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.cryptoPanel.Controls.Add(dv);
		}

		private void encryptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateAndAddEncryptionView();
		}

		private void decryptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateAndAddDecryptionView();
		}
	}
}
