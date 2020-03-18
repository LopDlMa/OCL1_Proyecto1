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
                        
                        if (a == 47)
                        {// /
                            Status_Flag = 1;
                            auxiliar += entrada[i];
                        }
                        #region
                        else if (a == 60)
                        {//<
                            Status_Flag = 2;
                            auxiliar += entrada[i];
                        }
                        else if (a == 67)
                        {//C
                            Status_Flag = 4;
                            auxiliar += entrada[i];
                        }
                        else if (a == 42)
                        {//*
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Cero_o_mas, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;

                        }
                        else if (a == 43)
                        {//+
                          //  Status_Flag = 9;
                            auxiliar += entrada[i];

                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Una_o_mas, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;

                        }
                        else if (((a >= 100 && a <= 113) || (a >= 65 && a <= 90) || (a >= 115 && a <= 122)) && a != 109 && a != 77)
                        {//a-z,A-Z
                            Status_Flag = 6;
                            auxiliar += entrada[i];
                        }
                        #region
                        else if (a == 44)
                        {//,
                            //Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Coma, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a == 46)
                        {//.
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Concatenación, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a == 59)
                        {//;
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Punto_Coma, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a == 63)
                        {//?
                         //Status_Flag = 9;
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Cero_o_1, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                            auxiliar += entrada[i];
                        }
                        else if (a == 123)
                        {//{
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Llave_A, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a == 124)
                        {// |
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Disyunción, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a == 125)
                        {// }
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Llave_C, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a == 126)
                        {//~
                           // Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Conjunto_Range, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        } 
                        else if (a == 34)
                        {// "
                            //Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comilla_Doble, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        
                        else if (a == 45)
                        {// -
                            Status_Flag = 5;
                            auxiliar += entrada[i];
                        }
                        #endregion
                        else if (a == 91)
                        {// [
                            Status_Flag = 6;
                            auxiliar += entrada[i];
                        }
                        else if (a == 58)
                        {//:
                            Status_Flag = 7;
                            auxiliar += entrada[i];
                        }
                        else if (a == 37)
                        {// %
                            Status_Flag = 14;
                            auxiliar += entrada[i];
                        }
                        else if (a == 92)
                        {// \
                            Status_Flag = 8;
                            auxiliar += entrada[i];
                        }
                        else
                        {//errores
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        #endregion
                        break;

                    #region
                    case 1:
                        int a1 = (int)entrada[i];
                        if (a1 == 47)
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
                    #region
                    case 2:
                        int a2 = (int)entrada[i];
                        if (a2 == 33)
                        {//!
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
                    
                    case 3:
                        int a3 = (int)entrada[i];
                        if (a3 == 108)
                        {//! 
                            Status_Flag = 14;
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
                    
                    case 4:
                        int a4 = (int)entrada[i];
                        if (a4 == 79)
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
                        if (a5 == 62)
                        {//>
                          //  Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
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
                    #endregion
                    #region
                    case 6:
                        int a6 = (int)entrada[i];
                        if (a6 == 58)
                        {//:
                          //  Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
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
                        if (a7 == 93)
                        {//]
                            //Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
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
                   
                    case 8:
                        int a8 = (int)entrada[i];
                        if (a8 == 110)
                        {//n
                           // Status_Flag = 9;
                            auxiliar += entrada[i];

                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Salto_Linea, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a8 == 116)
                        {// t
                        //    Status_Flag = 9;
                            auxiliar += entrada[i];
                          
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Tabulación, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a8 == 34)
                        {// "
                          //  Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comilla_Doble, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (a8 == 39)
                        {// '
                            //Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comilla_Simple, auxiliar, Saltos, Columnas));
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
                    #endregion
                    case 9: if (auxiliar.Equals("."))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Concatenación, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals(";"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Punto_Coma, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("~"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Conjunto_Range, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("\""))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comilla_Doble, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("->"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.flecha, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("%%"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Separador, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        
                        else
                        {
                            Console.WriteLine("TU IDEA NO FUNCIONÓ");
                        }
                    
                        
                        break;

                    case 10:
                        int a10 = (int)entrada[i];
                        if (a10 == 111)
                        {//o
                            Status_Flag = 21;
                            auxiliar += entrada[i];
                        }
                        else if (a10 == 97)
                        {//a
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

                    case 11:
                        int a11 = (int)entrada[i];
                        if (a11 == 67)
                        {//C
                            Status_Flag = 23;
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

                    case 12:
                        int a12 = (int)entrada[i];
                        if (a12 == 101)
                        {//e
                            Status_Flag = 24;
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

                    case 13:
                        int a13 = (int)entrada[i];
                        if (a13 == 114)
                        {//r
                            Status_Flag = 25;
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

                    case 14:
                        int a14 = (int)entrada[i];
                        if (a14 == 47)
                        {//%
                            Status_Flag = 9;
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

                    case 15:
                        int a15 = (int)entrada[i];
                        if (a15 == 78)
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

                    case 16:
                        int a16 = (int)entrada[i];
                        if (a16 == 101)
                        {//e
                            Status_Flag = 28;
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
                        if (a17 == 74)
                        {//J
                            Status_Flag = 19;
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

                    case 19:
                        int a19 = (int)entrada[i];
                        if (a19 == 58)
                        {//:
                          //  Status_Flag = 9;
                            auxiliar += entrada[i];
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Conjunto, auxiliar, Saltos, Columnas));
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
                    #endregion
                    //-----------COMENTARIO SIMPLE
                    #region
                    case 20:
                        int a20 = (int)entrada[i];
                        if (a20 != 10)
                        {// not enter
                            Status_Flag = 21;
                            auxiliar += entrada[i];
                        }
                        else if (a20 == 10)
                        {//si enter
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comentario_S, auxiliar, Saltos, Columnas));
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

                    case 21:
                        int a21 = (int)entrada[i];
                        if (a21 != 10)
                        {// not enter
                            Status_Flag = 21;
                            //auxiliar += entrada[i];
                        }
                        else if(a21 == 10)
                        {//si enter
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Comentario_S, auxiliar, Saltos, Columnas));
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
#endregion 
                    //----------------------------
                    //-----------COMENTARIO MULTILINEA
                    case 22:
                        int a22 = (int)entrada[i];
                        if (a22 != 33)
                        {// not !
                            Status_Flag = 23;
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

                    case 23:
                        int a23 = (int)entrada[i];
                        if (a23 != 33)
                        {// not !
                            Status_Flag = 23;
                        }
                        else if (a23 == 33)
                        {//si  !
                            Status_Flag = 24;
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

                    case 24:
                        int a24 = (int)entrada[i];
                        if (a24 == 62)
                        {//>
                            Status_Flag = 25;
                            auxiliar += entrada[i];
                        } else if (a24 != 25)
                        {
                            Status_Flag = 23;
                            
                        }
                        else
                        {
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        break;

                    case 25:
                        i = i - 1;
                        list_Tokens.Add(new Tokens(Tokens_T.Comentario_M, auxiliar, Saltos, Columnas));
                        auxiliar = "";
                        Status_Flag = 0;

                        break;

                }
            }
        }
    }
}

