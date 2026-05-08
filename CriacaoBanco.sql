CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    UsuarioLogin VARCHAR(50) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL
);

CREATE TABLE Enderecos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cep VARCHAR(9) NOT NULL,
    Logradouro VARCHAR(150) NOT NULL,
    Complemento VARCHAR(100),
    Bairro VARCHAR(100) NOT NULL,
    Cidade VARCHAR(100) NOT NULL,
    Uf CHAR(2) NOT NULL,
    Numero VARCHAR(10) NOT NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

INSERT INTO Usuarios (Nome, UsuarioLogin, Senha) 
VALUES ('Giovana Dev', 'giovana', '123456');