using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;

using RubyAndroidPlayerTest.SUT.Common;

namespace RubyAndroidPlayerTest.SUT.UI
{
    public class ContentSelectionView: BaseUI
    {
        public ContentSelectionView(AndroidDriver<AndroidElement> d)
            : base(d)
        {

        }

        public void SelectVideoClip(string clipName)
        {
            AndroidElement element = null;
            bool isEndOfList = false;
            string lastScreenshot = null;

            do
            {
                element = this.FindElement(By.Name(clipName));
                if (element == null)
                {
                    //Swipe to left screen
                    SwipeToLeft();

                    Util.Sleep(1);

                    //Check if this is the last screen swipe operation
                    if (lastScreenshot == null)
                    {
                        lastScreenshot = Util.TakeScreenshot();
                    }
                    else
                    {
                        string currentScreenshot = Util.TakeScreenshot();
                        if (Util.CompareScreenshots(lastScreenshot, currentScreenshot)!=0)
                        {
                            lastScreenshot = currentScreenshot;
                        }
                        else
                        {
                            isEndOfList = true;
                        }
                    }
                }
            } while ((element==null)&&(isEndOfList != true));

            if (element != null)
            {
                element.Click();
            }
            else
            {
                throw new Exception("Can't locate the element of specified video clip");
            }
        }

        public bool IsDetailViewDisplayed()
        {
            AndroidElement element = FindElement(By.Id("rl_detail_view_board"));
            if((element!=null)&&(element.Displayed))
                return true;
            else
                return false;
        }

        public bool IsContentSelViewDisplayed()
        {
            if (IsElementPresent(By.Name("Movie and Video Clips")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSplashScreenDisplayed()
        { 
            if(IsElementPresent(By.Name("Dolby Atmos and Dolby Vision Demo")))
            {
                return true;
            }else
            {
                return false;
            }
        }   

        public DetailView GetDetailView()
        {
            if (IsDetailViewDisplayed())
                return new DetailView(this.driver);
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SwipeToLeft()
        {
            int startX = 350;
            int startY = Util.GetCurrentDriver().Manage().Window.Size.Width / 2;

            TouchAction gesture = new TouchAction(this.driver);
            gesture.Press(startX, startY)
                    .MoveTo(-40, 0) //Offset to the last position of x, y, move to (startX-40, 0)
                    .Release().Perform();
        }

        public void SwipeToRight()
        {
            int startX = 350;
            int startY = Util.GetCurrentDriver().Manage().Window.Size.Width / 2;

            TouchAction gesture = new TouchAction(this.driver);
            gesture.Press(startX, startY)
                    .MoveTo(40, 0)  //Offset to the last position of x, y, move to (startX + 40, 0)
                    .Release().Perform();
        }

        public void ScrollBackToStart()
        {
            bool isStartOfList = false;
            string lastScreenshot = null;

            do
            {
                //Swipe to left screen
                SwipeToRight();

                Util.Sleep(1);

                //Check if this is the last screen swipe operation
                if (lastScreenshot == null)
                {
                    lastScreenshot = Util.TakeScreenshot();
                }
                else
                {
                    string currentScreenshot = Util.TakeScreenshot();
                    if (Util.CompareScreenshots(lastScreenshot, currentScreenshot) != 0)
                    {
                        lastScreenshot = currentScreenshot;
                    }
                    else
                    {
                        isStartOfList = true;
                    }
                 }
            } while (isStartOfList != true);

        }

        public void CloseDetailView()
        {
            Util.PressBackKey();
        }
    }
}
