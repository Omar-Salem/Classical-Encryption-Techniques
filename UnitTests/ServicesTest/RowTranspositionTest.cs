using EncryptionAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class RowTranspositionTest
    {
        readonly SecurityAlgorithm _target;

        public RowTranspositionTest()
        {
            _target = new RowTransposition(new int[] { 4, 3, 1, 2, 5, 6, 7 });
        }

        [TestMethod()]
        public void RowTransposition_EncryptTest()
        {
            //Arrange
            string plain = "attackpostponeduntiltwoam";
            string cypher = "ttna aptm tsuo aodw coi* knl* pet* ";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void RowTransposition_DecryptTest()
        {
            //Arrange
            string plain = "attackpostponeduntiltwoam";
            string cypher = "ttna aptm tsuo aodw coi* knl* pet* ";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
