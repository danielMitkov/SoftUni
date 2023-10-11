SELECT 
    CL.LastName,
    AVG(S.[Length]) AS CiagrLength,
    CEILING(AVG(S.RingRange)) AS CiagrRingRange
FROM 
    Clients AS CL
JOIN 
    ClientsCigars AS CC ON CC.ClientId = CL.Id
JOIN 
    Cigars AS C ON CC.CigarId = C.Id
JOIN 
    Sizes AS S ON S.Id = C.SizeId
GROUP BY 
    CL.LastName
ORDER BY 
    CiagrLength DESC