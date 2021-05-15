using ProviderQuality.Console.AwardObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class Program
    {
        public List<Award> Awards
        {
            get;
            set;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Updating award metrics...!");

            var app = new Program()
            {
                Awards = new List<Award> 
                { 
                    new Award("Gov Quality Plus", 10, 20),
                    new BlueFirstAward(2, 0),
                    new Award("ACME Partner Facility", 5, 7),
                    new BlueDistinctionPlusAward(0),
                    new BlueCompareAward(15, 20),
                    new Award("Top Connected Providres", 3, 6),
                    new BlueStarAward(2, 10)
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality() => Parallel.ForEach(Awards,(_) => _.ProcessUpdate());     
    }

}
