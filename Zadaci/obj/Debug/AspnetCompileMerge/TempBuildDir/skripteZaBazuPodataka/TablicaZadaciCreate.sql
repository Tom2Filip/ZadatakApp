﻿/* ZadaciDB */
CREATE TABLE [dbo].[Zadaci]
(  
 [Id]  INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
 [Start] DATETIME NOT NULL,
 [Naslov] NVARCHAR (50) NOT NULL,
 [Opis] NVARCHAR(300) NULL,
 [Status] BIT NOT NULL,
 [Kraj] DATETIME NULL

) ON [PRIMARY]
GO