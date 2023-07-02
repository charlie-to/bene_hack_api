# 概要
ハッカソングループ１０で使用するAPIです。
現在はAzure Web App にてホストしています。

公開URL：https://bene-hack-api.azurewebsites.net/

# 提供機能
- ユーザーデータ（ダミーデータ）の取得
- 課題の登録、削除、編集
- 課題の終了状況の確認

# 認証
なし。URLに直接GETアクセスするなどれば使用可能です。

# 要求
開発中😢

# 使い方
## ユーザーデータを取得する
https://bene-hack-api.azurewebsites.net/user

へGETでアクセスするとユーザーデータを取得できます。

## タスクを取得する
https://bene-hack-api.azurewebsites.net/quest

へGETでアクセスするとタスクデータを取得できます。

## タスクを追加する
https://bene-hack-api.azurewebsites.net/quest/

へPOSTでアクセスするとタスクを追加できます。
↓こんな感じです。
```
curl -X 'POST' \
  'https://bene-hack-api.azurewebsites.net/quest' \
  -H 'accept: text/plain' \
  -H 'Content-Type: text/json' \
  -d '{
  "id": 0,
  "name": "string",
  "deadline": "2023-07-01T15:08:54.127Z",
  "isFinished": true
}'
```
## タスクの終了状況を確認する
https://bene-hack-api.azurewebsites.net/quest/status/

にGETでアクセスするとタスクの進捗状況を確認できます。

例
```
curl -X 'GET' \
  'https://bene-hack-api.azurewebsites.net/quest/status/ \
  -H 'accept: text/plain'
```

## タスクの終了状況を確認する（ユーザーごと）
https://bene-hack-api.azurewebsites.net/quest/status/${user_id}

にGETでアクセスすると${user_id}に該当するユーザーのタスクの進捗状況を確認できます。

例
```
curl -X 'GET' \
  'https://bene-hack-api.azurewebsites.net/quest/status/0 \
  -H 'accept: text/plain'
```

## クエストモンスターのHPを確認する
https://bene-hack-api.azurewebsites.net/quest/status/hp/${quest_id}
にGETでアクセスすると該当するクエストのモンスターのHPを取得できます。

↓例
```
curl -X 'GET' \
  'https://bene-hack-api.azurewebsites.net/quest/status/hp/0' \
  -H 'accept: text/plain'
```