INSERT INTO [dbo].[Studies] ([IdStudy], Name)
VALUES (1, 'Name1')

INSERT INTO [dbo].[Studies] ([IdStudy], Name)
VALUES (2, 'Name2')

INSERT INTO [dbo].[Studies] ([IdStudy], Name)
VALUES (3, 'Name3')




INSERT INTO [dbo].[Enrollment] ([IdEnrollment],Semester, IdStudy, StartDate)
VALUES (1,1, 1, GETDATE());

INSERT INTO [dbo].[Enrollment] ([IdEnrollment],Semester, IdStudy, StartDate)
VALUES (2,1, 1, GETDATE());

INSERT INTO [dbo].[Enrollment] ([IdEnrollment],Semester, IdStudy, StartDate)
VALUES (3,1, 1, GETDATE());





INSERT INTO [dbo].[Student] (IndexNumber,FirstName, LastName, BirthDate, IdEnrollment)
VALUES (1,'Karol', 'Galazka', GETDATE(), 1)

INSERT INTO [dbo].[Student] (IndexNumber,FirstName, LastName, BirthDate, IdEnrollment)
VALUES (2,'Janek', 'Kowalski', GETDATE(), 1)

INSERT INTO [dbo].[Student] (IndexNumber,FirstName, LastName, BirthDate, IdEnrollment)
VALUES (3,'Franek', 'Galazka', GETDATE(), 1)












select * from Student
INNER JOIN Enrollment ON Student.IdEnrollment=Enrollment.IdEnrollment
INNER JOIN Studies ON Enrollment.IdStudy = Studies.IdStudy
where Student.IndexNumber='1' ;