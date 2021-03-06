﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TOHU.Toolbox.Utility.ORM_Mock.TestCase
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ConditionBuilding")]
    public partial class ConditionBuildingFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ConditionBuilding.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ConditionBuilding", "為提供 ORM 在 Query, Delete, Update 操作時\r\n建立條件\r\n提供對應條件字串及參數功能", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("使用字串設定單一條件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用字串設定單一條件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用字串設定單一條件", new string[] {
                        "ConditionBuilding"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("欄位 ID 等於 3752", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("得到語法 [ID] = @ID_1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table1.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
#line 11
  testRunner.And("得到參數集合", ((string)(null)), table1, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("使用字串設定多個條件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用字串設定多個條件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用字串設定多個條件", new string[] {
                        "ConditionBuilding"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("欄位 ID 等於 3752", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
  testRunner.And("以及欄位 Name 等於 TOHU", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table2.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table2.AddRow(new string[] {
                        "@Name_2",
                        "TOHU"});
#line 20
  testRunner.And("得到參數集合", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("使用字串同時設定多個條件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用字串同時設定多個條件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用字串同時設定多個條件", new string[] {
                        "ConditionBuilding"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("同時將欄位 ID 等於 3752 以及欄位 Name 等於 TOHU", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table3.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table3.AddRow(new string[] {
                        "@Name_2",
                        "TOHU"});
#line 30
  testRunner.And("得到參數集合", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("使用屬性一次設定多個條件-在取得字串及參數時才指定資料來源物件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用屬性一次設定多個條件_在取得字串及參數時才指定資料來源物件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用屬性一次設定多個條件-在取得字串及參數時才指定資料來源物件", new string[] {
                        "ConditionBuilding"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table4.AddRow(new string[] {
                        "3752",
                        "TOHU"});
#line 37
 testRunner.Given("條件來源物件", ((string)(null)), table4, "Given ");
#line 40
  testRunner.And("同時將類別 CustomObject 屬性 Initial 以及屬性 Name 設定為條件", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("要求來源物件 1 取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table5.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table5.AddRow(new string[] {
                        "@Name_2",
                        "TOHU"});
#line 43
 testRunner.And("得到參數集合", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("使用屬性分次設定多個條件-在取得字串及參數時才指定資料來源物件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用屬性分次設定多個條件_在取得字串及參數時才指定資料來源物件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用屬性分次設定多個條件-在取得字串及參數時才指定資料來源物件", new string[] {
                        "ConditionBuilding"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table6.AddRow(new string[] {
                        "3752",
                        "TOHU"});
#line 50
 testRunner.Given("條件來源物件", ((string)(null)), table6, "Given ");
#line 53
  testRunner.And("類別 CustomObject 屬性 Initial 設定為條件", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
  testRunner.And("以及類別 CustomObject 屬性 Name 設定為條件", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("要求來源物件 1 取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table7.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table7.AddRow(new string[] {
                        "@Name_2",
                        "TOHU"});
#line 57
 testRunner.And("得到參數集合", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("使用屬性分次設定多個條件-在設定時即指定採用不同資料來源")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用屬性分次設定多個條件_在設定時即指定採用不同資料來源()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用屬性分次設定多個條件-在設定時即指定採用不同資料來源", new string[] {
                        "ConditionBuilding"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table8.AddRow(new string[] {
                        "3752",
                        "TOHU"});
#line 64
 testRunner.Given("條件來源物件", ((string)(null)), table8, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table9.AddRow(new string[] {
                        "0001",
                        "ALL"});
#line 67
  testRunner.And("條件來源物件", ((string)(null)), table9, "And ");
#line 70
  testRunner.And("類別 CustomObject 屬性 Initial 設定為條件，採用第 1 個資料來源", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
  testRunner.And("以及類別 CustomObject 屬性 Name 設定為條件，採用第 2 個資料來源", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table10.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table10.AddRow(new string[] {
                        "@Name_2",
                        "ALL"});
#line 74
 testRunner.And("得到參數集合", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("使用屬性分次設定多個條件-部分在設定時指定資料來源-部分採用預設資料")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 使用屬性分次設定多個條件_部分在設定時指定資料來源_部分採用預設資料()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("使用屬性分次設定多個條件-部分在設定時指定資料來源-部分採用預設資料", new string[] {
                        "ConditionBuilding"});
#line 80
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table11.AddRow(new string[] {
                        "3752",
                        "TOHU"});
#line 81
 testRunner.Given("條件來源物件", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table12.AddRow(new string[] {
                        "0001",
                        "ALL"});
#line 84
  testRunner.And("條件來源物件", ((string)(null)), table12, "And ");
#line 87
  testRunner.And("類別 CustomObject 屬性 Initial 設定為條件，採用第 1 個資料來源", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
  testRunner.And("以及類別 CustomObject 屬性 Name 設定為條件", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When("要求來源物件 2 取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table13.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table13.AddRow(new string[] {
                        "@Name_2",
                        "ALL"});
#line 91
 testRunner.And("得到參數集合", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("混用字串及屬性設定條件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 混用字串及屬性設定條件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("混用字串及屬性設定條件", new string[] {
                        "ConditionBuilding"});
#line 97
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Initial",
                        "Name"});
            table14.AddRow(new string[] {
                        "0001",
                        "ALL"});
#line 98
 testRunner.Given("條件來源物件", ((string)(null)), table14, "Given ");
#line 101
  testRunner.And("欄位 ID 等於 3752", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
  testRunner.And("以及類別 CustomObject 屬性 Name 設定為條件，採用第 1 個資料來源", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("得到語法 [ID] = @ID_1 AND [Name] = @Name_2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table15.AddRow(new string[] {
                        "@ID_1",
                        "3752"});
            table15.AddRow(new string[] {
                        "@Name_2",
                        "ALL"});
#line 105
 testRunner.And("得到參數集合", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("括號框住單一資料來源單一欄位")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 括號框住單一資料來源單一欄位()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("括號框住單一資料來源單一欄位", new string[] {
                        "ConditionBuilding"});
#line 111
this.ScenarioSetup(scenarioInfo);
#line 112
 testRunner.Given("括號框住欄位 ID 等於 3752", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
 testRunner.Then("得到語法 ( [ID] = @ID_1_1 )", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table16.AddRow(new string[] {
                        "@ID_1_1",
                        "3752"});
#line 115
  testRunner.And("得到參數集合", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("多個括號框住單一條件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 多個括號框住單一條件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("多個括號框住單一條件", new string[] {
                        "ConditionBuilding"});
#line 120
this.ScenarioSetup(scenarioInfo);
#line 121
 testRunner.Given("括號分別框住第一組條件欄位 ID 等於 3752 以及第二組欄位 ID 等於 0001", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
 testRunner.Then("得到語法 ( [ID] = @ID_1_1 ) AND ( [ID] = @ID_1_2 )", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table17.AddRow(new string[] {
                        "@ID_1_1",
                        "3752"});
            table17.AddRow(new string[] {
                        "@ID_1_2",
                        "0001"});
#line 124
 testRunner.And("得到參數集合", ((string)(null)), table17, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("多個括號框住多個條件")]
        [NUnit.Framework.CategoryAttribute("ConditionBuilding")]
        public virtual void 多個括號框住多個條件()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("多個括號框住多個條件", new string[] {
                        "ConditionBuilding"});
#line 130
this.ScenarioSetup(scenarioInfo);
#line 131
 testRunner.Given("括號分別框住第一組條件欄位 ID 等於 3752 及 Name 欄位等於 TOHU 與第二組條件欄位 ID 等於 0001 及 Name 欄位等於 ALL 且以 " +
                    "OR 邏輯運算元串接括號", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 132
 testRunner.When("要求取得字串及參數", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
 testRunner.Then("得到語法 ( [ID] = @ID_1_1 AND [Name] = @Name_2_1 ) OR ( [ID] = @ID_1_2 AND [Name] = @" +
                    "Name_2_2 )", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Value"});
            table18.AddRow(new string[] {
                        "@ID_1_1",
                        "3752"});
            table18.AddRow(new string[] {
                        "@Name_2_1",
                        "TOHU"});
            table18.AddRow(new string[] {
                        "@ID_1_2",
                        "0001"});
            table18.AddRow(new string[] {
                        "@Name_2_2",
                        "ALL"});
#line 134
 testRunner.And("得到參數集合", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
