CREATE TABLE IF NOT EXISTS ranked.user (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    identifier VARCHAR(255) NOT NULL UNIQUE
);