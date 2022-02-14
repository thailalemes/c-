using System;

namespace ConsoleApplicationVSCode
{
     [System.Serializable]
     class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float valor,string autor)
        {
            this.nome = nome;
            this.valor = valor;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivrel dar entrada no estoque de um E-book, pois é um produto digital!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no E-Book {nome}");
            Console.WriteLine("Digite a quantidade  de vendas realizadas: ");
            int entrada =int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Vendas Registradas!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Valor:{valor}");
            Console.WriteLine($"Vendas:{vendas}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine("====================");
        }
    }
}