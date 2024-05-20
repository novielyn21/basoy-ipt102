CREATE TABLE [dbo].[accounts]
(
	[accountId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(50) NULL
)
