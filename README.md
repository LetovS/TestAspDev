## TestAspDev
#### Создание БД
В классе Program, Web.Api осуществляется авто накат миграций и тестовых данных ![image](https://github.com/LetovS/TestAspDev/assets/83654089/d0aa5a4e-7fe5-421c-a938-8b340ecc016f)

При создании БД через (pgAdmin || Dbeaver) нужно:
- ![image](https://github.com/LetovS/TestAspDev/assets/83654089/9ff6201f-1627-41ca-af0e-3a4b1132a3c6)
- [Использовать скрипт создания схемы БД](https://github.com/LetovS/TestAspDev/blob/main/CreateDatabaseScript.sql)
- [Добавить тестовые данные](https://github.com/LetovS/TestAspDev/tree/main/DataSqlScript)
  - [Добавить опрос](https://github.com/LetovS/TestAspDev/blob/main/DataSqlScript/_Surveys__202402271925.sql)
  - [Добавить вопросы](https://github.com/LetovS/TestAspDev/blob/main/DataSqlScript/_Questions__202402271924.sql)
  - [Добавить ответы](https://github.com/LetovS/TestAspDev/blob/main/DataSqlScript/_Answers__202402271924.sql)
  - [Добавить интервью](https://github.com/LetovS/TestAspDev/blob/main/DataSqlScript/_Interviews__202402271924.sql)

#### Demo работы приложения
##### Предварительно
Требуется установка [Docker desktop под ОС](https://www.docker.com/products/docker-desktop/)
##### Запуск демо
```shell
docker-compose up -d
```
##### Web api UI [Link](http://localhost:5000/swagger/index.html)
##### Тестовые данные
###### Для метода Get
surveyId: 
```shell
82b6e4f5-5830-4a8d-9e17-6b49c9fb7e4f
```
questionId: 
```shell
f8b1d827-4324-4c92-87a4-dcd0aa6f1c94
```
###### Для метода Post
surveyId: 
```shell
82b6e4f5-5830-4a8d-9e17-6b49c9fb7e4f
```
interviewId : 
```shell
6e33a3f8-1201-4e12-b919-f72a0a1c318e
```

body_request
```shell
{  
  "question": "How old you?",
  "answers": [
    "36"
  ]
}
```
##### Остановка демо
```shell
docker-compose down
```
