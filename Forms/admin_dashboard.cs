using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jandm_pos.Forms
{
    public partial class admin_dashboard : Form
    {
        public admin_dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            functions_system showSubPanel = new functions_system();
            showSubPanel.ShowSubMenu(panel5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            functions_system showSubPanel = new functions_system();
            showSubPanel.ShowSubMenu(panel6);
        }

        
    }
}
