```# Employee Management API

 Описание

   Employee Management API — это веб-приложение, разработанное на платформе .NET 8 с использованием ASP.NET Core Web API и PostgreSQL. Этот API предоставляет возможность управления данными сотрудников, включая создание, чтение, обновление и удаление записей.

   Технологии

- **.NET 8** (ASP.NET Core Web API)
- **Entity Framework Core** для работы с базой данных
- **Dapper** для выполнения SELECT-запросов
- **PostgreSQL** для хранения данных
- **Асинхронное программирование**
- **Dependency Injection (DI)** для управления зависимостями
- **Fluent API** для конфигурации EF Core
- **Middleware** для обработки запросов
- **Паттерн MVC** с использованием контроллеров
- **API Conventions** для стандартизации методов
- **Расширение методов (Extension Methods)** для удобства работы с результатами

   Структура базы данных

                     Таблица Employees
   

| Поле          | Тип           | Описание                                                |
|---------------|---------------|---------------------------------------------------------|
| Id            | UUID          | Идентификатор сотрудника (Primary Key)                  |
| FirstName     | VARCHAR(100)  | Имя сотрудника                                          |
| LastName      | VARCHAR(100)  | Фамилия сотрудника                                      |
| Email         | VARCHAR(255)  | Электронная почта (уникальное)                          |
| Phone         | VARCHAR(20)   | Номер телефона (минимум 10 символов)                    |
| DateOfBirth   | DATE          | Дата рождения (должна быть раньше текущей даты)         |
| HireDate      | DATE          | Дата найма на работу                                    |
| Position      | VARCHAR(100)  | Должность сотрудника                                    |
| Salary        | DECIMAL(18, 2)| Зарплата (неотрицательная)                              |
| DepartmentName | VARCHAR      | Имя Департамента                                        |
| ManagerId     | UUID          | Идентификатор руководителя (может быть пустым)          |
| IsActive      | BOOLEAN       | Статус активности (по умолчанию TRUE)                   |
| Address       | VARCHAR(255)  | Адрес проживания                                        |
| City          | VARCHAR(100)  | Город проживания                                        |
| Country       | VARCHAR(100)  | Страна проживания                                       |
| CreatedAt     | TIMESTAMP     | Дата создания записи                                    |
| UpdatedAt     | TIMESTAMP     | Дата последнего обновления записи                       |

    Функциональность API

    CRUD-операции для таблицы Employees

-- CREATE: Создание нового сотрудника
-- READ: Получение информации о сотрудниках
-- UPDATE: Обновление информации о сотруднике
-- DELETE: Удаление записи о сотруднике

### API для GET-запросов

-  Получение всех сотрудников: `GET /api/employees`
-  Получение информации о конкретном сотруднике по Id: `GET /api/employees/{id}`
-  Получение сотрудников по статусу активности: `GET /api/employees?isActive={isActive}`
-  Получение сотрудников по департаменту: `GET /api/employees/department/{departmentId}`
-  Получение статистики по зарплатам: `GET /api/employees/salary-statistics`
-  Получение сотрудников, рожденных в определенный период: `GET /api/employees/birthdays?startDate={startDate}&endDate={endDate}`

Developer: Jamshedzoda Khurhsed.
```