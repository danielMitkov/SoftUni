SELECT 
    [PeakName], 
    [RiverName], 
    LOWER
    (
        LEFT
        (
            [P].PeakName, LEN([P].PeakName) - 1
        ) + [R].RiverName
    ) AS [Mix] 
FROM 
    [Peaks] AS [P] 
JOIN 
    [Rivers] AS [R] ON RIGHT([P].PeakName, 1) = LEFT([R].RiverName, 1)
ORDER BY 
    [Mix]