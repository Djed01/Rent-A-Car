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
END