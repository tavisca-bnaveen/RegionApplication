using System;
using System.Collections.Generic;
using Xunit;

namespace RegionApplication.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Test_For_UnParsedData_To_Region()
        { 
            var parser = new Parser();
            var region=parser.RawRegionToLocation("704 | Barter Island | Barter Island, Alaska, United States of America| 70.129562 | -143.662949 | tree");
            Assert.Equal(704, region.RegionID);
        }
        [Fact]
        public void Test_For_UnParsedquotesData_To_Region()
        {
            var parser = new Parser();
            var region = parser.RawRegionToLocation("704 | Barter Island | Barter 'Island', Alaska, United States of America| 70.129562 | -143.662949 | tree");
            Assert.Equal("Barter 'Island', Alaska, United States of America", region.RegionNameLong);
        }
        [Fact]
        public void Test_For_EmptySub_To_Regional()
        {
            var parser = new Parser();
            var region = parser.RawRegionToLocation("704 | Barter Island | Barter 'Island', Alaska, United States of America| 70.129562 | -143.662949 | ");
            Assert.Equal("regional", region.SubClassification);
        }
        [Fact]
        public void Test_For_ListOfUnParsedstrings_To_ListOfRegionsCount()
        {
            
            List<string> unparsedlist = new List<string>();
            unparsedlist.Add("RegionID|RegionName|RegionNameLong|Latitude|Longitude|SubClassification");
            unparsedlist.Add("11741|Basse-Terre|Basse-Terre, Guadeloupe|16.161703|-61.682205|regional");
            unparsedlist.Add("9963|Sophia Antipolis|Sophia Antipolis, Valbonne, France|43.615974|7.031222|business");
            var parser = new Parser();
            var regions = parser.RawRegionsToLocations(unparsedlist);
            Assert.Equal(2,regions.Count);

        }
        [Fact]
        public void Test_For_ListOfUnParsedstrings_To_ListOfRegionId()
        {

            List<string> unparsedlist = new List<string>();
            unparsedlist.Add("RegionID|RegionName|RegionNameLong|Latitude|Longitude|SubClassification");
            unparsedlist.Add("11741|Basse-Terre|Basse-Terre, Guadeloupe|16.161703|-61.682205|regional");
            unparsedlist.Add("9963|Sophia Antipolis|Sophia Antipolis, Valbonne, France|43.615974|7.031222|business");
            var parser = new Parser();
            var regions = parser.RawRegionsToLocations(unparsedlist);
            Assert.Equal(9963, regions[2].RegionID);

        }



    }
}
