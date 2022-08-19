using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace WebView2Example
{
    public class RevitService 
    {
        private readonly Autodesk.Revit.ApplicationServices.Application _app;
        public UIApplication _uiApplication;
        private readonly UIDocument _uiDocument;
        public Document _document;

        public RevitService(UIApplication uiapp)
        {
            _app = uiapp.Application;
            _uiApplication = uiapp;
            _uiDocument = _uiApplication.ActiveUIDocument;
            _document = _uiDocument.Document;
        }

        public void UpdateFloors(List<FloorWrapper> floors)
        {
            int scale = 100;
            RemoveAllFloors();
            Level level = new FilteredElementCollector(_document).OfClass(typeof(Level)).FirstOrDefault() as Level;
            FloorType floorType = new FilteredElementCollector(_document).OfClass(typeof(FloorType)).FirstElement() as FloorType;

            foreach (FloorWrapper floor in floors)
            {
                XYZ first = new XYZ(floor.x * scale, floor.y * scale, 0);
                XYZ second = new XYZ(floor.x  * scale, (floor.y - floor.h) * scale, 0);
                XYZ third = new XYZ((floor.x + floor.w)  * scale, (floor.y - floor.h) * scale, 0);
                XYZ fourth = new XYZ((floor.x + floor.w) * scale, floor.y  * scale, 0);

                CurveArray profile = new CurveArray();
                profile.Append(Line.CreateBound(first, second));
                profile.Append(Line.CreateBound(second, third));
                profile.Append(Line.CreateBound(third, fourth));
                profile.Append(Line.CreateBound(fourth, first));

                XYZ normal = XYZ.BasisZ;
                using (Transaction tr = new Transaction(_document, "Creating of floors"))
                {
                    tr.Start();
                    _document.Create.NewFloor(profile, floorType, level, true, normal);
                    tr.Commit();
                }

            }

        }

        private void RemoveAllFloors()
        {
            List<Floor> floors = new FilteredElementCollector(_document).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).Cast<Floor>().ToList();

            using (Transaction tr = new Transaction(_document, "Removing of floors"))
            {
                tr.Start();
                floors.ForEach(floor => _document.Delete(floor.Id));
                tr.Commit();
            }
        }

    }
}
