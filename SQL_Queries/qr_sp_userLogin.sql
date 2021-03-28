--Queries of stored procedures.

create proc sp_userLogin(
@username varchar(50),
@password varchar(100)
)as begin 
select count(*) from Users where username = @username and 
password = hashbytes('sha2_512',@password + cast(salt as nvarchar(36)));
end 

--exec sp_userLogin 'wudi','password';