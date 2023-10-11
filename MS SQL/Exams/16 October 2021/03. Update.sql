UPDATE 
    Cigars
SET 
    PriceForSingleCigar += PriceForSingleCigar * 0.2
WHERE 
    TastId IN (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE 
    Brands
SET 
    BrandDescription = 'New description'
WHERE 
    BrandDescription IS NULL