-- USE codeworksfinal;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255),
--   creatorId VARCHAR(255),


--   PRIMARY KEY (id),

--   FOREIGN KEY(creatorId)
--    REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );

CREATE TABLE vaults
(
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  IsPrivate TINYINT,
  creatorId VARCHAR(255) NOT NULL,

  PRIMARY KEY (id),

  FOREIGN KEY(creatorId)
   REFERENCES profiles (id)
    ON DELETE CASCADE
);


-- DROP TABLE keeps
-- DROP TABLE vaults