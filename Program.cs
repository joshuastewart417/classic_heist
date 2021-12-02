using System;
using System.Collections.Generic;
using System.Linq;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            


            List<IRobber> rolodex = new List<IRobber>()
            {
                {new Hacker() {Name = "L33T", SkillLevel = 78, PercentageCut = 15}},
                {new Hacker() {Name = "360NOSCOPE", SkillLevel = 55, PercentageCut = 20}},
                {new Muscle() {Name = "Blazer", SkillLevel = 30, PercentageCut = 15}},
                {new Muscle() {Name = "Tazer", SkillLevel = 80, PercentageCut = 25}},
                {new LockSpecialist() {Name = "Click", SkillLevel = 65, PercentageCut = 15}},
                {new LockSpecialist() {Name = "Clack", SkillLevel = 55, PercentageCut = 10}}
            };

            Console.WriteLine("Current Operatives:\n");
            foreach(IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}");
            }

            string crewMember = "random";

            while (crewMember != "")
            {

                Console.WriteLine("Enter a new crew member:");
                crewMember = Console.ReadLine();

                if(crewMember == "") {
                    continue;
                }

                Console.Write($"What specialty should {crewMember} have?");
                Console.Write("(- Hacker - Muscle -Lock Specialist)");
                string specialty = Console.ReadLine();

                Console.Write($"What skill level (1-100) should this {specialty} have?");
                int skillLevel = int.Parse(Console.ReadLine());

                Console.Write($"What does {crewMember} want as a percentage cut?");
                int percentageCut = int.Parse(Console.ReadLine());

                if (specialty == "Hacker")
                {
                    rolodex.Add(new Hacker()
                    {
                        Name = crewMember,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });

                    break;
                }
                else if (specialty == "Muscle")
                {
                    rolodex.Add(new Muscle()
                    {
                        Name = crewMember,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });

                    break;
                }
                else if (specialty == "Lock Specialist")
                {
                    rolodex.Add(new LockSpecialist()
                    {
                        Name = crewMember,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });

                    break;
                }
            }   

            Random randInt = new Random();

            Bank bank1 = new Bank()
            {
                AlarmScore = randInt.Next(0, 100),
                VaultScore = randInt.Next(0, 100),
                SecurityGuardScore = randInt.Next(0, 100),
                CashOnHand = randInt.Next(50000, 1000000)
            };

            Dictionary<string, int> systemList = new Dictionary<string, int>(){
                {"Alarm", bank1.AlarmScore},
                {"Vault", bank1.VaultScore},
                {"Security Guard", bank1.SecurityGuardScore}
            };

            var sortedDict = from entry in systemList orderby entry. Value ascending select entry;




            Console.WriteLine($"Least Secure: {sortedDict.ElementAt(0).Key}");
            Console.WriteLine($"Most Secure: {sortedDict.ElementAt(2).Key}");

            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine($"{i}. {rolodex[i].Name}:  {rolodex[i].SkillLevel} {rolodex[i].PercentageCut}%");
                Console.WriteLine($"    Speciality: {rolodex[i].GetType().ToString().Split('.')[1]}");
                Console.WriteLine($"    Skill Level: {rolodex[i].SkillLevel}");
                Console.WriteLine($"    Skill Level: {rolodex[i].PercentageCut}%");
            }

            List<IRobber> crew = new List<IRobber>();
            Console.WriteLine("Enter the number of the operative you want to include in the heist");
            int num = int.Parse(Console.ReadLine());
            crew.Add(rolodex[num]); 
        }
    }
}
