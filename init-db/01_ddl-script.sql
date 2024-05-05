CREATE TABLE movies
(
    id                SERIAL PRIMARY KEY,
    title             VARCHAR(255) NOT NULL,
    original_title    VARCHAR(255),
    original_language VARCHAR(20),
    release_year      INTEGER      NOT NULL,
    duration          INTEGER      NOT NULL,
    content_rating    VARCHAR(20),
    genre             VARCHAR(255),
    budget            NUMERIC(18, 2),
    revenue           NUMERIC(18, 2)
);
