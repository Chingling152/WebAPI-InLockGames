-- Insere um usuario Administrador
Insert Into Usuarios(Email,Senha,TipoUsuario) Values('admin@admin.com','admin','ADMINISTRADOR');

-- Insere um exemplo de Cliente 
Insert Into Usuarios(Email,Senha,TipoUsuario) Values('cliente@cliente.com','cliente','CLIENTE');

-- Insere Os 3 estudios : Rockstar , Blizzard e Square Enix
Insert Into Estudios(NomeEstudio) Values ('Rockstar Studios'),('Blizzard'),('Square Enix');

-- Insere os jogos Diablo III
Insert Into Jogos(NomeJogo,Descricao,DataLancamento,EstudioId,Valor) Values 
('Diablo III','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','2012-05-12',2,99.00),
('Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western','2018-10-26',1,120.00);
