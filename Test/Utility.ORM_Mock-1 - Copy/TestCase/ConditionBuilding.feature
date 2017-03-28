Feature: ConditionBuilding
	為提供 ORM 在 Query, Delete, Update 操作時
	建立條件
	提供對應條件字串及參數功能

@ConditionBuilding
Scenario:使用字串設定單一條件	
	Given 欄位 ID 等於 3752
	When 要求取得字串及參數
	Then 得到語法 [ID] = @ID_1 
		And 得到參數集合
			| Key   | Value |
			| @ID_1 | 3752  |	
@ConditionBuilding
Scenario:使用字串設定多個條件
	Given 欄位 ID 等於 3752
		And 以及欄位 Name 等於 TOHU
	When 要求取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
		And 得到參數集合
			| Key     | Value |
			| @ID_1   | 3752  |
			| @Name_2 | TOHU  |

@ConditionBuilding
Scenario:使用字串同時設定多個條件
	Given 同時將欄位 ID 等於 3752 以及欄位 Name 等於 TOHU
	When 要求取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
		And 得到參數集合
			| Key     | Value |
			| @ID_1   | 3752  |
			| @Name_2 | TOHU  |

@ConditionBuilding
Scenario: 使用屬性一次設定多個條件-在取得字串及參數時才指定資料來源物件
	Given 條件來源物件
		| Initial | Name |
		| 3752    | TOHU |
		And 同時將類別 CustomObject 屬性 Initial 以及屬性 Name 設定為條件	
	When 要求來源物件 1 取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
	And 得到參數集合
	| Key     | Value |
	| @ID_1   | 3752  |
	| @Name_2 | TOHU  |

@ConditionBuilding
Scenario: 使用屬性分次設定多個條件-在取得字串及參數時才指定資料來源物件
	Given 條件來源物件
		| Initial | Name |
		| 3752    | TOHU |
		And 類別 CustomObject 屬性 Initial 設定為條件
		And 以及類別 CustomObject 屬性 Name 設定為條件	
	When 要求來源物件 1 取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
	And 得到參數集合
	| Key     | Value |
	| @ID_1   | 3752  |
	| @Name_2 | TOHU  |

@ConditionBuilding
Scenario: 使用屬性分次設定多個條件-在設定時即指定採用不同資料來源
	Given 條件來源物件
		| Initial | Name |
		| 3752    | TOHU |
		And 條件來源物件
		| Initial | Name |
		| 0001    | ALL  |
		And 類別 CustomObject 屬性 Initial 設定為條件，採用第 1 個資料來源
		And 以及類別 CustomObject 屬性 Name 設定為條件，採用第 2 個資料來源
	When 要求取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
	And 得到參數集合
	| Key     | Value |
	| @ID_1   | 3752  |
	| @Name_2 | ALL   |

@ConditionBuilding
Scenario: 使用屬性分次設定多個條件-部分在設定時指定資料來源-部分採用預設資料
	Given 條件來源物件
		| Initial | Name |
		| 3752    | TOHU |
		And 條件來源物件
		| Initial | Name |
		| 0001    | ALL  |
		And 類別 CustomObject 屬性 Initial 設定為條件，採用第 1 個資料來源
		And 以及類別 CustomObject 屬性 Name 設定為條件	
	When 要求來源物件 2 取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
	And 得到參數集合
	| Key     | Value |
	| @ID_1   | 3752  |
	| @Name_2 | ALL   |

@ConditionBuilding
Scenario: 混用字串及屬性設定條件
	Given 條件來源物件
		| Initial | Name |
		| 0001    | ALL  |
		And 欄位 ID 等於 3752
		And 以及類別 CustomObject 屬性 Name 設定為條件，採用第 1 個資料來源
	When 要求取得字串及參數
	Then 得到語法 [ID] = @ID_1 AND [Name] = @Name_2
	And 得到參數集合
	| Key     | Value |
	| @ID_1   | 3752  |
	| @Name_2 | ALL   |

@ConditionBuilding
Scenario:括號框住單一資料來源單一欄位
	Given 括號框住欄位 ID 等於 3752
	When 要求取得字串及參數
	Then 得到語法 ( [ID] = @ID_1_1 )
		And 得到參數集合
			| Key     | Value |
			| @ID_1_1 | 3752  |

@ConditionBuilding
Scenario:多個括號框住單一條件
	Given 括號分別框住第一組條件欄位 ID 等於 3752 以及第二組欄位 ID 等於 0001
	When 要求取得字串及參數
	Then 得到語法 ( [ID] = @ID_1_1 ) AND ( [ID] = @ID_1_2 )
	And 得到參數集合
	| Key     | Value |
	| @ID_1_1 | 3752  |
	| @ID_1_2 | 0001  |

@ConditionBuilding
Scenario:多個括號框住多個條件
	Given 括號分別框住第一組條件欄位 ID 等於 3752 及 Name 欄位等於 TOHU 與第二組條件欄位 ID 等於 0001 及 Name 欄位等於 ALL 且以 OR 邏輯運算元串接括號
	When 要求取得字串及參數
	Then 得到語法 ( [ID] = @ID_1_1 AND [Name] = @Name_2_1 ) OR ( [ID] = @ID_1_2 AND [Name] = @Name_2_2 )
	And 得到參數集合
	| Key       | Value |
	| @ID_1_1   | 3752  |
	| @Name_2_1 | TOHU  |
	| @ID_1_2   | 0001  |
	| @Name_2_2 | ALL   |

