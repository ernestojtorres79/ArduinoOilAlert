using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoYum.Model
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        public int STypeId { get; set; }
        public virtual SType STypes { get; set; }
        public int BoardIOId { get; set; }
        public virtual BoardIO BoardIOs { get; set; }
    }
}
