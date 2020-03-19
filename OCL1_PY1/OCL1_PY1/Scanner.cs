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
        String auxiliar;
        public List<Tokens> error_list = new List<Tokens>();


        public void Scaning(String input)
        {
            list_Tokens = new List<Tokens>();
            error_list = new List<Tokens>();
            Status_Flag = 0;
            auxiliar = "";
            int Saltos = 0;
            int Columnas = 0;

            Char[] entrada = input.ToCharArray();


            for (int i = 0; i < input.Length; i++)
            {
                int as0 = (int)entrada[i];
                Console.WriteLine("Caracter: " + entrada[i] + " | ascii" + as0 + " |estado: " + Status_Flag);

                if (as0 == 10 && Status_Flag == 0)
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
                        else if(a == 60)
                        {//<
                            Status_Flag = 2;
                            auxiliar += entrada[i];
                        }
                        else if(a == 67)
                        {// C
                            Status_Flag = 4;
                            auxiliar += entrada[i];
                        }
                        else if (a == 45)
                        {// -
                            Status_Flag = 5;
                            auxiliar += entrada[i];
                        }

                        else if( a== 91)
                        {//[
                            Status_Flag = 6;
                            auxiliar += entrada[i];
                        }
                        else if(a == 58)
                        {
                            Status_Flag = 7;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }

                            break;
                    // ---------------------COMENTARIOS---------------------

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
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;

                    case 2:
                        int a2 = (int)entrada[i];
                        if(a2 == 33)
                        {//!
                            Status_Flag = 21;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }

                        break;

                    case 3:
                        int a22 = (int)entrada[i];
                        if (a22 == 62)
                        {// >
                            auxiliar += entrada[i];
                           // i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comentario_M, auxiliar, Saltos, Columnas)); ;
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else
                        {
                            Status_Flag = 21;
                        }
                        break;

                    case 4:
                        int a4 = (int)entrada[i];
                        if(a4 == 79)
                        {//O
                            Status_Flag = 15;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;

                    case 5:
                        int a5 = (int)entrada[i];
                        if(a5 == 62)
                        {//>
                            auxiliar += entrada[i];
                            // i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.flecha, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;

                    case 6:
                        int a6 = (int)entrada[i];
                        if(a6 == 58)
                        {//:
                            auxiliar += entrada[i];
                            // i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Todo_A, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;

                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;

                    case 7:
                        int a7 = (int)entrada[i];
                        if(a7 == 93)
                        {//]
                            auxiliar += entrada[i];
                            // i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Todo_C, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;

                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;

                    case 15:
                        int a15 = (int)entrada[i];
                        if(a15 == 78)
                        {//N
                            Status_Flag = 17;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }

                        break;
                    case 17:
                        int a17 = (int)entrada[i];
                        if(a17 == 74)
                        {// J
                            Status_Flag = 22;
                            auxiliar += entrada[i];
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;
                    case 20:
                        int a20 = (int)entrada[i];
                        if(a20 == 10 )
                        {// es salto de linea
                           // i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comentario_S, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;

                        }
                        else 
                        {
                            Status_Flag = 20;
                        }
                        break;
                         
                    case 21:
                        int a21 = (int)entrada[i];
                        if(a21 == 33)
                        {//!
                            Status_Flag = 3;
                            auxiliar += entrada[i];
                        }
                        else if (a21 != 33)
                        {
                            Status_Flag = 21;
                        }
                        break;

                    case 22:
                        int a3 = (int)entrada[i];
                        if(a3 == 58)
                        {// : 
                            auxiliar += entrada[i];
                           // i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Reservada_Conjunto, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;
                   
                }
            }
        }
    }
}