using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace WebView2Example
{
    internal class Message
    {
        public string @event { get; set; }
        public object payload { get; set; }

        public Message() { }

        internal Message(EventsEnum eventName, object payload)
        {
            @event = Enum.GetName(typeof(EventsEnum), eventName);
            this.payload = payload;
        }

        public async static void SendMessage(WebView2 webView, Message message)
        {
            try
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(() => 
                webView.ExecuteScriptAsync($"dispatchWebViewEvent({JsonConvert.SerializeObject(message)})"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
