using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;

namespace Map
{
    public partial class Map : Form
    {
        WinformsMap winformsMap;

        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            winformsMap = new WinformsMap();
            winformsMap.Location = new Point(10, 100);
            winformsMap.Size = new Size(800, 622);
            winformsMap.Name = "winformsMap";
            winformsMap.Text = "winformsMap";
            winformsMap.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            winformsMap.DrawingQuality = DrawingQuality.HighQuality;
            winformsMap.Dock = DockStyle.Fill;
            winformsMap.MapUnit = GeographyUnit.DecimalDegree;
            Controls.Add(winformsMap);
            winformsMap.BackgroundOverlay.BackgroundBrush = new GeoSolidBrush(GeoColor.GeographicColors.ShallowOcean);
            LayerOverlay layerOverlay = LoadMap();
            winformsMap.Overlays.Add(layerOverlay);

            FileBitmapTileCache bitmapTileCache = new FileBitmapTileCache();
            bitmapTileCache.CacheDirectory = @"../../AppData/SampleCacheTiles";
            bitmapTileCache.CacheId = "World02CacheTiles";
            bitmapTileCache.TileAccessMode = TileAccessMode.Default;
            bitmapTileCache.ImageFormat = TileImageFormat.Png;

            layerOverlay.TileCache = bitmapTileCache;

            layerOverlay.Layers[4].Open();
            winformsMap.CurrentExtent = layerOverlay.Layers[4].GetBoundingBox();

            winformsMap.Refresh();
        }

        private static LayerOverlay LoadMap()
        {
            LayerOverlay layerOverlay = new LayerOverlay();

            ShapeFileFeatureLayer countryLayer = new ShapeFileFeatureLayer("../../AppData/Countries02.shp");
            countryLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = MapAreaStyles.Country1();
            countryLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            ShapeFileFeatureLayer countryLabelLayer = new ShapeFileFeatureLayer("../../AppData/Countries02.shp");
            countryLabelLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = MapTextStyles.Country2("SOVEREIGN");
            countryLabelLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle.BestPlacement = true;
            countryLabelLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level03;
            countryLabelLayer.ZoomLevelSet.ZoomLevel04.DefaultTextStyle = MapTextStyles.Country1("CNTRY_NAME");
            countryLabelLayer.ZoomLevelSet.ZoomLevel04.DefaultTextStyle.BestPlacement = true;
            countryLabelLayer.ZoomLevelSet.ZoomLevel04.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level12;
            countryLabelLayer.ZoomLevelSet.ZoomLevel13.DefaultTextStyle = MapTextStyles.Country1("LONG_NAME");
            countryLabelLayer.ZoomLevelSet.ZoomLevel13.DefaultTextStyle.BestPlacement = true;
            countryLabelLayer.ZoomLevelSet.ZoomLevel13.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level16;

            ShapeFileFeatureLayer cityLayer = new ShapeFileFeatureLayer("../../AppData/MajorCities.shp");
            cityLayer.ZoomLevelSet.ZoomLevel03.DefaultPointStyle = MapPointStyles.city1();
            cityLayer.ZoomLevelSet.ZoomLevel03.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level16;

            ShapeFileFeatureLayer cityLabelLayer = new ShapeFileFeatureLayer("../../AppData/MajorCities.shp");
            cityLabelLayer.ZoomLevelSet.ZoomLevel05.DefaultTextStyle = MapTextStyles.city1("AREANAME");
            cityLabelLayer.ZoomLevelSet.ZoomLevel05.DefaultTextStyle.BestPlacement = true;
            cityLabelLayer.ZoomLevelSet.ZoomLevel05.DefaultTextStyle.OverlappingRule = LabelOverlappingRule.AllowOverlapping;
            cityLabelLayer.ZoomLevelSet.ZoomLevel05.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level16;

            ShapeFileFeatureLayer streetLayer = new ShapeFileFeatureLayer("../../AppData/Austinstreets.shp");
            streetLayer.ZoomLevelSet.ZoomLevel09.DefaultLineStyle = MapLineStyles.Street1();
            streetLayer.ZoomLevelSet.ZoomLevel09.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            ShapeFileFeatureLayer streeLabelLayer = new ShapeFileFeatureLayer("../../AppData/Austinstreets.shp");
            streeLabelLayer.ZoomLevelSet.ZoomLevel09.DefaultTextStyle = MapTextStyles.street1("NAME");
            streeLabelLayer.ZoomLevelSet.ZoomLevel09.DefaultTextStyle.BestPlacement = true;
            streeLabelLayer.ZoomLevelSet.ZoomLevel09.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            layerOverlay.Layers.Add("CountryLayer", countryLayer);
            layerOverlay.Layers.Add("CountryLabelLayer", countryLabelLayer);
            layerOverlay.Layers.Add("CityLayer", cityLayer);
            layerOverlay.Layers.Add("CityLabelLayer", cityLabelLayer);
            layerOverlay.Layers.Add("StreetLayer", streetLayer);
            layerOverlay.Layers.Add("StreeLabelLayer", streeLabelLayer);

            return layerOverlay;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            winformsMap.ZoomIn(60);
            winformsMap.Refresh();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            winformsMap.ZoomOut(20);
            winformsMap.Refresh();
        }
    }
}
