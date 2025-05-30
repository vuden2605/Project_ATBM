-- connect vào sys trong cdb để unlock user lbacsys
CONNECT sys@localhost:1521/XE AS SYSDBA;
ALTER USER lbacsys IDENTIFIED BY lbacsys ACCOUNT UNLOCK;
-- connect sys trong pdb qldh
CONNECT sys@localhost:1521/QLDH AS SYSDBA;

--kiểm tra quyền ols
EXEC LBACSYS.CONFIGURE_OLS;
EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS; 
---> KHỞI ĐỘNG LẠI
SHUTDOWN IMMEDIATE;
STARTUP;
GRANT INHERIT PRIVILEGES ON USER ADMIN_QLDH TO LBACSYS WITH GRANT OPTION; 
GRANT INHERIT PRIVILEGES ON USER SYS TO LBACSYS WITH GRANT OPTION; 
GRANT INHERIT PRIVILEGES ON USER LBACSYS TO ADMIN_QLDH WITH GRANT OPTION;
GRANT CONNECT,RESOURCE TO ADMIN_QLDH; --CẤP QUYỀN CONNECT VÀ RESOURCE
GRANT UNLIMITED TABLESPACE TO ADMIN_QLDH; --CẤP QUOTA CHO ADMIN_QLDH
GRANT SELECT ANY DICTIONARY TO ADMIN_QLDH; --CẤP QUYỀN ĐỌC DICTIONARY
---> CẤP QUYỀN EXECUTE CHO ADMIN_QLDH
GRANT EXECUTE ON LBACSYS.SA_COMPONENTS TO ADMIN_QLDH WITH GRANT OPTION;
GRANT EXECUTE ON LBACSYS.sa_user_admin TO ADMIN_QLDH WITH GRANT OPTION;
GRANT EXECUTE ON LBACSYS.sa_label_admin TO ADMIN_QLDH WITH GRANT OPTION;
GRANT EXECUTE ON sa_policy_admin TO ADMIN_QLDH WITH GRANT OPTION;
GRANT EXECUTE ON char_to_label TO ADMIN_QLDH WITH GRANT OPTION;
---> ADD ADMIN_QLDH VÀO LBAC_DBA
GRANT LBAC_DBA TO ADMIN_QLDH;
GRANT EXECUTE ON sa_sysdba TO ADMIN_QLDH;
GRANT EXECUTE ON TO_LBAC_DATA_LABEL TO ADMIN_QLDH; -- CẤP QUYỀN THỰC THI

--- connect vào admin_qlhd/pdb
connect admin_qldh/admin_qldh@localhost:1521/QLDH;

CREATE TABLE THONGBAO (
    ID NUMBER PRIMARY KEY,
    NOIDUNG VARCHAR2(4000),
    NGAYTAO DATE DEFAULT SYSDATE
);
-- tạo người dùng để test
-- tạo u1-u8 gán quyền connect select trên thongbao
-- Tạo user và cấp quyền CONNECT + SELECT trên ADMIN_QLDH.THONGBAO
--
--CREATE USER TDV001 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO TDV001;
--
--CREATE USER TDV004 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO TDV004;
--
--CREATE USER TDV002 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO TDV002;
--
--CREATE USER GV004 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO GV004;
--
--CREATE USER SV0004 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO SV0004;
--
--CREATE USER TDV003 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO TDV003;
--
--CREATE USER GV001 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO GV001;
--
--CREATE USER NVPDT001 IDENTIFIED BY 123;
--GRANT CONNECT, SELECT ON ADMIN_QLDH.THONGBAO TO NVPDT001;
--- tạo chính sách
BEGIN
    sa_sysdba.create_policy(
        policy_name => 'THONGBAO_POLICY',
        column_name => 'OLS_LABEL'
    );
END;
/
EXEC SA_SYSDBA.ENABLE_POLICY ('THONGBAO_POLICY');
--- tắt sql dev đi mở lại
BEGIN
    sa_components.create_level(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Truong Don Vi',
        short_name => 'TDV',
        level_num => 9000
    );
END;
/

-- Tạo level Nhân viên  
BEGIN
    sa_components.create_level(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Nhan Vien',
        short_name => 'NV',
        level_num => 8000
    );
END;
/

-- Tạo level Sinh viên
BEGIN
    sa_components.create_level(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Sinh Vien',
        short_name => 'SV',
        level_num => 7000
    );
END;
/

-- Tạo compartment Toán
BEGIN
    sa_components.create_compartment(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Toan Hoc',
        short_name => 'TOAN',
        comp_num => 1000
    );
END;
/

-- Tạo compartment Lý
BEGIN
    sa_components.create_compartment(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Vat Ly',
        short_name => 'LY',
        comp_num => 2000
    );
END;
/

-- Tạo compartment Hóa
BEGIN
    sa_components.create_compartment(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Hoa Hoc',
        short_name => 'HOA',
        comp_num => 3000
    );
END;
/

-- Tạo compartment Hành chính
BEGIN
    sa_components.create_compartment(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Hanh Chinh',
        short_name => 'HC',
        comp_num => 4000
    );
END;
/

-- Tạo group Cơ sở 1
BEGIN
    sa_components.create_group(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Co So 1',
        short_name => 'CS1',
        group_num => 100
    );
END;
/

-- Tạo group Cơ sở 2
BEGIN
    sa_components.create_group(
        policy_name => 'THONGBAO_POLICY',
        long_name => 'Co So 2',
        short_name => 'CS2',
        group_num => 200
    );
END;
/
-- xem label
--SELECT * FROM DBA_SA_LABELS 
--WHERE POLICY_NAME = 'THONGBAO_POLICY';
--drop label

--BEGIN
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000018);
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000019);
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000020);
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000021);
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000022);
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000023);
--    sa_label_admin.drop_label(policy_name => 'THONGBAO_POLICY', label_tag => 1000000024);
--END;
--/

-- t1,Nhãn cho Trưởng đơn vị (có thể đọc tất cả)
BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1001,
        label_value => 'TDV::',
        data_label =>TRUE

    );
END;
/

-- T2: Cần phát tán đến tất cả nhân viên
BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1002,
        label_value => 'NV::',
        data_label =>TRUE

    );
END;
/
--

-- T3: Cần phát tán đến tất cả sinh viên
BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1003,
        label_value => 'SV::',
        data_label =>TRUE

    );
END;
/


-- T4: Cần phát tán đến sinh viên thuộc khoa Hóa ở cơ sở 1
BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1004,
        label_value => 'SV:HOA:CS1',
        data_label =>TRUE
    );
END;
/
-- T5: Cần phát tán đến sinh viên thuộc khoa Hóa ở cơ sở 2

BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1005,
        label_value => 'SV:HOA:CS2',
        data_label =>TRUE
    );
END;
/
-- T6: Cần phát tán đến sinh viên thuộc khoa Hóa ở cả hai cơ sở

BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1006,
        label_value => 'SV:HOA:',
        data_label =>TRUE
    );
END;
/
-- T8: Cần phát tán đến trưởng khoa Hóa ở cơ sở 1

BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1008,
        label_value => 'TDV:HOA:CS1',
        data_label =>TRUE
    );
END;
/
-- T9: Cần phát tán đến trưởng khoa Hóa ở cơ sở 1 và cơ sở 2

BEGIN
    sa_label_admin.create_label(
        policy_name => 'THONGBAO_POLICY',
        label_tag => 1009,
        label_value => 'TDV:HOA:',
        data_label =>TRUE
    );
END;
/
-- U1: Trưởng đơn vị có thể đọc toàn bộ thông báo
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'TDV001',
        'TDV:TOAN,LY,HOA,HC:CS1,CS2'
    );
END;
/
-- U2: Trưởng đơn vị phụ trách khoa Hóa tại cơ sở 2
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'TDV004',
        'TDV:HOA:CS2'
    );
END;
/

-- U3: Trưởng đơn vị phụ trách khoa Lý tại cơ sở 2
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'TDV002',
        'TDV:LY:CS2'
    );
END;
/

-- U4: Nhân viên thuộc khoa Hóa tại cơ sở 2
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'GV004',
        'NV:HOA:CS2'
    );
END;
/

-- U5: Sinh viên khoa Hóa tại cơ sở 2
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'SV0004',
        'SV:HOA:CS2'
    );
END;
/

-- U6: Trưởng đơn vị có thể đọc thông báo về Hành chính
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'TDV003',
        'TDV:HC:CS1,CS2'
    );
END;
/

-- U7: Nhân viên có thể đọc toàn bộ thông báo dành cho nhân viên
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'GV001',
        'NV:TOAN,LY,HOA,HC:CS1,CS2'
    );
END;
/

-- U8: Nhân viên có thể đọc thông báo về Hành chính tại cơ sở 1
BEGIN
    sa_user_admin.set_user_labels(
        'THONGBAO_POLICY',
        'NVPDT001',
        'NV:HC:CS1'
    );
END;
/
-- gán chính sách
BEGIN
    sa_policy_admin.apply_table_policy(
        policy_name => 'THONGBAO_POLICY',
        schema_name => 'ADMIN_QLDH',
        table_name => 'THONGBAO',
        table_options => 'READ_CONTROL'
    );
END;
/
-- T1: Cần phát tán đến tất cả trưởng đơn vị
-- Sử dụng label chung nhất cho TDV
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (1, 'Thông báo dành cho tất cả trưởng đơn vị', 1001);

-- T2: Cần phát tán đến tất cả nhân viên
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (2, 'Thông báo dành cho tất cả nhân viên',1002);

-- T3: Cần phát tán đến tất cả sinh viên
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (3, 'Thông báo dành cho tất cả sinh viên',1003);

-- T4: Cần phát tán đến sinh viên thuộc khoa Hóa ở cơ sở 1
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (4, 'Thông báo cho sinh viên khoa Hóa cơ sở 1',1004);

-- T5: Cần phát tán đến sinh viên thuộc khoa Hóa ở cơ sở 2
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (5, 'Thông báo cho sinh viên khoa Hóa cơ sở 2',1005);

-- T6: Cần phát tán đến sinh viên thuộc khoa Hóa ở cả hai cơ sở
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (6, 'Thông báo cho sinh viên khoa Hóa cả hai cơ sở', 1006);
--INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
--VALUES (16, 'Thông báo cho sinh viên khoa Hóa cả hai cơ sở', 
--        char_to_label('THONGBAO_POLICY', 'SV:HOA:'));
-- T7: Cần phát tán đến tất cả sinh viên thuộc cả hai cơ sở
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (7, 'Thông báo cho tất cả sinh viên cả hai cơ sở',1003);

-- T8: Cần phát tán đến trưởng khoa Hóa ở cơ sở 1
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (8, 'Thông báo cho trưởng khoa Hóa cơ sở 1', 1008);

-- T9: Cần phát tán đến trưởng khoa Hóa ở cơ sở 1 và cơ sở 2
INSERT INTO THONGBAO (ID, NOIDUNG, OLS_LABEL) 
VALUES (9, 'Thông báo cho trưởng khoa Hóa cả hai cơ sở', 1009);
commit;


