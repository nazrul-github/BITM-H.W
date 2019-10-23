use sample_db;

CREATE TABLE vehcileDatabase(
VehicleId INT IDENTITY PRIMARY KEY,
VehicleOwner NVARCHAR(50) NOT NULL,
Manufacturer NVARCHAR(50) NOT NULL,
ModelYear NVARCHAR(50) NOT NULL,
Color NVARCHAR(50) NOT NULL,
InsuranceNumber NVARCHAR(50) NOT NULL,
RegistrationCity NVARCHAR(50) NOT NULL
)