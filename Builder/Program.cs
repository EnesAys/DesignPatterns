using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamFederation teamFederation = new TeamFederation();
 
            BesiktasBuilder besiktasBuilder = new BesiktasBuilder();
            LiverpoolBuilder liverpoolBuilder = new LiverpoolBuilder();

            teamFederation.TeamConstruct(besiktasBuilder);
            Team besiktas = besiktasBuilder.GetTeam();
            besiktas.Show();
 
            teamFederation.TeamConstruct(liverpoolBuilder);
            Team liverpool = liverpoolBuilder.GetTeam();
            liverpool.Show();
 
            Console.ReadKey();
        }
    }

    #region Team (Product)
    
    class Team
    {
        public string Name { get; set; } 
        public string Stadium { get; set; }  
        public void Show()
        {
            Console.WriteLine("Team is {0} and stadium is {1}",Name,Stadium);      
        }      
    }

    #endregion

    #region ITeamBuilder (Builder)
    
    interface ITeamBuilder
    {
        void BuildTeamName();
        void BuildTeamStadium();
        Team GetTeam();
    }

    #region BesiktasBuilder (ConcreteBuilder)

    class BesiktasBuilder : ITeamBuilder
    {
        private Team team1=new Team();
        public void BuildTeamName()
        {
            team1.Name="Beşiktaş";
        }
        public void BuildTeamStadium()
        {
            team1.Stadium="Vodafone Park";
        }
        public Team GetTeam(){
            return team1;
        }
    }

    #endregion
    
    #region LiverpoolBuilder (ConcreteBuilder)
    
    class LiverpoolBuilder : ITeamBuilder
    {
        private Team team2=new Team();
        public void BuildTeamName()
        {
            team2.Name="Liverpool FC";
        }
        public void BuildTeamStadium()
        {
            team2.Stadium="Anfield";
        }
        public Team GetTeam(){
            return team2;
        }
    }

    #endregion
    

    #endregion
  
    #region TeamFederation (Director)
    
    class TeamFederation
    {
        public void TeamConstruct(ITeamBuilder teamBuilder)
        {
            teamBuilder.BuildTeamName();
            teamBuilder.BuildTeamStadium();
        }
    }

    #endregion
}
