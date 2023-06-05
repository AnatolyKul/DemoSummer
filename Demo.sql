CREATE DATABASE [Demo]
GO
USE [Demo]
GO

CREATE TABLE [Role]
(
[ID] int primary key identity (1,1),
[Name] varchar(55) not null
)

GO

CREATE TABLE [User]
(
[ID] int primary key identity (1,1),
[FullName] varchar(100) not null,
[Login] varchar (35) not null,
[Password] varchar (12) not null,
[Role] int foreign key references [Role] ([ID])
)

GO

CREATE TABLE [Manufacturer]
(
[Name] varchar (100) primary key
)

GO

CREATE TABLE [Product]
(
[ID] int primary key identity (1,1),
[Name] varchar(100) not null,
[Description] varchar (255) not null,
[Manufacturer] varchar (100) foreign key references [Manufacturer] ([Name]) not null,
Cost decimal(19,2),
CountDiscount varchar (3),
Photo varchar (100),
[CountInStock] int 
)

GO

CREATE TABLE Order_Status 
(
  [Name] nvarchar (30) primary key not null
)

GO

CREATE TABLE PickupPoint
(
 ID int primary key identity (1,1) not null,
 Adress varchar (200)
)

GO

create table [Order]
(
	OrderID int primary key identity (1,1),
	OrderDate date,
	OrderDeliveryDate datetime not null,
	OrderPickupPoint int foreign key references [PickupPoint] (ID) not null,
	Client int foreign key references [User] ([ID]),
	Code varchar (4),
	OrderStatus nvarchar(30) foreign key references Order_Status ([Name])
)

go

create table OrderProduct
(
	OrderID int foreign key references [Order](OrderID) not null,
	Product int foreign key references Product([ID]) not null,
	CountProduct int,
	Primary key (OrderID,Product)
)

