using Devices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevicesTests
{
    [TestClass]
    public class GpsSensorTests
    {
        [TestMethod]
        public void generateGPSMetric_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = new GpsSensor();

            // Act
            unitUnderTest.generateGPSMetric();

            // Assert
            Assert.Fail();
        }
    }
}
