CREATE SCHEMA IF NOT EXISTS mixednotesdb DEFAULT CHARACTER SET UTF8;

USE mixednotesdb;

CREATE TABLE IF NOT EXISTS notes (
	PRIMARY KEY (note_id),
    note_id		INT		NOT NULL AUTO_INCREMENT,
    content		TEXT	NOT NULL
);

CREATE TABLE IF NOT EXISTS lists (
	PRIMARY KEY (list_id),
    list_id		INT				NOT NULL AUTO_INCREMENT,
    title		VARCHAR(45)		NOT NULL
);

CREATE TABLE IF NOT EXISTS tasks (
	PRIMARY KEY (task_id),
    task_id		INT			NOT NULL AUTO_INCREMENT,
    list_id		INT			NOT NULL,
    content		TINYTEXT	NOT NULL,
	is_done		BOOLEAN		NULL,
		CONSTRAINT fk_tasks_lists
		FOREIGN KEY (list_id)
		REFERENCES lists (list_id)
);