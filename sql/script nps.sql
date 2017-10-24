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