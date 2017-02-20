Feature: UpdateBuilding
	為提供 ORM 在 Update 操作時
	建立設定值
	提供對應字串及參數

Scenario: 以字串設定-單一欄位
	Given 更新欄位 ID 值為 3752 的設定
	When 要求取得更新字串及參數
	Then 得到更新語法 [ID] = @ID_1 
		And 得到更新參數集合
			| Key   | Value |
			| @ID_1 | 3752  |		 

