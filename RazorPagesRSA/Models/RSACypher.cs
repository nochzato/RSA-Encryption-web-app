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

        //public string Encrypt(string text)
        //{
        //    var input = BigInteger.Parse(text);
        //    BigInteger e = PublicKey[0];
        //    BigInteger N = PublicKey[1];
        //    BigInteger result = BigInteger.ModPow(input, e, N);
        //    return result.ToString();
        //}

        public string Encrypt(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            bytes.Reverse();
            BigInteger input = new BigInteger(bytes);
            BigInteger e = PublicKey[0];
            BigInteger N = PublicKey[1];
            BigInteger result = BigInteger.ModPow(input, e, N);
            var bytes_out = result.ToByteArray();
            bytes_out.Reverse();
            string v = Encoding.UTF8.GetString(bytes_out);
            return v;
        }

        public string Decrypt(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            bytes.Reverse();
            BigInteger input = new BigInteger(bytes);
            BigInteger d = PrivateKey[0];
            BigInteger N = PrivateKey[1];
            BigInteger result = BigInteger.ModPow(input, d, N);
            var bytes_out = result.ToByteArray();
            bytes_out.Reverse();
            string v = Encoding.UTF8.GetString(bytes_out);
            return v;
        }

    }
}
