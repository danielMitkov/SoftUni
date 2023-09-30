SELECT 
    [MC].[CountryCode], 
    COUNT(*) AS [MountainRanges] 
FROM 
    [MountainsCountries] AS [MC] 
WHERE 
    [MC].[CountryCode] IN ('BG', 'US', 'RU') 
GROUP BY 
    [MC].[CountryCode]