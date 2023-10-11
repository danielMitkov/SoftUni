SELECT 
    C.Id,
    CigarName,
    PriceForSingleCigar,
    TasteType,
    TasteStrength
FROM 
    Cigars AS C
JOIN 
    Tastes AS T ON C.TastId = T.Id
WHERE 
    T.TasteType IN ('Earthy', 'Woody')
ORDER BY 
    PriceForSingleCigar DESC