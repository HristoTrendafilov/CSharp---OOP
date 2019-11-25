using DefineAnInterfaceIPerson.Contracts;
using DefineAnInterfaceIPerson.Enums;
using DefineAnInterfaceIPerson.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefineAnInterfaceIPerson.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private Dictionary<int,ISoldier> soldiers;
        public CommandInterpreter()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        public string Read(string[] args)
        {
            var soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            ISoldier soldier=null;
            if (soldierType == "Private")
            {
                var salary = decimal.Parse(args[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if(soldierType== "LieutenantGeneral")
            {
                var privates = new Dictionary<int, IPrivate>();
                for (int i = 5; i < args.Length; i++)
                {
                    var soldierId = int.Parse(args[i]);
                    var currSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currSoldier);
                }
                var salary = decimal.Parse(args[4]);
                soldier = new LieutenantGeneral(id, firstName, lastName,salary, privates);
            }
            else if (soldierType == "Engineer")
            {
                var salary = decimal.Parse(args[4]);
                bool isValidCorp = Enum.TryParse<Corps>(args[5], out Corps result);
                if (!isValidCorp)
                {
                    throw new Exception();
                }
                ICollection<IRepair> repairs = new List<IRepair>();
                for (int i = 6; i < args.Length; i+=2)
                {
                    var currentName = args[i];
                    int hours = int.Parse(args[i + 1]);

                    IRepair repair = new Repair(currentName, hours);
                    repairs.Add(repair);
                }
                soldier = new Engineer(id, firstName, lastName, salary, result, repairs);
            }
            else if (soldierType == "Commando")
            {
                var salary = decimal.Parse(args[4]);
                bool isValidCorp = Enum.TryParse<Corps>(args[5], out Corps result);
                
                if (!isValidCorp)
                {
                    throw new Exception();
                }
                
                ICollection<IMission> missions = new List<IMission>();
                
                for (int i = 6; i < args.Length; i += 2)
                {
                    var missionName = args[i];
                    string missionState = args[i + 1];

                    bool isValidMission = Enum.TryParse<State>(missionState, out State stateResult);
                   
                    if (!isValidMission)
                    {
                        continue;
                    }
                   
                    IMission mission = new Mission(missionName, stateResult);
                    missions.Add(mission);
                }
                soldier = new Commando(id, firstName, lastName, salary,result,missions);
            }
            else if (soldierType == "Spy")
            {
                var codeNumber = int.Parse(args[4]);
                soldier = new Spy(id, firstName, lastName, codeNumber);
            }
            soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
