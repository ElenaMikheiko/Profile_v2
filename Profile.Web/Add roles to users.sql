USE [ProfileTest]

DECLARE @adminId nvarchar(450);
DECLARE @studentId nvarchar(450);
DECLARE @trainerId nvarchar(450);
DECLARE @hrId nvarchar(450);

DECLARE @adminRoleId nvarchar(450);
DECLARE @studentRoleId nvarchar(450);
DECLARE @trainerRoleId nvarchar(450);
DECLARE @hrRoleId nvarchar(450);

SELECT
	@adminId = id
FROM
	[ProfileTest].[dbo].[User]
WHERE
	Email = 'admin@profile.com'SELECT
	
	@hrId = id
FROM
	[ProfileTest].[dbo].[User]
WHERE
	Email = 'hr@profile.com'
	
SELECT
	@studentId = id
FROM
	[ProfileTest].[dbo].[User]
WHERE
	Email = 'student@profile.com'
	
SELECT
	@trainerId = id
FROM
	[ProfileTest].[dbo].[User]
WHERE
	Email = 'trainer@profile.com'

SELECT
	@adminRoleId = id
FROM
	[ProfileTest].[dbo].[Role]
WHERE
	Name = 'Admin'
	
	SELECT
	@hrRoleId = id
FROM
	[ProfileTest].[dbo].[Role]
WHERE
	Name = 'Hr'
	
SELECT
	@studentRoleId = id
FROM
	[ProfileTest].[dbo].[Role]
WHERE
	Name = 'Student'
	
SELECT
	@trainerRoleId = id
FROM
	[ProfileTest].[dbo].[Role]
WHERE
	Name = 'Teacher'	

BEGIN
   IF @adminId IS NOT NULL AND NOT EXISTS (SELECT * FROM UserRoles 
                   WHERE UserId = @adminId AND RoleId = @adminRoleId)
   BEGIN
       INSERT INTO UserRoles (UserId, RoleId)
       VALUES (@adminId, @adminRoleId)
   END
END

BEGIN
   IF @hrId IS NOT NULL AND NOT EXISTS (SELECT * FROM UserRoles 
                   WHERE UserId = @hrId AND RoleId = @hrRoleId)
   BEGIN
       INSERT INTO UserRoles (UserId, RoleId)
       VALUES (@hrId, @hrRoleId)
   END
END

BEGIN
   IF @studentId IS NOT NULL AND NOT EXISTS (SELECT * FROM UserRoles 
                   WHERE UserId = @studentId AND RoleId = @studentRoleId)
   BEGIN
       INSERT INTO UserRoles (UserId, RoleId)
       VALUES (@studentId, @studentRoleId)
   END
END

BEGIN
   IF @trainerId IS NOT NULL AND NOT EXISTS (SELECT * FROM UserRoles 
                   WHERE UserId = @trainerId AND RoleId = @trainerRoleId)
   BEGIN
       INSERT INTO UserRoles (UserId, RoleId)
       VALUES (@trainerId, @trainerRoleId)
   END
END