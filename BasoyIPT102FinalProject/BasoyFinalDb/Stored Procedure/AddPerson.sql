CREATE PROCEDURE [dbo].[AddPerson]
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

    INSERT INTO Persons(FirstName, LastName, DateOfBirth, Gender, Address, PhoneNumber, Email, Education, Skills)
    VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Address, @PhoneNumber, @Email, @Education, @Skills);
    
END;
