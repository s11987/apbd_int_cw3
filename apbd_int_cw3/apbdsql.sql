DECLARE @var1 varchar(30);         
DECLARE @var2 varchar(30);  
DECLARE @var3 varchar(30);
SELECT @var1 = IdEnrollment FROM Student WHERE IndexNumber = 's11987';        
SELECT @var2 = IdStudy FROM Enrollment WHERE IdEnrollment = @var1;      
SELECT @var3 = Name FROM Studies WHERE IdStudy = @var2;      
SELECT @var3 AS 'Name', @var2 AS 'IdStudy'