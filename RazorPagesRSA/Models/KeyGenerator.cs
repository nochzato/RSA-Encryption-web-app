namespace RazorPagesRSA.Models
{
    public class KeyGenerator
    {
        public KeyGenerator()
        {

        }

        private bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n <= 1 || n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        private int GetRandomPrime()
        {
            Random rnd = new();
            int result = rnd.Next();
            while (!IsPrime(result))
            {
                result = rnd.Next();
            }
            return result;
        }

        private long gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private int GeneratePublicExponent(long lambda)
        {
            Random rnd = new();
            int result = rnd.Next();
            while (result >= lambda || result <= 1 || gcd(result, lambda) != 1)
            {
                result = rnd.Next();
            }
            return result;
        }

        private long modInverse(long a, long n)
        {
            long i = n, v = 0, d = 1;
            while (a > 0)
            {
                long t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        public long[][] Generate()
        {
            long[][] result = new long[2][];

            var p = GetRandomPrime();
            var q = GetRandomPrime();

            long N = Convert.ToInt64(p) * Convert.ToInt64(q);

            long lambda = Convert.ToInt64(p - 1) * Convert.ToInt64(q - 1);

            var e = GeneratePublicExponent(lambda);

            var d = modInverse(e, lambda);

            result[0] = new long[2] { d, N };
            result[1] = new long[2] { e, N };

            return result;
        }
    }
}
