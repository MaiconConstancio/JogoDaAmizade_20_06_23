using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoDaAmizade
{
    internal class Program
    {

        public static string mensagemDeCarregamento = "...................  ";
        public static string mensagemDeReticencias = "... :c\n\n";
        public static string oUltimoSuspiro = "Espero um dia te ver novamente....";
        public static string jogador01;
        public static string computador = "Amigo_Virtual_IA";
        public static int rodadas = 1;
        public static int placarJogador01 = 0;
        public static int placarComputador = 0;
        public static int jogador01Vitorias = 0;
        public static int computadorVitorias = 0;
        public static bool ganho = false;


        //---------------------------------- Sair do jogo ----------------------------------------------------


        public static string obrigadoPorJogar = $"Adeus {jogador01} e obrigado por jogar, o jogo da amizade comigo :)";
        public static string jaQueVoceNaoQuerBrincar = "\n\nE já que você não quer mais brincar comigo...\n";
        public static string euFechoOJogoParaVoce = "Pode deixar que eu fecho o jogo para você. :c\n" +
            "Não quero te incomodar mais do que eu já estou. :c\n";
        public static string janelaFechaEm13s = "\n\nEssa janela será encerrada automaticamente em 13 segundos.\n";
        public static string adeusAmigo = "Adeus amigo";

        //----------------------------------------------------------------------------------------------------


        static void EfeitoLetras(string msg)
        {
            for (int i = 0; i < msg.Length; i++)
            {
                Console.Write(msg[i]);
                Console.Beep(1500, 2); // barulinho do tac tac tac
                Thread.Sleep(10); // velocidade que a mensagem vai aparecer

            }

            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {
            //Tamanho da janela
            Console.WindowHeight = 25;
            Console.WindowWidth = 85;

            //titulo que fica em cima da janela
            Console.Title = "                                      JOGO DA AMIZADE - feito por MAICON CONSTANCIO ";


            Console.ForegroundColor = ConsoleColor.Cyan; //Troca de cor para Ciano
            string titulo = "\n                         BEM-VINDO AO JOGO DA AMIZADE\n"; // ------------------------------------------------------ STRING
            EfeitoLetras(titulo);

            IniciarJogo();
        }
        public static void IniciarJogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string mensagemDeNome = "Como posso te chamar? "; // ------------------------------------------------------ STRING
            EfeitoLetras(mensagemDeNome);

            jogador01 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nBem vindo {jogador01} vamos lá!");
            Console.Write($"Objetivo: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"Fique com a contagem mais alta sem ultrapassar o ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"número 21");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($", okay!?\n");
            Thread.Sleep(1000);

            //------------------------------- FIM DA INTRODUÇÃO ---------------------------------------------------
            //--------------------------------------- COMEÇO DA LOGICA --------------------------------------------


            while (true)
            {
                Random random = new Random();

                if (rodadas == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int CartasJogador01 = random.Next(1, 11);
                    int CartasAmigoIA = random.Next(1, 11);

                    placarJogador01 += CartasJogador01;
                    placarComputador += CartasAmigoIA;
                    EfeitoLetras(mensagemDeCarregamento);
                    Console.WriteLine($"{jogador01} seu primeiro numero é {CartasJogador01}\n");
                    Thread.Sleep(3000);
                    Console.ForegroundColor = ConsoleColor.Blue; // mudar de cor
                    EfeitoLetras(mensagemDeCarregamento);
                    Console.WriteLine($"{computador} seu primeiro número é {CartasAmigoIA}\n");
                    rodadas++;
                }
                if (rodadas > 1 && !ganho)
                {
                    if (placarComputador > placarJogador01)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{jogador01} o {computador} tem mais números que você, você precisa comprar mais!");
                        Console.WriteLine("Digite (Y) para receber mais números!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // mudar de cor
                        Console.Write("Gostaria de mais números? (Y/N)");
                    }

                    string mensagem = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (mensagem.ToLower() == "y" && !ganho)
                    {

                        int CartasJogador01 = random.Next(1, 11);
                        placarJogador01 += CartasJogador01;
                        Console.ForegroundColor = ConsoleColor.Green;
                        EfeitoLetras(mensagemDeCarregamento);
                        Console.WriteLine($"{jogador01} você recebeu {CartasJogador01} total de: {placarJogador01}\n");
                        ResultadosDosJogos(placarJogador01, placarComputador);
                        if (ganho) return;

                    }
                    else if (rodadas > 1 && mensagem.ToLower() == "n" && !ganho)
                    {
                        while (placarComputador <= placarJogador01 && placarJogador01 > 0) //Vez do IA
                        {
                            int CartasAmigoIA = random.Next(1, 11);
                            placarComputador += CartasAmigoIA;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            EfeitoLetras($"O {computador} está pensando... ");

                            Thread.Sleep(1000);
                            Console.WriteLine($"{computador} você recebeu {CartasAmigoIA} total de: {placarComputador}\n");
                            ResultadosDosJogos(placarJogador01, placarComputador);
                            if (placarComputador > placarJogador01) // aqui é onde o pc rouba kkk pq ele sempre vai tentar parar depois de vc
                                                                    // para ganhar
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{computador} ganhou!");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Você é muito ruim! HAHAHA!  :D ");
                                Console.Beep(1000, 500);
                                computadorVitorias++;

                                ContinuarJogando();
                            }

                        }

                    }

                }

            }

            //Console.ReadKey();
        }

        static void ContinuarJogando()
        {
            Console.ForegroundColor = ConsoleColor.White; //Troca de cor
            Console.Write("Continuar jogando? (Y/N)");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "y")
            {
                ReseteDoJogo();
            }
            else if (resposta.ToLower() == "n")
            {
                SairDoJogo();
            }
        }

        //--------------------------------- SAIR DO JOGO E TODAS MENSAGENS DENTRO DO TYPE --------------------------------
        private static void SairDoJogo()
        {
            Console.Clear(); //"apagar" informaçoes anteriores
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Adeus {jogador01} e obrigado por jogar, o jogo da amizade comigo :)");
            Console.WriteLine($"Espero ter deixado seu dia um pouco melhor!");
            Console.ForegroundColor = ConsoleColor.White; //Troca de cor
            EfeitoLetras(jaQueVoceNaoQuerBrincar); //E já que você não quer mais brincar comigo...
            EfeitoLetras(euFechoOJogoParaVoce); //Pode deixar que eu fecho para você :c
            Console.ForegroundColor = ConsoleColor.Red; //Troca de cor para VERMELHO
            EfeitoLetras(mensagemDeCarregamento); //..................
            EfeitoLetras(janelaFechaEm13s); //Essa janela será encerrada automaticamente em 13 segundos.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n"); //Muitas linhas para dar mais drama no Adeus kkkkk
            EfeitoLetras("........" + mensagemDeCarregamento); //..................
            EfeitoLetras(adeusAmigo); //Adeus amigo
            EfeitoLetras(mensagemDeReticencias); //... :c
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            EfeitoLetras(oUltimoSuspiro); //Espero um dia te ver novamente....


            Thread.Sleep(13000); // tempo

            Environment.Exit(0); // fechar janela
        }
        //--------------------------------- // -------------------------------------- // --------------------------------




        //---------------------------------------- ONDE O JOGO RESETA ---------------------------------------------------
        private static void ReseteDoJogo()
        {
            placarJogador01 = 0;
            placarComputador = 0;
            Program.rodadas = 1;
            Console.Clear(); //"apagar" informaçoes anteriores
            Console.ForegroundColor = ConsoleColor.Yellow; //Troca de cor

            string Rodadas = " - Rodada";
            int QuantidadeDeRodadas = computadorVitorias + jogador01Vitorias + 1;
            EfeitoLetras(QuantidadeDeRodadas + Rodadas.ToString());
            Console.WriteLine($"\n{jogador01}: {jogador01Vitorias}  | {computador}: {computadorVitorias}\n"); //Placar exibido
            Thread.Sleep(1000);
        }
        //--------------------------------- // -------------------------------------- // --------------------------------



        //------------------------------------ RESULTADO DE QUEM GANHOU OU PERDEU ---------------------------------------
        static void ResultadosDosJogos(int PlacarJogador01, int PlacarComputador)
        {
            if (PlacarJogador01 > 21)
            {

                //Quando o jogador 1 passa de 21, da essa mensagem (Amigo IA, ganha 1 ponto)
                Console.Beep(500, 500);
                Console.ForegroundColor = ConsoleColor.Red; //Troca de cor
                Console.WriteLine($"Sério {jogador01}????? KKKKKKKKK, achei que você seria um desafio para mim, " +
                    $"\nMas não sabe nem quando parar HAHAHA!");
                Console.ForegroundColor = ConsoleColor.Yellow; //Troca de cor
                Console.WriteLine($"{computador} É o vencedor!");
                computadorVitorias++; //somar para computador
                ContinuarJogando();


            }
            if (PlacarComputador > 21)
            {
                //Quando o Amigo IA passa de 21, da essa mensagem (Jogador 1, ganha 1 ponto)
                Console.Beep(2000, 200);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{computador} comentou: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Aaaa, eu passei de 21 :c, ta bem... admito.\n{jogador01}, você ganhou... :/");
                jogador01Vitorias++; // somar para jogador 1

                ContinuarJogando();

            }
            //--------------------------------- // -------------------------------------- // --------------------------------


        }

    }


}
