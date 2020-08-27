using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var contexto = new LojaContext())
            {

                ExibiProdutosPromocao();

                var cliente = contexto
                                .Clientes
                                .Include(c => c.EnderecoDeEntrega)
                                .FirstOrDefault();

                Console.WriteLine($"Endereço de Entrega: {cliente.EnderecoDeEntrega.Logradouro}");



                var produto = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(p => p.Id == 9004)
                    .FirstOrDefault();

                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(produto.Compras);
                }
            }
            

            Console.ReadKey();

        }


        private static void ExibiProdutosPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var promocao = contexto2.Promocoes.Include(c => c.Produtos).ThenInclude(pp => pp.Produto).FirstOrDefault();


                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }

        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataTermino = new DateTime(2017, 1, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                foreach (var item in produtos)
                {
                    Console.WriteLine(item);
                }

                contexto.Promocoes.Add(promocao);
                contexto.SaveChanges();

            }
        }

        private static void UmParaUm()
        {
            using (var contexto = new LojaContext())
            {

                var fulano = new Cliente();
                fulano.Nome = "Beltrano";
                fulano.EnderecoDeEntrega = new Endereco()
                {
                    Numero = 12,
                    Logradouro = "Rua dos Invalidos",
                    Complemento = "Sobrado",
                    Bairro = "Centro",
                    Cidade = "Cidade",
                };


                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();


                //contexto.Promocoes.Add(MuitosParaMuitos());
                //contexto.SaveChanges();


                var produtos = contexto.Produtos.ToList();

                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto);

                }

                var clientes = contexto.Clientes.ToList();

                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nome);

                }


            }
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.99, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Cafe", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 1.99, Unidade = "Gramas" };


            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

        }
    }

}
