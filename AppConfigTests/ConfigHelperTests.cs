using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AppConfig.Tests
{
    [TestClass()]
    public class ConfigHelperTests
    {
        [TestMethod()]

        [DataRow("A", "a")]
        [DataRow("B", "b")]
        [DataRow("C", "c")]
        [DataRow("D", null)]
        public void GetAppSettingValueTest(string input, string expected)
        {
            //Arrange
            ConfigHelper configHelper = new ConfigHelper();

            //Act
            var actual = configHelper.GetAppSettingValue(input);

            //Assert

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAllAppSettingValueTest()
        {
            ConfigHelper configHelper = new ConfigHelper();

            var actual = configHelper.GetAppSettingValue();

            var expected = new Dictionary<string, string>()
            {
                { "A", "a" }, { "B", "b" }, { "C", "c" }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("1", "123")]
        [DataRow("2", "456")]
        [DataRow("3", null)]
        public void GetConnectStringTest(string name, string expected)
        {
            ConfigHelper configHelper = new ConfigHelper();

            var actual = configHelper.GetConnectString(name);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetMySectionCodeTest()
        {
            ConfigHelper configHelper = new ConfigHelper();

            var actual = configHelper.GetMySectionCode();

            Assert.AreEqual("asdas", actual);
        }

        [TestMethod()]
        public void GetMySectionMemberTest()
        {
            ConfigHelper configHelper = new ConfigHelper();

            var actual = configHelper.GetMySectionMember();

            Assert.AreEqual("dasd", actual);
        }


        [TestMethod()]
        public void GetMySectionMembersTest()
        {
            ConfigHelper configHelper = new ConfigHelper();

            var actual = configHelper.GetMySectionMembers();

            Assert.AreEqual(3, actual);
        }

        [TestMethod()]
        public void GetMySectionMembersInGroupTest()
        {
            ConfigHelper configHelper = new ConfigHelper();

            var actual = configHelper.GetMySectionMembersInGroup();

            Assert.AreEqual(2, actual);

            actual = configHelper.GetMySectionMembersInGroupByOpenConfig();

            Assert.AreEqual(2, actual);

            actual = configHelper.GetMySectionMembersInGroupByOpenOtherConfig();

            Assert.AreEqual(4, actual);
        }
    }
}