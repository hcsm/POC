using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.FRWK
{
    public class FRWKChallenge
    {

        public FRWKChallenge(int naturalNumber)
        {
            this.number = naturalNumber;
            this.lstDivisors = new List<int>();
            this.lstPrimeNumbers = new List<int>();
        }

        [Range(1, int.MaxValue, ErrorMessage = "Somente número natural positivo menor que 2147483648, diferente de zero, é permitido.")]
        public int number { get; set; }
        public List<int> lstDivisors { get; set; }
        public List<int> lstPrimeNumbers { get; set; }
    }
}
