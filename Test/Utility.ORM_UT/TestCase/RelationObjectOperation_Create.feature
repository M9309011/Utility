Feature: RelationObjectOperation_Create
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario Outline: 新增關連資料物件清單
	Given 來源關連資料物件清單
	| ID   | Name |
	| 3752 | TOHU |
	| 0001 | ALL  |

	When 要求在 <TableName> 資料表建立記錄
	Then 取得 2 筆客戶關連資料物件
		| ID   | Name |
		| 3752 | TOHU |
		| 0001 | ALL  |
	And 資料庫代理接收到語法 <SQL>
	Examples: 
	| TableName | SQL                    |
	| Custom    | SELECT * FROM Custom   |
	| Employee  | SELECT * FROM Employee |

