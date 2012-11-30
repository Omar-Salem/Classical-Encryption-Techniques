using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class AutoKeyTest
    {
        [TestMethod()]
        public void AutoKey_EncryptTest()
        {
            //Arrange
            SecurityAlgorithm target = new AutoKey("deceptive");
            string plain = "wearediscoveredsaveyourself";
            string cypher = "zicvtwqngkzeiigasxstslvvwla";

            //Act
            string actual = target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void AutoKey_DecryptTest()
        {
            //Arrange
            SecurityAlgorithm target = new AutoKey("deceptivewearediscoveredsav");
            string plain = "wearediscoveredsaveyourself";
            string cypher = "zicvtwqngkzeiigasxstslvvwla";

            //Act
            string actual = target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
