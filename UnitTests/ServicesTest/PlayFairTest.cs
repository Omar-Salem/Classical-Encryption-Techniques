using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class PlayFairTest
    {
        readonly SecurityAlgorithm _target;

        public PlayFairTest()
        {
            _target = new PlayFair("playfairexample");
        }

        [TestMethod()]
        public void PlayFair_EncryptTest()
        {

            //Arrange
            string plain = "hidethegoldinthetreestump";
            string cypher = "bmodzbxdnabekudmuixmmouvif";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void PlayFair_DecryptTest()
        {

            //Arrange
            string plain = "hidethegoldinthetrexestump";
            string cypher = "bmodzbxdnabekudmuixmmouvif";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
