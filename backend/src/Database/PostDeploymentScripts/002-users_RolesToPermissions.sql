USE autohubdb 

INSERT INTO users_RolesToPermissions (RoleCode, PermissionCode)
SELECT * FROM (
    SELECT 'Admin' AS RoleCode, 'GetAuthenticatedUser' AS PermissionCode
    UNION ALL
    SELECT 'Member', 'GetAuthenticatedUser'
) AS temp
WHERE NOT EXISTS (
    SELECT 1 FROM users_RolesToPermissions WHERE PermissionCode = 'GetAuthenticatedUser'
);