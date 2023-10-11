SELECT 
    T.[Name],
    T.Age,
    T.PhoneNumber,
    T.Nationality,
    ISNULL(BR.[Name], '(no bonus prize)') AS Reward
FROM 
    Tourists AS T
LEFT JOIN 
    TouristsBonusPrizes AS TBR ON T.Id = TBR.TouristId
LEFT JOIN 
    BonusPrizes AS BR ON TBR.BonusPrizeId = BR.Id
ORDER BY 
    T.[Name]