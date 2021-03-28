--User Table Insertion 

declare @salt uniqueidentifier = newid();
insert into Users (username,email,password,salt)values(
'wudi','wudi_7@hotmail.com',hashbytes('sha2_512','password' + cast(@salt as nvarchar(36))),@salt
)

/*Password hashing using sha2_512*/

declare @password binary(64) = hashbytes('sha2_512','userpassword');
select @password;

/*Why salt? 
1. Generate completely different id every single times.
2. Unlike Hashing, the hashed value will be the same if users having the same password.
*/
declare @saltvalue uniqueidentifier = newid(); 
select @saltvalue;

/*Instead of hashing only the password, 
to enhance the security, we hashed both password and the salt value*/

declare @passwordNew binary(64) = hashbytes('sha2_512','userpassword' + cast(@salt as nvarchar(36)));
select @passwordNew;

