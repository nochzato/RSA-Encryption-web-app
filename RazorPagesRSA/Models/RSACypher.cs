using System.Text;
using System.Numerics;

namespace RazorPagesRSA.Models
{
    public class RSACypher
    {
        public long[]? PrivateKey { get; set; }

        public long[]? PublicKey { get; set; }

        public RSACypher()
        {
            PrivateKey = new long[2];
            PublicKey = new long[2];
        }


        public string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            BigInteger input = new BigInteger(Int64.Parse(text));
            BigInteger e = PublicKey[0];
            BigInteger N = PublicKey[1];
            BigInteger result = BigInteger.ModPow(input, e, N);
            return result.ToString();
        }

        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            BigInteger input = new BigInteger(Int64.Parse(text));
            BigInteger d = PrivateKey[0];
            BigInteger N = PrivateKey[1];
            BigInteger result = BigInteger.ModPow(input, d, N);
            return result.ToString();
        }

    }
}
