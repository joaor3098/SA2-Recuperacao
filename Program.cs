// See https://aka.ms/new-console-template for more information


using SA2.Classes;

string? opcao;
do
{
    Console.Clear();
    // Exibe Menu
    Console.WriteLine(@"
    1 - Cadastrar PJ
    2 - Listar PJ
    3 - Sair
    
    ");
    opcao = Console.ReadLine();

    PessoaJuridica metodosPj = new PessoaJuridica();

    switch (opcao)
    {
        case "1":
            PessoaJuridica pj = new PessoaJuridica();

            //Atribuir nome a Pessoa Juridica
            Console.WriteLine("Digite o nome da Pj: ");
            pj.Nome = Console.ReadLine();

            //Atribuir o rendimento a Pj
            Console.WriteLine("Informe o rendimento: ");
            pj.Rendimento = float.Parse(Console.ReadLine()!);

            bool cnpjValido;

            //Atribuir o CNPJ
            do
            {
                Console.WriteLine("Informe o CNPJ: ");
                pj.Cnpj = Console.ReadLine();
                cnpjValido = metodosPj.ValidarCnpj(pj.Cnpj!);
            } while (cnpjValido == false);
            
            //Cria um arquivo txt
            metodosPj.Inserir(pj);

            Console.WriteLine("Cadastro realizado com sucesso");
            Console.WriteLine("Aperte uma TECLA para continuar");
            Console.ReadLine();


            break;

        case"2":
            // Pergunta ao usuário o nome do arquivo txt 
            Console.WriteLine("Digite o nome do arquivo: ");
            string nomeArquivo = Console.ReadLine()!;

            // Leu e atribuiu a um objeto do tipo PessoaJuridica
            PessoaJuridica pjArquivo = metodosPj.Ler(nomeArquivo);

            //Mostrar dados da pessoa juridica
            Console.WriteLine(@$"
                Nome: {pjArquivo.Nome}
                Rendimento: {pjArquivo.Rendimento}
                CNPJ: {pjArquivo.Cnpj}
            ");
            Console.WriteLine("Aperte uma TECLA para continuar");
            Console.ReadLine();
            break;
        case"3":
            break;
        
        default:
            Console.WriteLine("Opção Invalida");
            break;
    }
    
} while (opcao != "3");
