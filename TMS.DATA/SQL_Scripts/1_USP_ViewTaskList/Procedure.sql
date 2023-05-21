CREATE PROCEDURE USP_ViewTaskList @TotalRecords INT OUTPUT
AS
BEGIN
	-- Check if the temporary table exists and drop it
	IF OBJECT_ID('tempdb..#Temp') IS NOT NULL
		DROP TABLE #Temp;

	-- Create the temporary table using SELECT INTO directly
	SELECT ROW_NUMBER() OVER (
			ORDER BY ta.Id
			) AS Id
		,t.Title
		,ua.UserName AS AssignedTo
		,ub.UserName AS AssignedBy
		,tc.Name AS Category
		,tsm.[Status]
	INTO #Temp
	FROM TaskAssignment ta
	INNER JOIN Task t ON ta.TaskId = t.Id
	INNER JOIN TaskCategory tc ON ta.CategoryId = tc.Id
	INNER JOIN TaskStatusMaster tsm ON ta.StatusId = tsm.Id
	INNER JOIN [User] ua ON ta.AssignedTo = ua.Id
	INNER JOIN [User] ub ON ta.AssignedBy = ub.Id
	WHERE ta.IsActive = 0
		AND tc.IsActive = 0
		AND tsm.IsActive = 0
		AND ua.IsActive = 0
		AND ub.IsActive = 0;

	-- Get the total number of records
	SELECT @TotalRecords = COUNT(*)
	FROM #Temp;

	-- Return the result set
	SELECT *
	FROM #Temp;
END