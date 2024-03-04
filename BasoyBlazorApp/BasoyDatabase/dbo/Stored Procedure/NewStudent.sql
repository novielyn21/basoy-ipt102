CREATE PROCEDURE [dbo].[NewStudent]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(50),
	@Country NVARCHAR(50),
	@SMessage NVARCHAR(MAX)
AS
BEGIN
INSERT INTO [dbo].[Students](FirstName, LastName, Email, Country, SMessage)
VALUES (@FirstName, @LastName, @Email, @Country, @SMessage);

END;

