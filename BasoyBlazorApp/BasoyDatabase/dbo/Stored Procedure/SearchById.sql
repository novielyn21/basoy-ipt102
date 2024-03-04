CREATE PROCEDURE [dbo].[SearchById]
	@StudentId INT
AS
	BEGIN

	SELECT * FROM [dbo].[Students]
	WHERE StudentId = @StudentId

	END;