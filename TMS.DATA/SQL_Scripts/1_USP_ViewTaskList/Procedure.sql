CREATE PROCEDURE [dbo].[USP_ViewTaskList]   
@From INT,    
@To INT,    
@Search VARCHAR(200),  
@SortColumn VARCHAR(100),  
@SortOrder VARCHAR(50),  
@TotalRecords INT OUTPUT      
AS      
BEGIN    
  
IF @SortOrder IS NULL SET @SortOrder = 'ASC'  
IF @SortColumn IS NULL SET @SortColumn = 'Id'  
IF @Search IS NULL SET @Search = ''  
 -- Check if the temporary table exists and drop it      
 IF OBJECT_ID('tempdb..#Temp') IS NOT NULL      
  DROP TABLE #Temp;      
     
 IF @From IS NULL OR @From = 0 SET @From = 1    
 -- Create the temporary table using SELECT INTO directly      
 SELECT ROW_NUMBER() OVER (      
   ORDER BY ta.Id      
   ) AS Id      
  ,t.Title      
  ,t.[Description] as [Description]    
  ,t.DueDate as DueDate    
  ,tpt.[Type] as [Priority]    
  ,ua.UserName AS AssignedTo      
  ,ub.UserName AS AssignedBy      
  ,tc.Name AS Category      
  ,tsm.[Status]      
 INTO #Temp      
 FROM TaskAssignment ta      
 INNER JOIN Task t ON ta.TaskId = t.Id      
 INNER JOIN TaskCategory tc ON ta.CategoryId = tc.Id      
 INNER JOIN TaskStatusMaster tsm ON ta.StatusId = tsm.Id      
 INNER JOIN TaskPriorityTypes tpt on t.[Priority] = tpt.Id    
 INNER JOIN [User] ua ON ta.AssignedTo = ua.Id      
 INNER JOIN [User] ub ON ta.AssignedBy = ub.Id      
 WHERE ta.IsActive = 1      
  AND tc.IsActive = 1      
  AND tsm.IsActive = 1      
  AND ua.IsActive = 1      
  AND ub.IsActive = 1;      
 -- Get the total number of records      
 SELECT @TotalRecords = COUNT(*)      
 FROM #Temp;      
  
SET @To = CASE    
    WHEN (@To IS NULL OR @To = -1) THEN    
        CASE    
            WHEN (@TotalRecords IS NULL OR @TotalRecords = 0) THEN 10    
            ELSE @TotalRecords    
        END    
    ELSE @To    
END    
    
 -- Return the result set      
SELECT *  
FROM #Temp  
WHERE  
    Title LIKE '%' + @Search + '%' OR  
    Description LIKE '%' + @Search + '%' OR  
    CONVERT(NVARCHAR(MAX), DueDate, 121) LIKE '%' + @Search + '%' OR  
    Priority LIKE '%' + @Search + '%' OR  
    AssignedTo LIKE '%' + @Search + '%' OR  
    AssignedBy LIKE '%' + @Search + '%' OR  
    Category LIKE '%' + @Search + '%' OR  
    Status LIKE '%' + @Search + '%'  
ORDER BY  
    CASE WHEN @SortOrder = 'ASC' THEN  
        CASE @SortColumn  
            WHEN 'Title' THEN [Title]  
            WHEN 'Description' THEN [Description]  
            WHEN 'DueDate' THEN CAST([DueDate] AS VARCHAR(50))  
            WHEN 'Priority' THEN [Priority]  
            WHEN 'AssignedTo' THEN [AssignedTo]  
            WHEN 'AssignedBy' THEN [AssignedBy]  
            WHEN 'Category' THEN [Category]  
            WHEN 'Status' THEN [Status]  
            ELSE CAST(ID AS VARCHAR(50))  
        END  
    END ASC,  
  
    CASE WHEN @SortOrder = 'DESC' THEN  
        CASE @SortColumn  
            WHEN 'Title' THEN [Title]  
            WHEN 'Description' THEN [Description]  
            WHEN 'DueDate' THEN CAST([DueDate] AS VARCHAR(50))  
            WHEN 'Priority' THEN [Priority]  
            WHEN 'AssignedTo' THEN [AssignedTo]  
            WHEN 'AssignedBy' THEN [AssignedBy]  
            WHEN 'Category' THEN [Category]  
            WHEN 'Status' THEN [Status]  
            ELSE CAST(ID AS VARCHAR(50))  
        END  
    END DESC  
OFFSET @From - 1 ROWS FETCH NEXT @To ROWS ONLY;  
  
END    
  