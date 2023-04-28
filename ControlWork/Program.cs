using System;
using System.Globalization;
using ControlWork.Entities.Enums;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ControlWork.Entities;

namespace ControlWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do departamento: ");
            string nomeDepartamento = Console.ReadLine();
                        
            Console.WriteLine("Nome do Trabalhador: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o nível do trabalhador: Junior, Medio ou Senior");
            //Enum NivelTrabalhador recebe o Enum.Parse (convertendo) para o tipo NivelTrabalhador o que o usuário inserir
            NivelTrabalhador nivel = Enum.Parse<NivelTrabalhador>(Console.ReadLine());

            Console.WriteLine("Digite seu salario base: ");
            double salarioBase = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            //Instanciando o objeto departamento com o nome inserifo pelo usuario
            Departamento dept = new Departamento(nomeDepartamento);
            Trabalhador trabalhador = new Trabalhador(nome, nivel, salarioBase, dept);

            Console.WriteLine("Quantos contratos o trabalhador terá ?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Digite o #{i} contrato: ");
                Console.WriteLine("Data: DD/MM/AAAA");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Valor por hora: ");
                double valorPorHora = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.WriteLine("Duração em horas: ");
                int horas = int.Parse(Console.ReadLine());
                HoraContratada contrato = new HoraContratada(data, valorPorHora, horas);
                trabalhador.AdicionarContrato (contrato);
            }

            Console.WriteLine();
            Console.WriteLine("Digite o mês e ano(MM/AAAA) para imprimir o valor total a receber:  "); 
            string mesEAno = Console.ReadLine();
            //Recortando e convertendo string para inteiro utilizando substring
            int mes = int.Parse(mesEAno.Substring(0, 2));
            int ano = int.Parse(mesEAno.Substring(3));

            Console.WriteLine("Nome: " + trabalhador.Nome);
            Console.WriteLine("Departamento: " + trabalhador.Departamento.Nome);
            Console.WriteLine("A renda para " + mesEAno + " : " + trabalhador.Renda(ano, mes));
        }
    }
}