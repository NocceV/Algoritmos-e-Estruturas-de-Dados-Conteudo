using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexidades_BigO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Notação Big O

            //Aaspectos a serem levados em consideração:
            /*
                Tempo de execução dos algoritmos cresce em taxas diferentes. Como um bom programador, geralmente devemos
            escolher o melhor tempo possível que o algoritmo em questão deve ser executado, com foco principalmente em eficiencia, tempo e espaço.
            */

            //Oque é a notação Big O?
            /*
                É uma notação "especial" usada para definir o quão rápido um algoritmo é. Ela não define esta medida através de tempo em segundos, pois cada máquina
            terá um desempenho diferente de acordo com seus aspectos físicos. A notação Big O define a complexidade de tempo de um algoritmo através da QUANTIDADE DE OPERAÇÕES, usando termos algébricos.
            */

            //Deixo uma recomendação para entender melhor sobre quantidade de operações e o poder disto no nosso dia a dia e também nos nossos códigos: Pesquise "Trigos em um tabuleiro de xadrez".

            //Complexidades mais comuns, das melhores para as piores:

            O1(500);
            LogN();
            ON(20);
            Oquadrado(10);
            nFatorial(5);
        }

        #region O(1)
        public static int O1(int n)
        {
            return ((n * 2) / 2) + 1;

            /*Aqui temos 3 operações, não importa se o "n" passado como parâmetro é igual a 3 ou a 90000, o seu tamanho não mudará a quantidade de operações que serão feitas.
             * Esta operação então é considerada O(3), sendo uma complexidade CONSTANTE, pois não muda o número de operações. Porém a notação Big(O) desconsidera o numero de operações feitas dentro de uma constante,
             *ele se importa mais com o comportamento do algoritmo a partir da entrada, por isso dizemos que a complexidade deste algoritmo é O(1), */
        }
        #endregion



        #region O(Log N)
        public static bool LogN()
        {

            int[] vetor = new int[] { 1, 5, 19, 37, 54, 128, 246 };
            int item = 5;
            bool busca = pesquisaBinaria(vetor, item, 0, vetor.Length);
            return busca;

            /*  Temos aqui a complexidade O(LogN), é uma o´tima complexidade, pois a partir de que um numero cresce, a quantidade de operações não cresce da mesma maneira,
             para uma lista de 8 números, você teria que verificar 3 números no máximo. Para uma lista de 1.024 elementos, log 1.024 = 10, porque 2 elevado a 10 == 1.024. 
             Então, para uma lista de 1.024 números, você tem que verificar 10 números no máximo.
                Recomendação de Leitura: Livro:"Entendendo algoritmos", tópico "Pesquisa Binária".
             */
        }

        public static bool pesquisaBinaria(int[] vetor, int item, int esquerda, int direita)
        {
            /*
             *    "Esse tipo de algoritmo é bem simples, você parte o input ao meio e ai compara pra verificar se o item a ser buscado é menor ou maior que o item no meio do array. 
             * Quando isso acontece você joga fora metade da lista ficando com uma parte menor e esse processo é repetido até que se encontre o item da busca diminuindo cada vez mais o processamento,
             * por isso ele é o inverso do exponencial você diminui o N toda vez que um processamento é feito.":Complexidade Logarítmica, Wagner Abrantes.
             */


            while (esquerda <= direita)
            {
                int meio = (esquerda + direita) / 2;

                if (vetor[meio] == item)
                {
                    return true;

                }
                if (vetor[meio] < item)
                {
                    esquerda = meio + 1;
                }
                else
                {
                    direita = meio - 1;
                }


            }

            return false;

        }
        #endregion


        #region O(N)
        public static int ON(int n)
        {
            /*  Toda complexidade diferente da constante se dá em relação ao número de itens que a sua função recebe. Logo, quanto maior o input, maior o tempo de execução do algoritmo.
            Apesar disso, na complexidade linear a diferença é bem proporcional ao tamanho da entrada, em vez de ser gritante. Em Big O Notation, complexidade linear é apresentada como O(n).
            */

            int soma = 0;

            if (n <= 10)
            {
                return soma;
            }


            for (int i = 0; i < n; i++)
            {
                soma += 1;
            }

            for (int i = 0; i < n; i++)
            {
                soma -= 1;
            }


            return soma;

            /*Neste caso o input "n", que definirá quantas operações serao feitas, seguindo exatamente o conceito de lineariadade, tornando-se assim O(n).  
            */

            //  Temos 2 casos especiais neste método de exemplo, o primeiro seria que poderiamos falar que é uma função O(2n), pelo fato de ter dois "for", fazendo assim rodar 2n,
            // porém , a complexidade será O(n) e não O(2n), porque Big O é sobre o comportamento quando a entrada cresce muito. Quanto maior fica a entrada, menos importa se é n ou 2n.
            // O outro caso em questão é bem no início, que temos um "if" e se caso for verdadeiro ele ja irá retornar o valor da variável "soma", deixando assim com uma complexidade O(1).
            // Apesar de isto estar certo, devemos sempre levar em consideração o pior caso de um algoritmo, pois não podemos ter certeza que sempre caira naquele melhor caso. Para isso dizemos que
            //sempre levamos em consideração o pior caso. Ex: Pior caso: O(n), melhor caso: O(1), esta regra serve para todos os algoritmos, deixei para falar no O(n), pois didaticamente seria mais simples de explicar.

            /*
              "A notação do O é sobre um “limite por cima”; a omega, “limite por baixo”; e a theta é a combinação de ambos. 
            ‘Small’ Notations representam afirmações mais rígidas sobre a complexidade do que ‘Big’ Notations".
            */
        }
        #endregion

        #region N^2
        public static int Oquadrado(int n)
        {
            int soma = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    soma += 1;
                }
            }

            return soma;

            /*
                Como mostrado anateriormente temos dois "for" novamente, porém é diferente pois agora temos dois for "aninhados" um dentro do outro, isto muda completamente tudo,
            deixando assim a complexidade N^2, por exemplo se n=10, entao teriamos um retorno de 100 neste algoritmo, a estas proporções, o algoritmo é sempre maior.

            "Enquanto a complexidade linear sobe em uma linha reta, a complexidade quadrática desenha uma curva (parábola) em relação ao eixo de tempo para cada vez que N aumenta."

                "Nesse caso, a regra de pensar quem domina quem também é válida. Se você tiver dois for aninhados e um solto dentro da função, 
            você não tem um O(n + n²) porque o N linear é insignificante perto do quanto N² cresce. Então, no final, conte apenas com a maior função: O(n²)."
            
                Por isso sempre preocupamos com o pior caso, pois os casos menores se tornam insignificantes perantes ao pior caso.

                Temos teambém a complexidade N^3, que tem a mesma ideia de N^2, porém ordem de grandezas maior.

                Nota pessoal: Eu sempre tento fugir da complexidade N^2 ou maires que esta, buscando sempre fazer algo mais simples ou então contornar esta complexidade de alguma forma "criativa", 
            sempre buscando uma complexidade menor e melhor que esta. Por isso temos talvez uma ideia que mesmo resolvendo um problema, não quer dizer que esta correto a resolução, podemos ter que literalmente pagar por uma resolução ruim.
             
             */
        }

        #endregion


        #region N!
        public static double nFatorial(double n)
        {
            if (n < 0)
            {

                throw new Exception("O fatorial não é definido para números negativos.");
            }
            else if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * nFatorial(n - 1);
            }


            /*
             *  Temos aqui uma péssima complexidade, n!, que seria o inverso de "logN", é uma ordem de grandeza muito grande e cresce exponencialmente, quanto maior o n, 
             * pior esta complexidade vai ficar, ao ponto de talvez não ser possível dela não ser calculada por um computador bom.
             * 
             *   Poderiaamos neste ponto nos perguntar: "Por que eu usaria esta complexidade? Vou contornar ela e fazer uma melhor...", porém temos casos impossíveis de não usar algo com esta complexidade.
             *  Recomendo pesquisar sobre "O caixeiro viajante", para entender melhor sobre.
             *  
             *   Em problemas práticos, é recomendável evitar algoritmos fatoriais sempre que possível, pois eles se tornam ineficientes rapidamente conforme "n" aumenta.
             *  Existem abordagens mais eficientes para muitos casos.
             */
        }

        /*
         Referências Bibliográficas:

            - Livro: Entendendo Algoritmos: Aditya Y. Bhargava.
            - O que é a notação Big O, complexidade de tempo e de espaço: Shen Huang.
            - Análise da Complexidade de Algoritmos: Wagner Abrantes.
            - Complexidade Linear O(n): Wagner Abrantes.
            - Teoria de Complexidade e Notações: How to get An Offer.
         
         */


        #endregion
    }
}
}
