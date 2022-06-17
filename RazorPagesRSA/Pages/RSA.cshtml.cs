using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesRSA.Models;

namespace RazorPagesRSA.Pages
{
    public class RSAModel : PageModel
    {
        public KeyGenerator keygen;
        public RSACypher cypher;

        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string EncryptedText { get; set; }
        public string DecryptedText { get; set; }

        public RSAModel(KeyGenerator keygen, RSACypher cypher)
        {
            this.keygen = keygen;
            this.cypher = cypher;
            PrivateKey = $"[{cypher.PrivateKey[0]}, {cypher.PrivateKey[1]}]";
            PublicKey = $"[{cypher.PublicKey[0]}, {cypher.PublicKey[1]}]";
        }

        public void OnGet()
        {
            PrivateKey = $"[{cypher.PrivateKey[0]}, {cypher.PrivateKey[1]}]";
            PublicKey = $"[{cypher.PublicKey[0]}, {cypher.PublicKey[1]}]";
        }
        public void OnPostGenerate()
        {
            var keys = keygen.Generate();
            cypher.PrivateKey = keys[0];
            cypher.PublicKey = keys[1];
            PrivateKey = $"[{cypher.PrivateKey[0]}, {cypher.PrivateKey[1]}]";
            PublicKey = $"[{cypher.PublicKey[0]}, {cypher.PublicKey[1]}]";
        }

        public void OnPostEncrypt(string text)
        {
            EncryptedText = cypher.Encrypt(text);
        }

        public void OnPostDecrypt(string text)
        {
            DecryptedText = cypher.Decrypt(text);
        }
    }

}
