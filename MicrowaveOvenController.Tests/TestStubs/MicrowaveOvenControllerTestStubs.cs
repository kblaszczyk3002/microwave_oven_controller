using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenController.Models;

namespace MicrowaveOvenController.Tests.TestStubs
{
    public class MicrowaveOvenControllerTestStubs
    {
        public static MicrowaveOvenControlPanel GetMicrowaveOvenControlPanelModelWithLightTurnedOn()
        {
            return new MicrowaveOvenControlPanel
            {
                DoorOpen = true,
                IsLightOn = true,
                LightMessage = "Light is turned on"
            };
        }

        public static MicrowaveOvenControlPanel GetMicrowaveOvenControlPanelModelWithLightTurnedOff()
        {
            return new MicrowaveOvenControlPanel
            {
                DoorOpen = false,
                IsLightOn = false,
                LightMessage = "Light is turned off"
            };
        }

        public static MicrowaveOvenControlPanel GetMicrowaveOvenControlPanelModelWithTwoMinuteTimer()
        {
            return new MicrowaveOvenControlPanel
            {
                Timer = "02:00"
            };
        }

        public static MicrowaveOvenControlPanel GetMicrowaveOvenControlPanelModelWithOneMinuteTimer()
        {
            return new MicrowaveOvenControlPanel
            {
                Timer = "01:00"
            };
        }
    }
}
