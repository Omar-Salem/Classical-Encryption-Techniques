using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class VigenereTest
    {
        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            ISecurity target = new Vigenere();
            string plain = "attackatdawn";
            object[] param = new object[1] { "lemon" };
            string cypher = "lxfopvefrnhr";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            //Arrange
            ISecurity target = new Vigenere();
            string plain = "attackatdawn";
            object[] param = new object[1] { "lemon" };
            string cypher = "lxfopvefrnhr";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
