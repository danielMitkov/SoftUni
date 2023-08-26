using RobotService.Models.Contracts;
namespace RobotService.Models
{
    public abstract class Supplement:ISupplement
    {
        private int interfaceStandard;
        public int InterfaceStandard
        {
            get { return interfaceStandard; }
            private set { interfaceStandard = value; }
        }
        private int batteryUsage;
        public int BatteryUsage
        {
            get { return batteryUsage; }
            private set { batteryUsage = value; }
        }
        public Supplement(int interfaceStandard,int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }
    }
}
