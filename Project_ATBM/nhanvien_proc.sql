CREATE OR REPLACE PROCEDURE update_phone_nhanvien (
    p_manld    IN SINHVIEN.MASV%TYPE,
    p_dt  IN SINHVIEN.DT%TYPE
)
IS
BEGIN
        UPDATE v_nvcb
        SET DT = p_dt
        WHERE MANLD = p_manld;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
END;
/
GRANT EXECUTE ON update_phone_nhanvien TO role_gv;
GRANT EXECUTE ON update_phone_nhanvien TO role_nvcb;
GRANT EXECUTE ON update_phone_nhanvien TO role_nvpdt;
GRANT EXECUTE ON update_phone_nhanvien TO role_nvpkt;
GRANT EXECUTE ON update_phone_nhanvien TO role_nvtchc;
GRANT EXECUTE ON update_phone_nhanvien TO role_trgdv;
GRANT EXECUTE ON update_phone_nhanvien TO role_nvctsv;
CREATE OR REPLACE PROCEDURE nvpdt_update_tinhtrangsv (
    p_masv    IN SINHVIEN.MASV%TYPE,
    p_tinhtrang  IN SINHVIEN.TINHTRANG%TYPE
)
IS
BEGIN
        UPDATE admin_qldh.SINHVIEN
        SET TINHTRANG = p_tinhtrang
        WHERE MASV = p_masv;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
END;
/
GRANT EXECUTE ON nvpdt_update_tinhtrangsv TO role_nvpdt;
CREATE OR REPLACE PROCEDURE nvpdt_insert_momon (
    p_mamm   VARCHAR2,
    p_mahp   VARCHAR2,
    p_magv   VARCHAR2,
    p_hk     NUMBER,
    p_nam    VARCHAR2,
    p_ngaybd DATE
)
IS
BEGIN
    INSERT INTO admin_qldh.MOMON (mamm, mahp, magv, hk, nam, ngaybd)
    VALUES (p_mamm, p_mahp, p_magv, p_hk, p_nam, p_ngaybd);

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Lỗi: ' || SQLERRM);
END;
/
GRANT EXECUTE ON nvpdt_insert_momon TO role_nvpdt;
CREATE OR REPLACE PROCEDURE nvpdt_delete_momon (
    p_mamm   VARCHAR2,
    p_ngaybd DATE,
    p_nam VARCHAR2
)
IS
BEGIN

    IF SYSDATE < p_ngaybd +14  AND (TO_NUMBER(SUBSTR(p_nam,1,4)) = EXTRACT(YEAR FROM SYSDATE)
                                    OR TO_NUMBER(SUBSTR(p_nam,6,9)) = EXTRACT(YEAR FROM SYSDATE)) THEN
        DELETE FROM admin_qldh.MOMON WHERE mamm = p_mamm;
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'Không thể xóa, đã quá hạn');
    END IF;
END;
/
GRANT EXECUTE ON nvpdt_delete_momon TO role_nvpdt;
CREATE OR REPLACE PROCEDURE SUA_DANGKY (
    p_masv    IN VARCHAR2,
    p_mamm    IN VARCHAR2,
    p_diemth  IN NUMBER,
    p_diemqt  IN NUMBER,
    p_diemck  IN NUMBER,
    p_diemtk  IN NUMBER
)
IS
BEGIN
    UPDATE DANGKY
    SET 
        DIEMTH = p_diemth,
        DIEMQT = p_diemqt,
        DIEMCK = p_diemck,
        DIEMTK = p_diemtk
    WHERE MASV = p_masv AND MAMM = p_mamm;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Không tìm thấy sinh viên hoặc môn học.');
    END IF;
    
    COMMIT;
END;
/
GRANT EXECUTE ON SUA_DANGKY TO role_nvpkt;
CREATE OR REPLACE PROCEDURE nvpdt_delete_dangky (
    p_masv VARCHAR2,
    p_mamm   VARCHAR2
)
IS
    v_ngaybd DATE;
    v_nam VARCHAR2(9);
BEGIN
    SELECT ngaybd , nam 
    INTO v_ngaybd, v_nam
    FROM admin_qldh.MOMON
    WHERE mamm = p_mamm;
    IF SYSDATE < v_ngaybd +14  AND (TO_NUMBER(SUBSTR(v_nam,1,4)) = EXTRACT(YEAR FROM SYSDATE)
                                    OR TO_NUMBER(SUBSTR(v_nam,6,9)) = EXTRACT(YEAR FROM SYSDATE)) THEN
        DELETE FROM admin_qldh.DANGKY WHERE mamm = p_mamm AND masv = p_masv;
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'Không thể xóa, đã quá hạn');
    END IF;
END;
/
GRANT EXECUTE ON nvpdt_delete_dangky to role_nvpdt;



