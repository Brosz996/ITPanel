using System.Net;

namespace ITPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        string publicIP = new WebClient().DownloadString("http://icanhazip.com");
        public void megnyitas(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);
            listBox1.Items.Clear();
            while (!sr.EndOfStream)
            {
                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                System.Diagnostics.Process.Start("CMD.exe", "/C ipconfig /all > ip.txt");
                button1.Enabled = false;
                radioButton4.Enabled = true;

            }
            else if (checkBox1.Checked == false)
            {
                System.Diagnostics.Process.Start("CMD.exe", "/C ipconfig > ip.txt");
                button1.Enabled = false;
                radioButton4.Enabled = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.Diagnostics.Process.Start("CMD.exe", "/C ipconfig /displaydns > dd.txt");
            button2.Enabled = false;
            button4.Enabled = true;
            radioButton1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.Diagnostics.Process.Start("CMD.exe", "/C ipconfig /flushdns");
            listBox1.Items.Add("Windows IP Configuration");
            listBox1.Items.Add("\n");
            listBox1.Items.Add("Successfully flushed the DNS Resolver Cache.");
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.Diagnostics.Process.Start("CMD.exe", "/C netsh wlan show profiles > sp.txt");
            button5.Enabled = false;
            radioButton3.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.Diagnostics.Process.Start("CMD.exe", "/C dir > dir.txt");
            button6.Enabled = false;
            radioButton2.Enabled = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton1.Enabled == false && radioButton2.Enabled == false && radioButton3.Enabled == false && radioButton4.Enabled == false)
            {
                button7.Enabled = false;
            }
            if (radioButton1.Checked == true)
            {
                megnyitas("dd.txt");
                System.Diagnostics.Process.Start("CMD.exe", "/C del dd.txt");
                button2.Enabled = true;
                radioButton1.Enabled = false;
            }
            if (radioButton2.Checked == true)
            {
                megnyitas("dir.txt");
                System.Diagnostics.Process.Start("CMD.exe", "/C del dir.txt");
                button6.Enabled = true;
                radioButton2.Enabled = false;
            }
            if (radioButton3.Checked == true)
            {
                megnyitas("sp.txt");
                System.Diagnostics.Process.Start("CMD.exe", "/C del sp.txt");
                button5.Enabled = true;
                radioButton3.Enabled = false;
            }
            if (radioButton4.Checked == true)
            {
                megnyitas("ip.txt");
                System.Diagnostics.Process.Start("CMD.exe", "/C del ip.txt");
                button1.Enabled = true;
                radioButton4.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("MY IP is:");
            listBox1.Items.Add(publicIP);
        }
    }
}