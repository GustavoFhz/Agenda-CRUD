using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Projeto02
{
    internal class Crud : Padrao
    {
        public override void Alterar()
        {
            Console.WriteLine("Informe o nome do contato que deseja alterar");
            string? nome = Console.ReadLine();

            for (int i = 0; i < Armazenamento.Contatos.Count; i++)
            {
                Console.WriteLine($"{i + 1} {Armazenamento.Contatos[i].Nome}");
            }

            Contato contato = new();

            // Localizar o aluno pelo nome
            var contatoExistente = Armazenamento.Contatos.FirstOrDefault(aluno => contato.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (contatoExistente != null)
            {
                Console.WriteLine("Escolha a opção que deseja alterar");
                Console.WriteLine("1 - Nome\n2 - Data de nascimento\n3 - Email\n4 - Celular\n5 - Estado\n6 - Cidade");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o novo nome:");
                        contatoExistente.Nome = Console.ReadLine(); break;
                    case 2:
                        Console.WriteLine("Informe a nova data de nascimento:");
                        string data = Console.ReadLine();

                        DateTime dataNascimento;
                        bool sucesso = DateTime.TryParseExact(data, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento);

                        if (sucesso)
                        {
                            contato.DataNascimento = dataNascimento;
                            Console.WriteLine($"Data de nascimento {contato.DataNascimento.ToString("dd/MM/yyyy")}");
                        }
                        else
                        {
                            Console.WriteLine("Formato de data inválido. Por favor, insira no formato correto (dd/MM/yyyy).");
                        } break;
                    case 3:
                        Console.WriteLine("Informe o novo email:");
                        contatoExistente.Email = Console.ReadLine(); break;
                    case 4:
                        Console.WriteLine("Informe o novo número de celular:");
                        contatoExistente.Celular = Console.ReadLine(); break;
                    case 5:
                        Console.WriteLine("Informe o novo Estado:");
                        contatoExistente.Estado = Console.ReadLine(); break;
                    case 6:
                        Console.WriteLine("Informe a nova cidade:");
                        contatoExistente.Cidade = Console.ReadLine(); break;
                }
            }
            else
            {
                Console.WriteLine($"Contato com o nome {nome} não foi encontrado.");
            }
            
        }

        public override void Cadastrar()
        {
            Contato contato = new();

            Console.WriteLine("Informe o nome do contato");
            contato.Nome = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento (formato: dd/MM/yyyy)");
            string data = Console.ReadLine();

            DateTime dataNascimento;
            bool sucesso = DateTime.TryParseExact(data, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento);

            if (sucesso)
            {
                contato.DataNascimento = dataNascimento;
                Console.WriteLine($"Data de nascimento {contato.DataNascimento.ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Por favor, insira no formato correto (dd/MM/yyyy).");
            }

            Console.WriteLine("Informe o Email");
            contato.Email = Console.ReadLine();

            Console.WriteLine("Informe o número de celular");
            contato.Celular = Console.ReadLine();

            Console.WriteLine("Informe o Estado");
            contato.Estado = Console.ReadLine();

            Console.WriteLine("Informe a cidade");
            contato.Cidade = Console.ReadLine();
        }

        public override void ObterAniversario()
        {
            int mesAtual = DateTime.Now.Month;

            Contato contato = new();
            
            var aniversarianteMes = Armazenamento.Contatos.Where(conato => conato.DataNascimento.Month == mesAtual).ToList();

            Console.WriteLine($"Aniversariante do mês {mesAtual}");

            foreach(var pessoa in aniversarianteMes)
            {
                Console.WriteLine($"{pessoa.Nome} - Aniversário em {pessoa.DataNascimento.Day} / {pessoa.DataNascimento.Month}");
            }
            if (aniversarianteMes.Count == 0)
            {
                Console.WriteLine("Nenhum aniversariante neste mês.");
            }
        }

        public override void Remover()
        {
            Console.WriteLine("Informe o nome do contato que deseja remover");
            string nome = Console.ReadLine();

            for(int i = 0; i < Armazenamento.Contatos.Count; i++)
            {
                Console.WriteLine($"{i+1} {Armazenamento.Contatos[i].Nome}");
            }
            Contato contato = new();
            var aluno = Armazenamento.Contatos.FirstOrDefault(aluno => contato.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if( aluno != null)
            {
                Armazenamento.Contatos.Remove(contato);
                Console.WriteLine($"O contato {nome} foi removido com sucesso");
            }
            else
            {
                Console.WriteLine($"O contato {nome} não foi localizado");
            }
        }

        public override void Selecionar()
        {
            for(int i = 0; i < Armazenamento.Contatos.Count; i++)
            {
                Console.WriteLine($"Nome: {Armazenamento.Contatos[i].Nome}");
                Console.WriteLine($"Data de nascimento: {Armazenamento.Contatos[i].DataNascimento}");
                Console.WriteLine($"Email: {Armazenamento.Contatos[i].Email}");
                Console.WriteLine($"Número de celular: {Armazenamento.Contatos[i].Celular}");
                Console.WriteLine($"Estado: {Armazenamento.Contatos[i].Estado}");
                Console.WriteLine($"Cidade: {Armazenamento.Contatos[i].Cidade}");
            }

            ObterAniversario();
        }
       
    }
    
}
