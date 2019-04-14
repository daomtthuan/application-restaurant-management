USE [master]
DROP DATABASE [RestaurantManagement]
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

-- Trạng thái bàn
CREATE TABLE [TableStatus]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại trạng thái
)

-- Trạng thái bill
CREATE TABLE [BillStatus]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại trạng thái
)

-- Loại thức ăn
CREATE TABLE [FoodCategory]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại thức ăn
)

-- Loại giới tính
CREATE TABLE [Gender]
(
	[ID] INT PRIMARY KEY,											-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại giới tính
)

-- Tài khoản
CREATE TABLE [Accounts]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[Username] NVARCHAR(100) NOT NULL UNIQUE,						-- Tên đăng nhập
	[Password] NVARCHAR(1000) NOT NULL DEFAULT 'user',				-- Mật khẩu
	[RoleID] INT NOT NULL DEFAULT 0,								-- Mã phân quyền
	[Name] NVARCHAR(100) NOT NULL,									-- Tên
	[GenderID] INT NOT NULL,										-- Giới tính		
	[Birthday] DATE NOT NULL,										-- Ngày sinh
	[IdentityCard] NVARCHAR(20) NOT NULL UNIQUE,					-- CMND/CCCD
	[Hometown] NVARCHAR(100) NOT NULL,								-- Quê quán
	[Address] NVARCHAR(100) NOT NULL,								-- Địa chỉ
	[Numberphone] NVARCHAR(20),										-- Số điện thoại
	[Email] NVARCHAR(100),											-- Email

	FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([ID]),
	FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([ID])
)

-- Bàn ăn
CREATE TABLE [FoodTables]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[Name] NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',			-- Tên bàn
	[StatusID] INT NOT NULL DEFAULT 0,								-- Trạng thái bàn

	FOREIGN KEY ([StatusID]) REFERENCES [TableStatus] ([ID])
)

-- Thức ăn
CREATE TABLE [Foods]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[Name] NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',			-- Tên thức ăn
	[CategoryID] INT NOT NULL,										-- Mã loại thức ăn
	[Price] INT NOT NULL DEFAULT 0,

	FOREIGN KEY ([CategoryID]) REFERENCES [FoodCategory] ([ID])
)

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

-- Chi tiết hoá đơn
CREATE TABLE [BillDetail]
(
	[ID] INT IDENTITY PRIMARY KEY,									-- Mã
	[BillID] INT NOT NULL REFERENCES [Bills] ([ID]),				-- Mã hoá đơn
	[FoodID] INT NOT NULL REFERENCES [Foods] ([ID]),				-- Mã thức ăn
	[Quantity] INT NOT NULL DEFAULT 0,								-- Số lượng

	FOREIGN KEY ([BillID]) REFERENCES [Bills] ([ID]),
	FOREIGN KEY ([FoodID]) REFERENCES [Foods] ([ID])
)
GO

---------------------------------------------------------------------------------------

INSERT INTO [Roles] VALUES (0, N'Không hoạt động')
INSERT INTO [Roles] VALUES (1, N'Quản lý')
INSERT INTO [Roles] VALUES (2, N'Nhân viên Thu ngân')
INSERT INTO [Roles] VALUES (3, N'Nhân viên Pha chế')
INSERT INTO [Roles] VALUES (4, N'Nhân viên Phục vụ')
INSERT INTO [Roles] VALUES (5, N'Nhân viên Tạp vụ')
INSERT INTO [Roles] VALUES (6, N'Nhân viên Vận chuyển')
INSERT INTO [Roles] VALUES (7, N'Bảo vệ')
GO

INSERT INTO [TableStatus] VALUES (0, N'Trống')
INSERT INTO [TableStatus] VALUES (1, N'Có người')
INSERT INTO [TableStatus] VALUES (2, N'Đã được đặt')
GO

INSERT INTO [BillStatus] VALUES	(0, N'Chưa thanh toán')
INSERT INTO [BillStatus] VALUES	(1, N'Đã thanh toán')
GO

INSERT INTO [Gender] VALUES (0, N'Nam')
INSERT INTO [Gender] VALUES (1, N'Nữ')
GO

INSERT INTO [Accounts] VALUES ('admin', 'admin', 1, N'Đào Minh Trung Thuận', 0, '1999-09-18', '362540898', N'Thành phố Cần Thơ', N'57 Đường B5, Phường Hưng Phú, Quận Cái Răng, Thành phố Cần Thơ', '0939908568', 'dao.mt.thuan@gmail.com')
INSERT INTO [Accounts] VALUES ('quanly', '1', 1, N'Cao Lập Triệu', 0, '1990-03-19', '101543076', N'Thành phố Hải Dương', N'74 Phố Hoán, Phường Võ Vỹ Sáng, Quận Tuyết Miên, Thành phố Hải Dương', '0253062672', 'lap.trieu@gmail.com')
INSERT INTO [Accounts] VALUES ('thungan', '1', 2, N'Cự Hà Trúc', 1, '1995-08-23', '635764587', N'Tỉnh Bắc Kạn', N'94 Thôn 08, Phường Ninh, Quận Chế Thêu, Tỉnh Bắc Kạn', '0599397220', 'ha.truc@gmail.com')
INSERT INTO [Accounts] VALUES ('phucvu1', '1', 4, N'La Cát Tuyến', 1, '1993-11-22', '715920211', N'Tỉnh Quảng Ninh', N'278 Thôn 5, Phường 76, Quận Đôn Nguyệt, Tỉnh Quảng Ninh', '01860831308', 'cat.tuyen@gmail.com')
INSERT INTO [Accounts] VALUES ('phucvu2', '1', 4, N'Mộc Hải Ngạn', 0, '1998-11-05', '365532348 ', N'Tỉnh Bạc Liêu', N'9336 Phố Nhiệm Toàn Ca, Xã Quyết Bào, Quận Cái, Tỉnh Bạc Liêu', '0919641619', 'hai.ngan@gmail.com')
GO

DECLARE @i INT = 1
WHILE @i <= 30
BEGIN
	INSERT INTO [FoodTables]([Name]) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
GO
UPDATE [FoodTables] SET [StatusID] = 1 WHERE [ID] IN (1,3,4,6,10,14)
GO

---------------------------------------------------------------------------------------

CREATE PROC [getAccountID]
	@username NVARCHAR(100),
	@password NVARCHAR(100)
AS SELECT [Accounts].[ID] FROM	[Accounts] WHERE [Username] = @username AND [Password] = @password
GO

CREATE PROC [getFoodTablesList]
AS 
	SELECT [FoodTables].[ID], [FoodTables].[Name], [TableStatus].[Name] AS [Status]
	FROM [FoodTables] JOIN [TableStatus] ON  [TableStatus].[ID] = [FoodTables].[StatusID] 
GO