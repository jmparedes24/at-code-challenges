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
        public void OrganizedArray_Error_When_Array_Has_Different_Lenght()
        {
            //Arrange             
            var names = new string[] { "Sonia", "Maria", "Wood", "Dempster" };
            var order = new string[] { "4", "1", "2" };

            //Act
            var result = _service.OrganizedArray(names, order);

            //Arrange
            Assert.False(result.Success);
            Assert.True(result.Message.Contains("Names can not be order because different lengths between names and order"));
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
    }
}