CREATE TABLE Arquivo
(
    id_arquivo integer primary key auto_increment,
    nome varchar(45),
    id_atualizacao integer,
    constraint fk_AutoArquivo foreign key (id_atualizacao) references Atualizacao (id_atualizacao)
)	
ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;