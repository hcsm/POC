using Domain.Entity.FRWK;
using Newtonsoft.Json;
using System;
using System.Text;
using Utilities;

namespace ConsoleApp.FRWK
{
    class Program
    {
        static void Main(string[] args)
        {
            
             Console.WriteLine("Digite um número natural positivo menor que "+int.MaxValue.ToString()+", diferente de zero: ");
             string line = Console.ReadLine();
            try
            {
                int value;
                if (int.TryParse(line, out value))
                {
                    Console.Clear();
                    Console.WriteLine("Resultado:");
                    Console.WriteLine("");
                    FRWKChallenge obj = Utilites.DecomposeNumberMethod2(value);
                    string json = JsonConvert.SerializeObject(obj);
                    Console.WriteLine(json);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("'"+line+"' não é um número válido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.Read();
        }

    }
}
