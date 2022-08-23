using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;

namespace WebView2Example.Model
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class WebView2Example : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                MainWindow mainWindow = new MainWindow(commandData.Application);
                mainWindow.Show();
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Result.Failed;
            }
        }

        public string GetName() => nameof(WebView2Example);  
    }
}
