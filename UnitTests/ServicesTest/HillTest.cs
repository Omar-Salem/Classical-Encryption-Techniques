using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class HillTest
    {
        readonly int[,] matrix;

        public HillTest()
        {
            matrix = new int[3, 3];

            matrix[0, 0] = 17;
            matrix[0, 1] = 21;
            matrix[0, 2] = 2;

            matrix[1, 0] = 17;
            matrix[1, 1] = 18;
            matrix[1, 2] = 2;

            matrix[2, 0] = 5;
            matrix[2, 1] = 21;
            matrix[2, 2] = 19;
        }

        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            ISecurity target = new Hill();
            string plain = "paymoremoney";
            object[] param = new object[2] { matrix, 3 };
            string cypher = "lnshdlewmtrw";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            //Arrange
            ISecurity target = new Hill();
            string plain = "paymoremoney";
            object[] param = new object[2] { matrix, 3 };
            string cypher = "lnshdlewmtrw";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
