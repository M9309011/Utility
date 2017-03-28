Feature: 條件式查詢取得資料物件
	為減少物件生成數量，提供查詢的條件，避免來源資料表數量龐大，而所需要的僅其中少數記錄。


Background: 
◆ 釋例說明： CustomObject 類別

	◇ CustomObject 類別標注 TableNameAttribute 並設定 TableName = Custom 以決定對應資料表。

	◇ 資料物件屬性 Initial 標注 PrimaryIndexAttribute 指定該屬性為索引欄位，在刪除及更新時使用。

	◇ 資料表欄位名稱 ID 與資料物件屬性名稱 Initial 不同，標注 MappingFieldAttribute 以指定對應欄位名稱。

	◇ 資料物件屬性 Email 無對應的資料表欄位，標注 SkipInsertAttribute 以忽略該屬性在插入及更新時使用。


	Given 具備 Custom 資料表內容的資料庫
		| ID   | Name | Extenstion |
		| 0001 | ALL  | 111        |
		| 0002 | MTEC | 111        |
		| 0003 | ETSH | 333        |
		| 3752 | TOHU | 444        |

Scenario: 透過字串指定查詢 ID 欄位的值為 0001 的關連資料物件
	Given 查詢條件為 ID 欄位的值為 0001 時
	When 要求取得符合查詢條件的 CustomObject 關連資料物件清單時
	Then 取得 CustomObject 資料物件
		| Initial | Name | Extenstion | Email |
		| 0001    | ALL  | 111        |       |

		
Scenario: 透過屬性指定查詢 Extenstion 屬性的值為 111 的關連資料物件
	Given 條件資料物件
		| Initial | Name | Extenstion | Email |
		| 0001    | ALL  | 111        |       |
		And 查詢屬性為 Extenstion 時
	When 要求取得符合屬性查詢條件的 CustomObject 關連資料物件清單時
	Then 取得 CustomObject 資料物件
		| Initial | Name | Extenstion | Email |
		| 0001    | ALL  | 111        |       |
		| 0002    | MTEC | 111        |       |