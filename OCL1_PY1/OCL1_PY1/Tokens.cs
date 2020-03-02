using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_PY1
{
    enum Tokens_T
    {
        Comentario_S,
        Comentario_M,
        Reservada_Conjunto,
        Concatenacion,
        Disyuncion,
        Cero_o_1,
        Cero_o_Mas,
        Una_o_Mas,
        Coma,
        Llave_A,
        Llave_C,
        Conjunto,
        Signos,
        Salto_de_Lineas,
        Comilla_Simple,
        Commilla_Doble,
        Tabulacion,
        Todo_A,
        Todo_C,
        Dos_Puntos,
        Error,
        Numero,
        Palabra,
        ID
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
                case Tokens_T.Cero_o_1:
                    return "?";
                case Tokens_T.Cero_o_Mas:
                    return "*";
                case Tokens_T.Coma:
                    return ",";
                case Tokens_T.Comentario_M:
                    return "Comentario Multilinea";
                case Tokens_T.Comentario_S:
                    return "Comentario Simple";
                case Tokens_T.Comilla_Simple:
                    return "'";
                case Tokens_T.Commilla_Doble:
                    return "\"";
                case Tokens_T.Concatenacion:
                    return ".";
                case Tokens_T.Conjunto:
                    return "~";
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
                case Tokens_T.Reservada_Conjunto:
                    return "CONJ";
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
