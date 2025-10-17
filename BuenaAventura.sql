CREATE DATABASE BuenaAventura;
Go

USE BuenaAventura;
Go

CREATE TABLE Clientes
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	NombreCompletoCli NVARCHAR(100) NOT NULL, 
	CedulaCliente NVARCHAR(20) NOT NULL, 
	Email NVARCHAR(150) UNIQUE NOT NULL,
	Contrase�a NVARCHAR (200) NOT NULL,
	Telefono NVARCHAR(20) NOT NULL
);

CREATE TABLE Agencias 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    NIT NVARCHAR(20) UNIQUE,
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(200),
);

CREATE TABLE AgentesViaje (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompletoAgen NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) UNIQUE NOT NULL,
    Telefono NVARCHAR(20),
    AgenciaId INT NOT NULL,
    FOREIGN KEY (AgenciaId) REFERENCES Agencias(Id)
);

CREATE TABLE Hoteles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Ubicacion NVARCHAR(200),
    Descripcion NVARCHAR(500),
    Rese�a NVARCHAR(500),
    AgenciaId INT NOT NULL,
    AgenteId INT NULL,
    FOREIGN KEY (AgenciaId) REFERENCES Agencias(Id),
    FOREIGN KEY (AgenteId) REFERENCES AgentesViaje(Id)
);

CREATE TABLE Presupuestos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    Destino NVARCHAR(150) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
	FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE Rese�as (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,           -- Cliente que hace la rese�a
    AgenciaId INT NULL,               -- Agencia rese�ada
    HotelId INT NULL,                 -- Hotel rese�ado
    AgenteId INT NULL,                -- Agente de viaje rese�ado
    Calificacion INT CHECK (Calificacion BETWEEN 1 AND 5),
    Comentario NVARCHAR(500),
    FechaRese�a DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (AgenciaId) REFERENCES Agencias(Id),
    FOREIGN KEY (HotelId) REFERENCES Hoteles(Id),
    FOREIGN KEY (AgenteId) REFERENCES AgentesViaje(Id)
);