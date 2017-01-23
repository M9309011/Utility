Feature: InterceptProcess	
	為提供橫切式需求
	建立 AOP 函式庫
	提供函式呼叫前後的執行呼叫

Scenario: 函式呼叫前執行自定程序
	Given 我先清空呼叫佇列
	When 執行DoSomethingAndPreProcess方法
	Then 執行順序是
	| CallStack   |
	| PreProcess  |
	| DoSomething |

Scenario: 函式呼叫後執行自定程序
	Given 我先清空呼叫佇列
	When 執行DoSomethingAndPostProcess方法
	Then 執行順序是
	| CallStack   |
	| DoSomething |
	| PostProcess |

Scenario: 函式呼叫前後執行自定程序
	Given 我先清空呼叫佇列
	When 執行DoSomethingAndPreProcessAndPostProcess方法
	Then 執行順序是
	| CallStack   |
	| PreProcess  |
	| DoSomething |
	| PostProcess |