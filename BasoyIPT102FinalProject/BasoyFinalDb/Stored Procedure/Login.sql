CREATE PROCEDURE [dbo].[Login]
	@username NVARCHAR(50),
    @password NVARCHAR(50)
AS
	BEGIN
    SELECT [D].[username] AS username, [D].[password] AS password
    FROM [dbo].[accounts] AS D
    WHERE [D].[username] = @username AND [D].[password] = @password
END;
