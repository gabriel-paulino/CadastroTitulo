CREATE DATABASE CadastroTitulo;

CREATE TABLE Filme (
    Id uniqueidentifier primary key,
    Genero int,
    Titulo varchar(255),
    Descricao varchar(255),
	Lancamento date,
	Excluido bit
);

CREATE TABLE Serie (
    Id uniqueidentifier primary key,
    Genero int,
    Titulo varchar(255),
    Descricao varchar(255),
	Lancamento date,
	Temporadas int,
	Episodios int,
	Excluido bit
);