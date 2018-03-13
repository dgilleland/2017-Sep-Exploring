using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLAccessPoint
{
    // https://www.epl.ca/open-data-branches-api-help/
    public class BranchData
    {
        private const string Url = @"https://www2.epl.ca/OpenData/Branches/Files/";
        private enum QueryStringParam { branch, format }
        private static readonly IDictionary<QueryStringParam, string> DefaultValues
            = new Dictionary<QueryStringParam, string>();
        static BranchData()
        {
            DefaultValues.Add(QueryStringParam.branch, "ALL");
            DefaultValues.Add(QueryStringParam.format, "xml");
        }

        public static string QueryUrl(string branch, string format)
        {
            branch = branch ?? DefaultValues[QueryStringParam.branch];
            format = format ?? DefaultValues[QueryStringParam.format];
            return $"{Url}?{QueryStringParam.branch}={branch}&{QueryStringParam.format}={format}";
        }
    }

    public class Hours
    {
        public string DayOfWeek { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }
    }
    public class HolidayClosure
    {
        public string HolidayName { get; set; }
        public DateTime HolidayDate { get; set; }
    }
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class EPLBranches
    {
        public IEnumerable<BranchInfo> BranchInfo { get; set; }
    }
    public class BranchInfo
    {
        public string BranchId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Hours> BranchHours { get; set; }
        public IEnumerable<HolidayClosure> HolidayClosures { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public Location Coordinates { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }


}
