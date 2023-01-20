using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.WinUI.Helpers
{
    public class ListOfCountries
    {
        public static List<string> CountryNames()
        {
            List<string> cultureList = new List<string>();
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var country in cultureInfos)
            {
                RegionInfo region = new RegionInfo(country.LCID);
                if (!(cultureList.Contains(region.EnglishName)))
                    cultureList.Add(region.EnglishName);
            }
            cultureList.Sort();
            return cultureList;
        }
    }
}
