CREATE DATABASE IdentityStudy
GO

use [IdentityStudy];

CREATE TABLE Users  
(  
 Id uniqueidentifier NOT NULL  
   DEFAULT newid(),
 Name nvarchar(40) NOT NULL,
 Surname nvarchar(40) NOT NULL,
 Email nvarchar(40) NOT NULL,
 Password nvarchar(90) NOT NULL,
 CONSTRAINT ID_PK PRIMARY KEY (ID)
)
GO

CREATE INDEX Email_Index ON Users (Email);
GO