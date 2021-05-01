CREATE DATABASE DapperDB
GO
use DapperDB
GO
USE DapperDB
GO
CREATE TABLE Ogrenciler(
Id int identity(1,1) primary key,
Ad nvarchar(50)
)
GO
CREATE TABLE Dersler(
Id int identity(1,1) primary key,
Ad nvarchar(50)
)
GO
CREATE TABLE OgrenciDers(
Id int identity(1,1) primary key,
OgrenciId int foreign key references Ogrenciler(Id),
DersId int foreign key references Dersler(Id),
unique(OgrenciId,DersId)
)
GO