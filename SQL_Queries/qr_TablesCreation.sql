--Queries 
--Creating database.
create database demoDB;
use demoDB;

--Creating user table.
create table dbo.Users(
ID int identity(1001,1), --started value, incremental value.
username varchar(20) unique, --no duplication
email varchar (50) unique, 
password binary(64), --hashed and salted password 
salt uniqueidentifier,
createdDate datetime default getdate()
)
