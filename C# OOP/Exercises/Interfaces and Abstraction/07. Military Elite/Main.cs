using MilitaryElite;
using MilitaryElite.Soldiers;
using MilitaryElite.Soldiers.Privates;
using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers;
List<Soldier> soldiers = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{//no interface needed since Soldier can be used to group them
    string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string id = data[1];
    string fullName = data[2] + " " + data[3];
    decimal salary = data[0] != "Spy" ? decimal.Parse(data[4]) : 0;
    switch(data[0])
    {//type
        case "Private":
            soldiers.Add(new Private(id,fullName,salary));
            break;
        case "LieutenantGeneral":
            string[] ids = data[5..];
            List<Private> privates = new();
            foreach(string idNumber in ids)
            {
                privates.Add((Private)soldiers?.Find(x => x.Id == idNumber));
            }
            soldiers.Add(new LieutenantGeneral(id,fullName,salary,privates));
            break;
        case "Engineer":
            string corps = data[5];
            string[] repairPairs = data[6..];
            try
            {
                soldiers.Add(new Engineer(id,fullName,salary,corps,repairPairs));
            }
            catch(ArgumentException)
            {//continue while loop
            }
            break;
        case "Commando":
            corps = data[5];
            string[] missionPairs = data[6..];
            try
            {
                soldiers.Add(new Commando(id,fullName,salary,corps,missionPairs));
            }
            catch(ArgumentException)
            {
            }
            break;
        case "Spy":
            int codeNumber = int.Parse(data[4]);
            soldiers.Add(new Spy(id,fullName,codeNumber));
            break;
    }
}
foreach(Soldier soldier in soldiers)
{
    Console.WriteLine(soldier.ToString());
}