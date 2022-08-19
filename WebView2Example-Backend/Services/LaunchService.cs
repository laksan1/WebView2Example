using Autodesk.Revit.UI;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebView2;

namespace WebView2Example
{
    internal class LaunchService
    {
        private MainWindowViewModel mainWindowViewModel;
        private Microsoft.Web.WebView2.Wpf.WebView2 webView;
        private RevitEvent revitEvent;
        private RevitService revitService;

        internal LaunchService(UIApplication app,
                             Microsoft.Web.WebView2.Wpf.WebView2 webView,
                             MainWindowViewModel mainWindowViewModel)
        {
            revitService = new RevitService(app);
            this.webView = webView;
            this.mainWindowViewModel = mainWindowViewModel;
            revitEvent = new RevitEvent();
            string uriString = "http://localhost:1234";
            Task ecwTask = webView.EnsureCoreWebView2Async(null);
            webView.Source = new Uri(uriString);
            webView.WebMessageReceived += new EventHandler<CoreWebView2WebMessageReceivedEventArgs>(ReceiveWebMessage);

        }

        private void ReceiveWebMessage(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            Message message = null;
            try
            {
                message = JsonConvert.DeserializeObject<Message>(e.WebMessageAsJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (message == null) return;

            switch ((EventsEnum)Enum.Parse(typeof(EventsEnum), message.@event))
            {
                case EventsEnum.Close:
                    mainWindowViewModel.CloseAction();
                    break;
                case EventsEnum.UpdateFloors:
                    WebView2EventHandler.UpdateFloors(revitEvent, revitService, message.payload);
                    break;

                case EventsEnum.ResizeWindow:
                    WebView2EventHandler.ResizeWindow(message.payload, revitEvent, mainWindowViewModel);
                    break;
                default:
                    break;
            }
        }
    }
}
