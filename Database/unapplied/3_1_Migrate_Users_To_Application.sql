CREATE TABLE IF NOT EXISTS ranked.user_elo (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNSIGNED NOT NULL UNIQUE,
    elo INT UNSIGNED NOT NULL,
    CONSTRAINT fk_user_elo_user FOREIGN KEY (user_id) REFERENCES ranked.user(id)
);

INSERT INTO application(name, guid) VALUES ('Global', '7b3f9c9f-5c0c-4a54-9e22-04a7a6a6c1f1');
SET @global_application_id = LAST_INSERT_ID();

INSERT INTO user_game (user_id, game_id)
SELECT id, @global_application_id
FROM user;