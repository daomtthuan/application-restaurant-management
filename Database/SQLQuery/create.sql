﻿-- Create database
USE [master]
DROP DATABASE [RestaurantManagement]
CREATE DATABASE [RestaurantManagement]
ON PRIMARY(NAME = 'RestaurantManagement_Data', FILENAME = 'E:\Github\restaurant-management\Database\RestaurantManagement_Data.mdf')
LOG ON (NAME = 'RestaurantManagement_Log', FILENAME = 'E:\Github\restaurant-management\Database\RestaurantManagement_Log.ldf')
GO

-- Create tables
USE [RestaurantManagement]
-- Phân quyền tài khoản
CREATE TABLE [Role] (
    [ID]   INT           IDENTITY(0, 1) PRIMARY KEY, -- Mã
    [Name] NVARCHAR(100) NOT NULL                    -- Loại tài khoản
)
GO

-- Trạng thái bàn
CREATE TABLE [TableStatus] (
    [ID]   INT           IDENTITY(0, 1) PRIMARY KEY, -- Mã
    [Name] NVARCHAR(100) NOT NULL                    -- Loại trạng thái
)
GO

-- Trạng thái bill
CREATE TABLE [BillStatus] (
    [ID]   INT           IDENTITY(0, 1) PRIMARY KEY, -- Mã
    [Name] NVARCHAR(100) NOT NULL                    -- Loại trạng thái
)
GO

-- Loại thức ăn
CREATE TABLE [FoodCategory] (
    [ID]   INT           IDENTITY(0, 1) PRIMARY KEY, -- Mã
    [Name] NVARCHAR(100) NOT NULL                    -- Loại thức ăn
)
GO

-- Loại giới tính
CREATE TABLE [Gender] (
    [ID]   INT           IDENTITY(0, 1) PRIMARY KEY, -- Mã
    [Name] NVARCHAR(100) NOT NULL                    -- Loại giới tính
)
GO

-- Tài khoản
CREATE TABLE [Account] (
    [ID]           INT            IDENTITY(1, 1) PRIMARY KEY, -- Mã
    [Username]     NVARCHAR(100)  NOT NULL UNIQUE,            -- Tên đăng nhập
    [Password]     NVARCHAR(1000) NOT NULL DEFAULT 'user',    -- Mật khẩu
    [RoleID]       INT            NOT NULL DEFAULT 0,         -- Mã phân quyền
    [Name]         NVARCHAR(100)  NOT NULL,                   -- Tên
    [GenderID]     INT            NOT NULL,                   -- Giới tính		
    [Birthday]     DATE           NOT NULL,                   -- Ngày sinh
    [IdentityCard] NVARCHAR(20)   NOT NULL UNIQUE,            -- CMND/CCCD
    [Hometown]     NVARCHAR(100)  NOT NULL,                   -- Quê quán
    [Address]      NVARCHAR(100)  NOT NULL,                   -- Địa chỉ
    [Numberphone]  NVARCHAR(20),                              -- Số điện thoại
    [Email]        NVARCHAR(100),                             -- Email

    FOREIGN KEY ([RoleID]) REFERENCES [Role] ([ID]),
    FOREIGN KEY ([GenderID]) REFERENCES [Gender] ([ID]))
GO

-- Bàn ăn
CREATE TABLE [Table] (
    [ID]       INT           IDENTITY(0, 1) PRIMARY KEY,       -- Mã
    [Name]     NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên', -- Tên bàn
    [StatusID] INT           NOT NULL DEFAULT 0,               -- Trạng thái bàn

    FOREIGN KEY ([StatusID]) REFERENCES [TableStatus] ([ID]))
GO

-- Thức ăn
CREATE TABLE [Food] (
    [ID]         INT           IDENTITY(0, 1) PRIMARY KEY,       -- Mã
    [Name]       NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên', -- Tên thức ăn
    [CategoryID] INT           NOT NULL,                         -- Mã loại thức ăn
    [Price]      INT           NOT NULL DEFAULT 0,
    FOREIGN KEY ([CategoryID]) REFERENCES [FoodCategory] ([ID]))
GO

-- Hoá đơn
CREATE TABLE [Bill] (
    [ID]       INT      IDENTITY(0, 1) PRIMARY KEY, -- Mã
    [CheckIn]  DATETIME NOT NULL DEFAULT GETDATE(), -- Thời gian vào
    [CheckOut] DATETIME,                            -- Thời gian ra
    [TableID]  INT      NOT NULL,                   -- Mã bàn ăn
    [StatusID] INT      NOT NULL DEFAULT 0,         -- Trạng thái hoá đơn
    [Discount] INT      NOT NULL DEFAULT 0,         -- Giảm giá

    CHECK ([CheckIn] <= [CheckOut]),
    CHECK (0 <= [Discount] AND [Discount] <= 100),
    FOREIGN KEY ([TableID]) REFERENCES [Table] ([ID]),
    FOREIGN KEY ([StatusID]) REFERENCES [BillStatus] ([ID]))
GO

-- Chi tiết hoá đơn
CREATE TABLE [BillDetail] (
    [ID]       INT IDENTITY(0, 1) PRIMARY KEY,        -- Mã
    [BillID]   INT NOT NULL REFERENCES [Bill] ([ID]), -- Mã hoá đơn
    [FoodID]   INT NOT NULL REFERENCES [Food] ([ID]), -- Mã thức ăn
    [Quantity] INT NOT NULL DEFAULT 0,                -- Số lượng

    CHECK ([Quantity] > 0),
    FOREIGN KEY ([BillID]) REFERENCES [Bill] ([ID]),
    FOREIGN KEY ([FoodID]) REFERENCES [Food] ([ID]))
GO

-- Create proc
-- get food tables
CREATE PROC [proc_GetAccountID]
    @username NVARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
    SELECT [Account].[ID] FROM [Account] WHERE [Username] = @username AND [Password] = @password
END
GO

-- get food tables
CREATE PROC [proc_GetTable]
AS
BEGIN
    SELECT [ID], [Name], [StatusID] FROM [Table]
END
GO

-- get bill by tableID, statusID
CREATE PROC [proc_GetBill]
    @tableID INT, @statusID INT
AS
BEGIN
    IF @statusID = -1
        SELECT [ID], [CheckIn], [CheckOut], [TableID], [StatusID], [Discount] FROM [Bill] WHERE [TableID] = @tableID
    ELSE
        SELECT [ID], [CheckIn], [CheckOut], [TableID], [StatusID], [Discount] FROM [Bill] WHERE [TableID] = @tableID AND [StatusID] = @statusID
END
GO

-- get BillDetail by billID
CREATE PROC [proc_GetBillDetailByBillID] @billID INT
AS
BEGIN
    SELECT [BillDetail].[ID], [Food].[Name] AS [FoodName], [Quantity], [Price], [Price] * [Quantity] AS [Total]
    FROM [BillDetail]
        JOIN [Food] ON [Food].[ID] = [BillDetail].[FoodID]
    WHERE [BillID] = @billID
END
GO

-- get FoodCategory
CREATE PROC [proc_GetFoodCategory]
AS
BEGIN
    SELECT [ID], [Name] FROM [FoodCategory]
END
GO

-- get food by CategoryID
CREATE PROC [proc_GetFood] @categoryID INT
AS
BEGIN
    SELECT [ID], [Name], [CategoryID], [Price] FROM [Food] WHERE [CategoryID] = @categoryID
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


CREATE PROC [proc_EditBill]
    @tableID INT, @foodID INT, @quantity INT
AS
BEGIN
    IF @quantity <> 0
    BEGIN
        DECLARE @billID INT = (SELECT [ID] FROM [Bill] WHERE [TableID] = @tableID AND [StatusID] = 0)
        IF @billID IS NULL
        BEGIN
            IF @quantity > 0
            BEGIN
                INSERT INTO [Bill] ([TableID]) VALUES (@tableID)
                SET @billID = (SELECT @@IDENTITY)
                INSERT INTO [BillDetail] ([BillID], [FoodID], [Quantity]) VALUES (@billID, @foodID, @quantity)               
            END
        END
        ELSE
        BEGIN
            DECLARE @billDetailID INT = (SELECT [ID] FROM [BillDetail] WHERE [BillID] = @billID AND [FoodID] = @foodID)
            IF @billDetailID IS NULL
            BEGIN
                IF @quantity > 0
                    INSERT INTO [BillDetail] VALUES (@billID, @foodID, @quantity)
            END
            ELSE
            BEGIN
                DECLARE @temp INT = (SELECT [Quantity] FROM [BillDetail] WHERE [ID] = @billDetailID) + @quantity
                IF @temp <= 0                
                    DELETE [BillDetail] WHERE [ID] = @billDetailID      
                ELSE
                    UPDATE [BillDetail] SET [Quantity] = @temp WHERE [ID] = @billDetailID
            END
        END
    END
END
GO

-- update bill for pay
CREATE PROC [proc_PayBill]
    @billID INT, @discount INT
AS
BEGIN
    UPDATE [Bill] SET [StatusID] = 1, [Discount] = @discount, [CheckOut] = GETDATE() WHERE [ID] = @billID
END
GO

-- create trigger

CREATE TRIGGER [trig_UpdateBill]
ON [Bill]
FOR UPDATE
AS
BEGIN
    DECLARE @tableID INT = (SELECT [TableID] FROM [Inserted])
    IF ((SELECT COUNT([ID]) FROM [Bill] WHERE [StatusID] = 0 AND [TableID] = @tableID) = 1)
        UPDATE [Table] SET [StatusID] = 1 WHERE [ID] = @tableID
    ELSE
        UPDATE [Table] SET [StatusID] = 0 WHERE [ID] = @tableID
END
GO

CREATE TRIGGER [trig_InsertBill] ON [Bill] FOR INSERT
AS BEGIN
    UPDATE [Table] SET [StatusID] = 1 WHERE [ID] = (SELECT [TableID] FROM [Inserted])
END
GO

CREATE TRIGGER [trig_DeleteBill] ON [Bill] FOR DELETE
AS BEGIN
    UPDATE [Table] SET [StatusID] = 0 WHERE [ID] = (SELECT [TableID] FROM [Deleted])
END
GO

CREATE TRIGGER [trig_DeleteBillDetail] ON [BillDetail] FOR DELETE
AS BEGIN
	DECLARE @billID INT = (SELECT [BillID] FROM [Deleted])
	IF (SELECT COUNT([ID]) FROM [BillDetail] WHERE [BillID] = @billID) = 0
		DELETE [Bill] WHERE [ID] = @billID  
END
GO

-- template data
USE [RestaurantManagement]
INSERT INTO [Role] VALUES (N'Không hoạt động')
INSERT INTO [Role] VALUES (N'Quản lý')
INSERT INTO [Role] VALUES (N'Nhân viên Thu ngân')
INSERT INTO [Role] VALUES (N'Nhân viên Pha chế')
INSERT INTO [Role] VALUES (N'Nhân viên Phục vụ')
INSERT INTO [Role] VALUES (N'Nhân viên Tạp vụ')
INSERT INTO [Role] VALUES (N'Nhân viên Vận chuyển')
INSERT INTO [Role] VALUES (N'Bảo vệ')
INSERT INTO [TableStatus] VALUES (N'Trống')
INSERT INTO [TableStatus] VALUES (N'Có người')
INSERT INTO [TableStatus] VALUES (N'Đã được đặt')
INSERT INTO [BillStatus] VALUES (N'Chưa thanh toán')
INSERT INTO [BillStatus] VALUES (N'Đã thanh toán')
INSERT INTO [Gender] VALUES (N'Nam')
INSERT INTO [Gender] VALUES (N'Nữ')
INSERT INTO [Account]
VALUES ('admin', 'admin', 1, N'Đào Minh Trung Thuận', 0, '1999-09-18', '362540898', N'Thành phố Cần Thơ', N'57 Đường B5, Phường Hưng Phú, Quận Cái Răng, Thành phố Cần Thơ', '0939908568', 'dao.mt.thuan@gmail.com')
INSERT INTO [Account]
VALUES ('quanly', '1', 1, N'Cao Lập Triệu', 0, '1990-03-19', '101543076', N'Thành phố Hải Dương', N'74 Phố Hoán, Phường Võ Vỹ Sáng, Quận Tuyết Miên, Thành phố Hải Dương', '0253062672', 'lap.trieu@gmail.com')
INSERT INTO [Account]
VALUES ('thungan', '1', 2, N'Cự Hà Trúc', 1, '1995-08-23', '635764587', N'Tỉnh Bắc Kạn', N'94 Thôn 08, Phường Ninh, Quận Chế Thêu, Tỉnh Bắc Kạn', '0599397220', 'ha.truc@gmail.com')
INSERT INTO [Account]
VALUES ('phucvu1', '1', 4, N'La Cát Tuyến', 1, '1993-11-22', '715920211', N'Tỉnh Quảng Ninh', N'278 Thôn 5, Phường 76, Quận Đôn Nguyệt, Tỉnh Quảng Ninh', '01860831308', 'cat.tuyen@gmail.com')
INSERT INTO [Account]
VALUES ('phucvu2', '1', 4, N'Mộc Hải Ngạn', 0, '1998-11-05', '365532348 ', N'Tỉnh Bạc Liêu', N'9336 Phố Nhiệm Toàn Ca, Xã Quyết Bào, Quận Cái, Tỉnh Bạc Liêu', '0919641619', 'hai.ngan@gmail.com')
DECLARE @i INT = 0
WHILE @i < 30
BEGIN
    SET @i = @i + 1
    INSERT INTO [Table] ([Name]) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
END
UPDATE [Table] SET [StatusID] = 1 WHERE [ID] IN (1, 2, 4, 6, 10, 14, 20, 21, 25, 26)
INSERT INTO [FoodCategory] VALUES (N'Trà sữa')
INSERT INTO [FoodCategory] VALUES (N'Thạch')
INSERT INTO [FoodCategory] VALUES (N'Trà')
INSERT INTO [FoodCategory] VALUES (N'Soda')
INSERT INTO [FoodCategory] VALUES (N'Sữa')
INSERT INTO [FoodCategory] VALUES (N'Thức uống khác')
INSERT INTO [FoodCategory] VALUES (N'Món ăn nhẹ')
INSERT INTO [FoodCategory] VALUES (N'Mì')
INSERT INTO [FoodCategory] VALUES (N'Cơm')
INSERT INTO [FoodCategory] VALUES (N'Canh')
INSERT INTO [FoodCategory] VALUES (N'Món thêm')
INSERT INTO [FoodCategory] VALUES (N'Bánh')
INSERT INTO [FoodCategory] VALUES (N'Chè')
INSERT INTO [Food] VALUES (N'Trà sữa trân châu', 0, 23000)
INSERT INTO [Food] VALUES (N'Trà sữa thập cẩm', 0, 23000)
INSERT INTO [Food] VALUES (N'Trà sữa truyền thống', 0, 18000)
INSERT INTO [Food] VALUES (N'Trà sữa thái xanh', 0, 23000)
INSERT INTO [Food] VALUES (N'Trà sữa thái đỏ', 0, 23000)
INSERT INTO [Food] VALUES (N'Trà sữa thái sương sáo', 0, 28000)
INSERT INTO [Food] VALUES (N'Trà sữa thái thập cẩm', 0, 28000)
INSERT INTO [Food] VALUES (N'Trân châu', 1, 5000)
INSERT INTO [Food] VALUES (N'Sương sáo', 1, 5000)
INSERT INTO [Food] VALUES (N'Thạch cà phê', 1, 5000)
INSERT INTO [Food] VALUES (N'Thạch cacao', 1, 5000)
INSERT INTO [Food] VALUES (N'Thạch trái cây', 1, 5000)
INSERT INTO [Food] VALUES (N'Jelly', 1, 2000)
INSERT INTO [Food] VALUES (N'Đào', 1, 7000)
INSERT INTO [Food] VALUES (N'Khúc bạch', 1, 1000)
INSERT INTO [Food] VALUES (N'Trà chanh', 2, 15000)
INSERT INTO [Food] VALUES (N'Trà chanh trân châu', 2, 20000)
INSERT INTO [Food] VALUES (N'Trà chanh thái xanh', 2, 18000)
INSERT INTO [Food] VALUES (N'Trà chanh thái đỏ', 2, 18000)
INSERT INTO [Food] VALUES (N'Trà đào', 2, 35000)
INSERT INTO [Food] VALUES (N'Trà đào không đào', 2, 30000)
INSERT INTO [Food] VALUES (N'Hồng trà', 2, 18000)
INSERT INTO [Food] VALUES (N'Hồng trà chanh', 2, 18000)
INSERT INTO [Food] VALUES (N'Mojito đào', 2, 30000)
INSERT INTO [Food] VALUES (N'Soda dâu', 3, 30000)
INSERT INTO [Food] VALUES (N'Soda đào', 3, 30000)
INSERT INTO [Food] VALUES (N'Soda việt quất', 3, 30000)
INSERT INTO [Food] VALUES (N'Soda chanh', 3, 30000)
INSERT INTO [Food] VALUES (N'Sữa dâu', 4, 30000)
INSERT INTO [Food] VALUES (N'Sữa đào', 4, 30000)
INSERT INTO [Food] VALUES (N'Sữa việt quất', 4, 30000)
INSERT INTO [Food] VALUES (N'Nước suối', 5, 10000)
INSERT INTO [Food] VALUES (N'Nước hoa Atiso', 5, 25000)
INSERT INTO [Food] VALUES (N'Blue sky', 5, 35000)
INSERT INTO [Food] VALUES (N'7up', 5, 12000)
INSERT INTO [Food] VALUES (N'Pepsi', 5, 12000)
INSERT INTO [Food] VALUES (N'Cocacola', 5, 12000)
INSERT INTO [Food] VALUES (N'Sting', 5, 12000)
INSERT INTO [Food] VALUES (N'Chân gà sốt cay', 6, 70000)
INSERT INTO [Food] VALUES (N'Chân gà nước mắm', 6, 70000)
INSERT INTO [Food] VALUES (N'Tokbokki phô mai', 6, 47000)
INSERT INTO [Food] VALUES (N'Cá viên chiên', 6, 45000)
INSERT INTO [Food] VALUES (N'Chả cá lạp xưởng', 6, 50000)
INSERT INTO [Food] VALUES (N'Salad bò trứng', 6, 45000)
INSERT INTO [Food] VALUES (N'Sandwish chiên', 6, 45000)
INSERT INTO [Food] VALUES (N'Cá viên cari', 6, 25000)
INSERT INTO [Food] VALUES (N'Bánh mè phô mai', 6, 40000)
INSERT INTO [Food] VALUES (N'Bắp xào tôm khô', 6, 35000)
INSERT INTO [Food] VALUES (N'Bắp xào trứng muối', 6, 25000)
INSERT INTO [Food] VALUES (N'Bắp xào tôm trứng', 6, 35000)
INSERT INTO [Food] VALUES (N'Mi kim chi sụn bò', 7, 55000)
INSERT INTO [Food] VALUES (N'Mi xào hải sản', 7, 58000)
INSERT INTO [Food] VALUES (N'Mi ý hải sản', 7, 55000)
INSERT INTO [Food] VALUES (N'Mi thái hải sản', 7, 55000)
INSERT INTO [Food] VALUES (N'Mi udon hải sản', 7, 78000)
INSERT INTO [Food] VALUES (N'Mi xào bò', 7, 55000)
INSERT INTO [Food] VALUES (N'Mi ý bò trứng', 7, 55000)
INSERT INTO [Food] VALUES (N'Mi trộn gà xé', 7, 50000)
INSERT INTO [Food] VALUES (N'Mi xào ốc giác', 7, 59000)
INSERT INTO [Food] VALUES (N'Mi cua', 7, 59000)
INSERT INTO [Food] VALUES (N'Cơm gà xé chà bông', 8, 55000)
INSERT INTO [Food] VALUES (N'Cơm bò phô mai', 8, 55000)
INSERT INTO [Food] VALUES (N'Cơm chiên trứng', 8, 35000)
INSERT INTO [Food] VALUES (N'Cơm kim chi', 8, 58000)
INSERT INTO [Food] VALUES (N'Cơm trộn maika', 8, 55000)
INSERT INTO [Food] VALUES (N'Cơm trộn maika', 8, 55000)
INSERT INTO [Food] VALUES (N'Cơm ruốc thái', 8, 58000)
INSERT INTO [Food] VALUES (N'Cơm gà sốt me', 8, 55000)
INSERT INTO [Food] VALUES (N'Canh kim chi', 9, 35000)
INSERT INTO [Food] VALUES (N'Canh kim chi không trứng', 9, 30000)
INSERT INTO [Food] VALUES (N'Canh miso', 9, 25000)
INSERT INTO [Food] VALUES (N'Canh trứng', 9, 10000)
INSERT INTO [Food] VALUES (N'Bún', 10, 5000)
INSERT INTO [Food] VALUES (N'Nước lèo', 10, 20000)
INSERT INTO [Food] VALUES (N'Mì', 10, 5000)
INSERT INTO [Food] VALUES (N'Rau', 10, 20000)
INSERT INTO [Food] VALUES (N'Trứng', 10, 5000)
INSERT INTO [Food] VALUES (N'Đồ ăn', 10, 20000)
INSERT INTO [Food] VALUES (N'Đồ ăn', 10, 40000)
INSERT INTO [Food] VALUES (N'Kim chi', 10, 5000)
INSERT INTO [Food] VALUES (N'Cơm', 10, 5000)
INSERT INTO [Food] VALUES (N'Bông lan trứng muối', 11, 20000)
INSERT INTO [Food] VALUES (N'Tiramisu', 11, 40000)
INSERT INTO [Food] VALUES (N'Chè khúc bạch', 12, 30000)
INSERT INTO [Food] VALUES (N'Jelly', 12, 10000)

INSERT INTO [Bill] VALUES (GETDATE() - 2, GETDATE() - 1.5, 1, 1, 3)
INSERT INTO [Bill] VALUES (GETDATE() - 1, GETDATE() - 0.8, 2, 1, 50)
INSERT INTO [Bill] VALUES (GETDATE() - 2, GETDATE() - 1.9, 3, 1, 0)
INSERT INTO [Bill] VALUES (GETDATE() - 3, GETDATE() - 2.6, 4, 1, 0)

INSERT INTO [Bill] ([TableID]) VALUES (1)
INSERT INTO [Bill] ([TableID]) VALUES (2)
INSERT INTO [Bill] ([TableID]) VALUES (4)
INSERT INTO [Bill] ([TableID]) VALUES (6)
INSERT INTO [Bill] ([TableID]) VALUES (10)
INSERT INTO [Bill] ([TableID]) VALUES (14)
INSERT INTO [Bill] ([TableID]) VALUES (20)
INSERT INTO [Bill] ([TableID]) VALUES (21)
INSERT INTO [Bill] ([TableID]) VALUES (25)
INSERT INTO [Bill] ([TableID]) VALUES (26)

INSERT INTO [BillDetail] VALUES (0, 0, 1)
INSERT INTO [BillDetail] VALUES (0, 2, 1)
INSERT INTO [BillDetail] VALUES (1, 8, 1)
INSERT INTO [BillDetail] VALUES (2, 12, 1)
INSERT INTO [BillDetail] VALUES (3, 32, 1)
INSERT INTO [BillDetail] VALUES (3, 36, 2)
INSERT INTO [BillDetail] VALUES (3, 30, 4)
INSERT INTO [BillDetail] VALUES (4, 0, 1)
INSERT INTO [BillDetail] VALUES (5, 0, 3)
INSERT INTO [BillDetail] VALUES (6, 10, 1)
INSERT INTO [BillDetail] VALUES (7, 22, 3)
INSERT INTO [BillDetail] VALUES (7, 36, 1)
INSERT INTO [BillDetail] VALUES (7, 41, 1)
INSERT INTO [BillDetail] VALUES (8, 0, 2)
INSERT INTO [BillDetail] VALUES (9, 5, 1)
INSERT INTO [BillDetail] VALUES (9, 10, 1)
INSERT INTO [BillDetail] VALUES (9, 20, 1)
INSERT INTO [BillDetail] VALUES (10, 0, 2)
INSERT INTO [BillDetail] VALUES (10, 2, 1)
INSERT INTO [BillDetail] VALUES (11, 8, 1)
INSERT INTO [BillDetail] VALUES (11, 12, 1)
INSERT INTO [BillDetail] VALUES (11, 25, 1)
INSERT INTO [BillDetail] VALUES (12, 12, 2)
INSERT INTO [BillDetail] VALUES (13, 10, 1)
INSERT INTO [BillDetail] VALUES (13, 20, 1)
INSERT INTO [BillDetail] VALUES (13, 0, 3)
GO