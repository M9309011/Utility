Feature: 提供函式橫切需求建立
	提供使用者可自訂橫切需求。

	橫切需求區分為函式執行前及函式執行後兩類。

	◆ 橫向需求套用步驟：

		1. 使用者先實做介面以自訂執行內容。
			
			◇ 函式執行前：TOHU.Toolbox.Utility.AOP.IPreProcessor

			◇ 函式執行後：TOHU.Toolbox.Utility.AOP.IPostProcessor

		2. 然後再需要的函式前加上 Attribute 標籤。
			
			◇ 函式執行前： [TOHU.Toolbox.Utility.AOP.PreProcess(typeof( [PreProcessor] ))]

			◇ 函式執行後： [TOHU.Toolbox.Utility.AOP.PostProcess(typeof( [PostProcessor] ))]

Background: 
	Given 清空呼叫佇列
		And 建立包含橫向需求方法的類別實體

Scenario: 函式未包含橫向需求
	When 執行未指定橫向需求的方法
	Then 呼叫佇列儲存的執行順序是
	| CallStack   |
	| DoSomething |

Scenario: 函式標示執行前橫向需求	
	When 執行標示執行前橫向需求的方法
	Then 呼叫佇列儲存的執行順序是
	| CallStack   |
	| PreProcess  |
	| DoSomething |

Scenario: 函式標示執行後橫向需求
	When 執行標示執行後橫向需求的方法
	Then 呼叫佇列儲存的執行順序是
	| CallStack   |
	| DoSomething |
	| PostProcess |

Scenario: 函式標示執行前及執行後橫向需求
	When 執行標示執行前及執行後橫向需求的方法
	Then 呼叫佇列儲存的執行順序是
	| CallStack   |
	| PreProcess  |
	| DoSomething |
	| PostProcess |