CREATE PROCEDURE sp_Employee (
@Mode [int], 
@ID [int] = NULL,
@Username [nvarchar](50),
@Gender [int],
@Phone [varchar](15),
@Email [nvarchar](100) NULL,
@DOB [date],
@Address [nvarchar](300),
@Document [int],
@SSC [bit] NULL,
@Inter [bit] NULL,
@Degree [bit] NULL
)
AS
BEGIN
IF (@Mode = 1)
	BEGIN
		INSERT INTO [dbo].[tbl_Employee]
				   ([Username]
				   ,[Gender]
				   ,[Phone]
				   ,[Email]
				   ,[DOB]
				   ,[Address]
				   ,[Document]
				   ,[SSC]
				   ,[Inter]
				   ,[Degree])
			 VALUES
				   (@Username
				   ,@Gender
				   ,@Phone
				   ,@Email
				   ,@DOB
				   ,@Address
				   ,@Document
				   ,@SSC
				   ,@Inter
				   ,@Degree)
	END 
	
ELSE IF (@Mode = 2)
	BEGIN
		UPDATE tbl_Employee SET 
			Username = @Username,
			Gender = @Gender,
			Phone = @Phone,
			Email = @Email,
			DOB =  @DOB,
			Address = @Address,
			Document = @Document,
			SSC = @SSC,
			Inter = @Inter,
			Degree = @Degree
		WHERE 
			ID = @ID

	END
ELSE IF (@Mode = 3)
	BEGIN
		DELETE FROM tbl_Employee WHERE ID = @ID
	END

END



