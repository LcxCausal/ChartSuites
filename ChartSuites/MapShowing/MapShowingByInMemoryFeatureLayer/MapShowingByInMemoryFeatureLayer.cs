using System;
using System.Drawing;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;
using System.Xml;

namespace MapShowingByInMemoryFeatureLayer
{
    public partial class MapShowingByInMemoryFeatureLayer : Form
    {
        public MapShowingByInMemoryFeatureLayer()
        {
            InitializeComponent();
        }

        private void MapShowingByInMemoryFeatureLayer_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            WinformsMap winformsMap1 = new WinformsMap();
            Controls.Add(winformsMap1);
            winformsMap1.Name = "winformsMap1";
            winformsMap1.Text = "winformsMap1";
            winformsMap1.Location = new Point(20, 60);
            winformsMap1.Size = new Size(740, 528);
            winformsMap1.MapUnit = GeographyUnit.DecimalDegree;
            winformsMap1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            winformsMap1.BackColor = Color.White;
            winformsMap1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            winformsMap1.DrawingQuality = DrawingQuality.HighQuality;

            LayerOverlay layerOverlay = new LayerOverlay();
            InMemoryFeatureLayer inMemoryFeatureLayer = new InMemoryFeatureLayer();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../AppData/LayerData.xml");
            XmlNode root = xmlDoc.SelectSingleNode("Layer");
            XmlNodeList nodes = root.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                string wkt = node.InnerText;
                Feature feature = new Feature(wkt);
                feature.ColumnValues.Add("NAME", node.Attributes["name"].Value);
                inMemoryFeatureLayer.InternalFeatures.Add(node.Attributes["name"].Value, feature);
            }
            //inMemoryFeatureLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = WorldMapKitAreaStyles.Water();
            //inMemoryFeatureLayer.ZoomLevelSet.ZoomLevel01.DefaultLineStyle.OuterPen = new GeoPen(GeoColor.FromArgb(200, GeoColor.StandardColors.Brown), 3);
            //inMemoryFeatureLayer.ZoomLevelSet.ZoomLevel01.DefaultPointStyle.SymbolPen = new GeoPen(GeoColor.FromArgb(255, GeoColor.StandardColors.Green), 8);
            //inMemoryFeatureLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = TextStyles.CreateSimpleTextStyle("Name", "Arial", 6, DrawingFontStyles.Regular, GeoColor.StandardColors.Black);
            //inMemoryFeatureLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            WorldMapKitWmsDesktopOverlay worldMapKitWmsDesktopOverlay = new WorldMapKitWmsDesktopOverlay();
            winformsMap1.Overlays.Add(worldMapKitWmsDesktopOverlay);
            layerOverlay.Layers.Add(inMemoryFeatureLayer);

            inMemoryFeatureLayer.Open();
            winformsMap1.Overlays.Add(layerOverlay);
            winformsMap1.CurrentExtent = inMemoryFeatureLayer.GetBoundingBox();
            winformsMap1.Refresh();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
