using System;
using System.Drawing;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;

namespace MapShowingByShapeFileFeatureLayer
{
    public partial class MapShowingByShapeFileFeatureLayer : Form
    {
        public MapShowingByShapeFileFeatureLayer()
        {
            InitializeComponent();
        }

        private void MapShowingByShapeFileFeatureLayer_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            WinformsMap winformsMap1 = new WinformsMap();
            Controls.Add(winformsMap1);
            winformsMap1.Location = new Point(20, 60);
            winformsMap1.Size = new Size(740, 528);
            winformsMap1.Name = "winformsMap1";
            winformsMap1.Text = "winformsMap1";
            winformsMap1.MapUnit = GeographyUnit.DecimalDegree;

            ShapeFileFeatureLayer worldLayer = new ShapeFileFeatureLayer("../../AppData/Countries02.shp");
            //worldLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyles.CreateSimpleAreaStyle(GeoColor.StandardColors.Red);
            //worldLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level10;
            //worldLayer.ZoomLevelSet.ZoomLevel11.DefaultAreaStyle = AreaStyles.CreateSimpleAreaStyle(GeoColor.StandardColors.Blue);
            //worldLayer.ZoomLevelSet.ZoomLevel11.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            ShapeFileFeatureLayer worldLabelLayer = new ShapeFileFeatureLayer("../../AppData/Countries02.shp");
            //worldLabelLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = TextStyles.CreateSimpleTextStyle("CNTRY_NAME", "Arial", 8, DrawingFontStyles.Italic, GeoColor.StandardColors.Black, 3, 3);
            //worldLabelLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;
            //worldLabelLayer.DrawingMarginInPixel = 50;

            ShapeFileFeatureLayer cityLayer = new ShapeFileFeatureLayer("../../AppData/MajorCities.shp");
            //cityLayer.ZoomLevelSet.ZoomLevel01.DefaultPointStyle = PointStyles.CreateSimpleCircleStyle(GeoColor.StandardColors.White, 7, GeoColor.StandardColors.Brown);
            //cityLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level10;
            //cityLayer.ZoomLevelSet.ZoomLevel10.DefaultPointStyle = PointStyles.Capital3;
            //cityLayer.ZoomLevelSet.ZoomLevel10.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            ShapeFileFeatureLayer cityLabelLayer = new ShapeFileFeatureLayer("../../AppData/MajorCities.shp");
            //cityLabelLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = TextStyles.CreateSimpleTextStyle("AREANAME", "Arial", 8, DrawingFontStyles.Italic, GeoColor.StandardColors.Black, 3, 3);
            //cityLabelLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            ShapeFileFeatureLayer streetLayer = new ShapeFileFeatureLayer("../../AppData/Austinstreets.shp");
            //streetLayer.ZoomLevelSet.ZoomLevel01.DefaultLineStyle = LineStyles.MajorStreet3;
            //streetLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            ShapeFileFeatureLayer streetLabelLayer = new ShapeFileFeatureLayer("../../AppData/Austinstreets.shp");
            //streetLabelLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = TextStyles.CreateSimpleTextStyle("NAME", "Arial", 8, DrawingFontStyles.Italic, GeoColor.StandardColors.Black, 3, 3);
            //streetLabelLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            LayerOverlay layerOverlay = new LayerOverlay();
            WorldMapKitWmsDesktopOverlay worldMapKitWmsDesktopOverlay = new WorldMapKitWmsDesktopOverlay();
            layerOverlay.Layers.Add(worldLabelLayer);
            layerOverlay.Layers.Add(worldLayer);
            layerOverlay.Layers.Add(worldLabelLayer);
            layerOverlay.Layers.Add(cityLayer);
            layerOverlay.Layers.Add(cityLabelLayer);
            layerOverlay.Layers.Add(streetLayer);
            layerOverlay.Layers.Add(streetLabelLayer);

            winformsMap1.Overlays.Add(worldMapKitWmsDesktopOverlay);
            winformsMap1.Overlays.Add(layerOverlay);
            cityLayer.Open();
            winformsMap1.CurrentExtent = cityLayer.GetBoundingBox();
            winformsMap1.Refresh();
        }
    }
}
