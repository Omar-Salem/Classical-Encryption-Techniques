using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class MonoalphabeticTest
    {
        readonly SecurityAlgorithm _target = new Monoalphabetic();

        [TestMethod()]
        public void Monoalphabetic_EncryptTest()
        {
            //Arrange
            string plain = "abcd";

            //Act
            string cypher = _target.Encrypt(plain);

            //Assert
            Assert.AreNotEqual(cypher, plain);

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
