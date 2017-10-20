use 
master

create database nps
go

use 
nps

create table dbo.avaliations(
	id int IDENTITY(1,1) NOT NULL
	,code nvarchar(150) NOT NULL
	,month nvarchar(10) NOT NULL
	,year nvarchar(6) NOT NULL
	,area int NOT NULL
	,removed int default(0) 
	,finished bit NOT NULL default(0) 
	,detrators int default(0) 
	,neutrals int default(0) 
	,promoters int default(0) 
	,result decimal(5, 2) default(0.0) 
	,constraint pk_id_avaliations primary key (id)
)
go

create table dbo.customers(
	id int IDENTITY(1,1) NOT NULL
	,name nvarchar(150) NOT NULL
	,responsible nvarchar(150) NOT NULL
	,area int NOT NULL
	,nps_status int NOT NULL
	,removed int NOT NULL default(0)
	,customer_since date NOT NULL
	,last_avaliation date
	,constraint pk_id_customers primary key (id)
)
go

create table dbo.avaliations_participants(
	id int IDENTITY(1,1) NOT NULL
	,customer_id int
	,avaliation_id int NULL
	,score int NOT NULL default(0)
	,feedback varchar(250) NOT NULL default('')
	,is_valid bit default(1)
	,finished bit default(0)
	,area int NOT NULL default(0)
	,justificative varchar(400) default('')
	,feedback_category varchar(250) default('')
	,constraint pk_id_avaliations_participants primary key(id)
	,constraint fk_id_avaliations_avaliations_participants foreign key (id) references dbo.avaliations(id)
	,constraint fk_id_customers_avaliations_participants foreign key (id) references dbo.customers(id)
)
go
