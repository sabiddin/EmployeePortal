EXEC sp_Employee 1,NULL,'sabiddin',1,'3476837445','zsyed@syed.com', '07/05/1982','3314 Wells Drive, Parlin NJ 08859',3,1,1,1
EXEC sp_Employee 2,3,'sabiddin',1,'(347683-7445)','zsyed@syed.com', '07/05/1982','3314 Wells Drive, Parlin NJ 08859',3,1,1,1

DECLARE @ID INT = NULL
	SELECT 
		e.ID,Gender as GenderID,
		g.Value as GenderDesc,  
		Username,Phone, Email,DOB,Address,SSC, Inter,Degree,
		Document as DocumentID, d.Value as DocumentDesc		
	FROM tbl_Employee e LEFT JOIN tbl_Gender g
	ON e.Gender = g.Code
	LEFT JOIN tbl_Document d ON e.Document = d.Code
	WHERE @ID IS NULL OR e.ID = @ID