using MicrowaveOvenController.Tests.TestStubs;
using MicrowaveOvenController.ViewModels;

namespace MicrowaveOvenController.Tests
{
    [TestClass]
    public sealed class MicrowaveOvenControllerTests
    {
        private MicrowaveOvenControllerViewModel _mockMicrowaveOvenControllerViewModel;

        public MicrowaveOvenControllerTests()
        {
            _mockMicrowaveOvenControllerViewModel = new MicrowaveOvenControllerViewModel();
        }
        #region DoorOpenChange
        [TestMethod]
        public void MicrowaveOvenControllerViewModelDoorOpenChangeDoorOpenFalseTurnsOnLight()
        {
            //Arrange
            var mockMicrowaveControlPanelModel = MicrowaveOvenControllerTestStubs.GetMicrowaveOvenControlPanelModelWithLightTurnedOn();

            //Act
            _mockMicrowaveOvenControllerViewModel.DoorOpenChange();

            //Assert
            Assert.AreEqual(mockMicrowaveControlPanelModel.DoorOpen, _mockMicrowaveOvenControllerViewModel.DoorOpen);
            Assert.AreEqual(mockMicrowaveControlPanelModel.IsLightOn, _mockMicrowaveOvenControllerViewModel.IsLightOn);
            Assert.AreEqual(mockMicrowaveControlPanelModel.LightMessage, _mockMicrowaveOvenControllerViewModel.LightMessage);
        }

        [TestMethod]
        public void MicrowaveOvenControllerViewModelDoorOpenChangeDoorOpenTrueTurnsOffLight()
        {
            //Arrange
            _mockMicrowaveOvenControllerViewModel.DoorOpen = true;
            var mockMicrowaveControlPanelModel = MicrowaveOvenControllerTestStubs.GetMicrowaveOvenControlPanelModelWithLightTurnedOff();

            //Act
            _mockMicrowaveOvenControllerViewModel.DoorOpenChange();

            //Assert
            Assert.AreEqual(mockMicrowaveControlPanelModel.DoorOpen, _mockMicrowaveOvenControllerViewModel.DoorOpen);
            Assert.AreEqual(mockMicrowaveControlPanelModel.IsLightOn, _mockMicrowaveOvenControllerViewModel.IsLightOn);
            Assert.AreEqual(mockMicrowaveControlPanelModel.LightMessage, _mockMicrowaveOvenControllerViewModel.LightMessage);
        }
        #endregion

        #region Start
        [TestMethod]
        public void MicrowaveOvenControllerViewModelStartReturnsTimerIncrementedOnce()
        {
            //Arrange
            var mockMicrowaveControlPanelModel = MicrowaveOvenControllerTestStubs.GetMicrowaveOvenControlPanelModelWithOneMinuteTimer();

            //Act
            _mockMicrowaveOvenControllerViewModel.Start();

            //Assert
            Assert.AreEqual(mockMicrowaveControlPanelModel.Timer, _mockMicrowaveOvenControllerViewModel.Timer);
        }

        [TestMethod]
        public void MicrowaveOvenControllerViewModelStartReturnsTimerIncrementedTwice()
        {
            //Arrange
            var mockMicrowaveControlPanelModel = MicrowaveOvenControllerTestStubs.GetMicrowaveOvenControlPanelModelWithTwoMinuteTimer();

            //Act
            _mockMicrowaveOvenControllerViewModel.Start();
            _mockMicrowaveOvenControllerViewModel.Start();

            //Assert
            Assert.AreEqual(mockMicrowaveControlPanelModel.Timer, _mockMicrowaveOvenControllerViewModel.Timer);
        }

        [TestMethod]
        public void MicrowaveOvenControllerViewModelStartOpenAndCloseDoorReturnsTimerIncrementedOnce()
        {
            //Arrange
            var mockMicrowaveControlPanelModel = MicrowaveOvenControllerTestStubs.GetMicrowaveOvenControlPanelModelWithOneMinuteTimer();

            //Act
            _mockMicrowaveOvenControllerViewModel.Start();
            _mockMicrowaveOvenControllerViewModel.DoorOpenChange();
            _mockMicrowaveOvenControllerViewModel.DoorOpenChange();
            _mockMicrowaveOvenControllerViewModel.Start();

            //Assert
            Assert.AreEqual(mockMicrowaveControlPanelModel.Timer, _mockMicrowaveOvenControllerViewModel.Timer);
        }

        #endregion
    }
}
