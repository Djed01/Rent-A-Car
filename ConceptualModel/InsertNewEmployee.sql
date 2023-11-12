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
END