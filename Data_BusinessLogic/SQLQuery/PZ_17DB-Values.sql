USE PZ17_117
INSERT INTO [UserType] ([Role]) 
VALUES 
(N'�������������'),
(N'������'),
(N'������');
INSERT INTO [ReqStatusType] ([Name]) 
VALUES 
(N'�������'),
(N'� ��������'),
(N'���������');
INSERT INTO [HomeTechType] ([Name]) 
VALUES 
(N'���������'),
(N'�����������'),
(N'���������� ������');
INSERT INTO [HomeTechModel] ([Name]) 
VALUES 
(N'LG OLED55CX6LA'),
(N'Samsung QLED Q80T'),
(N'Bosch KGV36VWEAS'),
(N'Samsung RB37J5000SA');
INSERT INTO [RepairParts] ([Name], [Price]) 
VALUES 
(N'������� ��� ����������', 15000),
(N'��������� ��� ������������', 3000),
(N'����� ��� ���������� ������', 2500),
(N'������ ��� ���������� ������', 800);
INSERT INTO [Users] ([Login], [Password], [Phone], [Name], [S_Name], [L_Name], [userType]) 
VALUES 
(N'admin', N'admin123', 79001234567, N'����', N'������', N'����', 1),
(N'master1', N'master123', 79007654321, N'����', N'������', N'����', 2),
(N'client1', N'client123', 79009876543, N'������', N'�������', N'������', 3);
INSERT INTO [Requests] ([startDate], [problemDescryption], [completionDate], [homeTechType], [homeTechModel], [repairParts], [clientID], [masterID], [status]) 
VALUES 
('2024-12-01 10:00:00', N'�� �������� ����� ����������', NULL, 1, 1, 1, 3, 2, 1),
('2024-12-02 14:00:00', N'����������� �� ���������', NULL, 2, 3, 2, 3, 2, 2),
('2024-12-03 09:00:00', N'�� �������� ���������� ������', NULL, 3, 4, 3, 3, 2, 1);
INSERT INTO [Comments] ([message], [requestID], [masterID]) 
VALUES 
(N'������ ������, ������ ������', 1, 2),
(N'������� ���������, �������� ���������', 2, 2),
(N'�������� ������, ������� ������', 3, 2);
