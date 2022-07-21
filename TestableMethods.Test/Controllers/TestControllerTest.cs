namespace TestableMethods.Test.Controllers
{
    [TestClass]
    public class TestControllerTest
    {
        private TestController _testController;
        private Mock<ILogger<TestController>> _mockLogger;
        private Mock<ITestService> _mockTestService;

        public TestControllerTest()
        {
            _mockLogger = new Mock<ILogger<TestController>>();
            _mockTestService = new Mock<ITestService>();
            _testController = new TestController(_mockLogger.Object, _mockTestService.Object);
        }

        [TestMethod]
        public void PublicLightsSwitch_WhenCalled_ReturnsNoContentOn()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitches()).Returns(SwitchStatus.On);

            //Act
            var result = _testController.PublicLightsSwitch();

            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void PublicLightsSwitch_WhenCalled_ReturnsNoContentOff()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitches()).Returns(SwitchStatus.Off);

            //Act
            var result = _testController.PublicLightsSwitch();

            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void PublicLightsSwitchDaytimeBased_WhenCalled_ReturnsNoContentOn()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitchesBasedOnDayTime(string.Empty)).Returns(SwitchStatus.On);

            //Act
            var result = _testController.PublicLightsSwitchDaytimeBased(string.Empty);

            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void PublicLightsSwitchDaytimeBased_WhenCalled_ReturnsNoContentOff()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitchesBasedOnDayTime(string.Empty)).Returns(SwitchStatus.Off);

            //Act
            var result = _testController.PublicLightsSwitchDaytimeBased(string.Empty);

            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}