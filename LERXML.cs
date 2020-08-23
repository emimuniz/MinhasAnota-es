using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivoExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Funcionario> listaFuncionario = ObterFuncionarioExcel();

            if(listaFuncionario != null)
            {
                foreach(var a in listaFuncionario)
                {
                    Console.WriteLine("{0}\t{1}", a.CodFunci, a.NomeFunci);
                }
            }

            Console.ReadKey();
        }

        static List<Funcionario> ObterFuncionarioExcel()
        {
            OleDbConnection _StringConexao = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Funcionarios.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';");
            string comandosql = "Select * from [Planilha1$]";
            OleDbCommand comando = new OleDbCommand(comandosql, _StringConexao);
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            try
            {
                using (_StringConexao)
                {
                    _StringConexao.Open();
                    OleDbDataReader rd = comando.ExecuteReader();

                    while (rd.Read())
                    {
                        if(rd["CodFunci"] != null)
                        {
                            listaFuncionarios.Add(new Funcionario()
                            {
                                CodFunci = Convert.ToInt32(rd["CodFunci"]),
                                NomeFunci = rd["NomeFunci"].ToString()
                            });
                        }
                        
                    }

                    return listaFuncionarios;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

    
