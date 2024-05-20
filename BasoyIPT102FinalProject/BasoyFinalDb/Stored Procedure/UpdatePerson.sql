CREATE PROCEDURE [dbo].[UpdatePerson]
	 @PersonID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DateOfBirth DATE,
    @Gender NVARCHAR(10),
    @Address NVARCHAR(255),
    @PhoneNumber NVARCHAR(15),
    @Email NVARCHAR(100),
    @Education NVARCHAR(255),
    @Skills NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Persons
    SET 
        FirstName = @FirstName,
        LastName = @LastName,
        DateOfBirth = @DateOfBirth,
        Gender = @Gender,
        Address = @Address,
        PhoneNumber = @PhoneNumber,
        Email = @Email,
        Education = @Education,
        Skills = @Skills
    WHERE 
        PersonID = @PersonID;
END;