using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//https://sahandsaba.com/cryptography-rsa-part-1.html

namespace RSA
{
    public class Rsa
    {
        private int _bitLength;
        private Random _rand = new Random();

        public Rsa(int bitLength)
        {
            if (bitLength % 2 != 0)
                throw new ArgumentException("BitLength needs to be dividable by 2");
            _bitLength = bitLength;
        }

        public void GenerateKeyPair()
        {
            var p = GenerateRandomPrime(_bitLength / 2);
            var bLength = _bitLength / 2;
        }

        public BigInteger GenerateRandomPrime(int bLength)
        {
            var prime = GetRandomNumber(bLength);
            for (int i = 0; ; i++)
            {
                if (TestForPrime(prime))
                    break;
                else
                    if (i % (bLength * 2) == 0)
                    prime = GetRandomNumber(bLength);
                else
                    prime += 2;
            }

            return prime;
        }

        private bool TestForPrime(BigInteger toCheck)
        {
            if (toCheck % 2 == 0)
                return toCheck == 2;
            if (toCheck % 3 == 0)
                return toCheck == 3;

            var k = 6L;
            while ((long)Math.Pow(k - 1, 2) <= toCheck)
            {
                if ((toCheck % (k - 1) == 0) || (toCheck % (k + 1) == 0))
                    return false;
                k += 6;
            }
            return true;
        }

        private bool RabinMillerTestPrime(BigInteger number, int k = 20)
        {
            var m = number - 1;
            var s = 0;
            while (m % 2 == 0)
            {
                s += 1;
                m /= 2;
            }

            var liars = new List<BigInteger>();
            while (liars.Count < k)
            {
                var x = GetRandomNumberInRange(2, number - 1);
                while (liars.Contains(x))
                    x = GetRandomNumberInRange(2, number - 1);
                var xi = BigInteger.ModPow(x, m, number);
                var witness = true;
                if xi == 1 or xi == n - 1:
            witness = False
                else:
            for __ in xrange(s - 1):
                xi = (xi * *2) % n
                if xi == 1:
                    return False
                        elif xi == n - 1:
                    witness = False
                            break
                    xi = (xi * *2) % n
                    if xi != 1:
                return False
                if witness:
            return False
                else:
            liars.add(x)
                            }
            return True
        }

        private BigInteger GetRandomNumberInRange(BigInteger minValue, BigInteger maxValue)
        {
            BigInteger newNumber = new BigInteger();
            while (newNumber < minValue || newNumber > maxValue)
            {
                var newBa = new byte[maxValue.ToByteArray().Length];
                _rand.NextBytes(newBa);
                newNumber = new BigInteger(newBa);
            }
            return newNumber;
        }

        private BigInteger GetRandomNumber(int bitLength)
        {
            var number = new byte[bitLength / 8];
            _rand.NextBytes(number);

            var result = new BigInteger(number.Append((byte)0).ToArray()) | (new BigInteger(1) << bitLength) | 1;

            return result;
        }
    }
}
