using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass()]
    public class RowTranspositionTest
    {
        [TestMethod()]
        public void EncryptTest()
        {
            //Arrange
            ISecurity target = new RowTransposition();
            string plain = "attackpostponeduntiltwoam";
            object[] param = new object[1] { "4,3,1,2,5,6,7" };
            string cypher = "ttna aptm tsuo aodw coi* knl* pet* ";

            //Act
            string actual = target.Encrypt(plain, param);

            //Assert
            Assert.AreEqual(cypher, actual);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            //Arrange
            ISecurity target = new RowTransposition();
            string plain = "attackpostponeduntiltwoam";
            object[] param = new object[1] { "4,3,1,2,5,6,7" };
            string cypher = "ttna aptm tsuo aodw coi* knl* pet* ";

            //Act
            string actual = target.Decrypt(cypher, param);

            //Assert
            Assert.AreEqual(plain, actual);
        }
    }
}
