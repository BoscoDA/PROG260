UPDATE [PROG260FA23].[dbo].[Game]
SET Sold = 12500, Publisher = 'Lucas Film Games' WHERE ID = 1

UPDATE [PROG260FA23].[dbo].[Game]
SET Sold = 0
WHERE Sold is NULL

DELETE FROM [PROG260FA23].[dbo].[Game] WHERE ID = 6

SELECT * FROM [PROG260FA23].[dbo].[Game]