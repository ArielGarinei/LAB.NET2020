using System;
using ejercicio2.exeptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [DataRow(20)]
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod_DivZero_Exception_DivideByZero(int i)
        {
            //Arrage is handled by DataRow
            var myExceptions = new MyExceptionsTest();
            //Act
            myExceptions.DivZero(i);
            //Assert is handled by the ExpectedException
        }

        [DataRow(-1, -1, int.MaxValue)]
        [DataRow(20, 2, 10)]
        [DataRow(20, 0, int.MaxValue)]
        [TestMethod]
        public void TestMethod_Dividir_Return_Susses(int i, int j, int expected)
        {
            //Arrage is handled by DataRow
            var logic = new Logic();
            //Act
            int actual = logic.Divide(i, j);
            //Assert
            Assert.AreEqual(actual, expected);
        }


        //Test error[DataRow(20, 2)]
        [DataRow(20, 0)]
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod_Dividir_Exception_DivideByZero(int i, int j)
        {
            //Arrage is handled by DataRow
            var myExceptions = new MyExceptionsTest();
            //Act
            myExceptions.Dividir(i, j);
            //Assert is handled by the ExpectedException
        }


        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestMethod_logic_TrhowExeption_DivideByZero()
        {
            //Arrage is handled by DataRow
            var myLogic = new Logic();
            //Act
            myLogic.TrhowExeption();
            //Assert is handled by the ExpectedException
        }

        [DataRow("Exepcion perzonalizada")]
        [TestMethod]
        [ExpectedException(typeof(ExceptionCustom))]
        public void TestMethod_logic_TrhowCustomExeption_ExceptionCustom(string message)
        {
            //Arrage is handled by DataRow
            var myLogic = new Logic(message);
            //Act
            myLogic.TrhowCustomExeption();
            //Assert is handled by the ExpectedException
        }


    }
}
