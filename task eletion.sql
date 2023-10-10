create table stock(

id int identity(1,1)primary key,
product varchar(100),
category varchar(100),
price int ,
quantity int,
total int
);


create proc sp_stock
@id int=0,
@product varchar(100)=null,
@category varchar(100)=null,
@price int =0,
@quantity int=0,
@total int =0,
@action varchar(50)=null
AS
BEGIN
begin
if(@action='insert')
insert into stock values(@product,@category,@price,@quantity,@total)
end

begin
if(@action='upadate')
update  stock set product=@product,category=@category,price=@price,quantity=@quantity,total=@total where id=@id
end



begin
if(@action='delete')
delete from stock where id=@id
end


begin
if(@action='selectone')
select* from stock where id=@id
end

begin
if(@action='select')
select* from stock
end

END


exec sp_stock @action='select'