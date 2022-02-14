using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplicationVSCode
{
     
    class Program
    {
        static List <IEstoque> produtos = new List<IEstoque>();
        enum Menu {Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while(escolheuSair == false){

                Console.WriteLine("Sistema de Estoque");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Registrar Entrada\n5 - Registrar Saida\n6 - Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

             if(opInt > 0 && opInt <7)
             {
                Menu escolha = (Menu)opInt;
                switch (escolha)
                {
                    case Menu.Listar:
                    Listagem();
                        break;
                    case Menu.Adicionar:
                    Cadastro();
                        break;
                    case Menu.Entrada:
                    Entrada();
                        break;
                    case Menu.Remover:
                    Remover();
                        break;
                    case Menu.Saida:
                    Saida();                 
                        break;
                    case Menu.Sair:
                        escolheuSair = true;  
                        break;      
                }
             }
             else
                {
                    escolheuSair = true;
                }  
                Console.Clear();  
            }
        }

        static void Listagem(){
            Console.WriteLine("Lista de Produtos");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

         static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1 - Produto Fisico\n2 - Ebook\n3 - Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);
            switch (escolhaInt)
        {
            case 1:
            CadastrarPFisico();
                break;
            case 2:
            CadastrarEbook();
                break;
            case 3:
            CadastrarCurso();
                break;        
        }
    }
    
        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando Produto Fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Valor: ");
            float valor = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse (Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome,valor,frete);
            produtos.Add(pf);
            SalvarLista();


        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Valor: ");
            float valor = float.Parse(Console.ReadLine());
            string autor = Console.ReadLine();
            Console.WriteLine("Valor: ");
            
            Ebook eb = new Ebook(nome, valor, autor);
            produtos.Add(eb);
            SalvarLista();
            


        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Valor: ");
            float valor = float.Parse(Console.ReadLine());
            string autor = Console.ReadLine();
            Console.WriteLine("Valor: ");
            
            Curso cs = new Curso(nome, valor, autor);
            produtos.Add(cs);
            SalvarLista();
        }
       
       static void SalvarLista()
       {
           FileStream stream = new FileStream("Produtos.dat",FileMode.OpenOrCreate);
           BinaryFormatter encoder = new BinaryFormatter();

           encoder.Serialize(stream, produtos);
           stream.Close();
       }

        static void Carregar(){
           FileStream stream = new FileStream("Produtos.dat",FileMode.OpenOrCreate);
           BinaryFormatter encoder = new BinaryFormatter();

           try{
               produtos = (List<IEstoque>)encoder.Deserialize(stream);

               if (produtos == null)
               {
                   produtos = new List<IEstoque>();
               }
           }catch(Exception e)
           {
               produtos = new List<IEstoque>();
           }

           stream.Close();

        }


        static void Remover(){
            Listagem();
            Console.WriteLine("Digite o ID  do elemento  que voce quer remover:");
            int id = int.Parse (Console.ReadLine());

            if (id >=0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                SalvarLista();
            }
            
        }

        static void Entrada(){
             Listagem();
            Console.WriteLine("Digite o ID  do elemento  que voce deseja adicionar:");
            int id = int.Parse (Console.ReadLine());

            if (id >=0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                SalvarLista();
        }

    } 
        static void Saida(){
             Listagem();
            Console.WriteLine("Digite o ID  do elemento  que voce deseja dar baixa:");
            int id = int.Parse (Console.ReadLine());

            if (id >=0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                SalvarLista();
        }




    }

}
}
