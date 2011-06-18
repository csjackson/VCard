using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VCardEater;

namespace VCardTest
{
    [TestClass]
    public class VCardWriterTest
    {
           [TestInitialize]
        public void Before_Each_Test()
        {
            // create a new personclass & fill properties
            VCardMaker.PersonClass Contact = new VCardMaker.PersonClass()
            {
                First_Name = "Melven",
                Middle_Name = "Edgar",
                Last_Name = "Ross",
                Title = "Functionary",
                Organization = "EIEIO",
            };
        }
        [TestMethod]
        public void FW_Should_Write_a_File()
        {
            //Arrange
           

            // Act
           // var result = new VCardMaker().SpitToFile(First, Last, Full);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void TicToc_Should_Format_Time_For_Rev_Field()
        {
            // Example: 20080424T195243Z
            // Arrange

            //Act
            // string rev = new VCardMaker.TimeChecker().TicToc();

            // Assert 
            // Assert.AreEqual(16, rev.Length);
            // Assert.IsTrue(rev.Substring(11, 2) == System.DateTime.UtcNow.Minute.ToString());
        }

        [TestMethod]
        public void Full_Name_Should_Handle_Middle_Name()
        {
            //Arrange
            VCardMaker.PersonClass Contact = new VCardMaker.PersonClass()
            {
                First_Name = "Melven",
                Middle_Name = "Edgar",
                Last_Name = "Ross",
                Title = "Functionary",
                Organization = "EIEIO",
            };

            //Act 
            var result = new VCardMaker.PersonClass().Full_Name_Maker(Contact);
            // Assert
           Assert.AreEqual("Melven Edgar Ross", result);
        }
        [TestMethod]
        public void Full_Name_Should_Handle_Missing_Middle_Name()
        {
            //Arrange
            VCardMaker.PersonClass Contact = new VCardMaker.PersonClass()
            {
                First_Name = "Melven",
                Middle_Name = string.Empty,
                Last_Name = "Ross",
                Title = "Functionary",
                Organization = "EIEIO",
            };

            // Act
            var result = new VCardMaker.PersonClass().Full_Name_Maker(Contact);

            // Assert
            Assert.AreEqual("Melven Ross", result);
        }
    }
}
