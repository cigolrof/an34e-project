use 
master

create database nps
go

use 
nps

-- Tabelas
create table dbo.avaliations(
	 id int IDENTITY(1,1) NOT NULL
	,code nvarchar(150) NOT NULL
	,month nvarchar(10) NOT NULL
	,year nvarchar(6) NOT NULL
	,area int NOT NULL	
	,finished bit NOT NULL default(0) 
	,detrators int default(0) 
	,neutrals int default(0) 
	,promoters int default(0) 
	,result decimal(5, 2) default(0.0) 
	,removed int default(0) 
	,constraint pk_id_avaliations primary key (id)
)
go

create table dbo.customers(
	 id int IDENTITY(1,1) NOT NULL
	,name nvarchar(150) NOT NULL
	,responsible nvarchar(150) NOT NULL
	,area int NOT NULL
	,nps_status int NOT NULL	
	,customer_since date NOT NULL
	,last_avaliation date
	,removed int NOT NULL default(0)
	,constraint pk_id_customers primary key (id)
)
go

create table dbo.questions(
	 id int IDENTITY(1,1) NOT NULL
	,question varchar(400) default('')
	,level int
	,level_required int
	,removed int NOT NULL default(0)
	,constraint pk_id_questions primary key(id)
)
go

create table dbo.avaliations_participants(
	 id int IDENTITY(1,1) NOT NULL
	,id_avaliation int NULL
	,id_customer int
	,id_questions int
	,score int NOT NULL default(0)
	,feedback varchar(250) NOT NULL default('')
	,is_valid bit default(1)
	,finished bit default(0)
	,area int NOT NULL default(0)
	,justificative varchar(400) default('')
	,feedback_category varchar(250) default('')
	,constraint pk_id_avaliations_participants primary key(id)
	,constraint fk_id_avaliations_avaliations_participants foreign key (id_avaliation) references dbo.avaliations(id)
	,constraint fk_id_customers_avaliations_participants foreign key (id_customer) references dbo.customers(id)
	,constraint fk_id_questions_avaliations_participants foreign key (id_questions) references dbo.questions(id)
)
go

-- Procedures
create procedure insertAvaliation
@Code nvarchar(150),
@Month nvarchar(10),
@Year nvarchar(6),
@Area int,
@Finished bit,
@Detrators int,
@Neutrals int,
@Promoters int,
@Result decimal(5,2)
as
begin
	insert into avaliations 
	(code, month, year, area, finished, detrators, neutrals, promoters, result)
	values
	(@Code, @Month, @Year, @Area, @Finished, @Detrators, @Neutrals, @Promoters, @Result)
	select @@IDENTITY as return_id
end


create procedure InsertCustomer
@Nome as nvarchar(150),
@Responsible as nvarchar(150),
@Area as int,
@NpsStatus as int,
@CustomerSince as date,
@LastAvaliation as date
as
begin
	insert into customers 
	(name, responsible, area, nps_status, customer_since, last_avaliation)
	values
	(@Nome, @Responsible, @Area, @NpsStatus, @CustomerSince, @LastAvaliation)
	select @@IDENTITY as return_id
end

create procedure searchIdCustomer
@Id as int
as 
begin
	select * from customers
	where id = @Id and removed = 0
end

create procedure listAllCustomers
as 
begin
	select * from customers
	where removed = 0
end