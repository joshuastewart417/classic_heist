using System;
using System.Collections.Generic;

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
                Console.WriteLine("${robber.Name}");
            }
            Console.WriteLine("Enter a new crew member:");
            string crewMember = Console.ReadLine();
            Console.Write($"What specialty (Hacker, Muscle, Lock Specialist) should {crewMember} have?");
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
            }
            else if (specialty == "Muscle")
            {
                rolodex.Add(new Muscle()
                {
                    Name = crewMember,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                });
            }
            else if (specialty == "Lock Specialist")
            {
                rolodex.Add(new LockSpecialist()
                {
                    Name = crewMember,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut
                });
            }
        }
    }
}
