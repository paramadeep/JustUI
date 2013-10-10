JustUI
======

 Wrapper arround UI Automation, making it usable by common man


 Basic Usage:
 
 myApp = new Application("&lt;location of application executable>");
 <br />
 myApp.launch();
 <br />
 Window appWindow = myApp.Window;
 <br />
 appWindow.Get&lt;Edit>(By.Id(textbox_id))).SetValue(text);
 <br />
 appWindow.Get&lt;Button>(By.Name(button_name)).Click();
