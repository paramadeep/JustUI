Endhira
======

  Simple automation tool for windows. Wrapper arround UI Automation, making it usable by common man


 Basic Usage:
 
 ```c#
 var myApp = new Application("<--location of application executable-->");
 myApp.launch();
 var appWindow = myApp.Window;
 appWindow.Get<Edit>(By.Id(textbox_id)).SetValue(text);
 appWindow.Get<Button>(By.Name(button_name)).Click();
```
