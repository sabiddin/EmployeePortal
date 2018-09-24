CREATE PROCEDURE sp_EmployeeGet 
@ID INT NULL
AS
BEGIN
	SELECT 
		e.ID,Gender as GenderID,
		g.Value as GenderDesc,  
		Username,Phone, Email,DOB,Address,SSC, Inter,Degree,
		Document as DocumentID, d.Value as DocumentDesc 
	FROM tbl_Employee e LEFT JOIN tbl_Gender g
	ON e.Gender = g.Code
	LEFT JOIN tbl_Document d ON e.Document = d.Code
	WHERE @ID IS NULL OR e.ID = @ID
END