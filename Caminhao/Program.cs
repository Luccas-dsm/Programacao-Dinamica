using System;
using System.Collections.Generic;

namespace Caminhao
{
    /* Material    M3    Ben
       Areia       12     8
       Pedra       12     7
       Cimento     3      13
       Cal         4      11,5
       Madeira     8      10
       Ferro       2      10
    */
    class Deposito
    {
        public int peso { get; set; }
        public double valor { get; set; }
        public string material { get; set; }

        public Deposito(string material, int metroCub, double ben)
        {
            this.peso = metroCub;
            this.valor = ben;
            this.material = material;
        }



        //formula max(T[i- 1, j], T[i, j - P i] + V i)
        // valor = beneficio
        //peso = m
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Deposito> deposito = new List<Deposito>();
            //item, peso, valor
            deposito.Add(new Deposito("Areia", 12, 8));
            deposito.Add(new Deposito("Pedra", 12, 7));
            deposito.Add(new Deposito("Cimento", 3, 13));
            deposito.Add(new Deposito("Cal", 4, 11.5));
            deposito.Add(new Deposito("Madeira", 8, 10));
            deposito.Add(new Deposito("Ferro", 2, 10));
            int caminhao = 20;
            Console.WriteLine("\t\t\t###################COM REPETICAO##################\n");
            programacaoDinamicaComRepeticao(deposito, caminhao);
            
            Console.WriteLine("\n\t\t\t###################SEM REPETICAO##################\n");
            programacaoDinamicaSemRepeticao(deposito, caminhao);
        }
        //Programação dinamica com repetição

        static void programacaoDinamicaSemRepeticao(List<Deposito> deposito, int caminhao)
        {
            double[,] tabela = new double[deposito.Count, caminhao + 1];

            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                if (j < deposito[0].peso)
                {
                    tabela[0, j] = 0;
                }
                else
                {
                    tabela[0, j] = deposito[0].valor;
                }
            }
            for (int i = 1; i < tabela.GetLength(0); i++)
            {

                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j < deposito[i].peso)
                        tabela[i, j] = tabela[i - 1, j];
                    else
                    tabela[i,j]=Math.Max(tabela[i - 1, j], tabela[i, j - deposito[i].peso]+deposito[i].valor);
                }
            }

            imprimirTabela(tabela);
        }
        //Programação dinamica com repetição

        static void programacaoDinamicaComRepeticao(List<Deposito> deposito, int caminhao)
        {
            double[,] tabela = new double[deposito.Count, caminhao + 1];

            for (int j = 0; j < tabela.GetLength(1); j++)
            {
                if (j < deposito[0].peso)
                {
                    tabela[0, j] = 0;
                }
                else
                {
                    tabela[0, j] = tabela[0, j - deposito[0].peso] + deposito[0].valor;
                }
            }
            for (int i = 1; i < tabela.GetLength(0); i++)
            {

                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (j < deposito[i].peso)
                        tabela[i, j] = tabela[i - 1, j];
                    else
                        tabela[i, j] = Math.Max(tabela[i, j], tabela[i, j - deposito[i].peso] + deposito[i].valor);
                }
            }

            imprimirTabela(tabela);
        }
        static void imprimirTabela(double[,] tabela)
        {
            for (int i = 0; i < tabela.GetLength(1); i++)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write(tabela[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

    }
}
