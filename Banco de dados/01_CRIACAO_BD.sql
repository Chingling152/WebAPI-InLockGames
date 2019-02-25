CREATE DATABASE InLock_Games_Manha;

USE InLock_Games_Manha;

-- Tabela com todos os estudios
CREATE TABLE Estudios(
	EstudioId int Identity Primary Key,
	NomeEstudio VarChar(250) Unique Not Null
);

-- Tabela com todos os jogos
CREATE TABLE Jogos(
	JogoId int Identity Primary Key,
	NomeJogo VarChar(200) Unique Not Null,
	Descricao Text Not Null,
	DataLancamento Date Not Null,
	Valor Money Not Null,
	EstudioId int Foreign Key References Estudios(EstudioId) Not Null
);

-- Tabela com todos os usuarios
CREATE TABLE Usuarios(
	UsuarioId int Identity Primary Key,
	Email VarChar(200) Unique Not Null,
	Senha VarChar(200) Not Null,
	TipoUsuario VarChar(200) Not Null
);