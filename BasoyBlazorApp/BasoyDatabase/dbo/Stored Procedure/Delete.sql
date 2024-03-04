CREATE PROCEDURE [dbo].[Delete]
	 @StudentId int
AS
BEGIN
    DELETE FROM [dbo].[Students]
        WHERE [StudentId] = @StudentId;

        
END;
