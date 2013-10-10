JustUI
======

 Wrapper arround UI Automation, making it usable by common man


 Basic Usage:
 
 myApp = new Application("<location of application executable>");
 myApp.launch;
 Window appWindow = myApp.window;
 appWindow.Get<Edit>(By.Id(textbox_id))).SetValue(text);
 appWindow.Get<Button>(By.Name(button_name)).Click();
