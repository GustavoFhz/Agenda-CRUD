using Projeto02;

Crud crud = new Crud();
int acao;

do 
{
    Console.WriteLine("Bem vindo a agenda, por favor selecione uma das opções abaixo");
    Console.WriteLine("1 - Cadastrar\n2 - Listar\n3 - Alterar\n4 - Remover");

    acao = Convert.ToInt32(Console.ReadLine());
    
    switch (acao)
    {
        case 1: crud.Cadastrar(); break;
        case 2: crud.Selecionar(); break;
        case 3: crud.Alterar(); break;
        case 4: crud.Remover(); break;
        default: Console.WriteLine("Opção inválida"); break;

    }
}
while (acao != 5);