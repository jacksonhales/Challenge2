﻿CREATE TABLE [dbo].[Tour]
(
	[tourID] INT NOT NULL,
	[name] VARCHAR(50) NOT NULL,
	[description] VARCHAR(300) NOT NULL,
	CONSTRAINT PK_Tour PRIMARY KEY (tourID)
)
