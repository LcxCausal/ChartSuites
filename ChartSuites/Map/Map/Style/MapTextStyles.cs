using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;

namespace Map
{
    public static class MapTextStyles
    {
        public static TextStyle Country1(string countryName)
        {
            return TextStyles.CreateSimpleTextStyle(countryName, "Arial", 10, DrawingFontStyles.Bold, GeoColor.StandardColors.Black);
        }

        public static TextStyle Country2(string countryName)
        {
            return TextStyles.CreateSimpleTextStyle(countryName, "Arial", 7, DrawingFontStyles.Italic, GeoColor.StandardColors.Black);
        }
        
        public static TextStyle city1(string cityName)
        {
            return TextStyles.CreateSimpleTextStyle(cityName, "Arial", 8, DrawingFontStyles.Regular, GeoColor.StandardColors.Black);
        }

        public static TextStyle city2(string cityName)
        {
            return TextStyles.CreateSimpleTextStyle(cityName, "Arial", 7, DrawingFontStyles.Regular, GeoColor.StandardColors.Black);
        }

        public static TextStyle street1(string streetName)
        {
            return TextStyles.MajorStreet1(streetName);
        }
    }
}
