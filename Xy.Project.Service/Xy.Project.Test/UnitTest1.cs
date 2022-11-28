using System.Security.Cryptography;
using Xy.Project.Core.Helpers;

namespace Xy.Project.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var key = Sm2CryptoHelper.GenerateKeyHex();
            Console.WriteLine("¹«Ô¿:" + key.publicKey);
            Console.WriteLine("Ë½Ô¿:" + key.privateKey);
        }

        [Test]
        public void Test3()
        {
            var key = AesCryptoHelper.GetIv();
            Console.WriteLine("ÃØÔ¿:" + key);
            //56gCGb5STzwTZH9jtXFngiAkZ2K7OR0z
            var password = "213213141223";
            var enc = AesCryptoHelper.Encrypt(password,key );
            Console.WriteLine(enc);
            var prc = AesCryptoHelper.Decrypt(enc,key);
            Console.WriteLine(prc);
        }
    }
}