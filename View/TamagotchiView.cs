﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi;

namespace Tamagotchi
{
    public class TamagotchiView{
    private string NomeJogador { get; set; }
    public TamagotchiView()
    {
        BoasVindas();
    }
    public void BoasVindas()
    {
        Console.WriteLine(@" 
     #######                                                                    
        #       ##    #    #    ##     ####    ####   #####   ####   #    #  # 
        #      #  #   ##  ##   #  #   #    #  #    #    #    #    #  #    #  # 
        #     #    #  # ## #  #    #  #       #    #    #    #       ######  # 
        #     ######  #    #  ######  #  ###  #    #    #    #       #    #  # 
        #     #    #  #    #  #    #  #    #  #    #    #    #    #  #    #  # 
        #     #    #  #    #  #    #   ####    ####     #     ####   #    #  #");

        Console.Write("\n\nQual é seu nome? ");
        NomeJogador = Console.ReadLine().ToUpper();
    }

    public void MenuInicial()
    {
        Console.WriteLine("\n\n--------------------------- MENU ---------------------------");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("3 - Sair");
        Console.Write($"{NomeJogador} Você deseja: ");
    }
    public string MenuAdocao()
    {
        Console.WriteLine("\n--------------------- ADOTAR UM MASCOTE ---------------------");
        Console.WriteLine("BULBASAUR");
        Console.WriteLine("IVYSAUR");
        Console.Write($"{NomeJogador} Escolha uma espécie: ");

        return Console.ReadLine().ToUpper();
    }
    public string DesejaSaberMais(string especie)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine($"1 - SABER MAIS SOBRE O {especie}");
        Console.WriteLine($"2 - ADOTAR {especie}");
        Console.WriteLine($"3 - VOLTAR");
        Console.Write($"{NomeJogador} VOCÊ DESEJA: ");

        return Console.ReadLine().ToUpper();
    }

    public void Detalhesmascote(Mascote mascote)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine("Nome mascote: " + mascote.Nome.ToUpper());
        Console.WriteLine("Altura: " + mascote.Altura);
        Console.WriteLine("Peso: " + mascote.Peso);

        Console.WriteLine("Habilidades: ");
        foreach (Abilities habilidade in mascote.Habilidades)
        {
            Console.Write(habilidade.ability.name.ToUpper() + " ");
        }
    }

    public void DetalhesmascoteAdotado(Mascote mascote)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine("Nome mascote: " + mascote.Nome.ToUpper());
        Console.WriteLine("Altura: " + mascote.Altura);
        Console.WriteLine("Peso: " + mascote.Peso);

        System.TimeSpan idade = DateTime.Now.Subtract(mascote.DataNascimento);

        Console.WriteLine("Idade: " + idade.Minutes + " Anos em Mascote Virtual");

        if (mascote.VerificarFome())
            Console.WriteLine($"{mascote.Nome.ToUpper()} Está com fome!");
        else
            Console.WriteLine($"{mascote.Nome.ToUpper()} Está alimentado!");

        if (mascote.Humor > 5)
            Console.WriteLine($"{mascote.Nome.ToUpper()} Está feliz!");
        else
            Console.WriteLine($"{mascote.Nome.ToUpper()} Está triste!");

        Console.WriteLine("Habilidades: ");
        foreach (Abilities habilidade in mascote.Habilidades)
        {
            Console.Write(habilidade.ability.name.ToUpper() + " ");
        }
    }

    public void SucessoAdocao(string especie)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine($"{NomeJogador} MASCOTE ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO: ");

        Console.WriteLine(@"
              ███╗
             ██████╗
            ████████╗
            ████████║
            ████████║
            ╚█████╔╝
             ╚════╝");
    }

    public int MenuConsultarMascotes(List<Mascote> mascotes)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine($"Você possui {mascotes.Count} mascote adotados.");
        int escolha = 0;
        if (mascotes.Count == 0)
        {
            Console.WriteLine("Você ainda não possui nenhum bixano");
                escolha = -1;
        }
        else
        {
            for (int indiceMascote = 0; indiceMascote < mascotes.Count; indiceMascote++)
            {
                Console.WriteLine($"{indiceMascote} - {mascotes[indiceMascote].Nome.ToUpper()}");
            }
            Console.Write($"Qual mascote você deseja interagir? ");
            escolha = Convert.ToInt32(Console.ReadLine());
        }
        return escolha;
    }

    public string InteragirComMascotes(Mascote mascote)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine($"1 - SABER COMO {mascote.Nome.ToUpper()} ESTÁ");
        Console.WriteLine($"2 - ALIMENTAR O {mascote.Nome.ToUpper()}");
        Console.WriteLine($"3 - BRINCAR COM {mascote.Nome.ToUpper()} ");
        Console.WriteLine($"4 - VOLTAR");
        Console.Write($"{NomeJogador} VOCÊ DESEJA: ");

        return Console.ReadLine().ToUpper();
    }

    public void AlimentarMascote()
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine($" (=^w^=)");
        Console.WriteLine($"Mascote Alimentado");
    }

    public void BrincarMascote()
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine($"(=^w^=)");
        Console.WriteLine($"Mascote mais feliz");
    }

    public void GameOver(Mascote mascote)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine("O mascote morreu de " + (mascote.Humor > 0 || mascote.Alimentacao > 0 ? "fome" : "tristeza"));

        Console.WriteLine(@"
              #####      #     #     #  #######      #######  #     #  #######  ######  
             #     #    # #    ##   ##  #            #     #  #     #  #        #     # 
             #         #   #   # # # #  #            #     #  #     #  #        #     # 
             #  ####  #     #  #  #  #  #####        #     #  #     #  #####    ######  
             #     #  #######  #     #  #            #     #   #   #   #        #   #   
             #     #  #     #  #     #  #            #     #    # #    #        #    #  
              #####   #     #  #     #  #######      #######     #     #######  #     # ");
    }
}
}
