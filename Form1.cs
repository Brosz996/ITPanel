namespace ITPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void megnyitas(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);
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
                System.Diagnostics.Process.Start("CMD.exe", "/K ipconfig /all");
            }
            else if (checkBox1.Checked == false)
            {
                System.Diagnostics.Process.Start("CMD.exe", "/K ipconfig");
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
            System.Diagnostics.Process.Start("CMD.exe", "/K netsh wlan show profiles");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.Diagnostics.Process.Start("CMD.exe", "/C dir > dir.txt");
            megnyitas("./dir.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                megnyitas("dd.txt");
            }
        }
    }
}