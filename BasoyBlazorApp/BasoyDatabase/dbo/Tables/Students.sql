CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Country] VARCHAR(50) NULL, 
    [SMessage] VARCHAR(MAX) NULL
)
