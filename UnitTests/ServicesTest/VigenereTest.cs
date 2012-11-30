using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class VigenereTest
    {
        [TestMethod()]
        public void Vigenere_EncryptTest()
        {
            //Arrange
            SecurityAlgorithm target = new Vigenere("lemon");
            string plain = "attackatdawn";
            string cypher = "lxfopvefrnhr";

            //Act
            string actual = target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void Vigenere_DecryptTest()
        {
            //Arrange
            SecurityAlgorithm target = new Vigenere("lemon");
            string plain = "attackatdawn";
            string cypher = "lxfopvefrnhr";

            //Act
            string actual = target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
