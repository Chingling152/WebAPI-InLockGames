-- Lista todos os usuarios
Select * From Usuarios;

-- Lista Todos os Estudios
Select * From Estudios;

-- Lista Todos os jogos
Select * From Jogos;

-- Lista Todos os jogos e seus Estudios
SELECT Jogos.* , Estudios.* FROM Jogos LEFT JOIN Estudios ON Estudios.EstudioId = Jogos.EstudioId;

-- Lista todos os estudios e seus respectivos jogos
Select Estudios.* ,Jogos.* From Jogos Right Join Estudios on Estudios.EstudioId = Jogos.EstudioId;

-- Lista um usuario por email e senha 
Select * From Usuarios Where Email = 'admin@admin.com' And Senha = 'admin';

-- Lista um Jogo pelo ID
Select * From Estudios Where EstudioId = 1;

-- Lista um Estudio Pelo ID
Select * From Jogos Where JogoId = 1;