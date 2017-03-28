Feature: 關連物件的查詢、新增、刪除及更新功能
提供關連資料物件操作。

◆ 關連資料物件強制性標注，如果沒有標注會造成部分操作失敗。
	
	◇ TOHU.Toolbox.Utility.ORM.TableNameAttribute：在類別標示以提供對應的資料表名稱，未標示則所有操作都會失敗。

	◇ TOHU.Toolbox.Utility.ORM.PrimaryIndexAttribute：在屬性標示以指定索引欄位，未標示則會造成刪除及更新失敗。


◆ 關連資料物件選擇性標注：

	◇ TOHU.Toolbox.Utility.ORM.MappingFieldAttribute：提供對應的欄位名稱，用於屬性名稱與欄位名稱相異的情形。

	◇ TOHU.Toolbox.Utility.ORM.SkipInsertAttribute：忽略該屬性在插入及更新時使用，用於該欄位由資料表決定情形，例如：自動編號的欄位。


Background: 
◆ 釋例說明： CustomObject 類別

	◇ CustomObject 類別標注 TableNameAttribute 並設定 TableName = Custom 以決定對應資料表。

	◇ 資料物件屬性 Initial 標注 PrimaryIndexAttribute 指定該屬性為索引欄位，在刪除及更新時使用。

	◇ 資料表欄位名稱 ID 與資料物件屬性名稱 Initial 不同，標注 MappingFieldAttribute 以指定對應欄位名稱。

	◇ 資料物件屬性 Email 無對應的資料表欄位，標注 SkipInsertAttribute 以忽略該屬性在插入及更新時使用。


	Given 具備 Custom 資料表內容的資料庫
		| ID   | Name | Extenstion |
		| 0001 | ALL  | 111        |
		| 0002 | MTEC | 222        |
		| 0003 | ETSH | 333        |
		| 3752 | TOHU | 444        |

Scenario: 查詢指定的關連資料物件
	When 要求取得 CustomObject 關連資料物件清單時
	Then 取得 CustomObject 資料物件
		| Initial | Name | Extenstion | Email |
		| 0001    | ALL  | 111        |       |
		| 0002    | MTEC | 222        |       |
		| 0003    | ETSH | 333        |       |
		| 3752    | TOHU | 444        |       |

Scenario: 新增指定的關連資料物件	
	When 要求新增 CustomObject 關連資料物件
		| Initial | Name | Extenstion | Email          |
		| 0005    | CEHS | 555        | CEHS@gmail.com |
		| 0006    | RICU | 666        | RICU@gmail.com |
		And 要求取得 CustomObject 關連資料物件清單時
	Then 取得 CustomObject 資料物件
		| Initial | Name | Extenstion | Email |
		| 0001    | ALL  | 111        |       |
		| 0002    | MTEC | 222        |       |
		| 0003    | ETSH | 333        |       |
		| 3752    | TOHU | 444        |       |
		| 0005    | CEHS | 555        |       |
		| 0006    | RICU | 666        |       |  

Scenario: 刪除指定的關連資料物件
	When 要求刪除關連資料物件
		| Initial | Name | Extenstion | Email          |
		| 0001    | ALL  | 111        | ALL@gmail.com  |
		| 0002    | MTEC | 222        | MTEC@gmail.com |
		And 要求取得 CustomObject 關連資料物件清單時
	Then 取得 CustomObject 資料物件
		| Initial | Name | Extenstion | Email |
		| 0003    | ETSH | 333        |       |
		| 3752    | TOHU | 444        |       |

Scenario: 更新指定的關連資料物件
	When 要求更新關連資料物件
		| Initial | Name | Extenstion | Email          |
		| 0001    | ALL  | 555        | ALL@gmail.com  |
		| 0002    | MTEC | 666        | MTEC@gmail.com |
		And 要求取得 CustomObject 關連資料物件清單時
	Then 取得 CustomObject 資料物件
		| Initial | Name | Extenstion | Email |
		| 0001    | ALL  | 555        |       |
		| 0002    | MTEC | 666        |       |
		| 0003    | ETSH | 333        |       |
		| 3752    | TOHU | 444        |       |
		