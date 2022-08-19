using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;

namespace WebView2Example.Model
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class WebView2Example : IExternalEventHandler //  Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        public void Execute(UIApplication app)
        {
            try
            {
                MainWindow mainWindow = new MainWindow(app);
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public string GetName() => nameof(WebView2Example);  
    }
}
