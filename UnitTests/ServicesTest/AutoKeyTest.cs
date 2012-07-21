using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class AutoKeyTest
    {
        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            ISecurity target = new AutoKey();
            string plain = "wearediscoveredsaveyourself";
            object[] param = new object[1] { "deceptive" };
            string cypher = "zicvtwqngkzeiigasxstslvvwla";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            //Arrange
            ISecurity target = new AutoKey();
            string plain = "wearediscoveredsaveyourself";
            object[] param = new object[1] { "deceptivewearediscoveredsav" };
            string cypher = "zicvtwqngkzeiigasxstslvvwla";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
