using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for CeaserTest and is intended
    ///to contain all CeaserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CeaserTest
    {
        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            ISecurity target = new Ceaser();
            string plain = "meetmeafterthetogaparty";
            object[] param = new object[1] { 3 };
            string cypher = "phhwphdiwhuwkhwrjdsduwb";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            //Arrange
            ISecurity target = new Ceaser();
            string plain = "meetmeafterthetogaparty";
            object[] param = new object[1] { 3 };
            string cypher = "phhwphdiwhuwkhwrjdsduwb";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
