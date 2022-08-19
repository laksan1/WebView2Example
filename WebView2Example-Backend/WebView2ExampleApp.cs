using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace WebView2Example
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class WebView2ExampleApp : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication uiControlApplication)
        {
            try
            {
                RibbonPanel ribbonPanelCreated = CreationRibbonPanel(uiControlApplication, "WebView2Example");
                AddPushButton("but1", "WebView2Example", "A plugin that links a web application and a c# application via WebView2", true, ribbonPanelCreated);
                ribbonPanelCreated.AddSeparator();
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Result.Cancelled;
            }
        }

        public void AddPushButton(string name,
                                   string text,
                                   string tooltip,
                                   bool toolTipImage,
                                   RibbonPanel _ribbonPanel)
        {
            try
            {
                string assemblyPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\WebView2Example.dll";
                PushButtonData pushButtonData = new PushButtonData(name,
                                                                    text,
                                                                    assemblyPath,
                                                                    "WebView2Example.Model.WebView2Example");

                pushButtonData.LargeImage = new BitmapImage(new Uri($"pack://application:,,,/WebView2Example;component/Resources/icon.png"));
                pushButtonData.ToolTip = tooltip;
                if (toolTipImage == true)
                {
                    pushButtonData.ToolTipImage = new BitmapImage(new Uri($"pack://application:,,,/WebView2Example;component/Resources/icon.png"));
                }
                _ribbonPanel.AddItem(pushButtonData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public RibbonPanel CreationRibbonPanel(UIControlledApplication application, string tabName)
        {
            application.CreateRibbonTab(tabName);
            RibbonPanel ribbonPanelCreated = application.CreateRibbonPanel(tabName, tabName);
            return ribbonPanelCreated;
        }

        public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
    }


}
