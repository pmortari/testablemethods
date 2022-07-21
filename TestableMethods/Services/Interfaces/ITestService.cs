using TestableMethods.Resources.Enums;

namespace TestableMethods.Services.Interfaces
{
    public interface ITestService
    {
        SwitchStatus ChangePublicLightsSwitchesBasedOnDayTime(string dateTime);

        SwitchStatus ChangePublicLightsSwitches();
    }
}