using System;

namespace ConsoleApplicationVSCode
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float valor,float frete)
        {
            this.nome = nome;
            this.valor = valor;
            this.frete = frete;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque de produto {nome}");
            Console.WriteLine("Digite a quantidade  que voce desejar adicionar: ");
            int entrada =int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque de produto {nome}");
            Console.WriteLine("Digite a quantidade  que voce desejar remover: ");
            int entrada =int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saída Registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Valor:{valor}");
            Console.WriteLine($"Frete:{frete}");
            Console.WriteLine($"Estoque:{estoque}");
            Console.WriteLine("====================");
        }
    }
}