using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

using RubyAndroidPlayerTest.SUT.Common;

namespace RubyAndroidPlayerTest.SUT.UI
{
    public class DetailView: BaseUI
    {
        private AndroidElement tvTitle;
        private AndroidElement tvAudio;
        private AndroidElement tvVideo;
        private AndroidElement tvAudioInfo;
        private AndroidElement tvVideoInfo;

        private AndroidElement tvPlay;

        public DetailView(AndroidDriver<AndroidElement> driver)
            : base(driver)
        {
            tvTitle = driver.FindElementById("tv_dvv_title");
            tvAudio = driver.FindElementById("tv_vdi_sound");
            tvVideo = driver.FindElementById("tv_vdi_image");

            tvAudioInfo = driver.FindElementById("tv_vdi_sound_info");
            tvVideoInfo = driver.FindElementById("tv_vdi_image_info");

            tvPlay = driver.FindElementById("iv_dvv_play");
        }

        /// <summary>
        /// Press Play button to start content playback
        /// </summary>
        public PlaybackView StartPlayback()
        {
            tvPlay.Click();

            return new PlaybackView(driver);
        }
        
        public String GetMovieTitle()
        { 
            return tvTitle.Text;
        }

        public String GetAudioInfo()
        { 
            return tvAudioInfo.Text;
        }

        public String GetVideoInfo()
        {
            return tvVideoInfo.Text;
        }

    }
}
