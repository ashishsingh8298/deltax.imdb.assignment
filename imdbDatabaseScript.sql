drop database imdb;
CREATE DATABASE imdb;

use imdb;

Create Table Actor
(
	ActorId int Primary Key Identity(1,1),
	ActorFirstName varchar(500) not null,
	ActorLastName varchar(500),
	Bio varchar(max) not null,
	DOB Datetime not null,
	Gender char(1) not null constraint Actor_gender_ck CHECK(Gender in ('M','F','O'))
);

Create Table Producer
(
	ProducerId int Primary Key Identity(1,1),
	ProducerFirstName varchar(500) not null,
	ProducerLastName varchar(500),
	Bio varchar(max) not null,
	DOB Datetime not null,
	Company varchar(max) not null,
	Gender char(1) not null constraint Producer_gender_ck CHECK(Gender in ('M','F','O'))
);


Create Table Movie
(
	MovieId int Primary Key Identity(1,1),
	MovieName varchar(500) not null,
	Plot varchar(max) not null,
	DateOfRelease Datetime not null,
	ProducerId int Foreign Key References Producer(ProducerId) not null,
	PosterURL varchar(max) not null
);



Create Table MovieActorsMapping(
	MovieActorsId int Identity(1,1),
	MovieId int Foreign Key References Movie(MovieId) not null,
	ActorId int Foreign Key References Actor(ActorId) not null,
	PRIMARY KEY (MovieId, ActorId)
);


--Run this command in Package Manager Console to complete Scaffolding and please change connection string in appsetting.json file
--Below command will create entity(Table) in the Models folder

--Scaffold-DbContext "Name=ConnectionStrings:ImdbDatabase" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

