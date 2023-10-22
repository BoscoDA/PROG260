SELECT Game.Name, Game_Stats.Sold, Game_Stats.Rating
FROM Game INNER JOIN Game_Stats
ON Game.ID = Game_Stats.GameID

SELECT Game.Name, Game_Stats.Sold, Game_Stats.Rating
FROM Game LEFT JOIN Game_Stats
ON Game.ID = Game_Stats.GameID

SELECT Game.Name, Game_Stats.Sold, Game_Stats.Rating
FROM Game_Stats RIGHT JOIN Game
ON Game.ID = Game_Stats.GameID

SELECT Game.Name, Game_Stats.Sold, Game_Stats.Rating
FROM Game RIGHT JOIN Game_Stats
ON Game.ID = Game_Stats.GameID

--useful for seeing if there are any children in the other table or if the children have no parent
SELECT Game.Name, Game_Stats.Sold
FROM Game LEFT JOIN Game_Stats
ON Game.ID = Game_Stats.GameID
WHERE Game_Stats.Sold is NULL

SELECT Game.Name, Game_Stats.Sold
FROM Game LEFT OUTER JOIN Game_Stats
ON Game.ID = Game_Stats.GameID
WHERE Game_Stats.Sold is NULL

SELECT G.ID as 'Game ID', GS.ID as 'Game Stats ID', G.Name,GS.Sold, GS.Rating
FROM Game as G FULL JOIN Game_Stats GS
ON G.ID = GS.GameID