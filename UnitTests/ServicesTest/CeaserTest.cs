using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class CeaserTest
    {
        readonly SecurityAlgorithm _target;

        public CeaserTest()
        {
            _target = new Ceaser(3);
        }

        [TestMethod()]
        public void Ceaser_EncryptTest()
        {
            //Arrange
            string plain = "meetmeafterthetogaparty";
            string cypher = "phhwphdiwhuwkhwrjdsduwb";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void Ceaser_DecryptTest()
        {
            //Arrange
            string plain = "meetmeafterthetogaparty";
            string cypher = "phhwphdiwhuwkhwrjdsduwb";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
