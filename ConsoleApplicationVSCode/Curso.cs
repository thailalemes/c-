using System;


namespace ConsoleApplicationVSCode
{
     [System.Serializable]
   class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float valor,string autor)
        {
            this.nome = nome;
            this.valor = valor;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade  de vagas disponiveis: ");
            int entrada =int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Vagas Registradas!");
            Console.ReadLine();
            
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Preencher vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade  de vagas preenchidas: ");
            int entrada =int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Vagas Registradas!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Valor:{valor}");
            Console.WriteLine($"Vagas:{vagas}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine("=========================");
        }
    }
}