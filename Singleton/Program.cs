using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManager manager1=DbManager.CreateDbManager();
            DbManager manager2=DbManager.CreateDbManager();

            Console.WriteLine("manager1 1 Id = {0} and manager2 2 Id = {1}",manager1.Id,manager2.Id);
            
            if(manager1.Id==manager2.Id)
                Console.WriteLine("YEP ! Singleton Pattern Succesfully used");
            else
                Console.WriteLine("There is a problem. Contact with me .");
        }   
    }

    public class DbManager
    {
        private static DbManager dbManager;

        private static Object lockObject = new Object();
     
        private DbManager()
        {
            Id=Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        public static DbManager CreateDbManager() 
        {
            if (dbManager == null) // This block guarantee just one object
            {
                lock (lockObject)
                {
                    if (dbManager == null)
                    {
                        dbManager = new DbManager();
                    }
                }
            }

            return dbManager;
        }
    }
}
