create database Pentacle_Marketing

create table Forms
(Id int Primary key IDENTITY(1,1) not null,
Email nvarchar(max) not null,
FullName nvarchar(max) not null,
Method nvarchar(max) not null,
Description nvarchar(max) not null,
CreateDate date not null)