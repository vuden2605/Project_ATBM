CREATE OR REPLACE PROCEDURE update_address (
    p_masv     IN SINHVIEN.MASV%TYPE,
    p_dchimoi  IN SINHVIEN.DCHI%TYPE
)
IS
BEGIN
        UPDATE SINHVIEN
        SET DCHI = p_dchimoi
        WHERE MASV = p_masv;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
END;
/

CREATE OR REPLACE PROCEDURE update_phone (
    p_masv     IN SINHVIEN.MASV%TYPE,
    p_sdtmoi  IN SINHVIEN.DCHI%TYPE
)
IS
BEGIN
        UPDATE SINHVIEN
        SET DT = p_sdtmoi
        WHERE MASV = p_masv;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
END;
/
CREATE OR REPLACE PROCEDURE sv_dk_monhoc (
    p_masv NVARCHAR2,
    p_mamm NVARCHAR2
)
IS
BEGIN
    INSERT INTO admin_qldh.DANGKY (masv, mamm) VALUES (p_masv, p_mamm);
END;
/
CREATE OR REPLACE PROCEDURE sv_delete_dk (
    p_masv NVARCHAR2,
    p_mamm NVARCHAR2
)
IS
BEGIN
    DELETE FROM admin_qldh.DANGKY WHERE masv = p_masv AND mamm= p_mamm;
END;
/
GRANT EXECUTE ON admin_qldh.sv_dk_monhoc TO role_sv;
GRANT EXECUTE ON admin_qldh.sv_delete_dk TO role_sv;
GRANT EXECUTE ON update_address TO role_sv;
GRANT EXECUTE ON update_phone TO role_sv;