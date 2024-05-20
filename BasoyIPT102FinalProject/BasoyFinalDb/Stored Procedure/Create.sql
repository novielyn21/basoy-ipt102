CREATE PROCEDURE [dbo].[Create]
	@username varchar(50),
	@password varchar(50)
AS
BEGIN 
INSERT INTO [dbo].[accounts](username, password)
VALUES (@username, @password);

END;
