# TestAspDev
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
