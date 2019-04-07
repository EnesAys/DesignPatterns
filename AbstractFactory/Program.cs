using System;

namespace AbstractFactory
{
    
    public interface Team
    {
        string  getTeamColor();
        string getStadium();
    }

    #region  Teams

    public class Besiktas : Team
    {
        public string getStadium()
        {
           return "Vodafone Park";
        }

        public string getTeamColor()
        {
            return "Black-White";
        }
    }

    public class RealMadrid : Team
    {
        public string getStadium()
        {
           return "Santiago Bernabéu";
        }

        public string getTeamColor()
        {
            return "White";
        }
    }

    #endregion
   

    #region  Factories
    public interface TeamAbstractFactory 
    {
        Team createTeam();
    }

    public class BesiktasFactory : TeamAbstractFactory
    {
        public Team createTeam()
        {
            return new Besiktas();
        }
    }
    public class RealMadridFactory : TeamAbstractFactory
    {
        public Team createTeam()
        {
            return new RealMadrid();
        }
    }

    //Produces team by factory type
    public class TeamFactory
    {        
        public static Team getTeam(TeamAbstractFactory factory)
        {
            return factory.createTeam();
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Team besiktas=TeamFactory.getTeam(new BesiktasFactory());
            Team realMadrid=TeamFactory.getTeam(new RealMadridFactory());

            Console.WriteLine("Beşiktaş stadium is {0} and color {1}",besiktas.getStadium(),besiktas.getTeamColor());
            Console.WriteLine("Real Madrid stadium is {0} and color {1}",realMadrid.getStadium(),realMadrid.getTeamColor());
        }
    }
    
    
}
