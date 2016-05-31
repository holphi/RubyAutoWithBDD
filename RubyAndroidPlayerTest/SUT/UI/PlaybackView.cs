using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;

using RubyAndroidPlayerTest.SUT.Common;

namespace RubyAndroidPlayerTest.SUT.UI
{
    public class PlaybackView:BaseUI
    {
        public PlaybackView(AndroidDriver<AndroidElement> d)
            : base(d)
        {
        
        }

        public void PressBack()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
                Util.Sleep(1);
            }

            FindElement(By.Name("Back")).Click();
        }

        public void PressPlayPause()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
                Util.Sleep(1);
            }

            FindElement(By.Id("com.dolby.gravityplayer:id/playback_pause_button"), 3).Click();
        }

        public string GetCurrentTime()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
                Util.Sleep(1);
            }

            return FindElement(By.Id("com.dolby.gravityplayer:id/tv_curtime")).Text;
        }

        public string GetRemainTime()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
                Util.Sleep(1);
            }

            return FindElement(By.Id("com.dolby.gravityplayer:id/tv_remaintime")).Text;
        }

        public void PressRewind()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
                Util.Sleep(1);
            }

            FindElement(By.Id("com.dolby.gravityplayer:id/rewind_button")).Click();
        }

        public bool IsPlaying()
        {
            string time1 = GetCurrentTime();
            Util.Sleep(2);
            string time2 = GetCurrentTime();

            if (!time1.Equals(time2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPlaybackCtlDisplayed()
        {
            if (IsElementPresent(By.Id("com.dolby.gravityplayer:id/btn_back"), 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCurrentTimeToSeconds()
        {
            string strTime = this.GetCurrentTime();

            int colon_pos = strTime.IndexOf(":");
            int minutes = Convert.ToInt32(strTime.Substring(0, colon_pos - 0));
            int seconds = Convert.ToInt32(strTime.Substring(colon_pos + 1, strTime.Length - colon_pos - 1));

            return minutes * 60 + seconds;
        }

        public void ShowPlaybackCtl()
        {
            int x = 350, y = 80;
            TouchAction gesture = new TouchAction(this.driver);
            gesture.Press(x, y).Release().Perform();
        }

        public void PrintSeekBarInfo()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
            }

            Console.WriteLine(FindElement(By.Id("com.dolby.gravityplayer:id/video_seek")).Location);
        }

        public void Seek()
        {
            if (IsPlaybackCtlDisplayed() == false)
            {
                ShowPlaybackCtl();
            }

            AndroidElement element = FindElement(By.Id("com.dolby.gravityplayer:id/video_seek"));

            int x = Util.GetRandomNum(element.Location.X, element.Location.X + 800);
            int y = element.Location.Y + 23;

            TouchAction gesture = new TouchAction(this.driver);
            gesture.Press(x, y).Release().Perform();
        }
    }
}
