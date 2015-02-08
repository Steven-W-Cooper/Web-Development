DECLARE @NEWID UNIQUEIDENTIFIER

SET @NEWID = NEWID()

INSERT INTO ASPNET_APPLICATIONS (APPLICATIONNAME, LoweredApplicationName, ApplicationId, [Description])
VALUES ('/Avenue-Heights', '/avenue-heights', @NEWID, 'Base App')

SET @NEWID = NEWID()

INSERT INTO ASPNET_APPLICATIONS (APPLICATIONNAME, LoweredApplicationName, ApplicationId, [Description])
VALUES ('/Avenue-Workflow', '/avenue-workflow', @NEWID, 'Workflow App')

SELECT * FROM ASPNET_APPLICATIONS

SET @NEWID = NEWID()

insert into aspnet_Roles (ApplicationId, RoleID, RoleName, LoweredRoleName, [Description])
values ('E6CF16D3-02FB-47AD-AEC3-3A052AAE46C0', @NEWID, 'Member', 'member', 'Base Member')

SET @NEWID = NEWID()

insert into aspnet_Roles (ApplicationId, RoleID, RoleName, LoweredRoleName, [Description])
values ('5F908C33-7EFF-47BD-92F8-859D5C7429FF', @NEWID, 'Member', 'member', 'Workflow Member')

select * from aspnet_Roles