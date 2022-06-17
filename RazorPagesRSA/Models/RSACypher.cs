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

        private byte[] TextToBytes(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }

        private string BytesToString(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
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
            BigInteger input = new BigInteger(Encoding.UTF8.GetBytes(text));
            BigInteger e = PublicKey[0];
            BigInteger N = PublicKey[1];
            BigInteger result = BigInteger.ModPow(input, e, N);
            var bytes = result.ToByteArray();
            return Encoding.UTF8.GetString(bytes);
        }

        //public string Decrypt(string text)
        //{
        //    var input = BigInteger.Parse(text);
        //    BigInteger d = PrivateKey[0];
        //    BigInteger N = PrivateKey[1];
        //    BigInteger result = BigInteger.ModPow(input, d, N);
        //    return result.ToString();
        //}

        public string Decrypt(string text)
        {
            BigInteger input = new BigInteger(Encoding.UTF8.GetBytes(text));
            BigInteger d = PrivateKey[0];
            BigInteger N = PrivateKey[1];
            BigInteger result = BigInteger.ModPow(input, d, N);
            var bytes = result.ToByteArray();
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
