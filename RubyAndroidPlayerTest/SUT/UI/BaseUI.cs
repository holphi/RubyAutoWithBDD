using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;

namespace RubyAndroidPlayerTest.SUT.UI
{
    public class BaseUI
    {
        protected AndroidDriver<AndroidElement> driver;

        protected const int KEYCODE_HOME = 3;
        protected const int KEYCODE_BACK = 4;
        protected const int KEYCODE_RECENT = 3;

        protected const int DEFAULT_TIMEOUT = 5;

        public BaseUI(AndroidDriver<AndroidElement> d)
        {
            this.driver = d;
        }

        /// <summary>
        /// Unlock the device screen
        /// </summary>
        public void UnlockScreen()
        {
           /*int startX = 300; 
           int startY=350;

           int height = 150;
            
           TouchAction gestures = new TouchAction(this.driver);
           gestures.Press(startX, startY)
                   .MoveTo(startX + height, startY-height)
                   .MoveTo(startX + 2*height, startY-2*height)
                   .MoveTo(startX + 3 * height, startY - 3 * height)
                   .Release().Perform();*/

            throw new Exception("Not implemented yet");
        
        }

        public void PullFile(string from, string to)
        { 

        }

        public void PushFile(string from, string to)
        { 
            
        }

        public bool IsElementPresent(By by, int num)
        {
            if (FindElement(by, num) != null)
                return true;
            else
                return false;
        }

        public bool IsElementPresent(By by)
        {
            if (FindElement(by) != null)
                return true;
            else
                return false;
        }

        protected AndroidElement FindElement(By by, int num)
        {
            int i = 0;

            AndroidElement element = null;

            while (i < num)
            {
                try
                {
                    element = driver.FindElement(by);
                    return element;
                }
                catch (NoSuchElementException)
                {
                    i = i + 1;
                    Console.WriteLine("Wait 1 second");
                    System.Threading.Thread.Sleep(1000);
                }
            }

            return element;
        }

        protected AndroidElement FindElement(By by)
        {
            return FindElement(by, DEFAULT_TIMEOUT);
        }
    }
}
