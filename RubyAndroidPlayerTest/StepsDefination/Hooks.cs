using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

using RubyAndroidPlayerTest.SUT.Common;

namespace RubyAndroidPlayerTest.StepsDefination
{
    [Binding]
    public sealed class Hooks
    {
        private static bool isFirstScenario = true;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeFeature]
        public static void BeforeFeature()
        {
            Util.CreateDriver();

            Util.SetOrientationToLandscape();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if (!isFirstScenario)
            {
                Util.GetCurrentDriver().ResetApp();
            }
            else
            {
                isFirstScenario = false;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Util.SetOrientationToLandscape();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Util.GetCurrentDriver().Quit();
        }
    }
}
