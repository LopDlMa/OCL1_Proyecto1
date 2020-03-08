using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_PY1
{
    class Scanner
    {
        public List<Tokens> list_Tokens = new List<Tokens>();
        int Status_Flag;
        bool anulable;
        String auxiliar;
        public List<Tokens> error_list = new List<Tokens>();

        public void Scaning(String input)
        {
            list_Tokens = new List<Tokens>();
            error_list = new List<Tokens>();
            Status_Flag = 0;
            auxiliar = "";
           // anulable = false;
            int Saltos = 0;
            int Columnas = 0;

            char[] entrada = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                int as0 = (int)entrada[i];
                Console.WriteLine("||Caracter: " + entrada[i] + "|| ASCII: " + as0 + "|| ESTADO:" + Status_Flag +"|| ANULABLE: " +anulable);
                if(as0 == 10 && Status_Flag == 0)
                {
                    Saltos++;
                    Columnas = -1;
                }
                switch (Status_Flag)
                {
                    case 0:
                        int a = (int)entrada[i];
                        if(a == 47)
                        {// /
                            Status_Flag = 1;
                            auxiliar += entrada[i];
                        }
                      
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Error, auxiliar,Saltos,Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;
                    case 1:
                        int a1 = (int)entrada[i];
                        if(a1 == 47)
                        {// /
                            Status_Flag = 20;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Error, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                            break;

                        }
                        break;
                  
                    case 20:
                        int a20 = (int)entrada[i];
                        if( a20 != 10 || a20!=11 )
                        {
                            Status_Flag = 21;
                            auxiliar += entrada[i];
                        } 
                        else if( a20 == 10|| a20 == 11)
                        {
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Error, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                            Console.WriteLine("Soy un Comentario :D");
                            break;

                        }
                        break;
                    case 9:
                        i = i - 1;
                        list_Tokens.Add(new Tokens(Tokens_T.Comentario_S, auxiliar, Saltos, Columnas));
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                }

            }
        }
    }
}
