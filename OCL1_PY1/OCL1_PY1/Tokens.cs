using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_PY1
{
    /* enum Tokens_T
     {   Dos_Puntos,
         Error,
         Numero,
         Palabra,
         ID
     };

         public String getTypeString()
         {
             switch (TokenType)
             {
                 case Tokens_T.Disyuncion:
                     return "|";
                 case Tokens_T.Dos_Puntos:
                     return ":";
                 case Tokens_T.ID:
                     return "ID";
                 case Tokens_T.Llave_A:
                     return "{";
                 case Tokens_T.Llave_C:
                     return "}";
                 case Tokens_T.Numero:
                     return "Número";
                 case Tokens_T.Palabra:
                     return "Palabra";
                 case Tokens_T.Salto_de_Lineas:
                     return "Salto de Linea";
                 case Tokens_T.Signos:
                     return "Signos";
                 case Tokens_T.Tabulacion:
                     return "Tabulación";
                 case Tokens_T.Todo_A:
                     return "[:";
                 case Tokens_T.Todo_C:
                     return ":]";
                 case Tokens_T.Una_o_Mas:
                     return "+";
                 case Tokens_T.Error:
                     return "Error Léxico: No reconocido";
                 default:
                     return "Léxico: Desconocido";
             }
         }

     }
 }
 */
    enum Tokens_T
    {
        Comentario_M,
        Comentario_S,
        Reservada_Conjunto,
        Concatenación,
        Disyunción,
        Cero_o_1,
        Cero_o_mas,
        Una_o_mas,
        Coma,
        Llave_A,
        Llave_C,
        Conjunto,
        Conjunto_Range,
        Signos,
        Salto_Linea,
        Comilla_Simple,
        Comilla_Doble,
        Tabulación,
        Todo_A,
        Todo_C,
        Dos_Puntos,
        Numero,
        Palabra,
        ID,
        Desconocido
    };


    class Tokens
    {
        public Tokens_T TokenType;
        private String value;
        public int linea = -1;
        public int columna = -1;



        public Tokens(Tokens_T type, String auxiliar, int linea, int columna)
        {
            this.TokenType = type;
            this.value = auxiliar;
            this.linea = linea;
            this.columna = columna;

        }


        public String Value
        {
            get { return this.value; }

        }

        public String getTypeString()
        {
            switch (TokenType)
            {
                case Tokens_T.Llave_C:
                    return "Llave Cerrada";
                case Tokens_T.Cero_o_mas:
                    return "Signo Cero o más";
                case Tokens_T.Reservada_Conjunto:
                    return "Reservada Conjunto";
                case Tokens_T.Conjunto:
                    return "Reservada CONJ";
                case Tokens_T.Conjunto_Range:
                    return "Reservada Conjunto Range";
                case Tokens_T.Llave_A:
                    return "Reservada copiar archivo";
                case Tokens_T.Cero_o_1:
                    return "Signo Cero o Uno";
                case Tokens_T.Comentario_M:
                    return "Comentario Multilinea";
                case Tokens_T.Signos:
                    return "Signos";
                case Tokens_T.Salto_Linea:
                    return "Reservada Saltos de Linea";
                case Tokens_T.Disyunción:
                    return "Signo Disyunción";
                case Tokens_T.Comilla_Simple:
                    return "Reservada Comilla Simple";
                case Tokens_T.Comilla_Doble:
                    return "Reservada Comillas Dobles";
                case Tokens_T.Coma:
                    return "Reservada Coma";
                case Tokens_T.Concatenación:
                    return "Reservada regresar";
                case Tokens_T.Una_o_mas:
                    return "Signo Una o mas";
                case Tokens_T.Comentario_S:
                    return "Comentario Simple";
                case Tokens_T.Tabulación:
                    return "Reservada Tabulación";
                case Tokens_T.Todo_A:
                    return "Reservada Englobado Abierto";
                case Tokens_T.Todo_C:
                    return "Reservada Englobado Cerrado";
                case Tokens_T.Dos_Puntos:
                    return "Reservada Dos puntos";
                case Tokens_T.Numero:
                    return "Reservada Número";
                case Tokens_T.Palabra:
                    return "Reservada Palabra";
                case Tokens_T.ID:
                    return "Reservada Identificador";
                case Tokens_T.Desconocido:
                    return "Desconocido";
                default:
                    return "Desconocido";


            }
        }

    }
}
