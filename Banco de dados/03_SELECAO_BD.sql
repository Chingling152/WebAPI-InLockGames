-- Lista todos os usuarios
Select * From Usuarios;

-- Lista Todos os Estudios
Select * From Estudios;

-- Lista Todos os jogos
Select * From Jogos;

-- Lista Todos os jogos e seus Estudios
Select J.* , E.NomeEstudio From Jogos as J Left Join Estudios as E on E.EstudioId = J.EstudioId;

-- Lista todos os estudios e seus respectivos jogos
Select E.NomeEstudio ,J.NomeJogo , J.Descricao , J.DataLancamento From Jogos as J Right Join Estudios as E on E.EstudioId = J.EstudioId;

-- Lista um usuario por email e senha 
Select * From Usuarios Where Email = 'admin@admin.com' And Senha = 'admin';

-- Lista um Jogo pelo ID
Select * From Estudios Where EstudioId = 1;

-- Lista um Estudio Pelo ID
Select * From Jogos Where JogoId = 1;