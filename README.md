# StaffPortal
Database Model Regeneration (Scaffold)
 Scaffold-DbContext "Server=DESKTOP-MSI1S2I\MSSQLSERVER01;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -Context AppDbContext -ContextDir AppContext -OutputDir "D:\GitHub test\StaffPortal\Core\StaffPortal.Domain\Entities" -Namespace StaffPortal.Domain.Entities -ContextNamespace StaffPortal.Persistence -force


Database commants
--Create Database CompanyDB
--use CompanyDB
--create table Employees(
--EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
--    FullName NVARCHAR(100) NOT NULL,
--    Position NVARCHAR(150) NOT NULL,
--    Department NVARCHAR(50) NOT NULL,
--    HireDate DATE NOT NULL,
--    Email NVARCHAR(100) NULL,
--    Phone NVARCHAR(50) NULL,
--    Salary DECIMAL(10,2) NULL,
--    FileBlob VARBINARY(MAX) NULL,
--    FilePath NVARCHAR(260) NULL,
--    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
--);

--select * from Employees


--INSERT INTO Employees (FullName, Position, Department, HireDate, Email, Phone, Salary)
--VALUES 
--('Ali Veliyev', 'Developer', 'IT', '2023-01-15', 'ali.veliyev@example.com', '0501112233', 1500.00),
--('Aysel Məmmədova', 'HR Manager', 'HR', '2022-03-10', 'aysel.mammadova@example.com', '0502223344', 1200.00),
--('Ramil Həsənov', 'Accountant', 'Finance', '2021-07-20', 'ramil.hasenov@example.com', '0503334455', 1100.00),
--('Leyla Quliyeva', 'Developer', 'IT', '2023-02-05', 'leyla.quliyeva@example.com', '0504445566', 1550.00),
--('Elvin Əliyev', 'Designer', 'Marketing', '2022-08-12', 'elvin.aliyev@example.com', '0505556677', 1300.00),
--('Nigar Hüseynova', 'HR Specialist', 'HR', '2021-11-01', 'nigar.huseynova@example.com', '0506667788', 1150.00),
--('Tural Məmmədli', 'Developer', 'IT', '2020-06-18', 'tural.mammedli@example.com', '0507778899', 1600.00),
--('Sevda Rzayeva', 'Accountant', 'Finance', '2019-09-23', 'sevda.rzayeva@example.com', '0508889900', 1120.00),
--('Orxan Qasımov', 'Designer', 'Marketing', '2022-12-30', 'orxan.qasimov@example.com', '0509990011', 1350.00),
--('Səmra Əliyeva', 'HR Manager', 'HR', '2021-05-14', 'semra.aliyeva@example.com', '0501234567', 1250.00);


--CREATE NONCLUSTERED INDEX IX_Employees_FullName ON Employees(FullName);


--CREATE PROCEDURE sp_SearchEmployees
--    @term NVARCHAR(200)
--AS
--BEGIN
--    SELECT *
--    FROM Employees
--    WHERE FullName LIKE '%' + @term + '%'
--       OR Position LIKE '%' + @term + '%'
--       OR Department LIKE '%' + @term + '%'
--       OR Email LIKE '%' + @term + '%'
--       OR Phone LIKE '%' + @term + '%';
--END;


--CREATE VIEW vw_EmployeesForExport AS
--SELECT
--    EmployeeID,
--    FullName,
--    Position,
--    Department,
--    HireDate,
--    Email,
--    Phone,
--    Salary
--FROM Employees;