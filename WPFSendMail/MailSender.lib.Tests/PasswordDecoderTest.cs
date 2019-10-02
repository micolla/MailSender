using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender.Lib;

namespace MailSender.lib.Tests
{
    [TestClass]
    public class PasswordDecoderTest
    {
        [TestMethod]
        public void Decode_ABC_TO_BCD()
        {
            // Принцип ААА
            // A - Arrange
            // A - Act
            // A - Assert

            #region Arrange

            var str = "ABC";
            var expected_result = "BCD";

            #endregion

            #region Act

            var actual_result = PasswordDecoder.getCodPassword(str);

            #endregion

            Assert.AreEqual(expected_result, actual_result);
        }
        [TestMethod]
        public void Decode_BCD_TO_ABC()
        {
            // Принцип ААА
            // A - Arrange
            // A - Act
            // A - Assert

            #region Arrange

            var str = "BCD";
            var expected_result = "ABC";

            #endregion

            #region Act

            var actual_result = PasswordDecoder.getPassword(str);

            #endregion

            Assert.AreEqual(expected_result, actual_result,"не совпадает");
        }

        [TestMethod]
        public void Decode_DBC_TO_CAB()
        {
            // Принцип ААА
            // A - Arrange
            // A - Act
            // A - Assert

            #region Arrange

            var str = "DBC";
            var expected_result = "CAB";

            #endregion

            #region Act

            var actual_result = PasswordDecoder.getPassword(str);

            #endregion

            StringAssert.Equals(expected_result, actual_result);
            StringAssert.Contains(expected_result, actual_result);
        }
    }
}
