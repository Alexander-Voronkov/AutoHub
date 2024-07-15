USE autohubdb 

CREATE TABLE IF NOT EXISTS users_Permissions (
    Code VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    PRIMARY KEY (Code)
);