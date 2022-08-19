using Autodesk.Revit.UI;
using System;
using System.Windows;
using System.Windows.Input;

namespace WebView2Example
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        public MainWindow(UIApplication app)
        {
            try
            {
                InitializeComponent();
                viewModel = new MainWindowViewModel(app, webView);
                DataContext = viewModel;
                viewModel.CloseAction = new Action(this.Close);
            }
            catch 
            {
            
            }
        }

        private void dragWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
    }
}
