using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
            

        public Operando():this(0)
        {
 
        }


        public Operando(double numero)
        {
            this.numero = numero;
        }


        public Operando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                this.numero = numero;
            }
        }

        /// <summary>
        /// Propiedad que valida que el string ingresado sea un numero
        /// </summary>
        public string Numero
        {
            set
            {
                double auxNumero = ValidarOperando(value);
                if (auxNumero != 0)
                {
                    this.numero = auxNumero;
                }
            }
        }

        /// <summary>
        /// Metodo privado que convierte un string a tipo double 
        /// </summary>
        /// <param name="strNumero">Parametro de tipo string</param>
        /// <returns>Devuelve el numero obtenido de la conversion</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }

        /// <summary>
        /// Metodo privado de tipo bool que verifica que el string este compuesto de 0 y 1
        /// </summary>
        /// <param name="binario">Parametro de tipo string</param>
        /// <returns>Devuelve true si el string es de 0 y 1, caso contrario false</returns>
        private bool EsBinario(string binario)
        {
            bool verificar = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] > '1')
                {
                    verificar = false;
                }
            }
            return verificar;
        }
             
        /// <summary>
        /// Metodo publico que convierte un numero de base binario a base decimal
        /// </summary>
        /// <param name="binario">Parametro de tipo string</param>
        /// <returns>Devuelve el numero como string si pudo hacer la conversion, caso contrario la frase valor invalido</returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario) == true)
            {
                char[] arrayBinario = binario.ToCharArray();
                Array.Reverse(arrayBinario);
                int suma = 0;

                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if (arrayBinario[i] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                }
                return suma.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Metodo publico de tipo string que convierte un numero entero positivo de base decimal a base binaria
        /// </summary>
        /// <param name="numero">Parametro de tipo double que contiene el numero a convertir</param>
        /// <returns>Devuelve un string: 0 si el numero era 0, caso contrario devuelve el numero binario</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int resto;
            int num = (int)numero;

            if (num == 0)
            {
               binario = "0";
            }    
            else
            {
               while (num > 0)
               {
                   resto = num % 2;
                   num /= 2;
                   binario = Convert.ToString(resto) + "" + binario;
               }
            }
                    
            return binario;
        }

        /// <summary>
        /// Metodo que convierte un numero (recibido como string) de base decimal a base binaria
        /// </summary>
        /// <param name="numero">Parametro de tipo string que tiene el numero a convertir</param>
        /// <returns>Devuelve como string el numero en base binaria o valor invalido si el parametro no era un numero</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "";
            if(double.TryParse(numero, out double auxNumero))
            {
                binario = DecimalBinario(auxNumero);
                return binario;
            }
            else
            {
                return "Valor invalido";
            }
            
        }

        /// <summary>
        /// Operador que resta el valor entre dos objetos Operando
        /// </summary>
        /// <param name="n1">Parametro de tipo objeto Operando</param>
        /// <param name="n2">Parametro de tipo objeto Operando</param>
        /// <returns>Devuelve la resta </returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Operador que suma el valor entre dos objetos Operando
        /// </summary>
        /// <param name="n1">Parametro de tipo objeto Operando</param>
        /// <param name="n2">Parametro de tipo objeto Operando</param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Operador que divide el valor entre dos objetos Operando
        /// </summary>
        /// <param name="n1">Parametro de tipo objeto Operando</param>
        /// <param name="n2">Parametro de tipo objeto Operando</param>
        /// <returns>Devuelve el resultado de la division, o el valor minimo de una variable double</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        /// <summary>
        /// Operador que multiplica el valor entre dos objetos Operando
        /// </summary>
        /// <param name="n1">Parametro de tipo objeto Operando</param>
        /// <param name="n2">Parametro de tipo objeto Operando</param>
        /// <returns>Devuelve el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
    }
}
