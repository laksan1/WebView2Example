using Autodesk.Revit.UI;
using Microsoft.Web.WebView2.Wpf;
using System;

namespace WebView2Example
{
    internal class MainWindowViewModel: ModelBase
    {
        public Action CloseAction { get; set; }
        private LaunchService launchService;

        private int mainWindowHeight = 900;
        public int MainWindowHeight
        {
            get
            {
                return mainWindowHeight;
            }
            set
            {
                mainWindowHeight = value;
                OnPropertyChanged("MainWindowHeight");
            }
        }

        private int mainWindowWidth = 1202;
        public int MainWindowWidth
        {
            get
            {
                return mainWindowWidth;
            }
            set
            {
                mainWindowWidth = value;
                OnPropertyChanged("MainWindowWidth");
            }
        }

        public MainWindowViewModel(UIApplication app, WebView2 webView)
        {
            launchService = new LaunchService(app, webView, this);
        }
    }
}
