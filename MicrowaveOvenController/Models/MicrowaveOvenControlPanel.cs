using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveOvenController.Models
{
    public class MicrowaveOvenControlPanel
    {
        public string Timer { get; set; }
        public string LightMessage { get; set; }
        public bool DoorOpen { get; set; }
        public bool IsLightOn { get; set; }
    }
}
