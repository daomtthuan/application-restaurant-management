USE [master]
--create database RestaurantManagement
CREATE DATABASE [RestaurantManagement] ON PRIMARY
(
	NAME = 'RestaurantManagement_Data',
	FILENAME = 'E:\Github\restaurant-management\Database\RestaurantManagement_Data.mdf'
) LOG ON
(
	NAME = 'RestaurantManagement_Log',
	FILENAME = 'E:\Github\restaurant-management\Database\RestaurantManagement_Log.ldf'
)
GO

USE [RestaurantManagement]

-- Phân quyền tài khoản
CREATE TABLE [Roles]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại tài khoản
)
GO

-- Trạng thái bàn
CREATE TABLE [TableStatus]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại trạng thái
)
GO

-- Trạng thái bill
CREATE TABLE [BillStatus]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại trạng thái
)
GO

-- Loại thức ăn
CREATE TABLE [FoodCategory]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại thức ăn
)
GO

-- Tài khoản
CREATE TABLE [Accounts]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[Username] VARCHAR(100) NOT NULL UNIQUE,						-- Tên đăng nhập
	[Password] VARCHAR(1000) NOT NULL DEFAULT 'user',				-- Mật khẩu
	[RoleID] INT NOT NULL DEFAULT 0,								-- Mã phân quyền
	[Name] NVARCHAR(100) NOT NULL,									-- Tên
	[Gender] NVARCHAR(3) NOT NULL,									-- Giới tính		
	[Birthday] DATE NOT NULL,										-- Ngày sinh
	[IdentityCard] VARCHAR(20) NOT NULL UNIQUE,						-- CMND/CCCD
	[Hometown] NVARCHAR(100) NOT NULL,								-- Quê quán
	[Address] NVARCHAR(100) NOT NULL,								-- Địa chỉ
	[Numberphone] VARCHAR(20),										-- Số điện thoại
	[Email] VARCHAR(100),											-- Email
	CHECK ([Gender] IN ('Nam', N'Nữ')),
	FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([ID])
)
GO

-- Bàn ăn
CREATE TABLE [FoodTables]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[Name] NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',			-- Tên bàn
	[StatusID] INT NOT NULL DEFAULT 0,								-- Trạng thái bàn
	[TableType] INT NOT NULL DEFAULT 1,								-- Loại bàn	
	CHECK ([TableType] > 0),
	FOREIGN KEY ([StatusID]) REFERENCES [TableStatus] ([ID])
)
GO

-- Thức ăn
CREATE TABLE [Foods]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[Name] NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',			-- Tên thức ăn
	[CategoryID] INT NOT NULL,										-- Mã loại thức ăn
	[Price] INT NOT NULL DEFAULT 0,
	FOREIGN KEY ([CategoryID]) REFERENCES [FoodCategory] ([ID])
)
GO

-- Hoá đơn
CREATE TABLE [Bills]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[CheckIn] DATETIME NOT NULL DEFAULT GETDATE(),					-- Thời gian vào
	[CheckOut] DATETIME,											-- Thời gian ra
	[TableID] INT NOT NULL,											-- Mã bàn ăn
	[StatusID] INT NOT NULL DEFAULT 0,								-- Trạng thái hoá đơn
	CHECK ([CheckIn] <= [CheckOut]),
	FOREIGN KEY ([TableID]) REFERENCES [FoodTables] ([ID]),
	FOREIGN KEY ([StatusID]) REFERENCES [BillStatus] ([ID])
)
GO

-- Chi tiết hoá đơn
CREATE TABLE [BillDetail]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[BillID] INT NOT NULL REFERENCES [Bills] ([ID]),				-- Mã hoá đơn
	[FoodID] INT NOT NULL REFERENCES [Foods] ([ID]),				-- Mã thức ăn
	[Quantity] INT NOT NULL DEFAULT 0,
	FOREIGN KEY ([BillID]) REFERENCES [Bills] ([ID]),
	FOREIGN KEY ([FoodID]) REFERENCES [Foods] ([ID])
)
GO