
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelixToolkit.Wpf;
using System.IO;


namespace RobotArmHelix
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {

        private const string MODEL_PATH21 = "test.stl";
        private const string modeltest = "aggramar.obj";
        string basePath = "";
        Model3D visualGrid = null; //Debug sphere to check in which point the joint is rotatin
        ModelVisual3D mvGrid;
        ModelVisual3D mvBoard;
        Vector3D basePoint;
        Color oldColor = Colors.White;
        GeometryModel3D oldSelectedModel = null;

        public Window1()
        {
            InitializeComponent();
            basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\3D_Models\\";

            /** Debug sphere to check in which point the joint is rotating**/
            var builder = new MeshBuilder(true, true);
            var position = new Point3D(0, 0, 0);
            builder.AddSphere(position, 5, 15, 15);
            visualGrid = new GeometryModel3D(builder.ToMesh(), Materials.Brown);
            mvGrid = new ModelVisual3D();
            mvGrid.Content = visualGrid;

            //add board
            ModelImporter import = new ModelImporter();
            var link = import.Load(basePath + MODEL_PATH21);
            mvBoard = new ModelVisual3D();
            mvBoard.Content = link;
            mvBoard.Transform = new TranslateTransform3D(basePoint);

            var materialGroup = new MaterialGroup();
            Color mainColor = Colors.White;
            EmissiveMaterial emissMat = new EmissiveMaterial(new SolidColorBrush(mainColor));
            DiffuseMaterial diffMat = new DiffuseMaterial(new SolidColorBrush(mainColor));
            SpecularMaterial specMat = new SpecularMaterial(new SolidColorBrush(mainColor), 200);
            materialGroup.Children.Add(emissMat);
            materialGroup.Children.Add(diffMat);
            materialGroup.Children.Add(specMat);

            GeometryModel3D model = link.Children[0] as GeometryModel3D;
            model.Material = materialGroup;
            model.BackMaterial = materialGroup;

            //
            viewPort3d.RotateGesture = new MouseGesture(MouseAction.RightClick);
            viewPort3d.PanGesture = new MouseGesture(MouseAction.LeftClick);
            viewPort3d.Children.Add(mvGrid);
 
            viewPort3d.Children.Add(mvBoard);



            viewPort3d.Camera.LookDirection = new Vector3D(20, -52, -29);
            viewPort3d.Camera.UpDirection = new Vector3D(-0.145, 0.372, 0.917);
            viewPort3d.Camera.Position = new Point3D(-15, 48, 37);
        }

        private void ViewPort3D_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(viewPort3d);
            PointHitTestParameters hitParams = new PointHitTestParameters(mousePos);
            VisualTreeHelper.HitTest(viewPort3d, null, ResultCallback, hitParams);
        }

        private void ViewPort3D_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Perform the hit test on the mouse's position relative to the viewport.
            HitTestResult result = VisualTreeHelper.HitTest(viewPort3d, e.GetPosition(viewPort3d));
            RayMeshGeometry3DHitTestResult mesh_result = result as RayMeshGeometry3DHitTestResult;

            if (oldSelectedModel != null)
                unselectModel();

            if (mesh_result != null)
            {
                selectModel(mesh_result.ModelHit);
            }
        }
        private void selectModel(Model3D pModel)
        {
            try
            {
                Model3DGroup models = ((Model3DGroup)pModel);
                oldSelectedModel = models.Children[0] as GeometryModel3D;
            }
            catch (Exception exc)
            {
                oldSelectedModel = (GeometryModel3D)pModel;
            }
            oldColor = changeModelColor(oldSelectedModel, ColorHelper.HexToColor("#ff0000"));
        }
        private void unselectModel()
        {
            changeModelColor(oldSelectedModel, oldColor);
        }

        private Color changeModelColor(GeometryModel3D pModel, Color newColor)
        {
            if (pModel == null)
                return oldColor;

            Color previousColor = Colors.Black;

            MaterialGroup mg = (MaterialGroup)pModel.Material;
            if (mg.Children.Count > 0)
            {
                try
                {
                    previousColor = ((EmissiveMaterial)mg.Children[0]).Color;
                    ((EmissiveMaterial)mg.Children[0]).Color = newColor;
                    ((DiffuseMaterial)mg.Children[1]).Color = newColor;
                }
                catch (Exception exc)
                {
                    previousColor = oldColor;
                }
            }

            return previousColor;
        }

        public HitTestResultBehavior ResultCallback(HitTestResult result)
        {
            // Did we hit 3D?
            RayHitTestResult rayResult = result as RayHitTestResult;
            if (rayResult != null)
            {
                // Did we hit a MeshGeometry3D?
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;
                visualGrid.Transform = new TranslateTransform3D(new Vector3D(rayResult.PointHit.X, rayResult.PointHit.Y, rayResult.PointHit.Z));

                if (rayMeshResult != null)
                {
                    // Yes we did!
                }
            }

            return HitTestResultBehavior.Continue;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                basePoint = new Vector3D(sliderX.Value, sliderY.Value, sliderZ.Value);
                visualGrid.Transform = new TranslateTransform3D(basePoint);
                mvBoard.Transform = new TranslateTransform3D(basePoint);

            }
            catch (Exception exc)
            {

            }
        }
    }


}
