using Autodesk.Revit.UI;
using System;
using System.Diagnostics;

namespace WebView2Example
{
    public class RevitEvent : IExternalEventHandler
    {
        private Action<UIApplication> action;
        private readonly ExternalEvent externalEvent;
        public RevitEvent()
        {
            externalEvent = ExternalEvent.Create(this);
        }
        public void Run(Action<UIApplication> action)
        {
            this.action = action;
            externalEvent.Raise();
        }
        public void Execute(UIApplication app)
        {
            try
            {
                action?.Invoke(app);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public string GetName() => nameof(RevitEvent);
    }
}
