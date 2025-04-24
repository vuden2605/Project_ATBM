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


-- phân quyền cho user
CREATE OR REPLACE PROCEDURE GrantForUser (
    n_pri     IN VARCHAR2,
    n_obj     IN VARCHAR2,
    n_user    IN VARCHAR2,
    n_column  IN VARCHAR2,
    n_flag    IN CHAR
)
AUTHID CURRENT_USER AS   
    v_sql VARCHAR2(1000);
BEGIN
    IF (n_pri IN ('SELECT', 'UPDATE')) AND n_column IS NOT NULL THEN
        -- Grant trên cột
        v_sql := 'GRANT ' || n_pri || ' (' || n_column || ') ON ' || n_obj || ' TO ' || n_user;
    ELSE
        -- Grant trên toàn table
        v_sql := 'GRANT ' || n_pri || ' ON ' || n_obj || ' TO ' || n_user;
    END IF;

    -- Thêm WITH GRANT OPTION nếu có
    IF n_flag = 'T' THEN
        v_sql := v_sql || ' WITH GRANT OPTION';
    END IF;

    EXECUTE IMMEDIATE v_sql;
END;

-- phân role cho user
CREATE OR REPLACE PROCEDURE GrantRoleForUser (
    n_role in varchar2,
    n_user in varchar2
)
AUTHID CURRENT_USER AS  
BEGIN
     EXECUTE IMMEDIATE 'GRANT ' || n_role || ' TO ' || n_user;
END;

-- phân quyền cho role
CREATE OR REPLACE PROCEDURE GrantForRole (
    n_pri     IN VARCHAR2,
    n_obj     IN VARCHAR2,
    n_role    IN VARCHAR2,
    n_column  IN VARCHAR2
)
AUTHID CURRENT_USER AS
    v_sql VARCHAR2(1000);
BEGIN
    IF (n_pri IN ('SELECT', 'UPDATE')) AND n_column IS NOT NULL THEN
        -- Grant trên cột
        v_sql := 'GRANT ' || n_pri || ' (' || n_column || ') ON ' || n_obj || ' TO ' || n_role;
    ELSE
        -- Grant toàn bảng
        v_sql := 'GRANT ' || n_pri || ' ON ' || n_obj || ' TO ' || n_role;
    END IF;
    -- Thực thi lệnh GRANT
    EXECUTE IMMEDIATE v_sql;
END;



-- thu hồi quyền của user
CREATE OR REPLACE PROCEDURE RevokeFromUser (
    n_pri in varchar2,
    n_obj in varchar2,
    n_user in varchar2
)
AUTHID CURRENT_USER AS   
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ' || n_pri || ' ON ' || n_obj || ' FROM '||n_user;
END;

-- thu hồi quyền của role
CREATE OR REPLACE PROCEDURE RevokeFromRole (
    n_pri in varchar2,
    n_obj in varchar2,
    n_role in varchar2
)
AUTHID CURRENT_USER AS   
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ' || n_pri || ' ON ' || n_obj || ' FROM '||n_role;
END;

-- thu hồi role của user
CREATE OR REPLACE PROCEDURE RevokeRoleFromUser(
    n_role in varchar2,
    n_user in varchar2
)
AUTHID CURRENT_USER AS   
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ' || n_role || ' FROM ' || n_user;
END;

-- thu hồi tất cả quyền của user
CREATE OR REPLACE PROCEDURE RevokeAllFromUser(
    n_obj in varchar2,
    n_user in varchar2
)
AUTHID CURRENT_USER AS   
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ALL ON ' || n_obj || ' FROM ' || n_user;
END;

--thu hồi tất cả quyền của role
CREATE OR REPLACE PROCEDURE RevokeAllFromRole(
    n_obj in varchar2,
    n_role in varchar2
)
AUTHID CURRENT_USER AS   
BEGIN
    EXECUTE IMMEDIATE 'REVOKE ALL ON ' || n_obj || ' FROM ' || n_role;
END;
