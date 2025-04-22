alter session set "_ORACLE_SCRIPT"=true;
CREATE USER admin_qldh IDENTIFIED BY admin_qldh;
GRANT dba to admin_qldh;
GRANT CREATE USER TO admin_qldh;
GRANT DROP USER TO admin_qldh;
GRANT CONNECT TO ADMIN_QLDH WITH ADMIN OPTION;
GRANT ALTER USER TO ADMIN_QLDH;
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
        -- Thu hồi các role đã cấp (nếu cần)
        BEGIN
            EXECUTE IMMEDIATE 'REVOKE CONNECT FROM "' || p_username || '"';
        EXCEPTION
            WHEN OTHERS THEN
                NULL; -- Bỏ qua nếu chưa được cấp hoặc lỗi nhỏ
        END;
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


