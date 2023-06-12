CREATE TABLE Departments (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(255) NOT NULL
);

CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName NVARCHAR(255) NOT NULL,
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);

CREATE TABLE Tickets (
    TicketId INT IDENTITY(1,1) PRIMARY KEY,
    Project NVARCHAR(MAX) NOT NULL,
    DepartmentId INT,
    EmployeeId INT,
    Description NVARCHAR(MAX) NOT NULL,
    DateTimeSubmitted DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

INSERT INTO Departments (DepartmentName)
VALUES 
('Division of Telecommunications Extranet Development'),
('Extranet Multimedia Connectivity and Security Division'),
('Branch of Extranet Implementation'),
('Branch of Intranet Computer Maintenance and E-Commerce PC Programming'),
('Wireless Extranet Backup Team'),
('Database Programming Branch'),
('Hardware Backup Department'),
('Multimedia Troubleshooting and Maintenance Team'),
('Office of Statistical Data Connectivity'),
('Division of Application Security'),
('Network Maintenance and Multimedia Implementation Committee'),
('Mainframe PC Development and Practical Source Code Acquisition Team'),
('PC Maintenance Department'),
('Bureau of Business-Oriented PC Backup and Wireless Telecommunications Control'),
('Software Technology and Networking Department');

INSERT INTO Employees (EmployeeName, DepartmentId)
VALUES 
('Roma Marcell', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Division of Telecommunications Extranet Development')),
('Hugo Wess', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Extranet Multimedia Connectivity and Security Division')),
('Kelvin Lahr', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Branch of Extranet Implementation')),
('Janelle Newberg', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Division of Telecommunications Extranet Development')),
('Mellie Lombard', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Branch of Intranet Computer Maintenance and E-Commerce PC Programming')),
('Reita Abshire', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Wireless Extranet Backup Team')),
('Dalila Vickrey', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Database Programming Branch')),
('Idella Dallman', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Branch of Extranet Implementation')),
('Farah Eldridge', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Hardware Backup Department')),
('Lana Montes', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Hardware Backup Department')),
('Leola Thornburg', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Extranet Multimedia Connectivity and Security Division')),
('Marcelo Paris', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Database Programming Branch')),
('Ione Tomlin', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Multimedia Troubleshooting and Maintenance Team')),
('Hilario Masterson', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Multimedia Troubleshooting and Maintenance Team')),
('Janice Skipper', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Wireless Extranet Backup Team')),
('Keren Gillespi', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Office of Statistical Data Connectivity')),
('Linh Leitzel', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Division of Telecommunications Extranet Development')),
('Rosalia Ayoub', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Division of Application Security')),
('Shawna Hood', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Branch of Intranet Computer Maintenance and E-Commerce PC Programming')),
('Wilfredo Stumpf', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Network Maintenance and Multimedia Implementation Committee')),
('Alexandra Brendle', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Office of Statistical Data Connectivity')),
('Luciano Riddell', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Mainframe PC Development and Practical Source Code Acquisition Team')),
('Boyce Perales', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Network Maintenance and Multimedia Implementation Committee')),
('Alissa Perlman', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Division of Telecommunications Extranet Development')),
('Latoyia Kremer', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Network Maintenance and Multimedia Implementation Committee')),
('Tawna Blackmore', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Wireless Extranet Backup Team')),
('Claudine Valderrama', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Hardware Backup Department')),
('Katheryn Lepak', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Network Maintenance and Multimedia Implementation Committee')),
('Sage Bow', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Multimedia Troubleshooting and Maintenance Team')),
('Altha Rudisill', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Hardware Backup Department')),
('Olympia Vien', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Division of Application Security')),
('Olene Pyron', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'PC Maintenance Department')),
('Delorse Searle', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Extranet Multimedia Connectivity and Security Division')),
('Greta Quigg', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Bureau of Business-Oriented PC Backup and Wireless Telecommunications Control')),
('Kenneth Bowie', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Branch of Intranet Computer Maintenance and E-Commerce PC Programming')),
('Colton Kranz', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Hardware Backup Department')),
('Kasie Barclay', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Multimedia Troubleshooting and Maintenance Team')),
('Thresa Levins', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Extranet Multimedia Connectivity and Security Division')),
('Diego Hasbrouck', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Software Technology and Networking Department')),
('Tomoko Gale', (SELECT DepartmentId FROM Departments WHERE DepartmentName = 'Database Programming Branch'));

