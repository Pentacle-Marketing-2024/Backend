create database Pentacle_Marketing

create table Forms
(Id int Primary key IDENTITY(1,1) not null,
Email varchar(max) not null,
FullName varchar(max) not null,
Method varchar(max) not null,
Description varchar(max) not null,
CreateDate date not null)