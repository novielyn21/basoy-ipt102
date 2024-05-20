CREATE PROCEDURE [dbo].[DisplayAllPersons]
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
        Persons;
END;
