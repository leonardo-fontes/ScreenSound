
// Screen Sound

string msgBoasVindas = "Boas vindas ao Screen Sound!";
// List<string> bandas = new List<string> {"U2", "The Beatles", "The Strokes" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin park", new List<int> {1, 5, 10, 8});
bandasRegistradas.Add("The Beatles", new List<int> ());



void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("");
    Console.WriteLine(msgBoasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    int opcaoEscolhida = int.Parse(Console.ReadLine()!);
    switch(opcaoEscolhida)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: CalcularMediaBanda();
            break;
        case -1: Console.WriteLine("Goodbye :)");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>()); //.Add == .push javascript
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
    Thread.Sleep(2000); //aguarda 2s
    Console.Clear(); //limpa o console
    ExibirOpcoesMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo bandas registradas!");
    
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu...");
    Console.ReadKey(); //le uma tecla qualquer
    Console.Clear();
    ExibirOpcoesMenu();
}


void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    //digite qual banda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    // senao, exibir msg e voltar ao Menu

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();

    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Pressione uma tecla para voltar ao Menu...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}


void CalcularMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir a média da Banda"); 
    Console.Write("Digite o nome da banda que deseja consultar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é: {notasBanda.Average()}");
        Console.WriteLine("Pressione uma tecla para voltar ao Menu...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

    else {
        Console.WriteLine($"\nA banda {nomeDaBanda} não existe no dicionário!");
        Console.WriteLine("Pressione uma tecla para voltar ao Menu...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
            
            

}

ExibirOpcoesMenu();
