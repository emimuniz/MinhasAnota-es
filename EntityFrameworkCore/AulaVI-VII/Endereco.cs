namespace Alura.Loja.Testes.ConsoleApp
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public Cliente Cliente { get; set; }
    }
}
