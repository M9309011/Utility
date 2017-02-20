Feature: ParameterCollection
	為提供關連資料物的生成／刪除／更新 動作
	一致的參數
	提供參數物件集中管理


Scenario: 設定條件式
	Given 自訂篩選條件式 Condition_1
		And 將篩選條件式設定給參數集
	When 向參數集要條件式時
	Then 取回原來的篩選條件式 Condition_1

Scenario: 一次設定二組條件式時取最後一組設定
	Given 自訂二組篩選條件式 Condition_1 以及 Condition_2
	And 將二個篩選條件式一次設定給參數集
	When 向參數集要條件式時
	Then 取回原來的篩選條件式 Condition_2

Scenario: 重覆設定條件式時取最後一組設定
	Given 自訂篩選條件式 Condition_1
		And 將篩選條件式設定給參數集
		And 重覆設定參數集的條件式 Condition_2
	When 向參數集要條件式時
	Then 取回原來的篩選條件式 Condition_2

Scenario: 設定更新值
	Given 自訂更新資訊 SetValue
	And 將更新資訊設定給參數集
	When 向參數集要更新資訊時
	Then 取回原來的更新資訊 SetValue

Scenario: 一次設定二組更新資訊時取最後一組設定
	Given 自訂二組更新資訊 SetValue1 以及 SetValue2
	And 將二個更新資訊一次設定給參數集
	When 向參數集要更新資訊時
	Then 取回原來的更新資訊 SetValue2

Scenario: 重覆設定更新資訊時取最後一組設定
	Given 自訂更新資訊 SetValue1
	And 將更新資訊設定給參數集
	And 重覆設定參數集的更新資訊 SetValue2
	When 向參數集要更新資訊時
	Then 取回原來的更新資訊 SetValue2
