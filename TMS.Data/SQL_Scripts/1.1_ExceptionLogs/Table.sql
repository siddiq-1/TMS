CREATE PROCEDURE USP_AddExceptionLog @CreateDate DATETIME
	,@Message VARCHAR(1000)
	,@Source VARCHAR(max)
	,@Type VARCHAR(250)
	,@Url VARCHAR(max)
AS
BEGIN
	INSERT INTO ExceptionLogs
	VALUES (
		@Message
		,@Type
		,@Source
		,@Url
		,@CreateDate
		)
END