use master
--create database RestaurantManagement
create database RestaurantManagement on primary
(
	Name = 'RestaurantManagement_Data',
	Filename = 'E:\Github\restaurant-management\Database\RestaurantManagement_Data.mdf'
)
log on
(
	Name = 'RestaurantManagement_Log',
	Filename = 'E:\Github\restaurant-management\Database\RestaurantManagement_Log.ldf'
)
go

use RestaurantManagement

-- Phân quyền tài khoản
create table Roles
(
	ID int primary key,												-- Mã
	[Name] nvarchar(100) not null									-- Loại tài khoản
)
go

-- Trạng thái bàn
create table TableStatus
(
	ID int primary key,												-- Mã
	[Name] nvarchar(100) not null									-- Loại trạng thái
)
go

-- Trạng thái bill
create table BillStatus
(
	ID int primary key,												-- Mã
	[Name] nvarchar(100) not null									-- Loại trạng thái
)
go

-- Loại thức ăn
create table FoodCategory
(
	ID int primary key,												-- Mã
	[Name] nvarchar(100) not null									-- Loại thức ăn
)
go

-- Tài khoản
create table Accounts
(
	ID int identity primary key,									-- Mã
	Username varchar(100) not null unique,							-- Tên đăng nhập
	[Password] varchar(1000) not null default 'user',				-- Mật khẩu
	RoleID int not null default 0,									-- Mã phân quyền
	[Name] nvarchar(100) not null,									-- Tên
	Gender nvarchar(3) not null,									-- Giới tính		
	Birthday date not null,											-- Ngày sinh
	IdentityCard  varchar(20) not null unique,						-- CMND/CCCD
	Hometown nvarchar(100) not null,								-- Quê quán
	[Address] nvarchar(100) not null,								-- Địa chỉ
	Numberphone varchar(20),										-- Số điện thoại
	Email varchar(100),												-- Email

	check (Gender in ('Nam', N'Nữ')),
	foreign key (RoleID) references Roles(ID)
)
go

-- Bàn ăn
create table FoodTables
(
	ID int identity primary key,									-- Mã
	[Name] nvarchar(100) not null default N'Chưa đặt tên',			-- Tên bàn
	StatusID int not null  default 0,								-- Trạng thái bàn
	TableType int not null default 1,								-- Loại bàn	
	
	check (TableType > 0),
	foreign key (StatusID) references TableStatus(ID)
)
go

-- Thức ăn
create table Foods
(
	ID int identity primary key,									-- Mã
	[Name] nvarchar(100) not null default N'Chưa đặt tên',			-- Tên thức ăn
	CategoryID int not null,										-- Mã loại thức ăn
	Price int not null default 0,
	
	foreign key (CategoryID) references FoodCategory(ID)
)
go

-- Hoá đơn
create table Bills
(
	ID int identity primary key,									-- Mã
	CheckIn datetime not null default getDate(),					-- Thời gian vào
	CheckOut datetime,												-- Thời gian ra
	TableID int not null,											-- Mã bàn ăn
	StatusID int not null default 0,								-- Trạng thái hoá đơn

	check(CheckIn <= CheckOut),
	foreign key (TableID) references FoodTables(ID),
	foreign key (StatusID) references BillStatus(ID)
)
go

-- Chi tiết hoá đơn
create table BillDetail
(
	ID int identity primary key,									-- Mã
	BillID int not null references Bills(ID),						-- Mã hoá đơn
	FoodID int not null references Foods(ID),						-- Mã thức ăn
	Quantity int not null default 0,

	foreign key (BillID) references Bills(ID),						
	foreign key (FoodID) references Foods(ID)	
)
go