CREATE DATABASE ConsultantsAndStoresDB
GO

USE ConsultantsAndStoresDB

BEGIN

	-- ########################################################################
	-- CREATE TABLES
	-- ########################################################################
	
	IF NOT EXISTS (SELECT 1 FROM sys.Tables WHERE Name = N'tblStore' AND TYPE = N'U')
	BEGIN
		CREATE TABLE dbo.tblStore(
			st_Id INT IDENTITY(1,1) NOT NULL,
			st_Name NVARCHAR(50) NOT NULL,
			st_Address NVARCHAR(256) NOT NULL,
			CONSTRAINT PK_Store PRIMARY KEY (st_Id)
		)
	END	

	IF NOT EXISTS (SELECT 1 FROM sys.Tables WHERE Name = N'tblConsultant' AND TYPE = N'U')
	BEGIN
		CREATE TABLE dbo.tblConsultant(
			cons_Id INT IDENTITY(1,1) NOT NULL,
			cons_Name NVARCHAR(50) NOT NULL,
			cons_LastName NVARCHAR(20) NOT NULL,
			cons_StoreId INT NULL,
			cons_AssignmentDate datetime NULL,
			CONSTRAINT PK_Consultant PRIMARY KEY (cons_Id)
		)
	END	
	
	-- ########################################################################
	-- FOREIGN KEYS
	-- ########################################################################

	IF EXISTS(SELECT 1 FROM sys.Tables WHERE Name = N'tblConsultant' AND TYPE = N'U')
		AND EXISTS(SELECT 1 FROM sys.Tables WHERE Name = N'tblStore' AND TYPE = N'U')
		AND NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_tblConsultant_TO_tblStore')
	BEGIN
		ALTER TABLE dbo.tblConsultant 
			ADD CONSTRAINT FK_tblConsultant_TO_tblStore FOREIGN KEY (cons_StoreId) REFERENCES dbo.tblStore (st_Id);
	END
	
END