using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class HillTest
    {
        readonly int[,] matrix;
        readonly SecurityAlgorithm _target;

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

            _target = new Hill(matrix);
        }

        [TestMethod()]
        public void Hill_EncryptTest()
        {
            //Arrange
            string plain = "paymoremoney";
            string cypher = "lnshdlewmtrw";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void Hill_DecryptTest()
        {
            //Arrange
            string plain = "paymoremoney";
            string cypher = "lnshdlewmtrw";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
