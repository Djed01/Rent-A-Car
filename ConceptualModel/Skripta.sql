-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema rent-a-car
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema rent-a-car
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `rent-a-car` DEFAULT CHARACTER SET utf8 ;
USE `rent-a-car` ;

-- -----------------------------------------------------
-- Table `rent-a-car`.`USER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`USER` (
  `idUSER` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `Surname` VARCHAR(50) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Phone` VARCHAR(45) NOT NULL,
  `Address` VARCHAR(100) NOT NULL,
  `City` VARCHAR(45) NOT NULL,
  `PostCode` VARCHAR(45) NOT NULL,
  `Username` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idUSER`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`ADMIN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`ADMIN` (
  `USER_idUSER` INT NOT NULL,
  PRIMARY KEY (`USER_idUSER`),
  INDEX `fk_ADMIN_USER1_idx` (`USER_idUSER` ASC) VISIBLE,
  CONSTRAINT `fk_ADMIN_USER1`
    FOREIGN KEY (`USER_idUSER`)
    REFERENCES `rent-a-car`.`USER` (`idUSER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`CAR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`CAR` (
  `ChassisNumber` VARCHAR(17) NOT NULL,
  `Brand` VARCHAR(45) NOT NULL,
  `Model` VARCHAR(45) NOT NULL,
  `Year` VARCHAR(45) NOT NULL,
  `PricePerDay` DOUBLE NOT NULL,
  `Engine` VARCHAR(45) NOT NULL,
  `Image` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ChassisNumber`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`EMPLOYEE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`EMPLOYEE` (
  `USER_idUSER` INT NOT NULL,
  PRIMARY KEY (`USER_idUSER`),
  CONSTRAINT `fk_EMPLOYEE_USER1`
    FOREIGN KEY (`USER_idUSER`)
    REFERENCES `rent-a-car`.`USER` (`idUSER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`CUSTOMER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`CUSTOMER` (
  `idCUSTOMER` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `Surname` VARCHAR(50) NOT NULL,
  `Email` VARCHAR(50) NULL,
  `Phone` VARCHAR(45) NULL,
  `ID_Number` VARCHAR(45) NOT NULL,
  `Date_Of_Birth` DATE NOT NULL,
  `Gender` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`idCUSTOMER`)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`RENT`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`RENT` (
  `idRENT` INT NOT NULL AUTO_INCREMENT,
  `CUSTOMER_idCUSTOMER` INT NOT NULL,
  `CAR_ChassisNumber` VARCHAR(17) NOT NULL,
  `Pick_Up` DATE NOT NULL,
  `Return` DATE NOT NULL,
  `Total_Price` DOUBLE NULL,
  `EMPLOYEE_USER_idUSER` INT NOT NULL,
  PRIMARY KEY (`idRENT`),
  INDEX `fk_RENT_CUSTOMER1_idx` (`CUSTOMER_idCUSTOMER` ASC) VISIBLE,
  INDEX `fk_RENT_CAR1_idx` (`CAR_ChassisNumber` ASC) VISIBLE,
  INDEX `fk_RENT_EMPLOYEE1_idx` (`EMPLOYEE_USER_idUSER` ASC) VISIBLE,
  CONSTRAINT `fk_RENT_CUSTOMER1`
    FOREIGN KEY (`CUSTOMER_idCUSTOMER`)
    REFERENCES `rent-a-car`.`CUSTOMER` (`idCUSTOMER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RENT_CAR1`
    FOREIGN KEY (`CAR_ChassisNumber`)
    REFERENCES `rent-a-car`.`CAR` (`ChassisNumber`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RENT_EMPLOYEE1`
    FOREIGN KEY (`EMPLOYEE_USER_idUSER`)
    REFERENCES `rent-a-car`.`EMPLOYEE` (`USER_idUSER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`DEACTIVATED`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`DEACTIVATED` (
  `Date` DATE NOT NULL,
  `ADMIN_USER_idUSER` INT NOT NULL,
  `EMPLOYEE_USER_idUSER` INT NOT NULL,
  INDEX `fk_DEACTIVATED_ADMIN1_idx` (`ADMIN_USER_idUSER` ASC) VISIBLE,
  PRIMARY KEY (`EMPLOYEE_USER_idUSER`),
  CONSTRAINT `fk_DEACTIVATED_ADMIN1`
    FOREIGN KEY (`ADMIN_USER_idUSER`)
    REFERENCES `rent-a-car`.`ADMIN` (`USER_idUSER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DEACTIVATED_EMPLOYEE1`
    FOREIGN KEY (`EMPLOYEE_USER_idUSER`)
    REFERENCES `rent-a-car`.`EMPLOYEE` (`USER_idUSER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `rent-a-car`.`Settings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rent-a-car`.`Settings` (
  `USER_idUSER` INT NOT NULL,
  `Language` TINYINT NOT NULL,
  `Mode` INT NOT NULL,
  PRIMARY KEY (`USER_idUSER`),
  CONSTRAINT `fk_Settings_USER1`
    FOREIGN KEY (`USER_idUSER`)
    REFERENCES `rent-a-car`.`USER` (`idUSER`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Stored Procedure `InsertNewEmployee`
-- -----------------------------------------------------
DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertNewEmployee`(
    IN p_Name VARCHAR(255),
    IN p_Surname VARCHAR(255),
    IN p_Email VARCHAR(255),
    IN p_Phone VARCHAR(15),
    IN p_Address VARCHAR(255),
    IN p_City VARCHAR(255),
    IN p_PostCode VARCHAR(10),
    IN p_Username VARCHAR(50),
    IN p_Password VARCHAR(255)
)
BEGIN
    DECLARE newUserId INT;
    DECLARE newSettingsId INT;

    INSERT INTO User (Name, Surname, Email, Phone, Address, City, PostCode, Username, Password)
    VALUES (p_Name, p_Surname, p_Email, p_Phone, p_Address, p_City, p_PostCode, p_Username, p_Password);

    SET newUserId = LAST_INSERT_ID();

    INSERT INTO Employee (USER_idUser)
    VALUES (newUserId);

    INSERT INTO Settings (USER_idUSER, Language, Mode)
    VALUES (newUserId, 0, 1);

    SELECT newUserId AS NewUserID;
END //

DELIMITER ;

-- -----------------------------------------------------
-- Stored Procedure `UpdateEmployee`
-- -----------------------------------------------------
DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateEmployee`(
    IN p_EmployeeID INT,
    IN p_Name VARCHAR(255),
    IN p_Surname VARCHAR(255),
    IN p_Email VARCHAR(255),
    IN p_Phone VARCHAR(15),
    IN p_Address VARCHAR(255),
    IN p_City VARCHAR(255),
    IN p_PostCode VARCHAR(10),
    IN p_Username VARCHAR(50),
    IN p_Password VARCHAR(255)
)
BEGIN
    UPDATE User
    SET Name = p_Name,
        Surname = p_Surname,
        Email = p_Email,
        Phone = p_Phone,
        Address = p_Address,
        City = p_City,
        PostCode = p_PostCode,
        Username = p_Username,
        Password = p_Password
    WHERE idUser = p_EmployeeID;
END //

DELIMITER ;

-- -----------------------------------------------------
-- Insert Admin User
-- -----------------------------------------------------
INSERT INTO `rent-a-car`.`USER` (`Name`, `Surname`, `Email`, `Phone`, `Address`, `City`, `PostCode`, `Username`, `Password`)
VALUES ('Admin', 'Admin', 'admin@example.com', '123456789', 'Admin Address', 'Admin City', '12345', 'admin', 'admin');

INSERT INTO `rent-a-car`.`ADMIN` (`USER_idUSER`) VALUES (LAST_INSERT_ID());
INSERT INTO Settings (USER_idUSER, Language, Mode)
    VALUES (LAST_INSERT_ID(), 0, 1);

-- -----------------------------------------------------
-- Insert Employee User
-- -----------------------------------------------------
CALL `InsertNewEmployee`('Employee', 'User', 'employee@example.com', '987654321', 'Employee Address', 'Employee City', '54321', 'zaposleni', 'zaposleni');

-- -----------------------------------------------------
-- Insert Cars
-- -----------------------------------------------------
INSERT INTO `rent-a-car`.`CAR` (`ChassisNumber`, `Brand`, `Model`, `Year`, `PricePerDay`, `Engine`, `Image`)
VALUES
('Chassis1', 'Hyundai', 'Elantra', '2022', 50, 'Petrol', '/Assets/CarImages/Chassis1.png'),
('Chassis2', 'Honda', 'Civic', '2021', 45, 'Petrol', '/Assets/CarImages/Chassis2.png'),
('Chassis3', 'Lexus', 'IS 300', '2014', 80, 'Petrol', '/Assets/CarImages/Chassis3.png');

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
