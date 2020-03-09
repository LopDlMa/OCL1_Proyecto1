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

                //if (as0 == 10 && Status_Flag == 0)
                //{
                //    Saltos++;
                //    Columnas = -1;
                //}
                switch (Status_Flag)
                {
                    case 0:
                        int a = (int)entrada[i];
                        if (a == 67)
                        {//C
                            Status_Flag = 4;
                            auxiliar += entrada[i];
                        }
                        else if (a == 47)
                        {// /
                            Status_Flag = 1;
                            auxiliar += entrada[i];
                        }
                        else if (a == 60)
                        {//<
                            Status_Flag = 2;
                            auxiliar += entrada[i];
                        }
                        else if (a == 42)
                        {//*
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 43)
                        {//+
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (((a >= 100 && a <= 113) || (a >= 65 && a <= 90) || (a >= 115 && a <= 122)) && a != 109 && a != 77)
                        {//a-z,A-Z
                            Status_Flag = 6;
                            auxiliar += entrada[i];
                        }
                        else if (a == 44)
                        {//,
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 46)
                        {//.
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 59)
                        {//;
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 63)
                        {//?
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 123)
                        {//{
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 124)
                        {// |
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 125)
                        {// }
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 126)
                        {//~
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        } 
                        else if (a== 34)
                        {// "
                            Status_Flag = 9;
                            auxiliar += entrada[i];
                        }
                        else if (a == 45)
                        {// -
                            Status_Flag = 5;
                            auxiliar += entrada[i];
                        }
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
                        {
                            Status_Flag = 14;
                            auxiliar += entrada[i];
                        }
                        else
                        {//errores
                            auxiliar = entrada[i].ToString();
                            error_list.Add(new Tokens(Tokens_T.Desconocido, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
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
                        {//l
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
                    #endregion
                    case 6:
                        int a6 = (int)entrada[i];
                        if (a6 == 58)
                        {//:
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

                    case 7:
                        int a7 = (int)entrada[i];
                        if (a7 == 93)
                        {//]
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

                    case 8:
                        int a8 = (int)entrada[i];
                        if (a8 == 97)
                        {//a
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

                    case 9:
                        if (auxiliar.Equals("CONJ:"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Reservada_Conjunto, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("*"))
                        {

                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Cero_o_mas, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        } 
                        else if (auxiliar.Equals("+"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Una_o_mas, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals(","))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Coma, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("."))
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
                        else if (auxiliar.Equals("?"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Cero_o_1, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("{"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Llave_A, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("|"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Disyunción, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals("}"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Llave_C, auxiliar, Saltos, Columnas));
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
                        else if (auxiliar.Equals("[:"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Todo_A, auxiliar, Saltos, Columnas));
                            auxiliar = "";
                            Status_Flag = 0;
                        }
                        else if (auxiliar.Equals(":]"))
                        {
                            i = i - 1;
                            list_Tokens.Add(new Tokens(Tokens_T.Todo_C, auxiliar, Saltos, Columnas));
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

                    case 18:
                        int a18 = (int)entrada[i];
                        if (a18 == 103)
                        {//g
                            Status_Flag = 30;
                            auxiliar += entrada[i];
                        }
                        else if (a18 == 110)
                        {//n
                            Status_Flag = 31;
                            auxiliar += entrada[i];
                        }
                        else if (a18 == 112)
                        {//p
                            Status_Flag = 139;
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

                    case 26:
                        int a26 = (int)entrada[i];
                        if (a26 == 109)
                        {//m
                            Status_Flag = 39;
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

                    case 27:
                        int a27 = (int)entrada[i];
                        if (a27 == 105)
                        {//i
                            Status_Flag = 40;
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

                    case 28:
                        int a28 = (int)entrada[i];
                        if (a28 == 114)
                        {//r
                            Status_Flag = 41;
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

                    case 29:
                        int a29 = (int)entrada[i];
                        if (a29 == 99)
                        {//c
                            Status_Flag = 42;
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

                    case 30:
                        int a30 = (int)entrada[i];
                        if (a30 == 114)
                        {//r
                            Status_Flag = 43;
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

                    case 31:
                        int a31 = (int)entrada[i];
                        if (a31 == 111)
                        {//o
                            Status_Flag = 44;
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

                    case 32:
                        int a32 = (int)entrada[i];
                        if (a32 == 117)
                        {//u
                            Status_Flag = 45;
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

                    case 33:
                        int a33 = (int)entrada[i];
                        if (a33 == 101)
                        {//e
                            Status_Flag = 46;
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

                    case 34:
                        int a34 = (int)entrada[i];
                        if (a34 == 105)
                        {//i
                            Status_Flag = 47;
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

                    case 35:
                        int a35 = (int)entrada[i];
                        if (a35 == 103)
                        {//g
                            Status_Flag = 48;
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

                    case 36:
                        int a36 = (int)entrada[i];
                        if (a36 == 92)
                        {//\
                            Status_Flag = 49;
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

                    case 37:
                        int a37 = (int)entrada[i];
                        if (a37 == 114)
                        {//r
                            Status_Flag = 50;
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

                    case 38:
                        int a38 = (int)entrada[i];
                        if (a38 == 114)
                        {//r
                            Status_Flag = 51;
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

                    case 39:
                        int a39 = (int)entrada[i];
                        if (a39 == 105)
                        {//i
                            Status_Flag = 52;
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

                    case 40:
                        int a40 = (int)entrada[i];
                        if (a40 == 114)
                        {//r
                            Status_Flag = 53;
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

                    case 41:
                        int a41 = (int)entrada[i];
                        if (a41 == 99)
                        {//c
                            Status_Flag = 54;
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

                    case 42:
                        int a42 = (int)entrada[i];
                        if (a42 == 117)
                        {//u
                            Status_Flag = 55;
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

                    case 43:
                        int a43 = (int)entrada[i];
                        if (a43 == 101)
                        {//e
                            Status_Flag = 56;
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

                    case 44:
                        int a44 = (int)entrada[i];
                        if (a44 == 109)
                        {//m
                            Status_Flag = 57;
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

                    case 45:
                        int a45 = (int)entrada[i];
                        if (a45 == 97)
                        {//a
                            Status_Flag = 58;
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

                    case 46:
                        int a46 = (int)entrada[i];
                        if (a46 == 114)
                        {//r
                            Status_Flag = 59;
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

                    case 47:
                        int a47 = (int)entrada[i];
                        if (a47 == 97)
                        {//a
                            Status_Flag = 60;
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

                    case 48:
                        int a48 = (int)entrada[i];
                        if (a48 == 97)
                        {//a
                            Status_Flag = 61;
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

                    case 49:
                        int a49 = (int)entrada[i];
                        if ((a49 >= 97 && a49 <= 122) || (a49 >= 65 && a49 <= 90))
                        {
                            Status_Flag = 62;
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

                    case 50:
                        int a50 = (int)entrada[i];
                        if (a50 == 67)
                        {//C
                            Status_Flag = 63;
                            auxiliar += entrada[i];
                        }
                        else if (a50 == 65)
                        {//A
                            Status_Flag = 64;
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

                    case 51:
                        int a51 = (int)entrada[i];
                        if (a51 == 67)
                        {//C
                            Status_Flag = 151;
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

                    case 52:
                        int a52 = (int)entrada[i];
                        if (a52 == 110)
                        {//n
                            Status_Flag = 66;
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

                    case 53:
                        int a53 = (int)entrada[i];
                        if (a53 == 65)
                        {
                            Status_Flag = 67;
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

                    case 54:
                        int a54 = (int)entrada[i];
                        if (a54 == 97)
                        {//a
                            Status_Flag = 68;
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

                    case 55:
                        int a55 = (int)entrada[i];
                        if (a55 == 116)
                        {//t
                            Status_Flag = 69;
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

                    case 56:
                        int a56 = (int)entrada[i];
                        if (a56 == 115)
                        {//s
                            Status_Flag = 70;
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

                    case 57:
                        int a57 = (int)entrada[i];
                        if (a57 == 98)
                        {//b
                            Status_Flag = 71;
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

                    case 58:
                        int a58 = (int)entrada[i];
                        if (a58 == 108)
                        {//l
                            Status_Flag = 72;
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

                    case 59:
                        int a59 = (int)entrada[i];
                        if (a59 == 32)
                        {//SPACE
                            Status_Flag = 73;
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

                    case 60:
                        int a60 = (int)entrada[i];
                        if (a60 == 114)
                        {//r
                            Status_Flag = 74;
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

                    case 61:
                        int a61 = (int)entrada[i];
                        if (a61 == 114)
                        {
                            Status_Flag = 137;
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

                    case 62:
                        int a62 = (int)entrada[i];
                        if ((a62 >= 97 && a62 <= 122) || (a62 >= 65 && a62 <= 90) || (a62 >= 48 && a62 <= 57) || a62 == 95)
                        {//alfabeto m y M && _
                            Status_Flag = 62;
                            auxiliar += entrada[i];
                        }
                        else if (a62 == 92)
                        {//\
                            Status_Flag = 75;
                            auxiliar += entrada[i];
                        }
                        else if (a62 == 34)
                        {//"
                            Status_Flag = 138;
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

                    case 63:
                        int a63 = (int)entrada[i];
                        if (a63 == 97)
                        {//a
                            Status_Flag = 76;
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

                    case 64:
                        int a64 = (int)entrada[i];
                        if (a64 == 114)
                        {//r
                            Status_Flag = 77;
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

                    case 65:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_CrearCarpeta, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_CrearCarpeta, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 66:
                        int a66 = (int)entrada[i];
                        if (a66 == 97)
                        {//a
                            Status_Flag = 78;
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

                    case 67:
                        int a67 = (int)entrada[i];
                        if (a67 == 114)
                        {//r
                            Status_Flag = 79;
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

                    case 68:
                        int a68 = (int)entrada[i];
                        if (a68 == 68)
                        {//D
                            Status_Flag = 80;
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

                    case 69:
                        int a69 = (int)entrada[i];
                        if (a69 == 97)
                        {//a
                            Status_Flag = 81;
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
                    case 119:
                        int a119 = (int)entrada[i];
                        if (a119 == 111)
                        {//o
                            Status_Flag = 134;
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

                    case 120:
                        int a120 = (int)entrada[i];
                        if (a120 == 111)
                        {//o
                            Status_Flag = 133;
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

                    case 121:
                        int a121 = (int)entrada[i];
                        if (a121 == 111)
                        {//o
                            Status_Flag = 135;
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

                    case 122:
                        int a122 = (int)entrada[i];
                        if (a122 == 118)
                        {//v
                            Status_Flag = 123;
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

                    case 123:
                        int a123 = (int)entrada[i];
                        if (a123 == 111)
                        {//o
                            Status_Flag = 136;
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

                    case 124:
                        i = i - 1;
                       // list_Tokens.Add(new Tokens(Tokens_T.Reservada_CrearArchivo, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_CrearArchivo, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 125:
                        i = i - 1;
                      //  list_Tokens.Add(new Tokens(Tokens_T.Reservada_eliminarC, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_eliminarC, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 126:
                        i = i - 1;
                      //  list_Tokens.Add(new Tokens(Tokens_T.Reservada_eliminarA, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_eliminarA, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 127:
                        i = i - 1;
                       // list_Tokens.Add(new Tokens(Tokens_T.Reservada_abrirArchivo, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_abrirArchivo, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 128:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_acercaDe, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_acercaDe, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 129:
                        i = i - 1;
                       // list_Tokens.Add(new Tokens(Tokens_T.Reservada_Ejecutar, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_Ejecutar, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 130:
                        i = i - 1;
                       // list_Tokens.Add(new Tokens(Tokens_T.Reservada_regresar, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_regresar, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 131:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_renombrarC, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_renombrarC, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 132:
                        i = i - 1;
                    //    list_Tokens.Add(new Tokens(Tokens_T.Reservada_renombrarA, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_renombrarA, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 133:
                        i = i - 1;
                  //      list_Tokens.Add(new Tokens(Tokens_T.Reservada_ManualTecnico, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_ManualTecnico, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 134:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_ManualUsuario, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_ManualUsuario, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 135:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_mover_archivo, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_mover_archivo, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 136:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_copiar_archivo, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_copiar_archivo, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 137:
                        i = i - 1;
                     //   list_Tokens.Add(new Tokens(Tokens_T.Reservada_cargar, auxiliar, Saltos, Columnas));
                        //palabra = new Tokens(Tokens_T.Reservada_cargar, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 138:
                        i = i - 1;
                   //     list_Tokens.Add(new Tokens(Tokens_T.Ruta, auxiliar, Saltos, Columnas));
                        //   palabra = new Tokens(Tokens_T.Ruta, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 139:
                        int a139 = (int)entrada[i];
                        if (a139 == 111)
                        {//o
                            Status_Flag = 140;
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

                    case 140:
                        int a140 = (int)entrada[i];
                        if (a140 == 114)
                        {//r
                            Status_Flag = 141;
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

                    case 141:
                        int a141 = (int)entrada[i];
                        if (a141 == 116)
                        {//t
                            Status_Flag = 142;
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

                    case 142:
                        int a142 = (int)entrada[i];
                        if (a142 == 101)
                        {
                            Status_Flag = 143;
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

                    case 143:
                        i = i - 1;
                       // list_Tokens.Add(new Tokens(Tokens_T.reporte, auxiliar, Saltos, Columnas));
                        //  palabra = new Tokens(Tokens_T.reporte, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 144:
                        int a144 = (int)entrada[i];
                        if (a144 == 97)
                        {//a
                            Status_Flag = 145;
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

                    case 145:
                        int a145 = (int)entrada[i];
                        if (a145 == 108)
                        {//l
                            Status_Flag = 146;
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

                    case 146:
                        int a146 = (int)entrada[i];
                        if (a146 == 105)
                        {//i
                            Status_Flag = 147;
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


                    case 147:
                        int a147 = (int)entrada[i];
                        if (a147 == 122)
                        {//z
                            Status_Flag = 148;
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

                    case 148:
                        int a148 = (int)entrada[i];
                        if (a148 == 97)
                        {//a
                            Status_Flag = 149;
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

                    case 149:
                        int a149 = (int)entrada[i];
                        if (a149 == 114)
                        {//r
                            Status_Flag = 150;
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

                    case 150:
                        i = i - 1;
                   //     list_Tokens.Add(new Tokens(Tokens_T.analizar, auxiliar, Saltos, Columnas));
                        //   palabra = new Tokens(Tokens_T.analizar, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;

                    case 151:
                        i = i - 1;
                      //  list_Tokens.Add(new Tokens(Tokens_T.Reservada_AbrirC, auxiliar, Saltos, Columnas));
                        //  palabra = new Tokens(Tokens_T.Reservada_AbrirC, auxiliar, Saltos, Columnas);
                        auxiliar = "";
                        Status_Flag = 0;
                        break;
                }
            }
        }
    }
}

