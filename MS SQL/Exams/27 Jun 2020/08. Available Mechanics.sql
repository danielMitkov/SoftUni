SELECT 
    M.FirstName + ' ' + M.LastName AS Available
FROM 
    Mechanics AS M
WHERE 
    MechanicId NOT IN 
(
    SELECT 
        ISNULL(MechanicId, 0)
    FROM 
        Jobs
    WHERE 
        Status <> 'Finished'
)
ORDER BY 
    M.MechanicId
--exercise is way more difficult than it looks, good job authors