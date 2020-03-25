using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_PY1
{
    class Pila 
    {
        public readonly string[] pila;
        public readonly int Size;
        public int cima = -1;

        public Pila(int size = 20)
        {
            pila = new string[size];
            Size = size;
        }

        public bool isEmpty()
        {
            return cima == -1;
        }
        public string peek()
        {
            if (isEmpty())
            {
                throw new Exception();
                
            }
            return pila[cima];
        }
        public string pop()
        {
            var result = peek();
            cima--;
            return result;
        }


        public void push(string value)
        {
            if(cima != Size - 1)
            {
                pila[++cima] = value;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
