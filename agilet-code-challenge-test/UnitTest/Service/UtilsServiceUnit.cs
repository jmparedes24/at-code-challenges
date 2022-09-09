using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agilet_code_challenge.Common;
using agilet_code_challenge.Services;
using NUnit.Framework;

namespace agilet_code_challenge_test.UnitTest.Service
{
    public class UtilsServiceUnit
    {
        private IUtilsService _service;
        [SetUp]
        public void Setup()
        {
            _service = new UtilsService();
        }

        [Test]
        public void OrganizedArray_Success_When_Array_Has_Same_Lenght()
        {
            //Arrange             
            var names = new string[] { "Sonia", "Maria", "Wood", "Dempster" };
            var order = new string[] { "4", "1", "2", "3" };

            //Act
            var result = _service.OrganizedArray(names, order);

            //Arrange
            Assert.True(result.Success);
        }

        [Test]
        public void OrganizedArray_Success_Order_When_Array_Has_Correct_Information()
        {
            //Arrange             
            var names = new string[] { "Sonia", "Maria", "Wood", "Dempster" };
            var order = new string[] { "4", "2", "3", "1" };
            var expectedResult = new string[] { "Dempster", "Maria", "Wood", "Sonia" };

            //Act
            var result = _service.OrganizedArray(names, order);

            //Arrange
            Assert.True(result.Success);
            Assert.AreEqual(result.Data, expectedResult);
        }

        [Test]
        public void OrganizedArray_Error_When_Array_Has_Different_Lenght()
        {
            //Arrange             
            var names = new string[] { "Sonia", "Maria", "Wood", "Dempster" };
            var order = new string[] { "4", "1", "2" };

            //Act
            var result = _service.OrganizedArray(names, order);

            //Arrange
            Assert.False(result.Success);
            Assert.True(result.Message.Contains(Consts.ERROR_DIFFERENT_LENGTH));
        }

        [Test]
        public void OrganizedArray_Error_When_Names_Are_Not_Provide()
        {
            //Arrange             
            var names = new string[] { };
            var order = new string[] { "4", "1", "2" };

            //Act
            var result = _service.OrganizedArray(names, order);

            //Arrange
            Assert.False(result.Success);
            Assert.True(result.Message.Contains(Consts.ERROR_NAMES_EMPTY));
        }
        [Test]
        public void OrganizedArray_Error_When_Order_Is_Not_Provide()
        {
            //Arrange             
            var names = new string[] { "Sonia", "Maria", "Wood", "Dempster" };
            var order = new string[] { };

            //Act
            var result = _service.OrganizedArray(names, order);

            //Arrange
            Assert.False(result.Success);
            Assert.True(result.Message.Contains(Consts.ERROR_ORDER_EMPTY));
        }

        /// <summary>
        /// Method that help us to generate random unique values
        /// </summary>
        /// <param name="minValue">int</param>
        /// <param name="maxValue">int</param>
        /// <returns>int[]</returns>
        public int[] GenerateUniqueNumbers(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentException("Minimal value cannot be bigger than maximal value.");

            int[] values = new int[maxValue - minValue + 1];

            for (int i = 0; i < values.Length; ++i)
                values[i] = minValue + i;

            Random random = new Random();

            for (int i = 0; i < values.Length; ++i)
            {
                int index = random.Next(values.Length);

                if (i == index)
                    continue;

                int tmp = values[i];

                values[i] = values[index];
                values[index] = tmp;
            }

            return values;
        }
    }
}