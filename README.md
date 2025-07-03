# TodoApi

Краткое описание проекта: ...

## 📦 Стек технологий

- .NET 9 / C#
- Clean Architecture (по мотивам [шаблона Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture))
- Web API
- PostgreSQL

## 🧱 Архитектура

Проект реализован по принципам **Clean Architecture**. Используются следующие слои:

- `Domain` — бизнес-логика и сущности
- `Application` — интерфейсы, use cases, обработчики
- `Infrastructure` — доступ к внешним источникам (БД, API и т.д.)
- `Web` — конечная точка (например, Web API)

## 🚀 Инициализация проекта

### 1. Создание решения и структуры каталогов

```bash
dotnet new sln -n ProjectName

mkdir src
mkdir src/Domain
mkdir src/Application
mkdir src/Infrastructure
mkdir src/Web
```

### 2. Создание проектов

```bash
cd src/Domain
dotnet new classlib -n Domain

cd ../Application
dotnet new classlib -n Application

cd ../Infrastructure
dotnet new classlib -n Infrastructure

cd ../Web
dotnet new webapi -n Web

cd ../..
```

### 3. Добавление проектов в решение

```bash
dotnet sln add src/Domain/Domain.csproj
dotnet sln add src/Application/Application.csproj
dotnet sln add src/Infrastructure/Infrastructure.csproj
dotnet sln add src/Web/Web.csproj
```

### 4. Добавление ссылок между проектами

```bash
dotnet add src/Application/Application.csproj reference src/Domain/Domain.csproj
dotnet add src/Infrastructure/Infrastructure.csproj reference src/Application/Application.csproj
dotnet add src/Web/Web.csproj reference src/Application/Application.csproj
dotnet add src/Web/Web.csproj reference src/Infrastructure/Infrastructure.csproj
```

## 📂 Структура проекта

```
TodoApi.sln
src/
├── Domain/
│   └── Domain.csproj
├── Application/
│   └── Application.csproj
├── Infrastructure/
│   └── Infrastructure.csproj
└── Web/
    └── Web.csproj
```

## ✅ Планы по развитию

- [ ] Подключить базу данных
- [ ] Настроить Dependency Injection
- [ ] Добавить юнит-тесты
- [ ] Реализовать CI/CD

---
