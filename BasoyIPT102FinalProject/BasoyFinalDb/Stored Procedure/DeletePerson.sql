CREATE PROCEDURE [dbo].[DeletePerson]
	 @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Persons
    WHERE PersonID = @PersonID;
END;