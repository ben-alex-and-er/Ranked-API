CREATE TABLE IF NOT EXISTS ranked.application (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE,
    guid CHAR(36) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS ranked.user_application (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNSIGNED NOT NULL,
    application_id INT UNSIGNED NOT NULL,
    CONSTRAINT fk_user_application_user FOREIGN KEY (user_id) REFERENCES ranked.user(id),
    CONSTRAINT fk_user_application_application FOREIGN KEY (application_id) REFERENCES ranked.application(id)
);

CREATE TABLE IF NOT EXISTS ranked.user_application_elo (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    user_application_id INT UNSIGNED NOT NULL UNIQUE,
    elo INT UNSIGNED NOT NULL,
    CONSTRAINT fk_user_application_elo_user_application FOREIGN KEY (user_application_id) REFERENCES ranked.user_application(id)
);