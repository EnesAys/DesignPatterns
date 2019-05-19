using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)//Client
        {
            Team teamBesiktas=new Team{
            TeamName="Beşiktaş",
            StadiumName="Vodafone Park"
            };

            Team copyTeamJuventus=(Team)teamBesiktas.Clone();
            copyTeamJuventus.TeamName= "Juventus";
            copyTeamJuventus.StadiumName="Allianz Stadium";

            Console.WriteLine(teamBesiktas.GetTeamInfo());
            Console.WriteLine(copyTeamJuventus.GetTeamInfo());
        }
    }

    public interface ITeam //Prototype interface
    {
        ITeam Clone();
        string GetTeamInfo();
    }
    public class Team:ITeam //ConcretePrototype class
    {
        public Team()
        {
         TeamId=Guid.NewGuid();
        }
        public Guid TeamId { get;}
        public string TeamName { get; set; }
        public string StadiumName { get; set; }

        public ITeam Clone()
        {
            return (ITeam)MemberwiseClone();
        }

        public string GetTeamInfo()
        {
           return string.Format("Team Id : {0} , Team Name : {1} , Stadium Name : {2}",TeamId,TeamName,StadiumName);
        }
    }
}
