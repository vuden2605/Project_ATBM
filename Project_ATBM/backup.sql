alter session set container = CDB$root;
CREATE OR REPLACE DIRECTORY DATA_PUMP_DIR AS 'D:\oracle\backup';
alter session set container = QLDH;
GRANT READ, WRITE ON DIRECTORY DATA_PUMP_DIR TO admin_qldh;
SELECT directory_name, directory_path FROM dba_directories;
GRANT DATAPUMP_EXP_FULL_DATABASE TO admin_qldh;
GRANT DATAPUMP_IMP_FULL_DATABASE TO admin_qldh;
