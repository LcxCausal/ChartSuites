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
    public static class MapPointStyles
    {
        public static PointStyle city1()
        {
            return PointStyles.CreateSimpleCircleStyle(GeoColor.SimpleColors.White, 5, GeoColor.StandardColors.Red, 1);
        }
    }
}
