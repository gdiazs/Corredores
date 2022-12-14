USE master
GO

IF NOT EXISTS (SELECT * FROM sys.sysdatabases WHERE name = 'CorredoresDB')
	CREATE DATABASE CorredoresDB
	GO
GO


USE CorredoresDB;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Corredor')
	CREATE TABLE Corredor (
		CorredorID int IDENTITY(0,1) NOT NULL,
		CorredorNombre varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		Minutos int,
		Segundos int,
		CONSTRAINT Corredor_PK PRIMARY KEY (CorredorID)
	);
	GO
GO
