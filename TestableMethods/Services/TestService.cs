using System.Runtime.CompilerServices;
using TestableMethods.Resources.Enums;
using TestableMethods.Services.Interfaces;

[assembly: InternalsVisibleTo("TestableMethods.Test")]

namespace TestableMethods.Services
{
    public class TestService : ITestService
    {
        public SwitchStatus ChangePublicLightsSwitches()
        {
            var dateTime = DateTime.Now;

            var timeOfDay = CheckTimeOfDay(dateTime);

            var value = TurnSwitch(timeOfDay);

            return value;
        }

        public SwitchStatus ChangePublicLightsSwitchesBasedOnDayTime(string dateTime)
        {
            var isValidDateTime = StringIsValidDateTime(dateTime);

            if (isValidDateTime == false)
            {
                throw new Exception();
            }

            var convertedDate = Convert.ToDateTime(dateTime);

            var timeOfDay = CheckTimeOfDay(convertedDate);

            var value = TurnSwitch(timeOfDay);

            return value;
        }

        internal bool StringIsValidDateTime(string dateTime)
        {
            var value = DateTime.TryParse(dateTime, out _);

            return value;
        }

        internal TimeOfDay CheckTimeOfDay(DateTime dateTime)
        {
            if (dateTime.Hour >= 6 && dateTime.Hour < 12) return TimeOfDay.Morning;

            if (dateTime.Hour >= 12 && dateTime.Hour < 18) return TimeOfDay.Afternoon;

            if (dateTime.Hour >= 18 && dateTime.Hour < 24) return TimeOfDay.Evening;

            return TimeOfDay.Night;
        }

        internal SwitchStatus TurnSwitch(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Morning:
                case TimeOfDay.Afternoon:
                    // Turn off switches
                    return SwitchStatus.Off;

                case TimeOfDay.Evening:
                case TimeOfDay.Night:
                default:
                    // Turn on switches
                    return SwitchStatus.On;
            }
        }
    }
}