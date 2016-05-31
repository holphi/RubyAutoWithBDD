using System;
using System.Collections.Generic;

using TechTalk.SpecFlow;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

using RubyAndroidPlayerTest.SUT.Common;
using RubyAndroidPlayerTest.SUT.UI;
using System.Configuration;

namespace RubyAndroidPlayerTest.StepsDefination
{
    [Binding]
    public class CommonSteps
    {
        private ContentSelectionView contentSelView = null;
        private DetailView detailView = null;
        private PlaybackView playbackView = null;

        private static string KEY_PATH_FOR_SCREENSHOT = "PATH_FOR_SCREENSHOT";
        private static string KEY_VIDEO_CLIPS_LIST = "VIDEO_CLIPS_LIST";
        private static string KEY_LAST_ACTIVITY = "LAST_ACTIVITY";
        private static string KEY_CURRENT_TIME_BEFORE_SEEK = "CURRENT_TIME_BEFORE_SEEK";
        private static string KEY_CURRENT_TIME_AFTER_SEEK = "CURRENT_TIME_AFTER_SEEK";

        [When(@"I close the detail view")]
        public void WhenICloseTheDetailView()
        {
            contentSelView.CloseDetailView();
        }

        [Then(@"I should see the text (.*) displayed")]
        public void ThenIShouldSeeTheTextDisplayed(string caption)
        {
            Assert.IsTrue(contentSelView.IsElementPresent(By.Name(caption)),
                          String.Format("Verify if the caption {0} displayed in current UI", caption));

            if (ScenarioContext.Current.ScenarioInfo.Tags[0] == "RU_17")
            { 
                //Delete the invalid file first, then restore the corrrect metadata file
                string shell_cmd = "shell rm " + Util.CONTENT_ASSETS_FOLDER + "media_config.xml";
                Util.ExecuteADBCommand(shell_cmd);
                Util.UnhideConfigFile();
            }
        }

        [When(@"I tap on Play button")]
        public void WhenITapOnPlayButton()
        {
            playbackView = detailView.StartPlayback();
        }

        [Then(@"I should be in playback view")]
        public void ThenIShouldBeInPlaybackView()
        {
            Assert.IsTrue(playbackView.IsPlaybackCtlDisplayed());

            if (ScenarioContext.Current.ScenarioInfo.Tags[0] == "RU_62")
            {
                //Delete the invalid file first, then restore the corrrect metadata file
                string shell_cmd = "shell rm " + Util.CONTENT_ASSETS_FOLDER + "media_config.xml";
                Util.ExecuteADBCommand(shell_cmd);
                Util.UnhideConfigFile();
            }
        }


        [Given(@"The metadata file is missing")]
        public void GivenTheMetadataFileIsMissing()
        {
            Util.HideConfigFile();
        }

        [Given(@"The metadata file is incorrect")]
        public void GivenTheMetadataFileIsIncorrect()
        {
            //Hide original metadata file first
            Util.HideConfigFile();

            //Push invalid metadata file to the storage of Android device
            string adb_cmd = "push ./TestData/Metadata_Files/media_config_invalid.xml " + Util.CONTENT_ASSETS_FOLDER + "media_config.xml";
            
            Util.ExecuteADBCommand(adb_cmd);
        }

        [Given(@"The content file is missing")]
        public void GivenTheContentFileIsMissing()
        {
            //Hide original metadata file first
            Util.HideConfigFile();

            //Push invalid metadata file to the storage of Android device
            string adb_cmd = "push ./TestData/Metadata_Files/media_config_missing_content.xml " + Util.CONTENT_ASSETS_FOLDER + "media_config.xml";

            Util.ExecuteADBCommand(adb_cmd);
        }

        [When(@"I first launch the app")]
        public void WhenIFirstLaunchTheApp()
        {
            ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT] = Util.TakeScreenshot();
        }

        [Then(@"I should see a splash screen pop up")]
        public void ThenIShouldSeeASplashScreenPopUp()
        {
            string appTitle = "Dolby Atmos and Dolby Vision Demo";
            string appLogo = "DOLBY";

            string text = Util.ExtractTextFromScreenshot(ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT].ToString());

            Assert.IsTrue(text.Contains(appTitle), String.Format("An title {0} should be in splash screen.",appTitle));
            Assert.IsTrue(text.Contains(appLogo), String.Format("A logo {0} should be in splash screen.", appLogo));
        }

        [Then(@"I should not see a splash screen pop up")]
        public void ThenIShouldNotSeeASplashScreenPopUp()
        {
            string appTitle = "Dolby Atmos and Dolby Vision Demo";
            string appLogo = "DOLBY";

            string text = Util.ExtractTextFromScreenshot(ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT].ToString());

            Assert.IsFalse(text.Contains(appTitle), String.Format("An title {0} should be in splash screen.", appTitle));
            Assert.IsFalse(text.Contains(appLogo), String.Format("A logo {0} should be in splash screen.", appLogo));
        }

        [When(@"I launch Dolby demo app")]
        public void WhenILaunchDolbyDemoApp()
        {
            Util.GetCurrentDriver().ResetApp();

            contentSelView = new ContentSelectionView(Util.GetCurrentDriver());
            Assert.IsTrue(contentSelView.IsContentSelViewDisplayed(),
                          "Verify if content selection view is displayed");
        }

        [When(@"I set demo app to background for (.*) seconds")]
        public void WhenISetDemoAppToBackgroundForSeconds(int sec)
        {
            Util.GetCurrentDriver().BackgroundApp(sec);
        }

        [Then(@"I should not see the detail view pop up")]
        public void ThenIShouldNotSeeTheDetailViewPopUp()
        {
            Assert.IsFalse(contentSelView.IsDetailViewDisplayed(),
                    "Verify if the detail view is displayed.");
        }

        [Given(@"I am in content selection view")]
        public void GivenIAmInContentSelectionView()
        {
            contentSelView = new ContentSelectionView(Util.GetCurrentDriver());

            Assert.IsTrue(contentSelView.IsContentSelViewDisplayed(),
                          "Verify if content selection view is displayed");
        }

        [Given(@"I have following video clips in metadata file")]
        public void GivenIHaveFollowingVideoClipsInMetadataFile(Table videoClipsTbl)
        {
            List<String> videoClipLst = new List<String>();

            foreach (TableRow row in videoClipsTbl.Rows)
            {
                videoClipLst.Add(row["Video clip title"]);
            }

            ScenarioContext.Current[KEY_VIDEO_CLIPS_LIST] = videoClipLst;
        }

        [Then(@"I should see those video clips listed in content selection view")]
        public void ThenIShouldSeeThoseVideoClipsListedInContentSelectionView()
        {
            List<String> videoClipLst = (List<String>)ScenarioContext.Current[KEY_VIDEO_CLIPS_LIST];

            foreach(string videoclip in videoClipLst)
            {
                contentSelView.IsElementPresent(By.Name(videoclip));
            }
        }

        [Then(@"I should be in content selection view")]
        public void ThenIShouldBeInContentSelectionView()
        {
            GivenIAmInContentSelectionView();
        }

        [Then(@"I should see a toast message (.*) pop up")]
        public void ThenIShouldSeeAToastMessagePopUp(string message)
        {
            //Appium can't capture toast component, we workaround it by extracting the text from screehshot direclty;
            string text = Util.ExtractTextFromScreenshot(Util.TakeScreenshot());

            if (ScenarioContext.Current.ScenarioInfo.Tags[0] == "RU_16")
            {
                //Not use the parameter message for verification due to character issue of Tessact
                Assert.IsTrue(text.Contains("Metadata"), "Verify if toast message is included in current UI");
                Assert.IsTrue(text.Contains("not found"), "Verify if toast message is included in current UI");
            }

            //Restore the test context: Unhide the configuration file
            Util.UnhideConfigFile();
        }

        [When(@"I select and play the demo content (.*)")]
        public void WhenISelectAndPlayTheDemoContent(string demoClipName)
        {
            contentSelView.SelectVideoClip(demoClipName);
            Assert.IsTrue(contentSelView.IsDetailViewDisplayed(), "Verify if the detail view pops up");

            detailView = new DetailView(Util.GetCurrentDriver());
            playbackView = detailView.StartPlayback();
        }

        [When(@"I press Home key")]
        public void WhenIPressHomeKey()
        {
            //Take a screenshot before pressing Home key
            ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT] = Util.TakeScreenshot();
            
            Util.PressHomeKey();

            Util.Sleep(6);
        }

        [When(@"I press Back key")]
        public void WhenIPressBackKey()
        {
            //Take a screenshot before pressing Back key
            ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT] = Util.TakeScreenshot();

            Util.PressBackKey();
        }

        [When(@"I set the app to foreground")]
        public void WhenISetTheAppToForeground()
        {
            Util.SetAppToForeground();

            Util.Sleep(1);

            ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT] = Util.TakeScreenshot();
        }

        [When(@"I lock the device for (.*) seconds and wake it up")]
        public void WhenILockTheDeviceForSeconds(int seconds)
        {
            //Remember current activity
            ScenarioContext.Current[KEY_LAST_ACTIVITY] = Util.GetCurrentDriver().CurrentActivity;

            //Lock the device for specified seconds
            Util.LockDevice(seconds);
        }

        [When(@"I select demo content (.*)")]
        public void WhenISelectDemoContent(string demoClipName)
        {
            contentSelView.SelectVideoClip(demoClipName);
        }

        [When(@"I press Play button")]
        public void WhenIPressPlayButton()
        {
            playbackView = detailView.StartPlayback();
        }

        [Then(@"I should see the detail view pop up")]
        public void ThenIShouldSeeTheDetailViewPopUp()
        {
            Assert.IsTrue(contentSelView.IsDetailViewDisplayed(), "Verify if the detail view pops up");

            detailView = new DetailView(Util.GetCurrentDriver());
        }

        [Then(@"I should see the audio attribute is ""(.*)""")]
        public void ThenIShouldSeeTheAudioAttributeIs(string value)
        {
            Assert.AreEqual(value, detailView.GetAudioInfo(),
                "Verify the value of audio attribute.");
        }

        [Then(@"I should see the video attribute is ""(.*)""")]
        public void ThenIShouldSeeTheVideoAttributeIs(string value)
        {
            Assert.AreEqual(value, detailView.GetVideoInfo(),
                            "Verify the value of video attribute.");
        }

        [Then(@"I should see the playback view pop up")]
        public void ThenIShouldSeeThePlaybackViewPopUp()
        {
            Assert.IsTrue(playbackView.IsPlaybackCtlDisplayed(), "Verify if playback view pops up");
        }

        [When(@"I rotate the device to (.*)")]
        public void WhenIRotateTheDeviceTo(string direction)
        {
            //Before rotate the device, take a screenshot
            ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT] = Util.TakeScreenshot();

            if (direction.ToUpper() == "PORTRAIT") {
                //Need to debug below method.
                //Util.SetOrientationToPortrait();  
            }
            else if (direction.ToUpper() == "LANDSCAPE") {
                //Util.SetOrientationToLandscape();
            }
            else {
                throw new Exception("The parameter cannot be resolved.");
            }
        }

        [Then(@"I should see the UI stay the same")]
        public void ThenIShouldSeeTheUIStayTheSame()
        {
            string strImgName = Util.TakeScreenshot();
            
            float result = Util.CompareScreenshots(ScenarioContext.Current[KEY_PATH_FOR_SCREENSHOT].ToString(), 
                                    strImgName);

            Assert.AreEqual(0.0, result, "Verify the UI stay the same by comparing the screenshots.");
        }


        [Then(@"the demo clip is being played back")]
        public void ThenTheDemoClipIsBeingPlayedBack()
        {
            Util.Sleep(8);

            Assert.IsTrue(playbackView.IsPlaying());
        }

        [Then(@"I should see following information appear in the detail view")]
        public void ThenIShouldSeeFollowingInformationAppearInTheDetailView(Table table)
        {
            TableRow row = table.Rows[0];

            string expectedTitleName = row["Video clip title"];
            string expectedAudioInfo = row["Audio"];
            string expectedVideoInfo = row["Video"];

            Assert.IsTrue(detailView.IsElementPresent(By.Name(expectedTitleName)),
                String.Format("Verify if title name {0} is shown in detail view", expectedTitleName));

            Assert.IsTrue(detailView.IsElementPresent(By.Name(expectedAudioInfo)),
                String.Format("Verify if audio info {0} is shown in detail view", expectedAudioInfo));

            Assert.IsTrue(detailView.IsElementPresent(By.Name(expectedVideoInfo)),
                String.Format("Verify if video info {0} is shown in detail view", expectedVideoInfo));
        }

        [Then(@"I should see playback control displayed")]
        public void ThenIShouldSeePlaybackControlDisplayed()
        {
            Assert.IsTrue(playbackView.IsPlaybackCtlDisplayed());
        }

        [When(@"after (.*) seconds")]
        public void WhenAfterSeconds(int seconds)
        {
            Util.Sleep(seconds);
        }

        [Then(@"after (.*) seconds")]
        public void ThenAfterSeconds(int seconds)
        {
            WhenAfterSeconds(seconds);
        }


        [Then(@"I should not see playback control display")]
        public void ThenIShouldNotSeePlaybackControlDisplay()
        {
            Assert.IsFalse(playbackView.IsPlaybackCtlDisplayed());
        }

        [When(@"I tap on screen")]
        public void WhenITapOnScreen()
        {
            playbackView.ShowPlaybackCtl();
        }

        [Then(@"the content should be played back")]
        public void ThenTheContentShouldBePlayedBack()
        {
            Assert.IsTrue(playbackView.IsPlaying());
        }

        [When(@"I tap on Back button")]
        public void WhenITapOnBackButton()
        {
            playbackView.PressBack();
        }

        [Then(@"after (.*) second")]
        public void ThenAfterSecond(int second)
        {
            Util.Sleep(second);
        }

        [When(@"I tap on Rewind button")]
        public void WhenITapOnRewindButton()
        {
            //Record current playback time before perform seek operaiton
            ScenarioContext.Current[KEY_CURRENT_TIME_BEFORE_SEEK] = playbackView.GetCurrentTimeToSeconds();

            playbackView.PressRewind();
        }

        [Then(@"the playback should go to (.*) seconds ago")]
        public void ThenThePlaybackShouldGoToSecondsAgo(int seconds)
        {
            //Record current playback time before perform seek operaiton
            int current_time = playbackView.GetCurrentTimeToSeconds();
            int current_time_before_seek = Convert.ToInt32(ScenarioContext.Current[KEY_CURRENT_TIME_BEFORE_SEEK].ToString());
            int time_difference = current_time_before_seek - current_time;

            Console.WriteLine(current_time);
            Console.WriteLine(current_time_before_seek);
            Console.WriteLine(time_difference);

            Assert.IsTrue(time_difference<=seconds, "Verify if the playback goes to specified position.");
        }

        [When(@"I press PlayPause button")]
        public void WhenIPressPlayPauseButton()
        {
            playbackView.PressPlayPause();
        }

        [Then(@"the content should not be played back")]
        public void ThenTheContentShouldNotBePlayedBack()
        {
            Assert.IsFalse(playbackView.IsPlaying(), 
                           "Verify the content should not be played back, it's in PAUSE state.");
        }

    }
}
