using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesRSA.Models
{
    public class RSAModel : PageModel
    {
        public long[]? PrivateKey { get; set; }

        public long[]? PublicKey { get; set; }
        public void OnPostGenerate()
        {
            var generator = new KeyGenerator();
            var keys = generator.Generate();
            PrivateKey = keys[0];
            PublicKey = keys[1];
            ViewData["PrivateKey"] = $"[{PrivateKey[0]}, {PrivateKey[1]}]";
            ViewData["PublicKey"] = $"[{PublicKey[0]}, {PublicKey[1]}]";
        }

        public void OnPostEncrypt()
        {
            ViewData["EncryptedText"] = "blah blah blah";
        }

        public void OnPostDecrypt()
        {
            ViewData["DecryptedText"] = "blah blah blah";
        }
    }
}

