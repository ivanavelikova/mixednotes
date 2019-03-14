
CREATE SCHEMA IF NOT EXISTS `mixednotesdb` DEFAULT CHARACTER SET utf8 ;
USE `mixednotesdb` ;

CREATE TABLE IF NOT EXISTS `mixednotesdb`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(15) NOT NULL,
  `password` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `mixednotesdb`.`notes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `content` TEXT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`, `user_id`),
  INDEX `fk_notes_users_idx` (`user_id` ASC) VISIBLE,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  CONSTRAINT `fk_notes_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `mixednotesdb`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `mixednotesdb`.`lists` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`, `user_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_lists_users1_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_lists_users1`
    FOREIGN KEY (`user_id`)
    REFERENCES `mixednotesdb`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `mixednotesdb`.`list_items` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `content` TEXT NOT NULL,
  `is_done` TINYINT NULL,
  `list_id` INT NOT NULL,
  PRIMARY KEY (`id`, `list_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_list_items_lists1_idx` (`list_id` ASC) VISIBLE,
  CONSTRAINT `fk_list_items_lists1`
    FOREIGN KEY (`list_id`)
    REFERENCES `mixednotesdb`.`lists` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
