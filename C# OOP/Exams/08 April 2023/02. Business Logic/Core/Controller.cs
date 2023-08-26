using RobotService.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Repositories;
using RobotService.Models;
using RobotService.Models.Contracts;
using System.Reflection;

namespace RobotService.Core
{
    public class Controller:IController
    {
        private SupplementRepository supplements = new SupplementRepository();
        private RobotRepository robots = new RobotRepository();
        public string CreateRobot(string model,string typeName)
        {
            IRobot robot = null;
            switch(typeName)
            {
                case nameof(DomesticAssistant):
                    robot = new DomesticAssistant(model);
                    break;
                case nameof(IndustrialAssistant):
                    robot = new IndustrialAssistant(model);
                    break;
                default:
                    return $"Robot type {typeName} cannot be created.";
            }
            robots.AddNew(robot);
            return $"{typeName} {model} is created and added to the RobotRepository.";
        }
        public string CreateSupplement(string typeName)
        {
            ISupplement supplement = null;
            switch(typeName)
            {
                case nameof(SpecializedArm):
                    supplement = new SpecializedArm();
                    break;
                case nameof(LaserRadar):
                    supplement = new LaserRadar();
                    break;
                default:
                    return $"{typeName} is not compatible with our robots.";
            }
            supplements.AddNew(supplement);
            return $"{typeName} is created and added to the SupplementRepository.";
        }
        public string PerformService(string serviceName,int intefaceStandard,int totalPowerNeeded)
        {
            int rememberTotalPowerNeeded = totalPowerNeeded;
            List<IRobot> selectedRobots = robots.Models()
                .Where(x => x.InterfaceStandards.Contains(intefaceStandard)).ToList();
            if(selectedRobots.Count == 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }
            selectedRobots = selectedRobots.OrderByDescending(x => x.BatteryLevel).ToList();
            int sumBatteryLevels = selectedRobots.Sum(x => x.BatteryLevel);
            if(sumBatteryLevels < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - sumBatteryLevels} more power needed.";
            }
            int usedRobotsCount = 0;
            foreach(IRobot robot in selectedRobots)
            {
                if(totalPowerNeeded == 0)
                {
                    break;
                }
                if(robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    usedRobotsCount++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    usedRobotsCount++;
                }
            }
            return $"{serviceName} is performed successfully with {usedRobotsCount} robots.";
        }
        public string Report()
        {
            List<IRobot> selectedRobots = robots.Models()
                .OrderByDescending(x => x.BatteryLevel)
                .ThenBy(x => x.BatteryCapacity).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(IRobot robot in selectedRobots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string RobotRecovery(string model,int minutes)
        {
            List<IRobot> selectedRobots = robots.Models()
                .Where(x => x.Model == model)
                .Where(x => x.BatteryLevel < x.BatteryCapacity * 0.5).ToList();
            foreach(IRobot robot in selectedRobots)
            {
                robot.Eating(minutes);
            }
            return $"Robots fed: {selectedRobots.Count}";
        }
        public string UpgradeRobot(string model,string supplementTypeName)
        {
            ISupplement supplement = supplements.Models()
                .FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int interfaceValue = supplement.InterfaceStandard;
            List<IRobot> selectedRobots = robots.Models()
                .Where(x => !x.InterfaceStandards.Contains(interfaceValue)).ToList();
            selectedRobots = selectedRobots.Where(x => x.Model == model).ToList();
            if(selectedRobots.Count == 0)
            {
                return $"All {model} are already upgraded!";
            }
            selectedRobots.First().InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return $"{model} is upgraded with {supplementTypeName}.";
        }
    }
}
