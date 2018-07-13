using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectionString;





namespace UpdateCost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            checkconnection();
           
        }
        void checkconnection()
        {
            Cbm.CheckConnectionCbm checkcbm = new Cbm.CheckConnectionCbm();

            textBox1.Text = checkcbm.ExcuteCbm();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void run_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 50000;
            status_lbl.Text = "RUNING";
            status_pnl.BackColor = Color.Green;
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            status_lbl.Text = "STOP";
            status_pnl.BackColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
