CREATE PROCEDURE [dbo].[Update]
	@StudentId INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(50),
    @Country NVARCHAR(50),
    @SMessage NVARCHAR(MAX)
AS
BEGIN
    UPDATE [dbo].[Students]
    SET
        [FirstName] = @FirstName,
        [LastName] = @LastName,
        [Email] = @Email,
        [Country] = @Country,
        [SMessage] = @SMessage

    WHERE [StudentId] = @StudentId;
END;
