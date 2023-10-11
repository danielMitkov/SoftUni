SELECT TOP (5)
    CigarName,
    PriceForSingleCigar,
    ImageURL
FROM 
    Cigars AS C
JOIN 
    Sizes AS S ON S.Id = C.SizeId
WHERE 
    S.[Length] >= 12 
AND 
    (CigarName LIKE '%ci%' OR PriceForSingleCigar > 50)
AND 
    S.RingRange > 2.55
ORDER BY 
    CigarName,
    PriceForSingleCigar DESC