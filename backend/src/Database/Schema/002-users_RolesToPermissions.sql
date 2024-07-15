USE autohubdb 

CREATE TABLE IF NOT EXISTS users_RolesToPermissions (
    RoleCode VARCHAR(50) NOT NULL,
    PermissionCode VARCHAR(50) NOT NULL,
    PRIMARY KEY (RoleCode, PermissionCode)
);