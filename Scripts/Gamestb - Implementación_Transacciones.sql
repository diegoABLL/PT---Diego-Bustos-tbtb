use Gamestb;

INSERT INTO Desarrolladora (Nombre) VALUES
('Naughty Dog'),
('343 Industries'),
('CD Projekt Red'),
('Mojang Studios'),
('Santa Monica Studio');


INSERT INTO Genero (Nombre) VALUES
('Acción'),
('Aventura'),
('RPG'),
('Sandbox'),
('Shooter');


INSERT INTO Juegos (Nombre, Precio, DesarrolladoraID) VALUES
('The Last of Us', 59.99, 1),
('Halo Infinite', 49.99, 2),
('Cyberpunk 2077', 39.99, 3),
('Minecraft', 19.99, 4),
('God of War', 29.99, 5),
('The Last of Us Part 2', 69.99, 1),
('Halo 5: Guardians', 49.99, 2),
('Halo: The Master Chief Collection', 39.99, 2),
('The Witcher 3: Wild Hunt', 59.99, 3),
('Gwent: The Witcher Card Game', 0.00, 3),
('Minecraft Dungeons', 19.99, 4),
('Scrolls', 4.99, 4),
('God of War Ragnarok', 69.99, 5),
('God of War III', 39.99, 5);



INSERT INTO Genero_Juegos (JuegoID, GeneroID) VALUES
(1, 1),  -- The Last of Us es Acción
(1, 2),  -- The Last of Us es Aventura
(2, 5),  -- Halo Infinite es Shooter
(3, 3),  -- Cyberpunk 2077 es RPG
(4, 4),  -- Minecraft es Sandbox
(5, 1),  -- God of War es Acción
(6, 1),  -- The Last of Us Part II es Acción
(6, 2),  -- The Last of Us Part II es Aventura
(7, 1),  -- Halo 5: Guardians es Acción
(7, 5),  -- Halo 5: Guardians es Shooter
(8, 5),  -- Halo: The Master Chief Collection es Shooter
(9, 3),  -- The Witcher 3: Wild Hunt es RPG
(10, 3), -- Gwent: The Witcher Card Game es RPG
(11, 4), -- Minecraft Dungeons es Sandbox
(12, 4), -- Scrolls es Sandbox
(13, 1), -- God of War Ragnarok es Acción
(14, 1); -- God of War III es Acción

-- Inner Join

SELECT J.Nombre AS Juego, D.Nombre AS Desarrolladora, G.Nombre AS Genero FROM Juegos J
INNER JOIN Desarrolladora D ON J.DesarrolladoraID = D.DesarrolladoraID
INNER JOIN Genero_Juegos GJ ON J.JuegoID = GJ.JuegoID
INNER JOIN Genero G ON GJ.GeneroID = G.GeneroID;

-- Left Join

SELECT J.Nombre AS Juego, D.Nombre AS Desarrolladora, G.Nombre AS Genero FROM Juegos J
LEFT JOIN Desarrolladora D ON J.DesarrolladoraID = D.DesarrolladoraID
LEFT JOIN Genero_Juegos GJ ON J.JuegoID = GJ.JuegoID
LEFT JOIN Genero G ON GJ.GeneroID = G.GeneroID;

-- UNION

SELECT * FROM Juegos WHERE DesarrolladoraID = '1'
UNION
SELECT * FROM Juegos WHERE DesarrolladoraID = '2';

-- CASE

SELECT Nombre, Precio,
CASE
    WHEN Precio > 40 THEN 'Precio Alto'
    ELSE 'Precio Bajo'
END AS CategoriaPrecio
FROM Juegos;