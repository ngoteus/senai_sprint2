USE Filmes;

INSERT INTO Usuario(Email, Senha, Permissao)
VALUES ('mateusmouraferreira8@gmail.com', '123123', 1),
		('joao@gmail.com', '321321',0)

SELECT Email, Senha, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha