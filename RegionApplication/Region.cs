using System.Numerics;

namespace RegionApplication
{
    public class Region
    {
        public BigInteger? RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionNameLong { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string SubClassification { get; set; }
    }
}
