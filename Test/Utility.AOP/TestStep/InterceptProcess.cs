using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TOHU.Toolbox.Utility.AOP_UT;

namespace TOHU.Toolbox.Utility.AOP_UT.TestStep
{
    [Binding]
    internal sealed class InterceptProcess
    {
        [Given(@"我先清空呼叫佇列")]
        public void Given我先清空呼叫佇列()
        {
            CallStacks.Reset();
        }

        [When(@"執行DoSomethingAndPreProcess方法")]
        public void When執行DoSomethingAndPreProcess方法()
        {
            ContextTarget objTarget = new ContextTarget();

            objTarget.DoSomethingAndPreProcess();
        }

        [When(@"執行DoSomethingAndPostProcess方法")]
        public void When執行DoSomethingAndPostProcess方法()
        {
            ContextTarget objTarget = new ContextTarget();

            objTarget.DoSomethingAndPostProcess();
        }

        [When(@"執行DoSomethingAndPreProcessAndPostProcess方法")]
        public void When執行DoSomethingAndPreProcessAndPostProcess方法()
        {
            ContextTarget objTarget = new ContextTarget();

            objTarget.DoSomethingAndPreProcessAndPostProcess();
        }

        [Then(@"執行順序是")]
        public void Then執行順序是(Table table)
        {
            Queue<string> objCalls = CallStacks.GetCalls();
            foreach (TableRow objRow in table.Rows)
            {
                Assert.AreEqual(objRow["CallStack"], objCalls.Dequeue());
            }
        }       
    }
}
