-- Create database
USE master
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

-- Create tables
USE [RestaurantManagement]
-- Phân quyền tài khoản
CREATE TABLE [Role]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại tài khoản
)
GO

-- Trạng thái bàn
CREATE TABLE [TableStatus]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại trạng thái
)
GO

-- Trạng thái bill
CREATE TABLE [BillStatus]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại trạng thái
)
GO

-- Loại thức ăn
CREATE TABLE [FoodCategory]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại thức ăn
)
GO

-- Loại giới tính
CREATE TABLE [Gender]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL									-- Loại giới tính
)
GO

-- Tài khoản
CREATE TABLE [Account]
(
	[ID] INT IDENTITY(1,1) PRIMARY KEY,								-- Mã
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

	FOREIGN KEY ([RoleID]) REFERENCES [Role] ([ID]),
	FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([ID])
)
GO

-- Bàn ăn
CREATE TABLE [Table]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',			-- Tên bàn
	[StatusID] INT NOT NULL DEFAULT 0,								-- Trạng thái bàn

	FOREIGN KEY ([StatusID]) REFERENCES [TableStatus] ([ID])
)
GO

-- Thức ăn
CREATE TABLE [Food]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[Name] NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',			-- Tên thức ăn
	[CategoryID] INT NOT NULL,										-- Mã loại thức ăn
	[Price] INT NOT NULL DEFAULT 0,

	FOREIGN KEY ([CategoryID]) REFERENCES [FoodCategory] ([ID])
)
GO

-- Hoá đơn
CREATE TABLE [Bill]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[CheckIn] DATETIME NOT NULL DEFAULT GETDATE(),					-- Thời gian vào
	[CheckOut] DATETIME,											-- Thời gian ra
	[TableID] INT NOT NULL,											-- Mã bàn ăn
	[StatusID] INT NOT NULL DEFAULT 0,								-- Trạng thái hoá đơn
	[Sale] INT NOT NULL DEFAULT	0,									-- Giảm giá

	CHECK ([CheckIn] <= [CheckOut]),
	CHECK (0 <= [Sale] AND [Sale] <= 100),
	FOREIGN KEY ([TableID]) REFERENCES [Table] ([ID]),
	FOREIGN KEY ([StatusID]) REFERENCES [BillStatus] ([ID])
)
GO

-- Chi tiết hoá đơn
CREATE TABLE [BillDetail]
(
	[ID] INT IDENTITY(0,1) PRIMARY KEY,								-- Mã
	[BillID] INT NOT NULL REFERENCES [Bill] ([ID]),					-- Mã hoá đơn
	[FoodID] INT NOT NULL REFERENCES [Food] ([ID]),					-- Mã thức ăn
	[Quantity] INT NOT NULL DEFAULT 0,								-- Số lượng

	CHECK ([Quantity] > 0),
	FOREIGN KEY ([BillID]) REFERENCES [Bill] ([ID]),
	FOREIGN KEY ([FoodID]) REFERENCES [Food] ([ID])
)
GO

-- Create proc
-- get food tables
CREATE PROC [procGetAccountID]
	@username NVARCHAR(100), @password NVARCHAR(100)
AS BEGIN 
	SELECT [Account].[ID] FROM	[Account] WHERE [Username] = @username AND [Password] = @password
END
GO

-- get food tables
CREATE PROC [procGetTable] 
AS BEGIN
	SELECT * FROM [Table]
END
GO

-- get bill by tableID, statusID
CREATE PROC [procGetUncheckedOutBillID] 
	@tableID INT
AS BEGIN
	SELECT [ID] FROM [Bill] WHERE [TableID] = @tableID AND [StatusID] = 0		
END
GO

-- get BillDetail by billID
CREATE PROC [procGetBillDetailByBillID]
	@billID INT
AS BEGIN
	SELECT [BillDetail].[ID], [Food].[Name] AS [FoodName], [Quantity], [Price], [Price]*[Quantity] AS [Total]
	FROM [BillDetail]
		JOIN [Food] ON [Food].[ID] = [BillDetail].[FoodID]
	WHERE [BillID] = @billID
END
GO

-- get FoodCategory
CREATE PROC [procGetFoodCategory]
AS BEGIN
	SELECT * FROM [FoodCategory]
END
GO

-- get food by CategoryID
CREATE PROC [procGetFood]
	@categoryID INT 
AS BEGIN
	SELECT * FROM [Food] 		
	WHERE [CategoryID] = @categoryID
END
GO

-- insert Food
/*	
	Nếu Table KHÔNG có Bill CHƯA thanh toán, tức có nghĩa là ko có bill đang hiện hành tại Table đó
		Thì tạo một Bill mới tại Table đó: 
			INSERT INTO [Bill] ([TableID]) VALUES (@tableID)
		Sau đó thêm Food vào Bill đó tại BillDetail:
			INSERT INTO [BillDetail] ([BillID], [FoodID], [Quantity]) VALUES (@billID, @foodID, @quantity)
	Nếu Table đã có Bill CHƯA thanh toán, tức là đang có bill hiện hành tại Table đó, thì Kiểm tra:
		Nếu Food thêm vào chưa có trong Bill thì thêm Food vào:
			NSERT INTO [BillDetail] ([BillID], [FoodID], [Quantity]) VALUES (@billID, @foodID, @quantity)
		Nếu Food thêm vào đã có trong Bill thì cập nhật lại Quantity cho Food đó:
			UPDATE [BillDetail] SET [Quantity] = [Quantity] + @quantity WHERE [BillID] = @billID AND [FoodID] = @foodID
			hoặc xoá nó if [Quantity] cập nhật lại thành 0
*/


CREATE PROC [procEditBill]
	@tableID INT, @foodID INT, @quantity INT
AS BEGIN
IF @quantity <> 0 
BEGIN	
	DECLARE @billID INT = (SELECT [ID] FROM [Bill] WHERE [TableID] = @tableID AND [StatusID]=0)
	IF @billID IS NULL 
	BEGIN
		IF @quantity > 0
		BEGIN		
			INSERT INTO [Bill] ([TableID]) VALUES (@tableID)
			SET @billID = (SELECT @@IDENTITY)
			INSERT INTO [BillDetail] ([BillID], [FoodID], [Quantity]) VALUES (@billID, @foodID, @quantity)
			UPDATE [Table] SET [StatusID] = 1 WHERE [ID] = @tableID
		END		
	END
	ELSE 
	BEGIN
		DECLARE @billDetailID INT = (SELECT [ID] FROM [BillDetail] WHERE [BillID] = @billID AND [FoodID] = @foodID)
		IF @billDetailID IS NULL 
		BEGIN		
			IF @quantity > 0 INSERT INTO [BillDetail] VALUES (@billID, @foodID, @quantity)
		END				
		ELSE 
		BEGIN
			DECLARE @temp INT = (SELECT [Quantity] FROM [BillDetail] WHERE [ID] = @billDetailID) + @quantity
			IF @temp <= 0
			BEGIN
				DELETE [BillDetail] WHERE [ID] = @billDetailID
				IF NOT EXISTS (SELECT [ID] FROM [BillDetail] WHERE [BillID] = @billID) 
				BEGIN
					DELETE [Bill] WHERE [ID] = @billID
					UPDATE [Table] SET [StatusID] = 0 WHERE [ID] = @tableID 
				END 
			END							
			ELSE UPDATE [BillDetail] SET [Quantity] = @temp WHERE [ID] = @billDetailID
		END			
	END
END
END
GO