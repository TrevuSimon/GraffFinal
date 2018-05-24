CREATE TABLE Pessoa(
idPessoa int NOT NULL PRIMARY KEY IDENTITY(1,1),
nome nvarchar(50),
idade int);

go

CREATE TABLE Produto(
idProduto int NOT NULL PRIMARY KEY IDENTITY(1,1),
nome nvarchar(50),
valor float);

go

CREATE TABLE Lance(
idLance int NOT NULL PRIMARY KEY IDENTITY(1,1),
idProduto int FOREIGN KEY REFERENCES Produto(idProduto),
idPessoa int FOREIGN KEY REFERENCES Pessoa(idPessoa),
valor float);

go

INSERT INTO Pessoa(nome,idade)
VALUES ('Jão',18),
('Maria',25);

go

INSERT INTO Produto(nome,valor)
VALUES ('Maça',2);