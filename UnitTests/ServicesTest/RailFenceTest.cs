using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for RailFenceTest and is intended
    ///to contain all RailFenceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RailFenceTest
    {
        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            ISecurity target = new RailFence();
            string plain = "meetmeafterthegraduationparty";
            object[] param = new object[1] { 2 };
            string cypher = "mematrhgautopryetefeterdainat*";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            //Arrange
            ISecurity target = new RailFence();
            string plain = "meetmeafterthegraduationparty*";
            object[] param = new object[1] { 2 };
            string cypher = "mematrhgautopryetefeterdainat*";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
