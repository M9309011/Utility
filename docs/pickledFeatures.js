jsonPWrapper ({
  "Features": [
    {
      "RelativeFolder": "Utility\\AOP\\提供函式橫切需求建立.feature",
      "Feature": {
        "Name": "提供函式橫切需求建立",
        "Description": "提供使用者可自訂橫切需求。\r\n\r\n橫切需求區分為函式執行前及函式執行後兩類。\r\n\r\n◆ 橫向需求套用步驟：\r\n\r\n\t1. 使用者先實做介面以自訂執行內容。\r\n\t\t\r\n\t\t◇ 函式執行前：TOHU.Toolbox.Utility.AOP.IPreProcessor\r\n\r\n\t\t◇ 函式執行後：TOHU.Toolbox.Utility.AOP.IPostProcessor\r\n\r\n\t2. 然後再需要的函式前加上 Attribute 標籤。\r\n\t\t\r\n\t\t◇ 函式執行前： [TOHU.Toolbox.Utility.AOP.PreProcess(typeof( [PreProcessor] ))]\r\n\r\n\t\t◇ 函式執行後： [TOHU.Toolbox.Utility.AOP.PostProcess(typeof( [PostProcessor] ))]",
        "FeatureElements": [
          {
            "Name": "函式未包含橫向需求",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "執行未指定橫向需求的方法",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "呼叫佇列儲存的執行順序是",
                "TableArgument": {
                  "HeaderRow": [
                    "CallStack"
                  ],
                  "DataRows": [
                    [
                      "DoSomething"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "函式標示執行前橫向需求",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "執行標示執行前橫向需求的方法",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "呼叫佇列儲存的執行順序是",
                "TableArgument": {
                  "HeaderRow": [
                    "CallStack"
                  ],
                  "DataRows": [
                    [
                      "PreProcess"
                    ],
                    [
                      "DoSomething"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "函式標示執行後橫向需求",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "執行標示執行後橫向需求的方法",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "呼叫佇列儲存的執行順序是",
                "TableArgument": {
                  "HeaderRow": [
                    "CallStack"
                  ],
                  "DataRows": [
                    [
                      "DoSomething"
                    ],
                    [
                      "PostProcess"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "函式標示執行前及執行後橫向需求",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "執行標示執行前及執行後橫向需求的方法",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "呼叫佇列儲存的執行順序是",
                "TableArgument": {
                  "HeaderRow": [
                    "CallStack"
                  ],
                  "DataRows": [
                    [
                      "PreProcess"
                    ],
                    [
                      "DoSomething"
                    ],
                    [
                      "PostProcess"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Background": {
          "Name": "",
          "Description": "",
          "Steps": [
            {
              "Keyword": "Given",
              "NativeKeyword": "Given ",
              "Name": "清空呼叫佇列",
              "StepComments": [],
              "AfterLastStepComments": []
            },
            {
              "Keyword": "And",
              "NativeKeyword": "And ",
              "Name": "建立包含橫向需求方法的類別實體",
              "StepComments": [],
              "AfterLastStepComments": []
            }
          ],
          "Tags": [],
          "Result": {
            "WasExecuted": false,
            "WasSuccessful": false
          }
        },
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "Utility\\ORM\\進階查詢\\條件式查詢取得資料物件.feature",
      "Feature": {
        "Name": "條件式查詢取得資料物件",
        "Description": "為減少物件生成數量，提供查詢的條件，避免來源資料表數量龐大，而所需要的僅其中少數記錄。",
        "FeatureElements": [
          {
            "Name": "透過字串指定查詢 ID 欄位的值為 0001 的關連資料物件",
            "Slug": "id-0001",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "查詢條件為 ID 欄位的值為 0001 時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "要求取得符合查詢條件的 CustomObject 關連資料物件清單時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "取得 CustomObject 資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "111",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "透過屬性指定查詢 Extenstion 屬性的值為 111 的關連資料物件",
            "Slug": "extenstion-111",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "條件資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "111",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "查詢屬性為 Extenstion 時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "要求取得符合屬性查詢條件的 CustomObject 關連資料物件清單時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "取得 CustomObject 資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "111",
                      ""
                    ],
                    [
                      "0002",
                      "MTEC",
                      "111",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Background": {
          "Name": "",
          "Description": "◆ 釋例說明： CustomObject 類別\r\n\r\n\t◇ CustomObject 類別標注 TableNameAttribute 並設定 TableName = Custom 以決定對應資料表。\r\n\r\n\t◇ 資料物件屬性 Initial 標注 PrimaryIndexAttribute 指定該屬性為索引欄位，在刪除及更新時使用。\r\n\r\n\t◇ 資料表欄位名稱 ID 與資料物件屬性名稱 Initial 不同，標注 MappingFieldAttribute 以指定對應欄位名稱。\r\n\r\n\t◇ 資料物件屬性 Email 無對應的資料表欄位，標注 SkipInsertAttribute 以忽略該屬性在插入及更新時使用。",
          "Steps": [
            {
              "Keyword": "Given",
              "NativeKeyword": "Given ",
              "Name": "具備 Custom 資料表內容的資料庫",
              "TableArgument": {
                "HeaderRow": [
                  "ID",
                  "Name",
                  "Extenstion"
                ],
                "DataRows": [
                  [
                    "0001",
                    "ALL",
                    "111"
                  ],
                  [
                    "0002",
                    "MTEC",
                    "111"
                  ],
                  [
                    "0003",
                    "ETSH",
                    "333"
                  ],
                  [
                    "3752",
                    "TOHU",
                    "444"
                  ]
                ]
              },
              "StepComments": [],
              "AfterLastStepComments": []
            }
          ],
          "Tags": [],
          "Result": {
            "WasExecuted": false,
            "WasSuccessful": false
          }
        },
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "Utility\\ORM\\關連物件的查詢、新增、刪除及更新功能.feature",
      "Feature": {
        "Name": "關連物件的查詢、新增、刪除及更新功能",
        "Description": "提供關連資料物件操作。\r\n\r\n◆ 關連資料物件強制性標注，如果沒有標注會造成部分操作失敗。\r\n\t\r\n\t◇ TOHU.Toolbox.Utility.ORM.TableNameAttribute：在類別標示以提供對應的資料表名稱，未標示則所有操作都會失敗。\r\n\r\n\t◇ TOHU.Toolbox.Utility.ORM.PrimaryIndexAttribute：在屬性標示以指定索引欄位，未標示則會造成刪除及更新失敗。\r\n\r\n\r\n◆ 關連資料物件選擇性標注：\r\n\r\n\t◇ TOHU.Toolbox.Utility.ORM.MappingFieldAttribute：提供對應的欄位名稱，用於屬性名稱與欄位名稱相異的情形。\r\n\r\n\t◇ TOHU.Toolbox.Utility.ORM.SkipInsertAttribute：忽略該屬性在插入及更新時使用，用於該欄位由資料表決定情形，例如：自動編號的欄位。",
        "FeatureElements": [
          {
            "Name": "查詢指定的關連資料物件",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "要求取得 CustomObject 關連資料物件清單時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "取得 CustomObject 資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "111",
                      ""
                    ],
                    [
                      "0002",
                      "MTEC",
                      "222",
                      ""
                    ],
                    [
                      "0003",
                      "ETSH",
                      "333",
                      ""
                    ],
                    [
                      "3752",
                      "TOHU",
                      "444",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "新增指定的關連資料物件",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "要求新增 CustomObject 關連資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0005",
                      "CEHS",
                      "555",
                      "CEHS@gmail.com"
                    ],
                    [
                      "0006",
                      "RICU",
                      "666",
                      "RICU@gmail.com"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "要求取得 CustomObject 關連資料物件清單時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "取得 CustomObject 資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "111",
                      ""
                    ],
                    [
                      "0002",
                      "MTEC",
                      "222",
                      ""
                    ],
                    [
                      "0003",
                      "ETSH",
                      "333",
                      ""
                    ],
                    [
                      "3752",
                      "TOHU",
                      "444",
                      ""
                    ],
                    [
                      "0005",
                      "CEHS",
                      "555",
                      ""
                    ],
                    [
                      "0006",
                      "RICU",
                      "666",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "刪除指定的關連資料物件",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "要求刪除關連資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "111",
                      "ALL@gmail.com"
                    ],
                    [
                      "0002",
                      "MTEC",
                      "222",
                      "MTEC@gmail.com"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "要求取得 CustomObject 關連資料物件清單時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "取得 CustomObject 資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0003",
                      "ETSH",
                      "333",
                      ""
                    ],
                    [
                      "3752",
                      "TOHU",
                      "444",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "更新指定的關連資料物件",
            "Slug": "",
            "Description": "",
            "Steps": [
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "要求更新關連資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "555",
                      "ALL@gmail.com"
                    ],
                    [
                      "0002",
                      "MTEC",
                      "666",
                      "MTEC@gmail.com"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "要求取得 CustomObject 關連資料物件清單時",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "取得 CustomObject 資料物件",
                "TableArgument": {
                  "HeaderRow": [
                    "Initial",
                    "Name",
                    "Extenstion",
                    "Email"
                  ],
                  "DataRows": [
                    [
                      "0001",
                      "ALL",
                      "555",
                      ""
                    ],
                    [
                      "0002",
                      "MTEC",
                      "666",
                      ""
                    ],
                    [
                      "0003",
                      "ETSH",
                      "333",
                      ""
                    ],
                    [
                      "3752",
                      "TOHU",
                      "444",
                      ""
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Background": {
          "Name": "",
          "Description": "◆ 釋例說明： CustomObject 類別\r\n\r\n\t◇ CustomObject 類別標注 TableNameAttribute 並設定 TableName = Custom 以決定對應資料表。\r\n\r\n\t◇ 資料物件屬性 Initial 標注 PrimaryIndexAttribute 指定該屬性為索引欄位，在刪除及更新時使用。\r\n\r\n\t◇ 資料表欄位名稱 ID 與資料物件屬性名稱 Initial 不同，標注 MappingFieldAttribute 以指定對應欄位名稱。\r\n\r\n\t◇ 資料物件屬性 Email 無對應的資料表欄位，標注 SkipInsertAttribute 以忽略該屬性在插入及更新時使用。",
          "Steps": [
            {
              "Keyword": "Given",
              "NativeKeyword": "Given ",
              "Name": "具備 Custom 資料表內容的資料庫",
              "TableArgument": {
                "HeaderRow": [
                  "ID",
                  "Name",
                  "Extenstion"
                ],
                "DataRows": [
                  [
                    "0001",
                    "ALL",
                    "111"
                  ],
                  [
                    "0002",
                    "MTEC",
                    "222"
                  ],
                  [
                    "0003",
                    "ETSH",
                    "333"
                  ],
                  [
                    "3752",
                    "TOHU",
                    "444"
                  ]
                ]
              },
              "StepComments": [],
              "AfterLastStepComments": []
            }
          ],
          "Tags": [],
          "Result": {
            "WasExecuted": false,
            "WasSuccessful": false
          }
        },
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    }
  ],
  "Summary": {
    "Tags": [],
    "Folders": [
      {
        "Folder": "Utility",
        "Total": 10,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 10
      }
    ],
    "NotTestedFolders": [
      {
        "Folder": "Utility",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      }
    ],
    "Scenarios": {
      "Total": 10,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 10
    },
    "Features": {
      "Total": 3,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 3
    }
  },
  "Configuration": {
    "GeneratedOn": "28 三月 2017 16:49:28"
  }
});