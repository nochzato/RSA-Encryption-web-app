using RazorPagesRSA.Models;

namespace RSATests
{
    public class Tests
    {
        private RSACypher cypher;
        private KeyGenerator keygen;

        [SetUp]
        public void Setup()
        {
            cypher = new RSACypher();
            keygen = new KeyGenerator();
            var keys = keygen.Generate();
            cypher.PrivateKey = keys[0];
            cypher.PublicKey = keys[1];
        }

        [Test]
        public void CorrectCypherDecypher()
        {
            Assert.AreEqual("a", cypher.Decrypt(cypher.Encrypt("a")));
        }
    }
}