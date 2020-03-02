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

namespace OCL1_PY1
{
    
    public partial class Form1 : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        RichTextBox rtbx = new RichTextBox();
        int pestaña = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------NUEVA PESTAÑA--------------------------
        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.Visible == false)
                {
                    tabControl1.Visible = true;
                }
                TabPage page = new TabPage();
                rtbx = new RichTextBox();
                int TabControl = (tabControl1.TabCount + 1);
                page.Text = "New " + TabControl.ToString();
                tabControl1.TabPages.Add(page);
                rtbx.Dock = DockStyle.Fill;
                page.Controls.Add(rtbx);
                return;
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), "ERROR");
            }
        }
        //--------------------------------ABRIR---------------------------
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open.Filter = "er|*.er";
            if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(open.FileName);
                String name = open.FileName;
                AddPage(reader.ReadToEnd(), Path.GetFileName(open.FileName));
                reader.Close();

                tabControl1.SelectedIndex = tabControl1.TabCount - 1;
                
            }
            tabControl1.Visible = true;
        }

        public void AddPage(String txt, String tag)
        {
            RichTextBox rtb = new RichTextBox();
            TabPage page = new TabPage();
            rtb.Width = tabControl1.Size.Width - 7;
            rtb.Height = tabControl1.Size.Height - 25;
            rtb.AcceptsTab = true;
            rtb.Text = txt;
            page.Controls.Add(rtb);
            page.Text = tag;
            tabControl1.TabPages.Add(page);
            rtb.Multiline = true;
            rtb.AcceptsTab = true;
            Path.GetFileName(open.FileName);

        }
    }
}
