using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp8
{
    class Program
    {
        /*Autores : Walter Dalla Torre Neto 17254
         *          Joao Henrique Correia Lima 172--- 
         *
         *Para modo manual sete a variavel "modoManual" para true e altere o vetor de pontos "vetorDePontos"
         *Para modo "Automatico" sete a variavel "modoManual" para false e siga as instruçoes do prorio programa
         * 
         */

        static void Main(string[] args) {
            Menu();
        }
        static void Menu()
        {
            int numeroDeCidades = 0;
            Boolean error = false;
            Ponto[] vetorDePontos;
            double distanciaTotal = 0;

            Boolean modoManual = false;

            if (modoManual) {

                vetorDePontos = new Ponto[3];

                vetorDePontos[0].x = 1;
                vetorDePontos[0].y = 1;

                vetorDePontos[1].x = 2;
                vetorDePontos[1].y = 2;

                vetorDePontos[2].x = 3;
                vetorDePontos[2].y = 3;

            }
            else
            {
                Console.WriteLine("Por qantas cidades você passou?");
                do
                {
                    try
                    {
                        numeroDeCidades = int.Parse(Console.ReadLine());
                        error = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite um numero");
                        error = true;
                    }
                } while (error);

                vetorDePontos = new Ponto[numeroDeCidades];

                for (int cont = 0; cont < vetorDePontos.Length; cont++)
                {
                    Console.WriteLine("Digite a posiçao X e Y da ciade {0}", cont);
                    do
                    {
                        try
                        {
                            Console.Write("X: ");
                            vetorDePontos[cont].x = int.Parse(Console.ReadLine());
                            Console.Write("Y: ");
                            vetorDePontos[cont].y = int.Parse(Console.ReadLine());
                            error = false;
                            
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite numeros validos numero");
                            error = true;
                        }
                    } while (error);
                }
            }

            for (int cont = 0; cont < vetorDePontos.Length; cont++)
            {
                try
                {
                    if (cont + 1 >= vetorDePontos.Length)
                    {
                        Console.WriteLine("a distancia entre a cidade 1 e a cidade {0} é de :{1}",
                            cont + 1, calculo(vetorDePontos[0], vetorDePontos[cont]));
                        distanciaTotal += calculo(vetorDePontos[0], vetorDePontos[cont]);
                    }
                    else
                    {
                        Console.WriteLine("a distancia entre a cidade {0} e a cidade {1} é de :{2}",
                            cont + 1, cont + 2, calculo(vetorDePontos[cont], vetorDePontos[cont + 1]));
                        distanciaTotal += calculo(vetorDePontos[cont], vetorDePontos[cont + 1]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Erro inesperado!");
                }
            }
            Console.WriteLine("A distancia total percorrida foi: {0}", distanciaTotal);
            Console.ReadKey();
        }

        struct Ponto
        {
            public int x;
            public int y;
        }

        static double CalculoPitagorico(double a, double b)
        {
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return c;
        }

        static double CalculoDistancia(int pont1, int pont2)
        {
            double distanciaAbs = 0;
            if (pont1 > pont2)
                distanciaAbs = Math.Abs(pont2 - pont1);
            else
                distanciaAbs = Math.Abs(pont1 - pont2);
            return distanciaAbs;
        }

        static double calculo(Ponto pont1, Ponto pont2)
        {
            return CalculoPitagorico(CalculoDistancia(pont1.x, pont2.x), CalculoDistancia(pont1.y, pont2.y)); ;
        }
    }
}
