CREATE TABLE Atualizacao
(
    id_atualizacao integer primary key auto_increment,
    versao integer,
    nome varchar(45),
    modelo varchar(45),
    status_atualizacao tinyint
)
ENGINE=InnoDB DEFAULT CHARSET=latin1;