using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebView2Example
{
    internal class WebView2EventHandler
    {
        internal static void UpdateFloors(RevitEvent revitEvent, RevitService revitService, object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            List<FloorWrapper> payloadFloors = JsonConvert.DeserializeObject<List<FloorWrapper>>(json);

            revitEvent.Run(app =>
            {
                revitService.UpdateFloors(payloadFloors);

            });
        }


        internal static void ResizeWindow(object payload,
                                          RevitEvent revitEvent,
                                          MainWindowViewModel mainWindowViewModel) 
        {
            string json = JsonConvert.SerializeObject(payload);
            Dictionary<string, object> payloadDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            int height = JsonConvert.DeserializeObject<int>(Convert.ToString(payloadDict["height"]));
            int width = JsonConvert.DeserializeObject<int>(Convert.ToString(payloadDict["width"]));

            revitEvent.Run(app =>
            {
                mainWindowViewModel.MainWindowHeight = height;
                mainWindowViewModel.MainWindowWidth = width;
            });
        }

    }
}
