using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Tesseract;

namespace RubyAndroidPlayerTest.SUT.Common
{
    public class Util
    {
        private static AndroidDriver<AndroidElement> driver = null;
        
        public static string DEVICE_NAME = ConfigurationManager.AppSettings["DeviceName"];
        public static string PLATFORM_VERSION = ConfigurationManager.AppSettings["PlatformVersion"];
        public static string REMOTE_ADDRESS = ConfigurationManager.AppSettings["RemoteAddress"];
        public static string CONTENT_ASSETS_FOLDER = ConfigurationManager.AppSettings["ContentAssetsFolder"];
        public static string APP_PACKAGE = ConfigurationManager.AppSettings["PackageName"];
        public static string APP_ACTIVITY = ConfigurationManager.AppSettings["ActivityName"];

        protected static int KEYCODE_HOME = 3;
        protected static int KEYCODE_BACK = 4;
        protected static int KEYCODE_RECENT = 3;

        /// <summary>
        /// Create an instance of Android driver
        /// </summary>
        public static AndroidDriver<AndroidElement> CreateDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", DEVICE_NAME);
            capabilities.SetCapability("platformVersion", PLATFORM_VERSION);
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("appPackage", APP_PACKAGE);
            capabilities.SetCapability("appActivity", APP_ACTIVITY);

            driver = new AndroidDriver<AndroidElement>(new Uri(REMOTE_ADDRESS), 
                                                       capabilities);

            return driver;
        }

        /// <summary>
        /// Set app from background to foreground
        /// </summary>
        public static void SetAppToForeground()
        {
            string shell_cmd = String.Format("shell am start -a android.intent.action.MAIN -n {0}/{1}",
                                             APP_PACKAGE, APP_ACTIVITY);

            //Util.GetCurrentDriver().FindElementByName("Ruby Demo").Click();
            Util.ExecuteADBCommand(shell_cmd);

            Util.Sleep(5);
        }

        public static void PressBackKey()
        {
            if(driver!=null)
            { 
                driver.KeyEvent(KEYCODE_BACK); 
            }
        }

        public static void PressHomeKey()
        {
            if(driver!=null)
            {
                driver.KeyEvent(KEYCODE_HOME);
            }
        }

        /// <summary>
        /// Compare image between two screenshots, it returns true if these two screenshots are the same;
        /// </summary>
        /// <param name="srcImagePath"></param>
        /// <param name="targetImagePath"></param>
        /// <returns></returns>
        public static float CompareScreenshots(string srcImagePath, string targetImagePath)
        {
            Bitmap img1 = new Bitmap(srcImagePath);
            Bitmap img2 = new Bitmap(targetImagePath);

            if (img1.Size != img2.Size)
            {
                //Console.Error.WriteLine("Images are of different sizes");
                return (float)1.00;
            }

            float diff = 0;

            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {
                    diff += (float)Math.Abs(img1.GetPixel(x, y).R - img2.GetPixel(x, y).R) / 255;
                    diff += (float)Math.Abs(img1.GetPixel(x, y).G - img2.GetPixel(x, y).G) / 255;
                    diff += (float)Math.Abs(img1.GetPixel(x, y).B - img2.GetPixel(x, y).B) / 255;
                }
            }

            return diff;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static string ExecuteADBCommand(string arguments)
        {
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "adb.exe";
            p.StartInfo.Arguments = arguments;

            Console.WriteLine("Execute adb command: {0}", p.StartInfo.FileName + " " + p.StartInfo.Arguments);

            string strStdOutput = "";

            try
            {
                p.Start();
                strStdOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                p.Close();
            }

            return strStdOutput;
        }

        public static void HideConfigFile()
        {
            string shell_cmd = "shell " + "rename " + CONTENT_ASSETS_FOLDER + "media_config.xml " + CONTENT_ASSETS_FOLDER + "media_config.xml.bak";   
            ExecuteADBCommand(shell_cmd);
        }

        public static void UnhideConfigFile()
        {
            string shell_cmd = "shell " + "rename " + CONTENT_ASSETS_FOLDER + "media_config.xml.bak " + CONTENT_ASSETS_FOLDER + "media_config.xml";
            ExecuteADBCommand(shell_cmd);
        }

        public static void Quit()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public static void SetOrientationToPortrait()
        {
            if ((driver != null) && (driver.Orientation != ScreenOrientation.Portrait))
            {
                try
                {
                    driver.Orientation = ScreenOrientation.Portrait;
                }
                catch (InvalidOperationException ex)
                { //Do nothing to handle unxpected server-side error. 
                }
            }
        }

        public static void SetOrientationToLandscape()
        {
            if ((driver != null)&&(driver.Orientation!=ScreenOrientation.Landscape))
            {
                try
                {
                    driver.Orientation = ScreenOrientation.Landscape;
                }
                catch (InvalidOperationException ex)
                {  //Do nothing to handle unxpected server-side error.
                }
            }
        }

        /// <summary>
        /// Lock the device for specified seconds
        /// </summary>
        /// <param name="seconds"></param>
        public static void LockDevice(int seconds)
        {
            driver.LockDevice(seconds);

            //Unlock device by executing belowing command
            Util.ExecuteADBCommand("shell am start -n io.appium.unlock/.Unlock");

            Util.Sleep(3);
        }

        public static string TakeScreenshot()
        {
            string path = System.Environment.CurrentDirectory;
            return TakeScreenshot(path);
        }

        public static string TakeScreenshot(string path)
        {
            String strFullName = path + "\\" + GetTimeStamp() + ".jpg";
            driver.GetScreenshot().SaveAsFile(strFullName, System.Drawing.Imaging.ImageFormat.Jpeg);

            //Set screenshot to landscape
            using (Image img = Image.FromFile(strFullName))
            {
                //If the image is vertical, then set it to landscape
                if (img.Width < img.Height)
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    img.Save(strFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }

            return strFullName;
        }

        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static void Reset()
        {
            if (driver != null)
            {
                driver.ResetApp();
            }
        }

        public static AndroidDriver<AndroidElement> GetCurrentDriver()
        {
            if (driver != null)
            {
                return driver;
            }
            else
            {
                throw new Exception("Android driver is not created yet.");
            }
        }

        /// <summary>
        /// Sleep forcibly for specified seconds
        /// </summary>
        /// <param name="seconds"></param>
        public static void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        /// <summary>
        /// Generate a randon number in a specified range
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomNum(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }

        /// <summary>
        /// Extract text from given screenshot
        /// </summary>
        /// <param name="imgFilePath"></param>
        /// <returns></returns>
        public static string ExtractTextFromScreenshot(string imgFilePath)
        {
            TesseractEngine engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            Pix img = Pix.LoadFromFile(imgFilePath);

            Page page = engine.Process(img);

            return page.GetText();
        }
    }
}
