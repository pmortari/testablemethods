namespace TestableMethods.Test.Services
{
    [TestClass]
    public class TestServiceTest
    {
        private readonly TestService _testService;
        private readonly Mock<ITestService> _mockTestService;

        public TestServiceTest()
        {
            _testService = new TestService();
            _mockTestService = new Mock<ITestService>();
        }

        [TestMethod]
        public void ChangePublicLightsSwitches_WhenCalled_ReturnsSwitchOn()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitches()).Returns(SwitchStatus.On);

            //Act
            var result = _mockTestService.Object.ChangePublicLightsSwitches();

            //Assert
            Assert.IsTrue(result == SwitchStatus.On);
        }

        [TestMethod]
        public void ChangePublicLightsSwitches_WhenCalled_ReturnsSwitchOff()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitches()).Returns(SwitchStatus.Off);

            //Act
            var result = _mockTestService.Object.ChangePublicLightsSwitches();

            //Assert
            Assert.IsTrue(result == SwitchStatus.Off);
        }

        [TestMethod]
        [DataRow("2022-07-21T19:30:20")]
        [DataRow("2022-07-22T00:25:45")]
        [DataRow("2022-07-22")]
        public void ChangePublicLightsSwitchesBasedOnDayTime_WhenCalled_ReturnsSwitchOn(string dateTime)
        {
            //Arrange
            //Nothing to do here

            //Act
            var result = _testService.ChangePublicLightsSwitchesBasedOnDayTime(dateTime);

            Assert.IsTrue(result == SwitchStatus.On);
        }

        [TestMethod]
        [DataRow("2022-07-21T14:27:15")]
        [DataRow("2022-07-22T08:15:55")]
        public void ChangePublicLightsSwitchesBasedOnDayTime_WhenCalled_ReturnsSwitchOff(string dateTime)
        {
            //Arrange
            //Nothing to do here

            //Act
            var result = _testService.ChangePublicLightsSwitchesBasedOnDayTime(dateTime);

            Assert.IsTrue(result == SwitchStatus.Off);
        }

        [TestMethod]
        public void ChangePublicLightsSwitchesBasedOnDayTime_WhenCalled_ReturnsSwitchOnUsingMoq()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitchesBasedOnDayTime("2022-07-21T19:45:10")).Returns(SwitchStatus.On);

            //Act
            var result = _mockTestService.Object.ChangePublicLightsSwitchesBasedOnDayTime("2022-07-21T19:45:10");

            //Assert
            Assert.IsTrue(result == SwitchStatus.On);
        }

        [TestMethod]
        public void ChangePublicLightsSwitchesBasedOnDayTime_WhenCalled_ReturnsSwitchOffUsingMoq()
        {
            //Arrange
            _mockTestService.Setup(p => p.ChangePublicLightsSwitchesBasedOnDayTime("2022-07-21T11:20:35")).Returns(SwitchStatus.Off);

            //Act
            var result = _mockTestService.Object.ChangePublicLightsSwitchesBasedOnDayTime("2022-07-21T11:20:35");

            //Assert
            Assert.IsTrue(result == SwitchStatus.Off);
        }

        [TestMethod]
        [DataRow(2022, 07, 21, 13, 55, 25)]
        [DataRow(2021, 01, 01, 15, 30, 00)]
        [DataRow(2023, 12, 31, 17, 59, 59)]
        public void CheckTimeOfDay_WhenCalled_ReturnsAfternoon(int year, int month, int day, int hour, int minutes, int seconds)
        {
            //Arrange
            var referenceDate = new DateTime(year, month, day, hour, minutes, seconds);

            //Act
            var result = _testService.CheckTimeOfDay(referenceDate);

            //Assert
            Assert.IsTrue(result == TimeOfDay.Afternoon);
        }

        [TestMethod]
        [DataRow(2022, 07, 21, 00, 00, 00)]
        [DataRow(2021, 03, 27, 04, 30, 23)]
        [DataRow(2023, 12, 31, 05, 59, 59)]
        public void CheckTimeOfDay_WhenCalled_ReturnsNight(int year, int month, int day, int hour, int minutes, int seconds)
        {
            //Arrange
            var referenceDate = new DateTime(year, month, day, hour, minutes, seconds);

            //Act
            var result = _testService.CheckTimeOfDay(referenceDate);

            //Assert
            Assert.IsTrue(result == TimeOfDay.Night);
        }

        [TestMethod]
        [DataRow(2022, 07, 21, 19, 00, 00)]
        [DataRow(2021, 01, 01, 21, 35, 13)]
        [DataRow(2023, 12, 31, 23, 59, 59)]
        public void CheckTimeOfDay_WhenCalled_ReturnsEvening(int year, int month, int day, int hour, int minutes, int seconds)
        {
            //Arrange
            var referenceDate = new DateTime(year, month, day, hour, minutes, seconds);

            //Act
            var result = _testService.CheckTimeOfDay(referenceDate);

            //Assert
            Assert.IsTrue(result == TimeOfDay.Evening);
        }

        [TestMethod]
        [DataRow(2022, 07, 21, 06, 55, 10)]
        [DataRow(2021, 01, 01, 09, 15, 20)]
        [DataRow(2023, 12, 31, 11, 25, 15)]
        public void CheckTimeOfDay_WhenCalled_ReturnsMorning(int year, int month, int day, int hour, int minutes, int seconds)
        {
            //Arrange
            var referenceDate = new DateTime(year, month, day, hour, minutes, seconds);

            //Act
            var result = _testService.CheckTimeOfDay(referenceDate);

            //Assert
            Assert.IsTrue(result == TimeOfDay.Morning);
        }

        [TestMethod]
        [DataRow(TimeOfDay.Evening)]
        [DataRow(TimeOfDay.Night)]
        public void TurnSwitch_WhenCalled_ReturnsOn(TimeOfDay timeOfDay)
        {
            //Arrange
            //Nothing to do here

            //Act
            var result = _testService.TurnSwitch(timeOfDay);

            //Assert
            Assert.IsTrue(result == SwitchStatus.On);
        }

        [TestMethod]
        [DataRow(TimeOfDay.Morning)]
        [DataRow(TimeOfDay.Afternoon)]
        public void TurnSwitch_WhenCalled_ReturnsOff(TimeOfDay timeOfDay)
        {
            //Arrange
            //Nothing to do here

            //Act
            var result = _testService.TurnSwitch(timeOfDay);

            //Assert
            Assert.IsTrue(result == SwitchStatus.Off);
        }

        [TestMethod]
        [DataRow("Invalid Date")]
        [DataRow("2022-09-15T01:01:000")]
        public void StringIsValidDateTime_WhenCalled_ReturnsFalse(string dateTime)
        {
            //Arrange
            //Nothing to do here

            //Act
            var result = _testService.StringIsValidDateTime(dateTime);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("2022-07")]
        [DataRow("2022-07-21T09:15:00")]
        [DataRow("2022/07/21T13:00:25")]
        public void StringIsValidDateTime_WhenCalled_ReturnsTrue(string dateTime)
        {
            //Arrange
            //Nothing to do here

            //Act
            var result = _testService.StringIsValidDateTime(dateTime);

            Assert.IsTrue(result);
        }
    }
}