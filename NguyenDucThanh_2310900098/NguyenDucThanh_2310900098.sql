create database NguyenDucThanh_2310900098;

use NguyenDucThanh_2310900098;

CREATE TABLE NdtEmployee (
    ndtEmpId INT PRIMARY KEY,
    ndtEmpName NVARCHAR(100),
    ndtEmpLevel NVARCHAR(50),
    ndtEmpStartDate DATE,
    ndtEmpStatus BIT  -- BIT là kiểu Boolean trong SQL Server
);

INSERT INTO NdtEmployee (ndtEmpId, ndtEmpName, ndtEmpLevel, ndtEmpStartDate, ndtEmpStatus)
VALUES 
(1, N'Nguyễn Đức Thành', N'Manager', '2025-07-01', 1),
(2, N'Nguyễn Thị Hoa', N'Staff', '2023-03-15', 1),
(3, N'Trần Văn Minh', N'Intern', '2020-10-10', 0);
