CREATE TABLE usuariopapel (
    idUser INT NOT NULL,
    IdRoler INT NOT NULL,
    PRIMARY KEY (idUser, idRoler),
    INDEX (idUser),
    INDEX (idRoler),

    FOREIGN KEY (idUser)
      REFERENCES users(id)
      ON DELETE CASCADE,

    FOREIGN KEY (idRoler)
      REFERENCES papel(id)
      ON DELETE CASCADE
)
ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;