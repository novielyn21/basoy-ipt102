CREATE PROCEDURE [dbo].[FindPersonById]
	  @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        PersonID,
        FirstName,
        LastName,
        DateOfBirth,
        Gender,
        Address,
        PhoneNumber,
        Email,
        Education,
        Skills
    FROM 
        Persons
    WHERE 
        PersonID = @PersonID;
END;
