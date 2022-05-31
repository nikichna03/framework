using OpenQA.Selenium;
using System;

namespace resources
{
	public class Screen
	{
		IWebDriver driver;

		public Screen(IWebDriver Driver)
		{
			this.driver = Driver;
		}

		public void MakeScreenshot()
		{
			string name = DateTime.Now.ToString("D-MM/dd/yyyy   T-HH:mm:ss");
			Screenshot picture = ((ITakesScreenshot)driver).GetScreenshot();
			picture.SaveAsFile("D://" + name.Replace(':', '.') + ".png",
					ScreenshotImageFormat.Png);
		}
	}
}