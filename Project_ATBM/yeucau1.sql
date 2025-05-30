--câu 1.1
--Người dùng có VAITRO là “NVCB” có quyền xem dòng dữ liệu của chính mình trong
--quan hệ NHANVIEN, có thể chỉnh sửa số điện thoại (ĐT) của chính mình (nếu số điện
--thoại có thay đổi).

create role role_nvcb;
CREATE OR REPLACE VIEW v_nvcb AS
SELECT * FROM NHANVIEN WHERE manld= SYS_CONTEXT('userenv','session_user');
GRANT SELECT ON v_nvcb TO role_nvcb;
GRANT UPDATE (DT) ON v_nvcb to role_nvcb;
--Câu 1.2 Tất cả nhân viên thuộc các vai trò còn lại đều có quyền của vai trò “NVCB”.
CREATE ROLE role_gv;
CREATE ROLE role_nvpdt;
CREATE ROLE role_nvpkt;
CREATE ROLE role_nvtchc;
CREATE ROLE role_nvctsv;
CREATE ROLE role_trgdv;

GRANT SELECT ON v_nvcb TO role_gv;
GRANT SELECT ON v_nvcb TO role_nvpdt;
GRANT SELECT ON v_nvcb TO role_nvpkt;
GRANT SELECT ON v_nvcb TO role_nvtchc;
GRANT SELECT ON v_nvcb TO role_nvctsv;
GRANT SELECT ON v_nvcb TO role_trgdv;

GRANT UPDATE (DT) ON v_nvcb to role_nvcb;
GRANT UPDATE (DT) ON v_nvcb to role_gv;
GRANT UPDATE (DT) ON v_nvcb to role_nvpdt;
GRANT UPDATE (DT) ON v_nvcb to role_nvpkt;
GRANT UPDATE (DT) ON v_nvcb to role_nvtchc;
GRANT UPDATE (DT) ON v_nvcb to role_nvctsv;
GRANT UPDATE (DT) ON v_nvcb to role_trgdv;

--câu 1.3 Người dùng có VAITRO là “TRGĐV” có quyền xem các dòng dữ liệu liên quan đến
--các nhân viên thuộc đơn vị mình làm trưởng, trừ các thuộc tính LUONG và PHUCAP.
CREATE OR REPLACE VIEW v_trgdv_nv as
SELECT MANLD,
    HOTEN   ,
    PHAI    ,
    NGSINH  ,
    DT      ,
    VAITRO  ,
    MADV 
FROM NHANVIEN nv WHERE madv in (
SELECT madv from DONVI where trgdv= sys_context('userenv','session_user')
) and MANLD != sys_context('userenv','session_user');
GRANT SELECT ON v_trgdv_nv TO role_trgdv;
--Câu 1.4 Người dùng có VAITRO là “NV TCHC” có quyền xem, thêm, cập nhật, xóa trên quan
--hệ NHANVIEN.
grant select, insert, delete, update on nhanvien to role_nvtchc;
--Câu 2.1 Người dùng có vai trò “GV” được quyền xem các dòng phân công giảng dạy liên quan
--đến chính giảng viên đó.
create or replace view v_gv_mm as
select * from momon where magv= sys_context('userenv','session_user');
GRANT SELECT ON v_gv_mm TO role_gv;
--Câu 2.2 Người dùng có vai trò “NV PĐT” có quyền xem, thêm, cập nhật, xóa dòng trong bảng
--MOMON liên quan đến học kỳ hiện tại của năm học đang diễn ra.
/

CREATE OR REPLACE FUNCTION GET_CURRENT_SEMESTER RETURN NUMBER IS
  current_month NUMBER;
BEGIN
  current_month := EXTRACT(MONTH FROM SYSDATE);

  IF current_month >= 9 THEN 
    RETURN 1; 
  ELSIF current_month >= 1 AND current_month <= 5 THEN
    RETURN 2; 
  ELSE 
    RETURN 3; 
  END IF;
END;
/
CREATE OR REPLACE VIEW V_nvpdt_mm AS
SELECT *
FROM MOMON
WHERE (
    TO_NUMBER(SUBSTR(NAM,1,4)) = EXTRACT(YEAR FROM SYSDATE)
    OR TO_NUMBER(SUBSTR(NAM,6,9)) = EXTRACT(YEAR FROM SYSDATE)
)
AND HK = GET_CURRENT_SEMESTER()
WITH CHECK OPTION;

GRANT SELECT, INSERT, UPDATE, DELETE ON V_nvpdt_mm TO role_nvpdt;

--Câu 2.3 Người dùng có vai trò “TRGĐV” có quyền xem các dòng phân công giảng dạy của
--các giảng viên thuộc đơn vị mình làm trưởng.
CREATE OR REPLACE VIEW v_trgdv_mm AS
select m.mamm, m.mahp, m.magv, m.hk, m.nam 
from momon m 
join nhanvien nv on m.magv=nv.manld 
join donvi dv on dv.madv= nv.madv where dv.trgdv= sys_context('userenv','session_user');
GRANT SELECT ON v_trgdv_mm to role_trgdv;
-- Câu 2.4 Sinh viên có quyền xem các dòng dữ liệu trong quan hệ MOMON liên quan các dòng
--mở các học phần thuộc quyền phụ trách chuyên môn bởi Khoa mà sinh viên đang theo
--học.
create or replace view v_sv_momon as
select m.mamm, m.mahp, m.magv, m.hk, m.nam, m.ngaybd 
from momon m 
join hocphan hp on hp.mahp=m.mahp
join sinhvien sv on sv.khoa=hp.madv where sv.masv=sys_context('userenv','session_user')
and ( TO_NUMBER(SUBSTR(NAM,1,4)) = EXTRACT(YEAR FROM SYSDATE)
    OR TO_NUMBER(SUBSTR(NAM,6,9)) = EXTRACT(YEAR FROM SYSDATE) )
AND m.HK = GET_CURRENT_SEMESTER();
GRANT SELECT ON v_sv_momon TO role_sv;
--Câu 3.1 Sinh viên có thể xem dòng dữ liệu liên quan đến chính mình, có thể sửa các trường địa
--chỉ (ĐCHI), số điện thoại (ĐT) liên quan đến chính mình.
CREATE OR REPLACE FUNCTION sv_vpd_policy (
    schema_name VARCHAR2,
    object_name VARCHAR2
)
RETURN VARCHAR2
AS
    makhoa VARCHAR2(50);
BEGIN
    IF SYS_CONTEXT('USERENV', 'SESSION_USER') = 'ADMIN_QLDH' THEN
        RETURN '1=1';  
    ELSIF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'SV%' THEN
        RETURN 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')'; 
    ELSIF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'NVCTSV%' THEN
        RETURN '1=1';
     ELSIF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'NVPDT%' THEN
        RETURN '1=1';
     ELSIF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'GV%' THEN
        SELECT madv INTO makhoa FROM NHANVIEN WHERE manld=SYS_CONTEXT('USERENV', 'SESSION_USER');
        RETURN ' KHOA = ''' || makhoa || '''';
    ELSE
        RETURN '1=0';
    END IF;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
    object_schema   => 'ADMIN_QLDH',         
    object_name     => 'SINHVIEN',
    policy_name     => 'SV_POLICY',
    function_schema => 'ADMIN_QLDH',         
    policy_function => 'sv_vpd_policy',
    statement_types => 'SELECT, INSERT, UPDATE, DELETE',
    update_check    => TRUE                  
  );
END;
/
--BEGIN
--    DBMS_RLS.DROP_POLICY (
--        object_schema  => 'ADMIN_QLDH',
--        object_name    => 'SINHVIEN',
--        policy_name    => 'SV_POLICY'
--    );
--END;
--/
CREATE OR REPLACE TRIGGER sv_restrict_update
BEFORE UPDATE ON SINHVIEN
FOR EACH ROW
BEGIN   
    IF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'NVCTSV%' THEN
        IF  UPDATING ('TINHTRANG') THEN
            RAISE_APPLICATION_ERROR(-20001, 'Nhân viên phòng công tác sinh viên không được cập nhật tình trạng.');
        END IF;
    END IF;
END;
/
CREATE ROLE role_sv;
GRANT SELECT,UPDATE(DCHI, DT)  ON SINHVIEN TO role_sv;

GRANT SELECT, INSERT, UPDATE, DELETE ON SINHVIEN TO role_nvpdt;
GRANT SELECT, INSERT, UPDATE, DELETE ON SINHVIEN TO role_nvctsv;
GRANT SELECT ON SINHVIEN TO role_gv;
--câu 4
CREATE OR REPLACE FUNCTION dk_vpd_policy (
    schema_name VARCHAR2,
    object_name VARCHAR2
)
RETURN VARCHAR2
AS
    v_user VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
BEGIN
    IF v_user = 'ADMIN_QLDH' THEN
        RETURN '1=1'; 
    ELSIF v_user LIKE 'SV%' THEN
        RETURN 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')'; 
    ELSIF v_user LIKE 'NVPKT%' THEN
        RETURN '1=1';
    ELSIF v_user LIKE 'NVPDT%' THEN
        RETURN '1=1';
    ELSIF v_user LIKE 'GV%' THEN
        RETURN ' MAMM IN (SELECT MAMM FROM MOMON WHERE MAGV = SYS_CONTEXT(''USERENV'', ''SESSION_USER''))';
    ELSE
        RETURN '1=0';
    END IF;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
    object_schema   => 'ADMIN_QLDH',         
    object_name     => 'DANGKY',
    policy_name     => 'DK_POLICY',
    function_schema => 'ADMIN_QLDH',         
    policy_function => 'dk_vpd_policy',
    statement_types => 'SELECT, INSERT, UPDATE, DELETE',
    update_check    => TRUE                  
  );
END;
/
--BEGIN
--    DBMS_RLS.DROP_POLICY (
--        object_schema  => 'ADMIN_QLDH',
--        object_name    => 'DANGKY',
--        policy_name    => 'DK_POLICY'
--    );
--END;
--/
CREATE OR REPLACE FUNCTION mask_diem_func (
  schema_name IN VARCHAR2,
  table_name  IN VARCHAR2
) RETURN VARCHAR2 IS
  v_user VARCHAR2(30);
BEGIN
  v_user := SYS_CONTEXT('USERENV', 'SESSION_USER');

  IF v_user LIKE 'NVPDT%' THEN
    RETURN '1=0';  
  ELSE
    RETURN NULL; 
  END IF;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY(
    object_schema   => 'ADMIN_QLDH',
    object_name     => 'DANGKY',
    policy_name     => 'mask_diem_policy',
    function_schema => 'ADMIN_QLDH',
    policy_function => 'mask_diem_func',
    statement_types => 'SELECT',
    sec_relevant_cols => 'DIEMTK, DIEMTH, DIEMCK, DIEMQT',
    sec_relevant_cols_opt => DBMS_RLS.ALL_ROWS
  );
END;
/
--BEGIN
--    DBMS_RLS.DROP_POLICY (
--        object_schema  => 'ADMIN_QLDH',
--        object_name    => 'DANGKY',
--        policy_name    => 'mask_diem_policy'
--    );
--END;
--/
CREATE OR REPLACE TRIGGER dk_restrict_update
BEFORE INSERT OR UPDATE OR DELETE ON DANGKY
FOR EACH ROW
DECLARE
    v_user       VARCHAR2(30) := SYS_CONTEXT('USERENV', 'SESSION_USER');
    v_today      DATE := SYSDATE;
    v_start_date DATE;
    v_end_date   DATE;
    v_mamm       VARCHAR2(10);
BEGIN
    IF INSERTING OR UPDATING THEN
        v_mamm := :NEW.MAMM;
    ELSIF DELETING THEN
        v_mamm := :OLD.MAMM;
    END IF;

    SELECT NGAYBD INTO v_start_date
    FROM MOMON
    WHERE MAMM = v_mamm;

    v_end_date := v_start_date + 14;

    IF v_user LIKE 'SV%' OR v_user LIKE 'NVPDT%' THEN
        IF v_today > v_end_date THEN
            RAISE_APPLICATION_ERROR(-20001, 'Chỉ được phép sửa trong 14 ngày đầu học kỳ.');
        END IF;
        IF INSERTING OR UPDATING THEN
            IF :NEW.DIEMTH IS NOT NULL OR :NEW.DIEMQT IS NOT NULL OR 
               :NEW.DIEMCK IS NOT NULL OR :NEW.DIEMTK IS NOT NULL THEN
                RAISE_APPLICATION_ERROR(-20002, 'Không được phép nhập điểm.');
            END IF;
        END IF;
    END IF;
END;
/
GRANT SELECT, INSERT, DELETE ON DANGKY TO role_sv;
GRANT SELECT, INSERT, DELETE ON DANGKY TO role_nvpdt;
GRANT SELECT, UPDATE (DIEMTH,DIEMQT,DIEMCK,DIEMTK) ON DANGKY TO role_nvpkt;
GRANT SELECT ON DANGKY TO role_gv;

