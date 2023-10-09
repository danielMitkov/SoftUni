DELETE FROM 
    ProductsClients
WHERE 
    ClientId IN (
                    SELECT 
                        Id
                    FROM 
                        Clients
                    WHERE 
                        NumberVat LIKE 'IT%'
                ) 

DELETE FROM 
    Invoices
WHERE 
    ClientId IN (
                    SELECT 
                        Id
                    FROM 
                        Clients
                    WHERE 
                        NumberVat LIKE 'IT%'
                ) 

DELETE FROM 
    Clients 
WHERE 
    NumberVat LIKE 'IT%'
