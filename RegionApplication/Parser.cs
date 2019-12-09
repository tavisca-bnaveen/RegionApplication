using System;
using System.Collections.Generic;
using System.Numerics;

namespace RegionApplication
{
    public class Parser
    {
        public List<Region> RawRegionsToLocations(List<string> unParsedStrings)
        {
            var AllRegions = new List<Region>();
            for(int i=1;i< unParsedStrings.Count;i++)
            {
                AllRegions.Add(RawRegionToLocation(unParsedStrings[i]));
            }
            return AllRegions;
        }
        public Region RawRegionToLocation(string unparse)
        {
            var splitStrings = unparse.Split('|');
            var region = new Region();
            try
            {
                region.RegionID = BigInteger.Parse(splitStrings[0].TrimStart().TrimEnd());
                region.RegionName = splitStrings[1].TrimStart().TrimEnd();
                region.RegionNameLong = splitStrings[2].TrimStart().TrimEnd();
                region.Latitude = double.Parse(splitStrings[3].TrimStart().TrimEnd());
                region.Longitude = double.Parse(splitStrings[4].TrimStart().TrimEnd());
                region.SubClassification = splitStrings[5].TrimStart().TrimEnd();
                if(region.SubClassification!=null)
                {
                    region.SubClassification = "regional";
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return region;
        }
    }
}
