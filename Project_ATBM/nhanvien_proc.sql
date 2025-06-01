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
    p_nam    VARCHAR2,
    p_ngaybd DATE
)
IS
    v_hk NUMBER;
    v_thang NUMBER := EXTRACT(MONTH FROM p_ngaybd);
BEGIN
    -- Xác định học kỳ dựa trên tháng của ngày bắt đầu
    IF v_thang >= 9 THEN
        v_hk := 1;
    ELSIF v_thang >= 5 THEN
        v_hk := 3;
    ELSE
        v_hk := 2;
    END IF;

    -- Chèn vào bảng MOMON
    INSERT INTO admin_qldh.MOMON (mamm, mahp, magv, hk, nam, ngaybd)
    VALUES (p_mamm, p_mahp, p_magv, v_hk, p_nam, p_ngaybd);

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
    p_diemck  IN NUMBER
)
IS
    v_diemtk NUMBER;
BEGIN
    v_diemtk := 0.2 * p_diemqt + 0.3 * p_diemth + 0.5 * p_diemck;

    UPDATE DANGKY
    SET 
        DIEMTH = p_diemth,
        DIEMQT = p_diemqt,
        DIEMCK = p_diemck,
        DIEMTK = v_diemtk
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
CREATE OR REPLACE PROCEDURE nvtchc_insert_nhanvien (
    p_manld    IN VARCHAR2,
    p_hoten    IN VARCHAR2,
    p_phai     IN VARCHAR2,
    p_ngaysinh IN DATE,
    p_luong    IN NUMBER,
    p_phucap   IN NUMBER,
    p_sdt      IN VARCHAR2,
    p_vaitro   IN VARCHAR2,
    p_dv       IN VARCHAR2
)
IS
    v_count NUMBER;
BEGIN
    -- Kiểm tra trùng mã nhân viên
    SELECT COUNT(*) INTO v_count
    FROM NHANVIEN
    WHERE MANLD = p_manld;

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Mã nhân viên đã tồn tại.');
    END IF;

    -- Insert dữ liệu mới
    INSERT INTO NHANVIEN (MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, VAITRO, MaDV)
    VALUES (p_manld, p_hoten, p_phai, p_ngaysinh, p_luong, p_phucap, p_sdt, p_vaitro, p_dv);
    
    COMMIT;
END;
/
GRANT EXECUTE ON nvtchc_insert_nhanvien TO role_nvtchc;
CREATE OR REPLACE PROCEDURE nvtchc_delete_nhanvien (
    p_manld    IN VARCHAR2
)
IS
BEGIN
    DELETE FROM admin_qldh.NHANVIEN WHERE manld = p_manld;
    COMMIT;
END;
/
GRANT EXECUTE ON nvtchc_delete_nhanvien TO role_nvtchc;
CREATE OR REPLACE PROCEDURE nvpdt_insert_dangky (
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
        INSERT INTO admin_qldh.DANGKY (masv,mamm) VALUES (p_masv, p_mamm); 
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'Không thể thêm, đã quá hạn');
    END IF;
END;
/
GRANT EXECUTE ON nvpdt_insert_dangky TO role_nvpdt;
CREATE OR REPLACE PROCEDURE nvpdt_insert_dangky (
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
        INSERT INTO admin_qldh.DANGKY (masv,mamm) VALUES (p_masv, p_mamm); 
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'Không thể thêm, đã quá hạn');
    END IF;
END;
/
GRANT EXECUTE ON nvpdt_insert_dangky TO role_nvpdt;
CREATE OR REPLACE PROCEDURE nvpdt_insert_dangky (
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
        INSERT INTO admin_qldh.DANGKY (masv,mamm) VALUES (p_masv, p_mamm); 
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'Không thể thêm, đã quá hạn');
    END IF;
END;
/
GRANT EXECUTE ON nvpdt_insert_dangky TO role_nvpdt;
CREATE OR REPLACE PROCEDURE nvpdt_insert_dangky (
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
        INSERT INTO admin_qldh.DANGKY (masv,mamm) VALUES (p_masv, p_mamm); 
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'Không thể thêm, đã quá hạn');
    END IF;
END;
/
GRANT EXECUTE ON nvpdt_insert_dangky TO role_nvpdt;


-- của ctsv
CREATE OR REPLACE PROCEDURE CAPNHAT_SINHVIEN (
    p_masv     IN VARCHAR2,
    p_hoten    IN VARCHAR2,
    p_phai     IN VARCHAR2,
    p_ngsinh   IN DATE,
    p_dchi     IN VARCHAR2,
    p_dt       IN VARCHAR2,
    p_khoa     IN VARCHAR2
)
IS
BEGIN
    UPDATE SINHVIEN
    SET
        HOTEN  = p_hoten,
        PHAI   = p_phai,
        NGSINH = p_ngsinh,
        DCHI   = p_dchi,
        DT     = p_dt,
        KHOA   = p_khoa
    WHERE MASV = p_masv;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Không tìm thấy sinh viên với MASV đã cho.');
    END IF;

    COMMIT;
END;
/
GRANT EXECUTE ON CAPNHAT_SINHVIEN TO role_nvctsv;
--tchc sửa 
CREATE OR REPLACE PROCEDURE SUA_NHANVIEN (
    p_manv    IN VARCHAR2,
    p_hoten   IN VARCHAR2,
    p_phai    IN VARCHAR2,
    p_ngsinh  IN DATE,
    p_luong   IN NUMBER,
    p_phucap  IN NUMBER,
    p_dt      IN VARCHAR2,
    p_vaitro  IN VARCHAR2,
    p_madv    IN VARCHAR2
)
IS
BEGIN
    UPDATE NHANVIEN
    SET
        HOTEN   = p_hoten,
        PHAI    = p_phai,
        NGSINH  = p_ngsinh,
        LUONG   = p_luong,
        PHUCAP  = p_phucap,
        DT      = p_dt,
        VAITRO  = p_vaitro,
        MADV    = p_madv
    WHERE MANLD = p_manv;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Không tìm thấy nhân viên có mã ' || p_manv);
    END IF;

    COMMIT;
END;
/
GRANT EXECUTE ON SUA_NHANVIEN TO role_nvtchc;
-- sửa magv trong momon cuẩ 
CREATE OR REPLACE PROCEDURE SUA_MAGV_MOMON (
    p_mamm IN VARCHAR2,
    p_magv IN VARCHAR2
)
IS
BEGIN
    UPDATE MOMON
    SET MAGV = p_magv
    WHERE MAMM = p_mamm;

    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Không tìm thấy môn môn có mã: ' || p_mamm);
    END IF;

    COMMIT;
END;
/
GRANT EXECUTE ON SUA_MAGV_MOMON TO role_nvpdt;
