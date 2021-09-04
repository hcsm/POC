using Domain.Entity.FRWK;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Utilities
{
    public static class Utilites
    {
        public static FRWKChallenge DecomposeNumberMethod2(int number)
        {
            ICollection<ValidationResult> results = null;
            FRWKChallenge obj = new FRWKChallenge(number);

            if (!Validate(obj, out results))
            {
                throw new Exception(results.Select(o => o.ErrorMessage).First().ToString());
            }

            for (var i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    obj.lstDivisors.Add(i);
                }
            }

            obj.lstDivisors.Add(number);

            int divider = 2;
            
            while (number != 1)
            {
                while (number % divider != 0)
                {
                    divider++;
                }

                number = number / divider;
                obj.lstPrimeNumbers.Add(divider);
            }

            obj.lstPrimeNumbers = obj.lstPrimeNumbers.Distinct().ToList();
            return obj;
        }

        public static FRWKChallenge DecomposeNumberMethod1(int number)
        {
            ICollection<ValidationResult> results = null;
            FRWKChallenge obj = new FRWKChallenge(number);

            if (!Validate(obj, out results))
            {
                throw new Exception(results.Select(o => o.ErrorMessage).First().ToString());
            }

            int divider = 2;
            while (number != 1)
            {
                while (number % divider != 0)
                {
                    divider++;
                }

                number = number / divider;
                obj.lstPrimeNumbers.Add(divider);
            }

            obj.lstDivisors.Add(1);
            int left = obj.lstPrimeNumbers[0];
            int right = obj.lstDivisors[0];

            for (var i = 0; i < obj.lstPrimeNumbers.Count; i++)
            {
                int size = obj.lstDivisors.Count;

                for (var o = 0; o < size; o++)
                {

                    if (!obj.lstDivisors.Contains((obj.lstPrimeNumbers[i] * obj.lstDivisors[o])))
                    {
                        obj.lstDivisors.Add((obj.lstPrimeNumbers[i] * obj.lstDivisors[o]));
                    }
                }

            }

            obj.lstPrimeNumbers = obj.lstPrimeNumbers.Distinct().ToList();
            obj.lstDivisors.Sort();
            return obj;
        }

        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
