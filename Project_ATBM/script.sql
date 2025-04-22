alter session set "_ORACLE_SCRIPT"=true;
CREATE USER admin_qldh IDENTIFIED BY admin_qldh;
GRANT dba to admin_qldh;
GRANT CREATE USER TO admin_qldh;
GRANT DROP USER TO admin_qldh;
GRANT CONNECT TO ADMIN_QLDH WITH ADMIN OPTION;
GRANT ALTER USER TO ADMIN_QLDH;
GRANT CREATE ROLE TO ADMIN_QLDH;
GRANT GRANT ANY ROLE TO ADMIN_QLDH;
CONNECT admin_qldh/admin_qldh@localhost:1521/XE;
-- create user
CREATE OR REPLACE PROCEDURE CreateUser (
    p_username IN NVARCHAR2,
    p_password IN NVARCHAR2
)
AS
    v_count NUMBER;
BEGIN
    SELECT COUNT(*) INTO v_count
    FROM all_users
    WHERE UPPER(username) = UPPER(p_username);
    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'User đã tồn tại.');
        return;
    END IF;
    EXECUTE IMMEDIATE 'CREATE USER ' || p_username || ' IDENTIFIED BY ' || p_password;
    EXECUTE IMMEDIATE 'GRANT CONNECT TO ' || p_username;
    
END;
/

--delete user
CREATE OR REPLACE PROCEDURE DeleteUser (
    p_username IN NVARCHAR2
)
AUTHID CURRENT_USER
AS
    v_count NUMBER;
BEGIN
    -- Kiểm tra user có tồn tại hay không
    SELECT COUNT(*) INTO v_count
    FROM all_users
    WHERE UPPER(username) = UPPER(p_username);
    
    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'User không tồn tại.');
    ELSE
        -- Xóa user và toàn bộ schema
        EXECUTE IMMEDIATE 'DROP USER "' || p_username || '" CASCADE';
    END IF;
END;
/
-- update user
CREATE OR REPLACE PROCEDURE UpdateUser (
    p_username IN NVARCHAR2,
    p_new_password IN NVARCHAR2
)
AS
    v_count NUMBER;
BEGIN
    -- Kiểm tra xem user có tồn tại trong cơ sở dữ liệu không
    SELECT COUNT(*) INTO v_count
    FROM all_users
    WHERE UPPER(username) = UPPER(p_username);
    
    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'User không tồn tại.');
        return;
    ELSE
    -- Cập nhật mật khẩu cho user
        EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' IDENTIFIED BY "' || p_new_password || '"';
    END IF;
END;
/


CREATE OR REPLACE PROCEDURE CreateRole (
    p_rolename IN NVARCHAR2
)
AS
    v_count NUMBER;
BEGIN
    EXECUTE IMMEDIATE 'CREATE ROLE ' || p_rolename;
END;
CREATE OR REPLACE PROCEDURE DeleteRole (
    p_rolename IN NVARCHAR2
)
AS
    v_count NUMBER;
BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ' || p_rolename;
END;
/

--update role
CREATE OR REPLACE PROCEDURE UpdateRole(
    p_rolename IN NVARCHAR2,
    p_new_password IN NVARCHAR2
)
AS
    v_count NUMBER;
BEGIN
    -- Cập nhật mật khẩu cho role
    EXECUTE IMMEDIATE 'ALTER ROLE ' || p_rolename || ' IDENTIFIED BY "' || p_new_password || '"';
END;
/


