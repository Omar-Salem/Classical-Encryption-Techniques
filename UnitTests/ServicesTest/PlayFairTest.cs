using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class PlayFairTest
    {
        [TestMethod()]
        public void EncryptTest()
        {

            //Arrange
            ISecurity target = new PlayFair();
            string plain = "hidethegoldinthetreestump";
            object[] param = new object[1] { "playfairexample" };
            string cypher = "bmodzbxdnabekudmuixmmouvif";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {

            //Arrange
            ISecurity target = new PlayFair();
            string plain = "hidethegoldinthetrexestump";
            object[] param = new object[1] { "playfairexample" };
            string cypher = "bmodzbxdnabekudmuixmmouvif";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
