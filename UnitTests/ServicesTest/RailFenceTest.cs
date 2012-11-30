using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class RailFenceTest
    {
        readonly SecurityAlgorithm _target;

        public RailFenceTest()
        {
            _target = new RailFence(2);
        }

        [TestMethod()]
        public void RailFence_EncryptTest()
        {
            //Arrange
            string plain = "meetmeafterthegraduationparty";
            string cypher = "mematrhgautopryetefeterdainat*";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void RailFence_DecryptTest()
        {
            //Arrange
            string plain = "meetmeafterthegraduationparty*";
            string cypher = "mematrhgautopryetefeterdainat*";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
