using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Url boş geçilemez");
            else
            {
                listView1.Items.Clear();
                RssReader rs = new RssReader(textBox1.Text);
                foreach (Haber haber in rs.GetNews())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = haber.Haberbasligi;
                    lvi.SubItems.Add(haber.Link);
                    listView1.Items.Add(lvi);
                }

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.Items.Count>0)
            {
                webBrowser1.Navigate(listView1.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
