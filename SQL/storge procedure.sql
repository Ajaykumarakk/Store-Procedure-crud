create table vegetables
(
name nvarchar (200) not null,
ownername nvarchar (200) not null,
quantity int not  null,
price int not null,
location nvarchar (200)not null
)

drop table vegetables
select * from vegetables

create procedure pinsert(@name nvarchar (200),@ownername nvarchar (200),@quantity int,@price int,@location nvarchar(200))
as
begin
insert into vegetables(name,ownername,quantity,price,location) values (@name,@ownername,@quantity,@price,@location)
end

exec pinsert 'tomato','ajay',20,200,'palani'

create procedure selects
as
begin
select * from vegetables
end 

exec selects