# WebView2Example
This repository contains two projects. The first project is the backend part, which is written in the c# programming language. The backend part consists of a plugin for Revit with a wpf window, to which webview2 connects. The frontend part is a project on the angular framework.

Preview:

![image](https://github.com/laksan1/WebView2Example/blob/main/gifs/preview.gif)

Installation. 
1. Clone
2. Open the "WebView2Example-Front" project
3. In the terminal set the dependencies with the command "npm install"
4. Run the command "start" in package.json
5. Check http://localhost:1234
6. Open an empty project in Revit.
7. Open the "WebView2Example-Backend" project
8. Change the paths in the "build events" (project properties). 
9. Check WebView2Loader from packages\Microsoft.Web.WebView2.1.0.1185.39\runtimes\win-x64\native\.This depends on the version of your operating system. It needs for button on RevitRibbon. 
If you use Add Inn Manager  go to the next step.
9. Build the project (addin and dll file are copied to the addins folder).
10. Click the button on the Revit panel "WebView2Example" (or TO USE ADD IN MANAGER ) .
11. Drag and drop rectangles in the window of the revit plugin