Feature: RelationObjectOperator
	提供關連資料物件操作。

@RelationObjectOperator
Scenario: 取得指定的關連資料物件			
	When 要求取得欄位 ID 為 3752 的 CustomObject 關連資料物件
	Then 取得 CustomObject 資料物件
			| Initial | Name |
			| 3752    | TOHU |
		And 得到執行語法 SELECT * FROM Custom WHERE [ID] = @ID_1
		And 得到查詢參數集合包含
			| Key   | Value |
			| @ID_1 | 3752  |

@RelationObjectOperator
Scenario: 新增指定的關連資料物件
	Given 關連資料物件集合
		| Initial | Name |
		| 0005    | CEHS |
		| 0006    | RICH |
	When 要求新增關連資料物件
	Then 得到執行語法 INSERT INTO [Custom] ( [ID], [Name] ) VALUES ( @ID, @Name )
		And 得到參數集合包含
			| Key   | Value |
			| @ID   | 0005  |
			| @Name | CEHS  |
		And 得到參數集合包含
			| Key   | Value |
			| @ID   | 0006  |
			| @Name | RICH  |

@RelationObjectOperator
Scenario: 刪除指定的關連資料物件
	Given 關連資料物件集合
		| Initial | Name |
		| 3752    | TOHU |
		| 0001    | ALL  |
		| 0002    | MTEC |
		And 條件為欄位 Initial
	When 要求刪除關連資料物件
	Then 得到執行語法 DELETE FROM [Custom] WHERE [ID] = @ID_1
		And 得到參數集合包含
			| Key   | Value |
			| @ID_1 | 3752  |
		And 得到參數集合包含
			| Key   | Value |
			| @ID_1 | 0001  |
		And 得到參數集合包含
			| Key   | Value |
			| @ID_1 | 0002  |

@RelationObjectOperator
Scenario: 更新指定的關連資料物件
	Given 關連資料物件集合
		| Initial | Name |
		| 0002    | TOHU |
		| 0003    | ALL  |
		And 條件為欄位 Initial 
		And 更新欄位 Name
	When 要求更新關連資料物件
	Then 得到執行語法 UPDATE [Custom] SET [Name] = @Name_U1 WHERE [ID] = @ID_1
		And 得到參數集合包含
			| Key      | Value |
			| @ID_1    | 0002  |
			| @Name_U1 | TOHU  |
		And 得到參數集合包含
			| Key      | Value |
			| @ID_1    | 0003  |
			| @Name_U1 | ALL   |

@RelationObjectOperator
Scenario: 更新欄位與條件欄位相同
	Given 建立關連資料物件集合項目
		| Initial | Name |
		| 0002    | TOHU |
		And 條件為欄位 Initial 
		And 更新 ID 欄位為 1000
	When 要求更新關連資料物件
	Then 得到執行語法 UPDATE [Custom] SET [ID] = @ID_U1 WHERE [ID] = @ID_1
		And 得到參數集合包含
			| Key    | Value |
			| @ID_U1 | 1000  |
			| @ID_1  | 0002  |
	
@RelationObjectOperator
Scenario: 無條件式更新指定的關連資料物件
	Given 關連資料物件集合
		| Initial | Name |
		| 3752    | TOHU |
		| 0001    | ALL  |
		And 更新欄位 Name
	When 要求更新關連資料物件
	Then 得到執行語法 UPDATE [Custom] SET [Name] = @Name_U1
		And 得到參數集合包含
			| Key      | Value |
			| @Name_U1 | TOHU  |
		And 得到參數集合包含
			| Key      | Value |
			| @Name_U1 | ALL   |	 

@RelationObjectOperator
Scenario: 無條件式取得指定的關連資料物件			
	When 要求取得 Custom 關連資料物件
	Then 取得 CustomObject 資料物件
			| Initial | Name |
			| 3752    | TOHU |
			| 0001    | ALL  |
			| 0002    | MTEC |
			| 0003    | ETSH |
		And 得到執行語法 SELECT * FROM Custom

@RelationObjectOperator
Scenario: 無條件刪除指定的關連資料物件
	Given 關連資料物件集合
		| Initial | Name |
		| 3752    | TOHU |
		| 0001    | ALL  |	
	When 要求刪除關連資料物件
	Then 得到執行語法 DELETE FROM [Custom]
					