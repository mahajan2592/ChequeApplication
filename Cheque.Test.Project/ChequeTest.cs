using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChequeService;

namespace Cheque.Test.Project
{
    [TestClass]
    public class ChequeTest
    {
        [TestMethod]
        public void TestMethodForNumberInTens()
        {
            
            string tensNumber = "78";
            string tensNUmberWord = "Seventy Eight";
            string getWord= ChequeWritingWebService.tens(tensNumber);

            Assert.AreEqual(tensNUmberWord.ToLower(), getWord.ToLower());
        }

        [TestMethod]
        public void TestMethodForNumberInHundred()
        {
           
            string hundredNumber = "781";
            string hundredNUmberWord = "Seven Hundred Eighty One";
            string getWord= ChequeWritingWebService.ConvertNumberToWords(hundredNumber);

            Assert.AreEqual(hundredNUmberWord.ToLower(), getWord.ToLower());
        }
    }
}
