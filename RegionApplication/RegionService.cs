using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegionApplication
{
    public class RegionService
    {
        IDatabase _database;
        public RegionService(string Dbname)
        {
            _database = DatabaseFactory.SelectDatabase(Dbname);
        }
        public void ReigionsToDatabase(List<Region> Regions)
        {
            
            foreach (var region in Regions)
            {
                 _database.RegionintoDatabase(region);
            }
            
            
        }
    }
}
