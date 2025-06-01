--PDT thêm sửa MOMON
CREATE OR REPLACE TRIGGER trg_check_gv_mahp_cung_donvi
BEFORE INSERT OR UPDATE ON MOMON
FOR EACH ROW
DECLARE
    v_dv_gv   NHANVIEN.MADV%TYPE;
    v_dv_hp   HOCPHAN.MADV%TYPE;
BEGIN
    -- Lấy mã đơn vị của giảng viên
    SELECT MADV INTO v_dv_gv
    FROM NHANVIEN
    WHERE MANV = :NEW.MAGV;

    -- Lấy mã đơn vị của học phần
    SELECT MADV INTO v_dv_hp
    FROM HOCPHAN
    WHERE MAHP = :NEW.MAHP;

    -- So sánh đơn vị
    IF v_dv_gv != v_dv_hp THEN
        RAISE_APPLICATION_ERROR(-20004,
            'Giảng viên và học phần phải thuộc cùng một đơn vị.');
    END IF;
END;
/
