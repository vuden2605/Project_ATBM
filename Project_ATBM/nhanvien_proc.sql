CREATE OR REPLACE PROCEDURE update_phone_nhanvien (
    p_manld    IN SINHVIEN.MASV%TYPE,
    p_dt  IN SINHVIEN.DCHI%TYPE
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
GRANT EXECUTE ON update_phone_nhanvien TO role_gv;
GRANT EXECUTE ON update_phone_nhanvien TO role_trgdv;
GRANT EXECUTE ON update_phone_nhanvien TO role_nvctsv;
