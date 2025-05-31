--audit
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'ADMIN_QLDH',
    object_name     => 'DANGKY',
    policy_name     => 'AUDIT_DANGKY',
    audit_condition => 'SYS_CONTEXT(''USERENV'',''CURRENT_USER'') NOT LIKE ''NVPKT%''',
    audit_column    => 'DIEMQT, DIEMCK, DIEMTK, DIEMTH',
    enable          => TRUE,
    statement_types => 'UPDATE'
  );
END;


/
--BEGIN
--  DBMS_FGA.DROP_POLICY( 
--    object_schema => 'ADMIN_QLDH',
--    object_name   => 'DANGKY',
--    policy_name   => 'AUDIT_DANGKY'
--  );
--END;
--/
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'ADMIN_QLDH',
    object_name     => 'NHANVIEN',
    policy_name     => 'AUDIT_SELECT_LUONG_PHUCAP',
    audit_condition => 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'') NOT LIKE ''NVTCHC%'' AND MANLD <> SYS_CONTEXT(''USERENV'', ''SESSION_USER'')',
    audit_column    => 'LUONG, PHUCAP',
    statement_types => 'SELECT'
  );
END;
/
--BEGIN
--  DBMS_FGA.DROP_POLICY( 
--    object_schema => 'ADMIN_QLDH',
--    object_name   => 'NHANVIEN',
--    policy_name   => 'AUDIT_SELECT_LUONG_PHUCAP'
--  );
--END;
--/
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'ADMIN_QLDH',
    object_name     => 'NHANVIEN',
    policy_name     => 'AUDIT_UPDATE_NHANVIEN',
    audit_condition => 'SYS_CONTEXT(''USERENV'',''SESSION_USER'') NOT LIKE ''NVTCHC%''',
    statement_types => 'UPDATE'
  );
END;
/
--BEGIN
--  DBMS_FGA.DROP_POLICY( 
--    object_schema => 'ADMIN_QLDH',
--    object_name   => 'NHANVIEN',
--    policy_name   => 'AUDIT_UPDATE_NHANVIEN'
--  );
--END;
--/
CREATE OR REPLACE FUNCTION fga_check_thoi_gian (
  v_mamm IN VARCHAR2
)
RETURN NUMBER
AS
  v_ngaybd DATE;
BEGIN
  IF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'SV%' THEN
      SELECT ngaybd INTO v_ngaybd
      FROM momon
      WHERE mamm = v_mamm;
    
      IF SYSDATE > v_ngaybd + 14 THEN
        RETURN 1;
      ELSE
        RETURN 0;
      END IF;
  END IF;
  return 0;
END;
/
CREATE OR REPLACE FUNCTION fga_check_sinh_vien (
  v_masv IN VARCHAR2
)
RETURN NUMBER
AS
BEGIN
    -- Nếu user hiện tại là sinh viên
    IF SYS_CONTEXT('USERENV', 'SESSION_USER') LIKE 'SV%' AND v_masv <> SYS_CONTEXT('USERENV', 'SESSION_USER') THEN
        RETURN 1;  -- Không cho phép
    END IF;
    RETURN 0;
END;
/
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema   => 'ADMIN_QLDH',
    object_name     => 'DANGKY',
    policy_name     => 'AUDIT_CHECK_SV_DANGKY',
    audit_condition => 'fga_check_sinh_vien(masv)= 1',
    statement_types => 'INSERT, UPDATE, DELETE',
    audit_column_opts  => DBMS_FGA.ANY_COLUMNS
  );
END;    
/
--BEGIN
--  DBMS_FGA.DROP_POLICY( 
--    object_schema => 'ADMIN_QLDH',
--    object_name   => 'DANGKY',
--    policy_name   => 'AUDIT_CHECK_SV_DANGKY'
--  );
--END;
--/
BEGIN
    DBMS_FGA.ADD_POLICY(
    object_schema   => 'ADMIN_QLDH',
    object_name     => 'DANGKY',
    policy_name     => 'AUDIT_SV_DANGKY_OVER_TIME',
    audit_condition => 'fga_check_thoi_gian(MAMM)=1',
    statement_types => 'INSERT, UPDATE, DELETE',
    audit_column_opts  => DBMS_FGA.ANY_COLUMNS
    );
END;
/
--BEGIN
--  DBMS_FGA.DROP_POLICY( 
--    object_schema => 'ADMIN_QLDH',
--    object_name   => 'DANGKY',
--    policy_name   => 'AUDIT_SV_DANGKY_OVER_TIME'
--  );
--END;
--/

-- ket qua log nhanvien
SELECT EVENT_TIMESTAMP,
  DBUSERNAME,
  OBJECT_NAME,
  ACTION_NAME,
  SQL_TEXT,
  UNIFIED_AUDIT_POLICIES
FROM UNIFIED_AUDIT_TRAIL
WHERE OBJECT_NAME = 'NHANVIEN'
ORDER BY EVENT_TIMESTAMP DESC;
-- ket qua log dangky
SELECT EVENT_TIMESTAMP,
  DBUSERNAME,
  OBJECT_NAME,
  ACTION_NAME,
  SQL_TEXT,
  UNIFIED_AUDIT_POLICIES
FROM UNIFIED_AUDIT_TRAIL
WHERE OBJECT_NAME = 'DANGKY'
ORDER BY EVENT_TIMESTAMP DESC;

--standard audit cho nvpkt001
--connect nvpkt001/nvpkt001@localhost:1521/QLDH;
--update admin_qldh.DANGKY set diemck=10; 

CREATE AUDIT POLICY dangky_audit_policy ACTIONS UPDATE ON DANGKY;
AUDIT POLICY dangky_audit_policy BY nvpkt001;

SELECT AUDIT_TYPE, EVENT_TIMESTAMP, DBUSERNAME, OBJECT_NAME, ACTION_NAME, SQL_TEXT, UNIFIED_AUDIT_POLICIES  
FROM unified_audit_trail 
WHERE OBJECT_NAME = 'DANGKY'
ORDER BY event_timestamp DESC;




