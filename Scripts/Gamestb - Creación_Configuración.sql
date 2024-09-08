create database Gamestb;

use Gamestb;


CREATE TABLE Desarrolladora (
    DesarrolladoraID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) UNIQUE NOT NULL
);


CREATE TABLE Genero (
    GeneroID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) UNIQUE NOT NULL
);


-- (Relación uno a muchos)

CREATE TABLE Juegos (
    JuegoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) UNIQUE NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    DesarrolladoraID INT NOT NULL,  
    FOREIGN KEY (DesarrolladoraID) REFERENCES Desarrolladora(DesarrolladoraID)
);

-- (Relación muchos a muchos)
CREATE TABLE Genero_Juegos (
    JuegoID INT NOT NULL,
    GeneroID INT NOT NULL,
    PRIMARY KEY (JuegoID, GeneroID),
    FOREIGN KEY (JuegoID) REFERENCES Juegos(JuegoID),
    FOREIGN KEY (GeneroID) REFERENCES Genero(GeneroID)
);

