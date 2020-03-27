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
using System.Collections;
using System.Xml;
using System.Security;
using System.Runtime.ExceptionServices;

namespace OCL1_PY1
{
    
    public partial class Form1 : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        RichTextBox rtbx = new RichTextBox();
        List<Tokens> ultimos_lexemas;
        List<Tokens> ultimos_errores;
        public static String grafo;
        public string IN = "";
        public string eva = "";
        private Pila Pila;
        private int nodo = 0;
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
        public String DOT()
        {
            grafo += "digraph T{";
            grafo += "rankdir = LR;";
            estructuraDot();

            grafo += "}";

            return grafo;
        }
        public void estructuraDot()
        {
            
            for (int i= 0; i < ultimos_lexemas.Count; i++)
            {

                if (ultimos_lexemas[i].TokenType.ToString().Equals("ID") && ultimos_lexemas[i+1].TokenType.ToString().Equals("flecha")) 
                {
                    List<Tokens> respaldo = new List<Tokens>();
                    for (int j = i+2; j < ultimos_lexemas.Count; j++) 
                    {
                        if (!ultimos_lexemas[j].TokenType.ToString().Equals("Comilla_Doble"))
                        {
                            respaldo.Add(ultimos_lexemas[j]);
                        }
                        if (ultimos_lexemas[j+1].TokenType.ToString().Equals("Punto_Coma")) 
                        {
                            nodo = 0;
                            string done = Ordenar(respaldo);
                            Console.WriteLine(done);
                            dibujardot(done);
                       
                            break;
                        }
                    }
                }

            }
        
        }
        //private string Convertir(List<Tokens> tkn)
        //{
        //    string retorno = "";
        //    for (int i=0;i<tkn.Count;i++)
        //    {
        //        retorno += tkn[i].Value;
        //        if (i < tkn.Count - 1) {
        //            retorno += " ";
        //        }
        //    }
        //    return retorno;
        //}
        private string Ordenar(List<Tokens> entra)
        {
            IN = OrdenarP(entra);
            return IN;
        }
        
        private string OrdenarP(List<Tokens> entra)
        {
            string res = "";
            string derecha = "";
            string izquierda = "";
            Pila = new Pila(entra.Count);

            for (var pivote = entra.Count-1; pivote >=0; pivote--)
            {
                
                if (isOperator(entra[pivote].Value))
                {
                    if ((isOperator(entra[pivote + 1].Value) && entra[pivote].Value.Equals("+"))|| (isOperator(entra[pivote + 1].Value) && entra[pivote].Value.Equals("*"))||(isOperator(entra[pivote + 1].Value) && entra[pivote].Value.Equals("?")))
                    {
                        Pila.push(Pila.pop() + entra[pivote].Value);
                    }
                    else if (((pivote+1)==(entra.Count-1) && entra[pivote].Value.Equals("+"))|| ((pivote + 1) == (entra.Count - 1) && entra[pivote].Value.Equals("*"))|| ((pivote + 1) == (entra.Count - 1) && entra[pivote].Value.Equals("?"))) 
                    {
                        Pila.push(Pila.pop() + entra[pivote].Value);
                    }
                    else if ((((pivote-1)>=0)&&isOperator(entra[pivote-1].Value)&&entra[pivote].Value.Equals("+"))|| (((pivote - 1) >= 0) && isOperator(entra[pivote - 1].Value) && entra[pivote].Value.Equals("*"))|| (((pivote - 1) >= 0) && isOperator(entra[pivote - 1].Value) && entra[pivote].Value.Equals("?")))
                    {
                        Pila.push(Pila.pop() + entra[pivote].Value);
                    }

                    else
                    {
                        izquierda = Pila.pop();
                        derecha = Pila.pop();
                        Pila.push("(" + izquierda + entra[pivote].Value + derecha + ")");
                    }
                }
                else {
                    Pila.push(entra[pivote].Value);
                }
            }
            res += Pila.pop();
            return res;
        }

        private bool isOperator(string x)
        {
            switch (x)
            {
                case ".":
                    return true;
                   
                case "|":
                    return true;
                   
                case "+":
                    return true;
                   
                case "*":
                    return true;
                   
                case "?":
                    return true;
                  
                default:
                  return  false;

            }
        }

        private void dibujardot(string datos) 
        {
            
            for (int i = 0; i < datos.Length; i++)
            {
                if (((i + 3) < datos.Length)&&datos[i+1].Equals('(')) //(a)

                {
                    for (int a = i+2; a<datos.Length;a++)
                    {
                        if (datos[a].Equals(')'))
                        {
                            bool bandera = true;
                            for (int b = i + 2; b < a; b++)
                            {
                                if (datos[b].Equals('('))
                                {
                                    for (int c =i+2; c<b;c++) 
                                    {
                                        if (datos[c].Equals('+'))
                                        {
                                            if (datos[c + 1].Equals('.')|| datos[c + 1].Equals('|'))
                                            {
                                                string dato = palabra(i+2, c - 1, datos);
                                                cerPos(dato);
                                            } 
                                        }
                                        if (datos[c].Equals('.'))
                                        {
                                            if ((datos[c - 1].Equals('+')&&!datos[c + 1].Equals('(')) || (datos[c - 1].Equals('*')&&!datos[c + 1].Equals('(')) || (datos[c - 1].Equals('?')&&!datos[c + 1].Equals('(')))
                                            {
                                                string dato = palabra(c+1,b,datos);
                                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + dato + "\"] ;";//1->2
                                                nodo++;
                                            }
                                            else if ((datos[c-1].Equals("+")&&datos[c + 1].Equals('(')) || (datos[c - 1].Equals("*") && datos[c + 1].Equals('('))|| (datos[c - 1].Equals("?") && datos[c + 1].Equals('(')))
                                            {
                                                grafo += nodo + "->" + (nodo + 1) + " ;";
                                                nodo++;
                                            }
                                            else if (datos[c + 1].Equals('('))
                                            {
                                                string nombre = palabra(i+2,c-1,datos);
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"" + nombre + "\"];";//1->2
                                                nodo++;
                                            }
                                        }
                                        if (datos[c].Equals('*'))
                                        {
                                            if (datos[c + 1].Equals('.') || datos[c + 1].Equals('|'))
                                            {
                                                string dato = palabra(i + 2, c - 1, datos);
                                                CerK(dato);
                                            }
                                        }
                                        if (datos[c].Equals('?'))
                                        {
                                            if (datos[c + 1].Equals('.') || datos[c + 1].Equals('|'))
                                            {
                                                string dato = palabra(i + 2, c - 1, datos);
                                                cerNeg(dato);
                                            }
                                        }
                                        if (datos[c].Equals('|')) {
                                            if (datos[c - 1].Equals('+'))
                                            {
                                                string dato = palabra(i + 2, c - 2, datos);
                                                string dato2 = palabra(c + 1, b - 1, datos);
                                                int aux = nodo;
                                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"ε \"];";//0-> 1  
                                                nodo++;
                                                grafo += aux + "->" + (nodo + 2) + " [ label= \"ε \"];";//0->3
                                                cerPos(dato);
                                                aux = nodo;
                                                nodo++;
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"" + dato2 + "\"];";//3->4
                                                nodo++;
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//4->5
                                                grafo += aux + "->" + (nodo + 1) + " [ label= \"ε \"];";//2->5
                                                nodo++;
                                            }
                                            if (datos[c - 1].Equals('*'))
                                            {
                                                string dato = palabra(i + 2, c - 2, datos);
                                                string dato2 = palabra(c + 1, b - 1, datos);
                                                int aux = nodo;
                                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"ε \"];";//0-> 1  
                                                nodo++;
                                                grafo += aux + "->" + (nodo + 2) + " [ label= \"ε \"];";//0->3
                                                CerK(dato);
                                                aux = nodo;
                                                nodo++;
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"" + dato2 + "\"];";//3->4
                                                nodo++;
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//4->5
                                                grafo += aux + "->" + (nodo + 1) + " [ label= \"ε \"];";//2->5
                                                nodo++;
                                            }
                                            if (datos[c - 1].Equals('?'))
                                            {
                                                string dato = palabra(i + 2, c - 2, datos);
                                                string dato2 = palabra(c + 1, b - 1, datos);
                                                int aux = nodo;
                                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"ε \"];";//0-> 1  
                                                nodo++;
                                                grafo += aux + "->" + (nodo + 2) + " [ label= \"ε \"];";//0->3
                                                cerNeg(dato);
                                                aux = nodo;
                                                nodo++;
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"" + dato2 + "\"];";//3->4
                                                nodo++;
                                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//4->5
                                                grafo += aux + "->" + (nodo + 1) + " [ label= \"ε \"];";//2->5
                                                nodo++;
                                            }
                                        }
                                    }
                                    bandera = false;
                                    break;
                                }
                            }
                            if (bandera == false)
                            {
                                break;
                            }
                            else if ((a+1<datos.Length)&& datos[a+1].Equals('|')&&datos[a+2].Equals('(')) 
                            {
                                string dato = conc(i+1,a,datos);
                                Console.WriteLine(dato);
                                string dato2 = conc(a+2, datos.Length-1, datos);
                                Console.WriteLine(dato2);
                                int aux = nodo;
                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"ε \"];";//0-> 1
                                nodo++;
                                dibujardot(dato);
                                grafo += aux + "->" + nodo + " [ label= \"ε \"];";//0->3
                                aux = nodo-1;
                                dibujardot(dato2);
                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//4->5
                                grafo += aux + "->" + (nodo + 1) + " [ label= \"ε \"];";//2->5
                                nodo++;
                                break;
                            }
                            else
                            {

                                for (int e = i + 2; e < a; e++)
                                {
                                    if (datos[e].Equals('+'))
                                    {
                                        string dato = palabra(i + 2, e - 1, datos);
                                        cerPos(dato);
                                    }
                                    else if (datos[e].Equals('.'))
                                    {
                                        string dato = palabra(i + 2, e - 1, datos);
                                        string dato2 = palabra(e + 1, a - 1, datos);
                                        concatenación(dato, dato2);
                                    }
                                    else if (datos[e].Equals('*'))
                                    {

                                        string dato = palabra(i + 2, e - 1, datos);
                                        CerK(dato);
                                    }
                                    else if (datos[e].Equals('|'))
                                    {
                                        string dato = palabra(i + 2, e - 1, datos);
                                        string dato2 = palabra(e + 1, a - 1, datos);
                                        or(dato, dato2);
                                    }
                                    else if (datos[e].Equals('?'))
                                    {
                                        string dato = palabra(i + 2, e - 1, datos);
                                        cerNeg(dato);
                                    }
                                }
                            }
                            if ((a + 1 < datos.Length) && datos[a + 1].Equals('+'))
                            {
                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//0-> 1              
                                nodo++;
                                int aux = nodo;
                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//1->2
                                nodo++;
                                grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//2->3
                                grafo += (nodo + 1) + "->" + nodo + " [ label= \"ε \"];";//3->2
                                nodo++;
                                grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//3->4
                                grafo += (nodo + 1) + "->" + aux + " [ label= \"ε \"];";//4->1
                                nodo++;
                            }
                        }
                    }
                }
            }
        }

        private void concatenación (string datos, string dato2)
        {//.
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//0-> 1              
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"" + dato2 + "\"];";//1->2
            nodo++;
        }

        private void or (string datos, string dato2)
        {//|
            int aux = nodo;
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"ε \"];";//0-> 1  
            nodo++;
            grafo += aux + "->" + (nodo + 2) + " [ label= \"ε \"];";//0->3
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//1->2
            nodo++;
            aux = nodo;
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \""+dato2+ "\"];";//3->4
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//4->5
            grafo += aux + "->" + (nodo + 1) + " [ label= \"ε \"];";//2->5
            nodo++;
        }

        private void CerK(string datos)
        {//*
            int aux = nodo;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//1->2
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//2->3
            grafo += (nodo + 1) + "->" + nodo + " [ label= \"ε \"];";//3->2
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//3->4
            grafo += (nodo + 1) + "->" + aux + " [ label= \"ε \"];";//4->1
            nodo++;
        }

        private void cerPos(string datos)
        {//+
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//0-> 1              
            nodo++;
            int aux = nodo;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//1->2
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos+ "\"];";//2->3
            grafo += (nodo + 1) + "->" + nodo + " [ label= \"ε \"];";//3->2
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//3->4
            grafo += (nodo + 1) + "->" + aux + " [ label= \"ε \"];";//4->1
            nodo++;
        }

        private void cerNeg(string datos)
        {//?
            int aux = nodo;
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"ε \"];";//0-> 1  
            nodo++;
            grafo += aux + "->" + (nodo + 2) + " [ label= \"ε \"];";//0->3
            grafo += nodo + "->" + (nodo + 1) + "[ label= \"" + datos + "\"];";//1->2
            nodo++;
            aux = nodo;
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//3->4
            nodo++;
            grafo += nodo + "->" + (nodo + 1) + " [ label= \"ε \"];";//4->5
            grafo += aux + "->" + (nodo + 1) + " [ label= \"ε \"];";//2->5
            nodo++;
        }

        private string conc(int i, int f, string palabra)
        {
            String devolver = "";
            for (int a = i; a <= f; a++)
            {
                devolver += palabra[a];
            }
            return devolver;
        }
        private String palabra(int i, int f, String palabra)
        {
            String devolver = "";
            for (int a = f; a>=i;a--)
            {
                if (isOperator(Char.ToString(palabra[a])))
                {
                    break;
                }
                devolver += palabra[a];
            }
            return devolver;
        }
        private String palabra2(int i, int f, String palabra)
        {
            String devolver = "";
            for (int a = i; a < f; a++)
            {
                if (isOperator(Char.ToString(palabra[a])))
                {
                    break;
                }
                devolver += palabra[a];
            }
            return devolver;
        }
        private static Image generarImagen(String grafico)
        {
            
          //  String graph = DOT();

         
            
               
                WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
                
                WINGRAPHVIZLib.BinaryImage img = dot.ToJPEG(grafico);
                byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                img.Save(@"C:\\Users\PC\\Desktop\\thompson.jpg");
            return image;
                
          
            
           
        }

        private void cargarThompsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.AutoScroll = true;
           
            Image img = generarImagen(DOT());
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = img;
        }
    }
}
