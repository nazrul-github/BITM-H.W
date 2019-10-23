SELECT * FROM vehcileDatabase ORDER BY VehicleId DESC;

CREATE PROCEDURE spNewVehicle
@OwnerName NVARCHAR(50),
@ModelYear NVARCHAR(50),
@Color NVARCHAR(50),
@InsuranceNumber NVARCHAR(50),
@RegistrationCity NVARCHAR(50),
@Manufacturer NVARCHAR(50),
@RegistrationNumber INT OUT
AS
BEGIN
INSERT INTO vehcileDatabase VALUES(@OwnerName,@Manufacturer,@ModelYear,@Color,@InsuranceNumber,@RegistrationCity)
SELECT @RegistrationNumber = SCOPE_IDENTITY()
end;
