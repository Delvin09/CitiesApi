# CitiesApi
Test project for  kasko2go

Spec:
Необходимо реализовать web сервис на C# .net core, который взаимодействует с БД.
- при старте сервис загружает в БД список городов России (просто из файла)
- содержит GET метод, который позволяет вернуть id города по имени
- содержит POST метод, позволяет добавить в БД пользователя с указанием значения, например: BODY {name: 'Alex', townId: 1, value: 10}
  если пользователь существует, то value обновляется
