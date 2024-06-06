CREATE PROCEDURE [dbo].[SearchByName]
	 @CustomerName NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM [dbo].[Persons]
    WHERE FirstName LIKE '%' + @CustomerName + '%';
END;