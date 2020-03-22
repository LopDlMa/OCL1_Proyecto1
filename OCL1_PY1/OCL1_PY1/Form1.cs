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
using System.Xml;

namespace OCL1_PY1
{
    
    public partial class Form1 : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        RichTextBox rtbx = new RichTextBox();
        List<Tokens> ultimos_lexemas;
        List<Tokens> ultimos_errores;
        
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

        //---------------------------------------GUARDAR------------------------------------
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "er| *.er";
            if(save.ShowDialog() == System.Windows.Forms.DialogResult.OK && save.FileName.Length > 0)
            {
                rtbx.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                TabPage PAGE = tabControl1.TabPages[tabControl1.SelectedIndex];
                RichTextBox rtext = (RichTextBox)PAGE.Controls[0];
                MessageBox.Show("Guardado \n" + save.FileName);
                System.IO.File.WriteAllText(save.FileName, rtext.Text);
            }
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabControl1.TabCount >= 1)
            {
                ultimos_lexemas = new List<Tokens>();
                ultimos_errores = new List<Tokens>();

                TabPage myPage = tabControl1.TabPages[tabControl1.SelectedIndex];
                RichTextBox myRich = (RichTextBox)myPage.Controls[0];

                Scanner scan = new Scanner();
                scan.Scaning(myRich.Text);

                ultimos_errores = (List<Tokens>)scan.error_list;
                ultimos_lexemas = (List<Tokens>)scan.list_Tokens;
                MessageBox.Show("ANALISIS REALIZADO");

                Console.WriteLine("LISTADO DE TOKENS");
                Console.WriteLine("**********************");
                foreach(Tokens t in ultimos_lexemas)
                {

                    Console.WriteLine(t.Value + " || LINEA : " + t.linea + " || COLUMNA : " + t.columna + "| TOKEN: "+t.TokenType);

                }
                Console.WriteLine("ERRORES ENCONTRADOS ");
                Console.WriteLine("...--...--...--...--..");
                foreach(Tokens t in ultimos_errores)
                {
                    Console.WriteLine("entro aqui en errores");
                    Console.WriteLine(t.Value + " || LINEA : " + t.linea + " || COLUMNA : " + t.columna);
                }
            }
            else
            {
                MessageBox.Show("Cree más Pestañas", "Word", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }

        private void generarReportesDeErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public void ReporteT()
        {
            ultimos_lexemas = new List<Tokens>();
            TabPage myPage = tabControl1.TabPages[tabControl1.SelectedIndex];
            RichTextBox myRich = (RichTextBox)myPage.Controls[0];

            Scanner scan = new Scanner();
            scan.Scaning(myRich.Text);

            ultimos_lexemas = (List<Tokens>)scan.list_Tokens;

            // GENERANDO

            XmlTextWriter writer = new XmlTextWriter("Reporte Tokens.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("ListaTokens");
            foreach(Tokens t in scan.list_Tokens)
            {
                NodosToken(t.TokenType.ToString(), t.Value, t.linea,t.columna,writer);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("REPORTE DE TOKENS CREADO");
           

        }
        private void NodosToken(String ID, String Val, int fila, int columna ,XmlTextWriter writer)
        {
            writer.WriteStartElement("Token");
           
            writer.WriteStartElement("Nombre");
            writer.WriteString(ID);
            writer.WriteEndElement();
            writer.WriteStartElement("Valor");
            writer.WriteString(Val);
            writer.WriteEndElement();
            writer.WriteStartElement("Fila");
            writer.WriteString(fila.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Columna");
            writer.WriteString(columna.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();


        }

        public void ReporteE()
        {
            ultimos_errores = new List<Tokens>();
            TabPage myPage = tabControl1.TabPages[tabControl1.SelectedIndex];
            RichTextBox myRich = (RichTextBox)myPage.Controls[0];

            Scanner scan = new Scanner();
            scan.Scaning(myRich.Text);

            ultimos_errores = (List<Tokens>)scan.error_list;

            // GENERANDO

            XmlTextWriter writer = new XmlTextWriter("Reporte Errores.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("ListaErrores");
            foreach (Tokens t in scan.error_list)
            {
                NodosError(t.Value, t.linea, t.columna, writer);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
     

        }

        private void NodosError(String Val, int fila, int columna, XmlTextWriter writer)
        {
            writer.WriteStartElement("Error");

            
            writer.WriteStartElement("Valor");
            writer.WriteString(Val);
            writer.WriteEndElement();
            writer.WriteStartElement("Fila");
            writer.WriteString(fila.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Columna");
            writer.WriteString(columna.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();


        }

        private void guardarTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReporteT();
        }

        private void guardarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteE(); 
        }
    }
}
