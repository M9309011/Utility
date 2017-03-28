using System.Collections.Generic;
using TOHU.Toolbox.Utility.AOP_Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Utility_UT.Utility.AOP
{
    [Binding]
    public sealed class 提供函式橫切需求建立
    {

        [Given(@"清空呼叫佇列")]
        public void Given清空呼叫佇列()
        {
            TOHU.Toolbox.Utility.AOP_Mock.CallStacks.Reset();
        }

        [Given(@"建立包含橫向需求方法的類別實體")]
        public void Given建立包含橫向需求方法的類別實體()
        {
            ScenarioContext.Current.Set<ContextTarget>(new ContextTarget(), "Target");
        }

        [When(@"執行未指定橫向需求的方法")]
        public void When執行未指定橫向需求的方法()
        {
            ScenarioContext.Current.Get<ContextTarget>("Target").DoSomethingWithNotSetting();
        }

        [When(@"執行標示執行前橫向需求的方法")]
        public void When執行標示執行前橫向需求的方法()
        {
            ScenarioContext.Current.Get<ContextTarget>("Target").DoSomethingWithPreProcess();
        }

        [When(@"執行標示執行後橫向需求的方法")]
        public void When執行標示執行後橫向需求的方法()
        {
            ScenarioContext.Current.Get<ContextTarget>("Target").DoSomethingWithPostProcess();
        }

        [When(@"執行標示執行前及執行後橫向需求的方法")]
        public void When執行標示執行前及執行後橫向需求的方法()
        {
            ScenarioContext.Current.Get<ContextTarget>("Target").DoSomethingWithBothPreAndPostProcessor();
        }
        
        [Then(@"呼叫佇列儲存的執行順序是")]
        public void Then呼叫佇列儲存的執行順序是(Table table)
        {
            Queue<string> objCalls = CallStacks.GetCalls();

            foreach (TableRow objRow in table.Rows)
            {
                Assert.AreEqual(objRow["CallStack"], objCalls.Dequeue());
            }
        }

    }
}
