using System;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Metodo estatico que realiza operaciones matematicas segun el operador recibido
        /// </summary>
        /// <param name="num1">Parametro de tipo objeto Operando</param>
        /// <param name="num2">Parametro de tipo objeto Operando</param>
        /// <param name="operador">Parametro de tipo char</param>
        /// <returns>Devuelve el resultado de la operacion como tipo double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operando = ValidarOperador(operador);
            double resultado = 0;
            if (num1 is not null && num2 is not null)
            {
                switch (operando)
                {
                    case '-':
                        resultado = num1 - num2;
                        break;

                    case '+':
                        resultado = num1 + num2;
                        break;

                    case '*':
                        resultado = num1 * num2;
                        break;

                    case '/':                        
                        resultado = num1 / num2;
                        break;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Metodo que valida que el parametro recibido sea un operador matematico
        /// </summary>
        /// <param name="operador"> Parametro de tipo char</param>
        /// <returns> Devuelve el operador validado o '+' si la validacion fallo </returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
    }
}
