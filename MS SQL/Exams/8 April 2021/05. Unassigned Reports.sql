SELECT 
    R.[Description],
    FORMAT(R.OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM
    Reports AS R
WHERE 
    EmployeeId IS NULL
ORDER BY 
    R.OpenDate,
    [Description]