Feature: RelationObjectOperator
	提供關連資料物件操作。

@RelationObjectOperator
Scenario: 取得指定的關連資料物件	
	Given 資料表 Custom 資料表符合條件的記錄
		| ID   | Name |
		| 3752 | TOHU |				
	When 要求取得欄位 ID 為 3752 的 CustomObject 關連資料物件
	Then 取得 CustomObject 資料物件
			| ID   | Name |
			| 3752 | TOHU |
		And 得到執行語法 SELECT * FROM Custom WHERE [ID] = @ID_1
		And 得到查詢參數集合包含
			| Key   | Value |
			| @ID_1 | 3752  |

@RelationObjectOperator
Scenario: 新增指定的關連資料物件
	Given 關連資料物件集合
		| ID   | Name |
		| 3752 | TOHU |
		| 0001 | ALL  |  
	When 要求新增關連資料物件
	Then 得到執行語法 INSERT INTO [Custom] ( [ID], [Name] ) VALUES ( @ID, @Name )
		And 得到參數集合包含
			| Key   | Value |
			| @ID   | 3752  |
			| @Name | TOHU  |
		And 得到參數集合包含
			| Key   | Value |
			| @ID   | 0001  |
			| @Name | ALL   |

@RelationObjectOperator
Scenario: 刪除指定的關連資料物件
	Given 關連資料物件集合
		| ID   | Name |
		| 3752 | TOHU |
		| 0001 | ALL  |
		And 條件為欄位 ID
	When 要求刪除關連資料物件
	Then 得到執行語法 DELETE FROM [Custom] WHERE [ID] = @ID_1
		And 得到參數集合包含
			| Key   | Value |
			| @ID_1 | 3752  |
		And 得到參數集合包含
			| Key   | Value |
			| @ID_1 | 0001  |	

@RelationObjectOperator
Scenario: 更新指定的關連資料物件
	Given 關連資料物件集合
		| ID   | Name |
		| 3752 | TOHU |
		| 0001 | ALL  |
		And 條件為欄位 ID 
		And 更新欄位 Name
	When 要求更新關連資料物件
	Then 得到執行語法 UPDATE [Custom] SET ( [Name] = @Name_1 ) WHERE [ID] = @ID_1
		And 得到參數集合包含
			| Key     | Value |
			| @ID_1   | 3752  |
			| @Name_1 | TOHU  |
		And 得到參數集合包含
			| Key     | Value |
			| @ID_1   | 0001  |
			| @Name_1 | ALL   |

@RelationObjectOperator
Scenario: 無條件式更新指定的關連資料物件
	Given 關連資料物件集合
		| ID   | Name |
		| 3752 | TOHU |
		| 0001 | ALL  |		
		And 更新欄位 Name
	When 要求更新關連資料物件
	Then 得到執行語法 UPDATE [Custom] SET ( [Name] = @Name_1 )
		And 得到參數集合包含
			| Key     | Value |
			| @Name_1 | TOHU  |
		And 得到參數集合包含
			| Key     | Value |
			| @Name_1 | ALL   |		 

@RelationObjectOperator
Scenario: 無條件式取得指定的關連資料物件	
	Given 資料表 Custom 資料表符合條件的記錄
		| ID   | Name |
		| 3752 | TOHU |				
	When 要求取得 Custom 關連資料物件
	Then 取得 CustomObject 資料物件
			| ID   | Name |
			| 3752 | TOHU |
		And 得到執行語法 SELECT * FROM Custom

@RelationObjectOperator
Scenario: 無條件刪除指定的關連資料物件
	Given 關連資料物件集合
		| ID   | Name |
		| 3752 | TOHU |
		| 0001 | ALL  |		
	When 要求刪除關連資料物件
	Then 得到執行語法 DELETE FROM [Custom]
					