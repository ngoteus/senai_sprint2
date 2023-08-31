USE Filmes;

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(100),
	Senha VARCHAR (100),
	Permissao BIT

)
