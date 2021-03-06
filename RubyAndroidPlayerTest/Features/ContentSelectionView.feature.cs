﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RubyAndroidPlayerTest.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Content selection view")]
    public partial class ContentSelectionViewFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ContentSelectionView.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Content selection view", "As a demo representative\r\nI want to show content selection view by default when I" +
                    " start the app\r\nSo I can view all video clips I am going to demo to customers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Default elements in content sel view")]
        [NUnit.Framework.CategoryAttribute("RU_11")]
        public virtual void DefaultElementsInContentSelView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Default elements in content sel view", new string[] {
                        "RU_11"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I am in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Then("I should see the text Movie and Video Clips displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("In content sel view, rotate the device")]
        [NUnit.Framework.CategoryAttribute("RU_12")]
        public virtual void InContentSelViewRotateTheDevice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("In content sel view, rotate the device", new string[] {
                        "RU_12"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("I am in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.When("I rotate the device to Portrait", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("I should see the UI stay the same", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Scroll video clips")]
        [NUnit.Framework.CategoryAttribute("RU_13")]
        public virtual void ScrollVideoClips()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Scroll video clips", new string[] {
                        "RU_13"});
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("I am in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Video clip title"});
            table1.AddRow(new string[] {
                        "Deep Look"});
            table1.AddRow(new string[] {
                        "NBA"});
            table1.AddRow(new string[] {
                        "Homeland"});
            table1.AddRow(new string[] {
                        "English Premier League"});
#line 20
 testRunner.And("I have following video clips in metadata file", ((string)(null)), table1, "And ");
#line 26
 testRunner.Then("I should see those video clips listed in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Tap on the demo clip")]
        [NUnit.Framework.CategoryAttribute("RU_14")]
        public virtual void TapOnTheDemoClip()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Tap on the demo clip", new string[] {
                        "RU_14"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I am in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.When("I select demo content NBA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("I should see the detail view pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Metadata file is missing")]
        [NUnit.Framework.CategoryAttribute("RU_16")]
        public virtual void MetadataFileIsMissing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Metadata file is missing", new string[] {
                        "RU_16"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("The metadata file is missing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.When("I launch Dolby demo app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("I should be in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("I should see a toast message Metadata file not found pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Metadata file content is invalid")]
        [NUnit.Framework.CategoryAttribute("RU_17")]
        public virtual void MetadataFileContentIsInvalid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Metadata file content is invalid", new string[] {
                        "RU_17"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("The metadata file is incorrect", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.When("I launch Dolby demo app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("I should be in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("I should see the text No this kind of media on the device. displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("In content sel view, lock and unlock device")]
        [NUnit.Framework.CategoryAttribute("RU_18")]
        public virtual void InContentSelViewLockAndUnlockDevice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("In content sel view, lock and unlock device", new string[] {
                        "RU_18"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I am in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.When("I lock the device for 4 seconds and wake it up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then("I should be in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.And("I should see the text Movie and Video Clips displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Set the app from background to foreground")]
        [NUnit.Framework.CategoryAttribute("RU_61")]
        public virtual void SetTheAppFromBackgroundToForeground()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Set the app from background to foreground", new string[] {
                        "RU_61"});
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
 testRunner.Given("I am in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
 testRunner.When("I press Home key", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.And("I set the app to foreground", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("I should be in content selection view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.And("I should see the UI stay the same", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
