USE autohubdb 

INSERT INTO users_Permissions (Code, Name, Description)
select 'GetAuthenticatedUser', 'GetAuthenticatedUser', 'Get information about authenticated user'
where NOT EXISTS (SELECT 1 FROM users_Permissions);