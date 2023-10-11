CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
SELECT 
    CigarName, 
    CONCAT('$', C.PriceForSingleCigar) AS Price, 
    TasteType, 
    BrandName, 
    CONCAT(S.[Length], ' cm') AS CigarLength, 
    CONCAT(S.RingRange, ' cm') AS CigarRingRange
FROM 
    Cigars AS C
JOIN 
    Tastes AS T ON T.Id = C.TastId
JOIN 
    Sizes AS S ON S.Id = C.SizeId
JOIN 
    Brands AS B ON B.Id = C.BrandId
WHERE 
    T.TasteType = @taste
ORDER BY 
    CigarLength,
    CigarRingRange DESC