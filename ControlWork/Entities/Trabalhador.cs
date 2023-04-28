using ControlWork.Entities.Enums;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ControlWork.Entities
{
    class Trabalhador
    {   //Nome do trabalhador
        public string Nome { get; set; } 
        //O NivelTrabalhador foi criado como enumeração dentro da sub pasta Enums
        public NivelTrabalhador Nivel { get; set; }
        //Salario base que o trabalhador terá fixo sem contar as horas contratadas
        public double SalarioBase { get; set; } 
        // Os contratos do trabalhador serão separados pelo objeto Departamento que sempre está ligado ao trabalhador
        public Departamento Departamento { get; set; } 
        //Pelo fato de um trabalhador poder conter varios contratos, é necessário utilizar a LISTA para armazenar esses dados
        // Para garantir que a lista não fique nula, será feito a instanciação da mesma
        public List<HoraContratada> Contratos { get; set; } = new List<HoraContratada> ();

        public Trabalhador(string nome, NivelTrabalhador nivel, double salarioBase, Departamento departamento)
        {
            Nome = nome;
            Nivel = nivel;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarContrato (HoraContratada contrato) 
        {
            //Adiciona contrato na Lista criada
            Contratos.Add(contrato);
        }

        public void RemoverContrato(HoraContratada contrato)
        {
            //Remove contrato na Lista criada
            Contratos.Remove(contrato);
        }

        public double Renda (int ano, int mes)
        {
            //Variavel soma sendo iniciado com o Salario Base que será inserido pelo usuário
            double sum = SalarioBase;
            //Percorrendo a lista
            foreach (HoraContratada contrato in Contratos)
            {   //Validando se existe o ano e mês inserido para a soma total da renda do trabalhador
                if (contrato.Data.Year == ano && contrato.Data.Month == mes)
                {
                    sum += contrato.ValorTotal();
                }
            }
            return sum;
        }
    }
}
