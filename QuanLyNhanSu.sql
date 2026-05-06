CREATE DATABASE QUANLYNHANSU
USE QUANLYNHANSU

--TẠO BẢNG PHÒNG BAN--
CREATE TABLE PHONGBAN (
    MaPB CHAR(6) PRIMARY KEY,
    TenPB NVARCHAR(70) NOT NULL,
    MoTa NVARCHAR(100)
);
GO
--TẠO BẢNG CHỨC VỤ--
CREATE TABLE CHUCVU (
    MaCV CHAR(4) PRIMARY KEY,
    TenCV NVARCHAR(30) NOT NULL,
    MoTa NVARCHAR(100),

	CONSTRAINT CK_TenCV CHECK (TenCV IN (N'Giám đốc', N'Phó giám đốc', N'Trưởng phòng', N'Phó phòng', N'Quản lý', N'Nhân viên', N'Thực tập sinh'))
);
GO
--TẠO BẢNG LOẠI NHÂN VIÊN--
CREATE TABLE LOAINHANVIEN (
    MaLoai CHAR(4) PRIMARY KEY,
    TenLoaiNV NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(100),

	CONSTRAINT CK_TenLoaiNV CHECK (TenLoaiNV IN (N'Nhân viên chính thức', N'Nhân viên thử việc', N'Nhân viên tạm thời', N'Thực tập'))
);
GO
--TẠO BẢNG NHÂN VIÊN--
CREATE TABLE NHANVIEN (
    MaNV CHAR(5) PRIMARY KEY,
    HoNV NVARCHAR(50) NOT NULL,
    TenNV NVARCHAR(20) NOT NULL,
	CCCD CHAR(14) NOT NULL
	CONSTRAINT UQ_CCCD UNIQUE (CCCD),
    GioiTinh NVARCHAR(5) NOT NULL
	CONSTRAINT CK_GioiTinh_NV CHECK (GioiTinh in (N'Nam', N'Nữ', N'Khác')),
    NgaySinh DATE NOT NULL
	CONSTRAINT CK_NgaySinh CHECK (NgaySinh < GETDATE()),
	CONSTRAINT CK_Tuoi_LonHon18 CHECK (DATEDIFF(YEAR, NgaySinh, GETDATE()) >= 18),
    Sdt_NV CHAR(10) NOT NULL,
    Email_NV NVARCHAR(70) NOT NULL,
	DiaChi NVARCHAR(70) NOT NULL,
    MaCV CHAR(4) NOT NULL,
    MaPB CHAR(6) NOT NULL,
    MaLoai CHAR(4) NOT NULL,
    NgayVaoLam DATE NOT NULL,
    HeSoLuong DECIMAL(3,2) NOT NULL,
    
    FOREIGN KEY (MaCV) REFERENCES CHUCVU(MaCV),
    FOREIGN KEY (MaPB) REFERENCES PHONGBAN(MaPB),
    FOREIGN KEY (MaLoai) REFERENCES LOAINHANVIEN(MaLoai)
);
GO
ALTER TABLE NHANVIEN
ADD STK CHAR(20)
GO
ALTER TABLE NHANVIEN
ADD TenNH CHAR(70)
GO
CREATE TABLE TAIKHOAN (
	Tendangnhap CHAR(30) NOT NULL,
	Matkhau CHAR(20) PRIMARY KEY,
	MaNV CHAR(5) NOT NULL,
	FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO
ALTER TABLE TAIKHOAN
ADD MaTK CHAR(5);

ALTER TABLE TAIKHOAN
DROP CONSTRAINT PK__TAIKHOAN__FAEC8907405BC546; 

WITH X AS (
    SELECT 
        Tendangnhap,
        MaTK,
        ROW_NUMBER() OVER (ORDER BY Tendangnhap) AS rn
    FROM TAIKHOAN
)
UPDATE X
SET MaTK = 'TK' + RIGHT('000' + CAST(rn AS VARCHAR(3)), 3);

ALTER TABLE TAIKHOAN
ALTER COLUMN MaTK CHAR(10) NOT NULL;

ALTER TABLE TAIKHOAN
ADD CONSTRAINT PK_TAIKHOAN PRIMARY KEY (MaTK);

--TẠO BẢNG BẢNG CHẤM CÔNG--
CREATE TABLE BANGCHAMCONG (
    MaBCC CHAR(12) PRIMARY KEY,
    NgayChamCong DATE NOT NULL
	CONSTRAINT CK_NgayChamCong CHECK (NgayChamCong <= GETDATE()),
    GioVaoLam TIME NOT NULL,
    GioTanLam TIME NOT NULL,
    MaNV CHAR(5) NOT NULL,
    
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO
--TẠO BẢNG BẢNG LƯƠNG
CREATE TABLE BANGLUONG (
    MaBangLuong CHAR(6) PRIMARY KEY,
    TenBangLuong NVARCHAR(30) NOT NULL,
    LuongCoBan FLOAT NOT NULL
	CONSTRAINT CK_LuongCoBan CHECK (LuongCoBan > 0),
	CS_Thuong FLOAT NOT NULL,
    PhuCap FLOAT NOT NULL
	CONSTRAINT CK_PhuCap_KhongAm CHECK (PhuCap >= 0),
    KhauTru FLOAT NOT NULL,
    ThucLanh FLOAT NOT NULL,
    MaNV CHAR(5) NOT NULL,
    
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO
ALTER TABLE BANGLUONG
DROP COLUMN TenBangLuong
GO
ALTER TABLE BANGLUONG
ADD NgayNhanLuong DATE
GO
UPDATE NHANVIEN
SET TenNH = N'Vietcombank';
GO
--TẠO BẢNG HỢP ĐỒNG LAO ĐỘNG--
CREATE TABLE HOPDONGLAODONG (
    MaHD CHAR(6) PRIMARY KEY,
    TenHD NVARCHAR(70) NOT NULL,
    LoaiHD NVARCHAR(50) NOT NULL
	CONSTRAINT CK_LoaiHD CHECK (LoaiHD in (N'Thử việc', N'Chính thức', N'Thời vụ')),
    NgayKyKet DATE NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    MaNV CHAR(5) NOT NULL,
    
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
	CONSTRAINT CK_NgayBatDau_NgayKetThuc_HD CHECK (NgayBatDau < NgayKetThuc),
	CONSTRAINT CK_NgayKyKet_NgayBatDau_HD CHECK (NgayKyKet <= NgayBatDau)
);
GO
--TẠO BẢNG ĐỢT TUYỂN DỤNG--
CREATE TABLE DOTTUYENDUNG (
    MaDTD CHAR(10) PRIMARY KEY,
    MaNV CHAR(5) NOT NULL,
    ViTriCanTuyen NVARCHAR(70) NOT NULL,
    PhongBan NVARCHAR(50) NOT NULL,
    SoLuongTuyen TINYINT NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
	CONSTRAINT CK_NgayBatDau_NgayKetThuc_DTD CHECK (NgayBatDau < NgayKetThuc)
);
GO
--TẠO BẢNG ĐỢT PHỎNG VẤN--
CREATE TABLE DOTPHONGVAN (
    MaDPV CHAR(10) PRIMARY KEY,
    TenDPV NVARCHAR(70) NOT NULL,
    MaDTD CHAR(10) NOT NULL,
    MaNV CHAR(5) NOT NULL,
    SoLuongUV TINYINT NOT NULL,
    NgayPV DATE NOT NULL,
    
    FOREIGN KEY (MaDTD) REFERENCES DOTTUYENDUNG(MaDTD),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO
--TẠO BẢNG ỨNG VIÊN--
CREATE TABLE UNGVIEN (
    MaUV CHAR(7) PRIMARY KEY,
    HoUV NVARCHAR(50) NOT NULL,
    TenUV NVARCHAR(20) NOT NULL,
    GioiTinh_UV NVARCHAR(5) NOT NULL
	CONSTRAINT CK_Gioitinh_UV CHECK (Gioitinh_UV in (N'Nam', N'Nữ', N'Khác')),
    NgaySinh_UV DATE NOT NULL,
    Sdt_UV CHAR(10) NOT NULL,
    Email_UV NVARCHAR(70) NOT NULL
);
GO
--TẠO BẢNG ỨNG VIÊN THAM GIA PHỎNG VẤN--
CREATE TABLE UV_THAMGIA (
    MaUV CHAR(7),
    MaDPV CHAR(10),
    ViTriUngTuyen NVARCHAR(100) NOT NULL,
    KetQuaPV NVARCHAR(100) NOT NULL,
    PRIMARY KEY (MaUV, MaDPV),
    
    FOREIGN KEY (MaUV) REFERENCES UNGVIEN(MaUV),
    FOREIGN KEY (MaDPV) REFERENCES DOTPHONGVAN(MaDPV)
);
GO
--TẠO BẢNG LOẠI CHỨNG CHỈ--
CREATE TABLE LOAICHUNGCHI (
    MaCC CHAR(6) PRIMARY KEY,
    TenCC NVARCHAR(50) NOT NULL
);
GO
--TẠO BẢNG CHỨNG CHỈ CỦA ỨNG VIÊN--
CREATE TABLE CHUNGCHI_UV (
    MaUV CHAR(7),
    MaCC CHAR(6),
    KetQua NVARCHAR(50) NOT NULL,
    DonViCap NVARCHAR(100) NOT NULL,
    NgayCapCC DATE NOT NULL,
    ThoiHan INT NOT NULL,
    PRIMARY KEY (MaUV, MaCC),
    
    FOREIGN KEY (MaUV) REFERENCES UNGVIEN(MaUV),
    FOREIGN KEY (MaCC) REFERENCES LOAICHUNGCHI(MaCC)
);
GO
--TẠO BẢNG CHỨNG CHỈ CỦA NHÂN VIÊN--
CREATE TABLE CHUNGCHI_NV (
    MaNV CHAR(5),
    MaCC CHAR(6),
    KetQua NVARCHAR(50) NOT NULL,
    DonViCap NVARCHAR(100) NOT NULL,
    NgayCapCC DATE NOT NULL,
    ThoiHan INT NOT NULL,
    PRIMARY KEY (MaNV, MaCC),
    
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    FOREIGN KEY (MaCC) REFERENCES LOAICHUNGCHI(MaCC)
);
GO
--TẠO BẢNG LOẠI BẰNG CẤP--
CREATE TABLE LOAIBANGCAP (
    MaBC CHAR(8) PRIMARY KEY,
    TenBC NVARCHAR(50) NOT NULL
);
GO
--TẠO BẢNG BẰNG CẤP CỦA NHÂN VIÊN--
CREATE TABLE BANGCAP_NV (
    MaNV CHAR(5),
    MaBC CHAR(8),
    NgayCap DATE NOT NULL,
    TruongCap NVARCHAR(100) NOT NULL,
    NamTN DATE NOT NULL,
    PRIMARY KEY (MaNV, MaBC),
    
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    FOREIGN KEY (MaBC) REFERENCES LOAIBANGCAP(MaBC)
);
GO
--TẠO BẢNG BẰNG CẤP CỦA ỨNG VIÊN--
CREATE TABLE BANGCAP_UV (
    MaUV CHAR(7),
    MaBC CHAR(8),
    NgayCap DATE NOT NULL,
    TruongCap NVARCHAR(100) NOT NULL,
    NamTN DATE NOT NULL,
    PRIMARY KEY (MaUV, MaBC),
    
    FOREIGN KEY (MaUV) REFERENCES UNGVIEN(MaUV),
    FOREIGN KEY (MaBC) REFERENCES LOAIBANGCAP(MaBC)
);
GO
--TẠO TRIGGER CHO RÀNG BUỘC Ngayphongvan trong bảng DOTPHONGVAN phải nằm trong khoảng giữa Ngaybatdau và Ngayketthuc trong bảng DOTTUYENDUNG--
CREATE TRIGGER Trg_CHECK_NGAYPV
ON DOTPHONGVAN
FOR INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN DOTTUYENDUNG d ON i.MaDTD = d.MaDTD
        WHERE i.NgayPV < d.NgayBatDau OR i.NgayPV > d.NgayKetThuc
    )
    BEGIN
        PRINT (N'Lỗi: Ngày phỏng vấn phải nằm trong khoảng Ngày bắt đầu và Ngày kết thúc của đợt tuyển dụng.');
        ROLLBACK;
    END
END;
GO
-- =========================================================
-- BO SUNG CHUC NANG: NGHI PHEP, KHEN THUONG, KY LUAT, TIEU CHI
-- VA CAC THU TUC THONG KE / LOC PHUC VU UNG DUNG
-- =========================================================

-- NGHI PHEP
IF OBJECT_ID('NGHIPHEP','U') IS NULL
BEGIN
CREATE TABLE NGHIPHEP (
    MaNP CHAR(8) PRIMARY KEY,
    MaNV CHAR(5) NOT NULL,
    TuNgay DATE NOT NULL,
    DenNgay DATE NOT NULL,
    LyDo NVARCHAR(200) NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Chờ duyệt' -- Chờ duyệt | Được duyệt | Từ chối
        CONSTRAINT CK_NP_TrangThai CHECK (TrangThai IN (N'Chờ duyệt', N'Được duyệt', N'Từ chối')),
    CONSTRAINT FK_NP_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT CK_NP_KhoangNgay CHECK (TuNgay <= DenNgay)
);
END
GO

-- TIEU CHI KHEN THUONG / KY LUAT
IF OBJECT_ID('TIEUCHI','U') IS NULL
BEGIN
CREATE TABLE TIEUCHI (
    MaTC CHAR(6) PRIMARY KEY,
    TenTC NVARCHAR(100) NOT NULL,
    Loai NVARCHAR(15) NOT NULL -- KhenThuong | KyLuat
        CONSTRAINT CK_TC_Loai CHECK (Loai IN (N'KhenThuong', N'KyLuat')),
    MoTa NVARCHAR(200) NULL
);
END
GO

-- KHEN THUONG
IF OBJECT_ID('KHENTHUONG','U') IS NULL
BEGIN
CREATE TABLE KHENTHUONG (
    MaKT CHAR(8) PRIMARY KEY,
    MaNV CHAR(5) NOT NULL,
    MaTC CHAR(6) NOT NULL,
    NgayKT DATE NOT NULL,
    GhiChu NVARCHAR(200) NULL,
    CONSTRAINT FK_KT_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT FK_KT_TC FOREIGN KEY (MaTC) REFERENCES TIEUCHI(MaTC)
);
END
GO
alter table KHENTHUONG
alter column SoTien decimal NULL;
sp_columns KHENTHUONG;
-- KY LUAT
IF OBJECT_ID('KYLUAT','U') IS NULL
BEGIN
CREATE TABLE KYLUAT (
    MaKL CHAR(8) PRIMARY KEY,
    MaNV CHAR(5) NOT NULL,
    MaTC CHAR(6) NOT NULL,
    NgayKL DATE NOT NULL,
    GhiChu NVARCHAR(200) NULL,
    CONSTRAINT FK_KL_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT FK_KL_TC FOREIGN KEY (MaTC) REFERENCES TIEUCHI(MaTC)
);
END
GO
alter table KYLUAT
alter column SoTien decimal NULL;

-- =========================================================
-- THU TUC THONG KE / LOC
-- =========================================================

-- Tong so nhan vien va so truong phong (CV03)
IF OBJECT_ID('sp_ThongKeNhanVien','P') IS NOT NULL DROP PROC sp_ThongKeNhanVien;
GO
CREATE PROC sp_ThongKeNhanVien
AS
BEGIN
    SELECT 
        TongNhanVien = COUNT(*),
        SoTruongPhong = SUM(CASE WHEN MaCV = 'CV03' THEN 1 ELSE 0 END)
    FROM NHANVIEN;
END
GO

-- Thong ke so luong nhan vien theo phong ban
IF OBJECT_ID('sp_ThongKeNhanVienTheoPhongBan','P') IS NOT NULL DROP PROC sp_ThongKeNhanVienTheoPhongBan;
GO
CREATE PROC sp_ThongKeNhanVienTheoPhongBan
AS
BEGIN
    SELECT pb.MaPB, pb.TenPB, SoLuong = COUNT(nv.MaNV)
    FROM PHONGBAN pb
    LEFT JOIN NHANVIEN nv ON nv.MaPB = pb.MaPB
    GROUP BY pb.MaPB, pb.TenPB
    ORDER BY pb.TenPB;
END
GO

-- Loc hop dong lao dong: con han / het han (tai ngay hien tai)
IF OBJECT_ID('sp_LocHopDong','P') IS NOT NULL DROP PROC sp_LocHopDong;
GO
CREATE PROC sp_LocHopDong
    @TrangThai NVARCHAR(10) -- 'ConHan' | 'HetHan'
AS
BEGIN
    IF (@TrangThai = N'ConHan')
        SELECT * FROM HOPDONGLAODONG WHERE GETDATE() BETWEEN NgayBatDau AND NgayKetThuc;
    ELSE IF (@TrangThai = N'HetHan')
        SELECT * FROM HOPDONGLAODONG WHERE GETDATE() > NgayKetThuc;
    ELSE
        SELECT * FROM HOPDONGLAODONG;
END
GO
-- [SP sp_LocHopDong removed; implement logic in application]

-- Loc ung vien theo so nam kinh nghiem va chuyen mon (dua tren BANGCAP_UV + CHUNGCHI_UV don gian)
IF OBJECT_ID('sp_LocUngVien','P') IS NOT NULL DROP PROC sp_LocUngVien;
GO
CREATE PROC sp_LocUngVien
    @NamKinhNghiemMin INT = 0,         -- so nam (dua theo NamTN ~ nam tot nghiep)
    @ChuyenMon NVARCHAR(50) = NULL     -- tuong ung TenBC (VD: N'Đại học', N'Kỹ sư') hoac TenCC
AS
BEGIN
    ;WITH KinhNghiem AS (
        SELECT MaUV,
               NamKN = ISNULL(DATEDIFF(YEAR, MIN(NamTN), GETDATE()), 0)
        FROM BANGCAP_UV
        GROUP BY MaUV
    ),
    ChuyenMon AS (
        SELECT buv.MaUV
        FROM BANGCAP_UV buv
        JOIN LOAIBANGCAP lbc ON lbc.MaBC = buv.MaBC
        WHERE @ChuyenMon IS NULL OR lbc.TenBC LIKE N'%' + @ChuyenMon + N'%'
        UNION
        SELECT cuv.MaUV
        FROM CHUNGCHI_UV cuv
        JOIN LOAICHUNGCHI lcc ON lcc.MaCC = cuv.MaCC
        WHERE @ChuyenMon IS NULL OR lcc.TenCC LIKE N'%' + @ChuyenMon + N'%'
    )
    SELECT uv.*,
           ISNULL(kn.NamKN, 0) AS NamKinhNghiem
    FROM UNGVIEN uv
    LEFT JOIN KinhNghiem kn ON kn.MaUV = uv.MaUV
    LEFT JOIN ChuyenMon cm ON cm.MaUV = uv.MaUV
    WHERE ISNULL(kn.NamKN, 0) >= @NamKinhNghiemMin
      AND (@ChuyenMon IS NULL OR cm.MaUV IS NOT NULL);
END
GO
-- [SP sp_LocUngVien removed; implement logic in application]

-- Loc nghi phep theo trang thai
IF OBJECT_ID('sp_LocNghiPhep','P') IS NOT NULL DROP PROC sp_LocNghiPhep;
GO
CREATE PROC sp_LocNghiPhep
    @TrangThai NVARCHAR(20) = NULL -- Chờ duyệt | Được duyệt | Từ chối | NULL = tất cả
AS
BEGIN
    SELECT np.*, nv.HoNV + N' ' + nv.TenNV AS HoTen
    FROM NGHIPHEP np
    JOIN NHANVIEN nv ON nv.MaNV = np.MaNV
    WHERE @TrangThai IS NULL OR np.TrangThai = @TrangThai
    ORDER BY np.TuNgay DESC;
END
GO
-- [SP sp_LocNghiPhep removed; implement logic in application]

-- Mau seed nhe (co the bo qua neu da co du lieu)
IF NOT EXISTS (SELECT 1 FROM TIEUCHI)
BEGIN
    INSERT INTO TIEUCHI(MaTC, TenTC, Loai, MoTa) VALUES
    ('TC0001', N'Thanh tich xuat sac', N'KhenThuong', N'Thanh tich thang'),
    ('TC0002', N'Vi pham noi quy',    N'KyLuat',     N'Di tre/bo viec');
END
GO
--TẠO TRIGGER CHO RÀNG BUỘC Ngaykyket phải bé hơn hoặc bằng Ngaybatdau trong bảng HOPDONGLAODONG--
CREATE TRIGGER trg_CHECK_NGAYVAOLAM
ON NHANVIEN
FOR INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN HOPDONGLAODONG h ON i.MaNV = h.MaNV
        WHERE i.NgayVaoLam < h.NgayBatDau
    )
    BEGIN
        PRINT (N'Ngày vào làm phải lớn hơn hoặc bằng ngày bắt đầu hợp đồng.');
        ROLLBACK;
    END
END;
GO
--INSERT DATA--
INSERT INTO PHONGBAN (MaPB, TenPB, MoTa)
VALUES 
('PBR&D', N'Phòng R&D', N'Nghiên cứu và phát triển sản phẩm mới'),
('PBKTTC', N'Phòng Kế toán - Tài chính', N'Quản lý tài chính và kế toán của công ty'),
('PBLOGI', N'Phòng Logistic', N'Quản lý vận chuyển và kho bãi'),
('PBHCNS', N'Phòng Hành chính - Nhân sự', N'Tuyển dụng, đào tạo và quản lý nhân sự'),
('PBQLCL', N'Phòng Quản lý chất lượng', N'Giám sát và đảm bảo chất lượng sản phẩm'),
('PBKTSX', N'Phòng Kỹ thuật - Sản xuất', N'Vận hành và bảo trì dây chuyền sản xuất'),
('PBMAR', N'Phòng Marketing - Thương hiệu', N'Phát triển thương hiệu và chiến lược tiếp thị');
GO
INSERT INTO CHUCVU (MaCV, TenCV, MoTa)
VALUES 
('CV01', N'Giám đốc', N'Quản lý toàn bộ hoạt động của công ty'),
('CV02', N'Phó giám đốc', N'Hỗ trợ giám đốc trong công tác điều hành'),
('CV03', N'Trưởng phòng', N'Chịu trách nhiệm quản lý phòng ban'),
('CV04', N'Phó phòng', N'Hỗ trợ trưởng phòng trong công tác quản lý'),
('CV05', N'Quản lý', N'Giám sát hoạt động và nhân sự'),
('CV06', N'Nhân viên', N'Thực hiện các công việc chuyên môn được phân công'),
('CV07', N'Thực tập sinh', N'Học hỏi kinh nghiệm và hỗ trợ công việc');
GO
INSERT INTO LOAINHANVIEN (MaLoai, TenLoaiNV, MoTa)
VALUES 
('LNV1', N'Nhân viên chính thức', N'Hợp đồng dài hạn, đầy đủ quyền lợi'),
('LNV2', N'Nhân viên thử việc', N'Đang trong giai đoạn đánh giá năng lực'),
('LNV3', N'Nhân viên tạm thời', N'Nhân viên làm việc theo thời vụ'),
('LNV4', N'Thực tập', N'Sinh viên đang thực tập tại công ty');
GO
INSERT INTO NHANVIEN (MaNV, HoNV, TenNV, CCCD, GioiTinh, NgaySinh, Sdt_NV, Email_NV, DiaChi, MaCV, MaPB, MaLoai, NgayVaoLam, HeSoLuong)
VALUES
('NV001', N'Nguyễn Văn', N'Hùng', '01234567891234', N'Nam', '1980-05-10', '0912345678', 'hung.nguyen@example.com', N'Hà Nội', 'CV01', 'PBHCNS', 'LNV1', '2010-03-01', 7.50),
('NV002', N'Trần Thị', N'Lan', '01234567891235', N'Nữ', '1985-09-15', '0987654321', 'lan.tran@example.com', N'Hồ Chí Minh', 'CV03', 'PBKTSX', 'LNV1', '2015-06-10', 4.80),
('NV003', N'Lê Minh', N'Tuấn', '01234567891236', N'Nam', '1995-11-20', '0901122334', 'tuan.le@example.com', N'Đà Nẵng', 'CV06', 'PBMAR', 'LNV1', '2020-01-15', 2.80),
('NV004', N'Hoàng Văn', N'Đạt', '01234567891238', N'Nam', '2001-07-30', '0977889900', 'dat.hoang@example.com', N'Cần Thơ', 'CV07', 'PBHCNS', 'LNV4', '2025-06-01', 1.10),
('NV005', N'Đỗ Văn', N'Khoa', '01234567891239', N'Nam', '1978-02-14', '0912341111', 'khoa.do@example.com', N'TP.HCM', 'CV02', 'PBHCNS', 'LNV1', '2012-05-01', 6.20),
('NV006', N'Ngô Thị', N'Thảo', '01234567891240', N'Nữ', '1986-03-18', '0933221111', 'thao.ngo@example.com', N'Thái Bình', 'CV05', 'PBHCNS', 'LNV1', '2016-09-01', 4.20),
('NV007', N'Phạm Văn', N'Long', '01234567891241', N'Nam', '1990-01-25', '0966448822', 'long.pham@example.com', N'Hà Nội', 'CV06', 'PBKTTC', 'LNV1', '2018-03-10', 3.00),
('NV008', N'Vũ Thị', N'Mai', '01234567891242', N'Nữ', '1998-06-10', '0977556633', 'mai.vu@example.com', N'Bình Dương', 'CV06', 'PBKTSX', 'LNV2', '2024-08-01', 1.90),
('NV009', N'Tống Văn', N'Chiến', '01234567891243', N'Nam', '1983-07-30', '0922334455', 'chien.tong@example.com', N'Đà Nẵng', 'CV03', 'PBLOGI', 'LNV1', '2013-04-20', 4.70),
('NV010', N'Nguyễn Thị', N'Trâm', '01234567891244', N'Nữ', '1994-10-15', '0933998855', 'tram.nguyen@example.com', N'Tây Ninh', 'CV06', 'PBMAR', 'LNV1', '2021-06-01', 2.60),
('NV011', N'Phan Văn', N'Quân', '01234567891245', N'Nam', '2002-08-20', '0900337722', 'quan.phan@example.com', N'Cần Thơ', 'CV07', 'PBQLCL', 'LNV4', '2025-06-15', 1.10),
('NV012', N'Lương Thị', N'Huyền', '01234567891246', N'Nữ', '1988-04-01', '0977881122', 'huyen.luong@example.com', N'Quảng Nam', 'CV04', 'PBHCNS', 'LNV1', '2017-09-15', 4.00),
('NV013', N'Hoàng Văn', N'Khang', '01234567891247', N'Nam', '1999-05-05', '0911002233', 'khang.hoang@example.com', N'Quảng Ngãi', 'CV06', 'PBHCNS', 'LNV2', '2024-11-01', 1.80),
('NV014', N'Trịnh Thanh', N'Bình', '01234567891248', N'Nam', '1982-12-25', '0955778899', 'binh.trinh@example.com', N'TP.HCM', 'CV03', 'PBMAR', 'LNV1', '2011-02-01', 5.20),
('NV015', N'Đinh Thị', N'Tuyết', '01234567891249', N'Nữ', '1993-03-12', '0919234567', 'tuyet.dinh@example.com', N'Hà Nội', 'CV06', 'PBHCNS', 'LNV1', '2020-04-15', 2.90),
('NV016', N'Tạ Minh', N'Trung', '01234567891250', N'Nam', '1987-07-08', '0944231789', 'trung.ta@example.com', N'TP.HCM', 'CV04', 'PBR&D', 'LNV1', '2016-11-01', 4.10),
('NV017', N'Lý Thị', N'Thương', '01234567891251', N'Nữ', '1998-12-01', '0984567221', 'thuong.ly@example.com', N'Bình Dương', 'CV06', 'PBLOGI', 'LNV2', '2024-12-01', 1.85),
('NV018', N'Hồ Văn', N'Tuấn', '01234567891252', N'Nam', '1991-09-09', '0909112345', 'tuan.ho@example.com', N'Huế', 'CV06', 'PBR&D', 'LNV1', '2019-08-10', 3.10),
('NV019', N'Võ Thị', N'Trúc', '01234567891253', N'Nữ', '2002-06-06', '0965341290', 'truc.vo@example.com', N'An Giang', 'CV07', 'PBKTTC', 'LNV4', '2025-05-15', 1.10),
('NV020', N'Nguyễn Văn', N'Khôi', '01234567891254', N'Nam', '1989-04-22', '0912349000', 'khoi.nguyen@example.com', N'Hải Dương', 'CV04', 'PBMAR', 'LNV1', '2018-06-05', 4.20),
('NV021', N'Hà Thị', N'Xuân', '01234567891255', N'Nữ', '1994-05-01', '0921345678', 'xuan.ha@example.com', N'Bắc Ninh', 'CV06', 'PBHCNS', 'LNV1', '2021-02-20', 2.60),
('NV022', N'Trần Quốc', N'Phong', '01234567891256', N'Nam', '1984-02-28', '0978421312', 'phong.tran@example.com', N'Tây Ninh', 'CV05', 'PBLOGI', 'LNV1', '2015-10-01', 4.30),
('NV023', N'Phạm Ngọc', N'Thịnh', '01234567891257', N'Nam', '2001-11-30', '0937738494', 'thinh.pham@example.com', N'TP.HCM', 'CV07', 'PBMAR', 'LNV4', '2025-06-20', 1.15),
('NV024', N'Bùi Thị', N'Diễm', '01234567891258', N'Nữ', '1986-10-10', '0901345678', 'diem.bui@example.com', N'Tiền Giang', 'CV04', 'PBHCNS', 'LNV1', '2013-03-01', 4.10),
('NV025', N'Huỳnh Thanh', N'Trúc', '01234567891259', N'Nữ', '1990-09-20', '0938771234', 'truc.huynh@example.com', N'Vĩnh Long', 'CV05', 'PBQLCL', 'LNV1', '2016-05-15', 3.80);
GO
WITH STK_NHANLUONG AS (
    SELECT MaNV,
           '001079' + RIGHT('0000000' + CAST(ROW_NUMBER() OVER (ORDER BY MaNV) AS VARCHAR), 7) AS STK_NHANLUONG
    FROM NHANVIEN
)
UPDATE NV
SET NV.STK = CTE.STK_NHANLUONG
FROM NHANVIEN NV
JOIN STK_NHANLUONG CTE ON NV.MaNV = CTE.MaNV;
GO
UPDATE NHANVIEN
SET TenNH = 'Vietcombank'
GO
ALTER TABLE NHANVIEN
ADD CONSTRAINT UQ_NHANVIEN_STK UNIQUE (STK);
GO
INSERT INTO TAIKHOAN (Tendangnhap, Matkhau, MaNV) VALUES
('Hung001', 'Hung1234', 'NV001'),
('Lan002', 'Lan1235', 'NV002'),
('Tuan003', 'Tuan1236', 'NV003'),
('Dat004', 'Dat1238', 'NV004'),
('Khoa005', 'Khoa1239', 'NV005'),
('Thao006', 'Thao1240', 'NV006'),
('Long007', 'Long1241', 'NV007'),
('Mai008', 'Mai1242', 'NV008'),
('Chien009', 'Chien1243', 'NV009'),
('Tram010', 'Tram1244', 'NV010'),
('Quan011', 'Quan1245', 'NV011'),
('Huyen012', 'Huyen1246', 'NV012'),
('Khang013', 'Khang1247', 'NV013'),
('Binh014', 'Binh1248', 'NV014'),
('Tuyet015', 'Tuyet1249', 'NV015'),
('Trung016', 'Trung1250', 'NV016'),
('Thuong017', 'Thuong1251', 'NV017'),
('Tuan018', 'Tuan1252', 'NV018'),
('Truc019', 'Truc1253', 'NV019'),
('Khoi020', 'Khoi1254', 'NV020'),
('Xuan021', 'Xuan1255', 'NV021'),
('Phong022', 'Phong1256', 'NV022'),
('Thinh023', 'Thinh1257', 'NV023'),
('Diem024', 'Diem1258', 'NV024'),
('Truc025', 'Truc1259', 'NV025');
GO
INSERT INTO BANGLUONG (MaBangLuong, LuongCoBan, CS_Thuong, PhuCap, KhauTru, ThucLanh, MaNV)
VALUES
('BL0001', 13500000, 2000000, 2500000, 1000000, 17000000, 'NV001'),
('BL0002', 8640000, 1200000, 1800000, 800000, 10800000, 'NV002'),
('BL0003', 5040000, 1000000, 1500000, 700000, 6840000, 'NV003'),
('BL0004', 1980000, 500000, 700000, 300000, 2380000, 'NV004'),
('BL0005', 11160000, 1600000, 1900000, 900000, 13760000, 'NV005'),
('BL0006', 7560000, 1000000, 1400000, 600000, 9360000, 'NV006'),
('BL0007', 5400000, 800000, 1200000, 500000, 7000000, 'NV007'),
('BL0008', 3420000, 700000, 900000, 400000, 4300000, 'NV008'),
('BL0009', 8460000, 1100000, 1600000, 700000, 10450000, 'NV009'),
('BL0010', 4680000, 600000, 900000, 500000, 5640000, 'NV010'),
('BL0011', 1980000, 300000, 400000, 200000, 2280000, 'NV011'),
('BL0012', 7200000, 1000000, 1100000, 700000, 8600000, 'NV012'),
('BL0013', 3240000, 500000, 700000, 300000, 3700000, 'NV013'),
('BL0014', 9360000, 1500000, 1800000, 800000, 11880000, 'NV014'),
('BL0015', 5220000, 700000, 900000, 400000, 6420000, 'NV015'),
('BL0016', 7380000, 1000000, 1100000, 600000, 8880000, 'NV016'),
('BL0017', 3330000, 500000, 600000, 300000, 3530000, 'NV017'),
('BL0018', 5580000, 800000, 900000, 400000, 6300000, 'NV018'),
('BL0019', 1980000, 300000, 500000, 200000, 2300000, 'NV019'),
('BL0020',  7560000, 1200000, 1400000, 700000, 9040000, 'NV020'),
('BL0021', 4680000, 600000, 800000, 400000, 5400000, 'NV021'),
('BL0022', 7740000, 900000, 1300000, 600000, 8900000, 'NV022'),
('BL0023', 2070000, 400000, 500000, 200000, 2770000, 'NV023'),
('BL0024', 7380000, 1100000, 1300000, 600000, 9210000, 'NV024'),
('BL0025', 6840000, 900000, 1000000, 500000, 7900000, 'NV025');
GO
INSERT INTO BANGLUONG (MaBangLuong, NgayNhanLuong, LuongCoBan, CS_Thuong, PhuCap, KhauTru, ThucLanh, MaNV)
VALUES
('BL0026', '2025-06-10', 13500000, 2500000, 2600000, 1200000, 17400000, 'NV001'),
('BL0027', '2025-06-10', 8640000, 1000000, 1700000, 700000, 10630000, 'NV002'),
('BL0028', '2025-06-10', 5040000, 1200000, 1400000, 600000, 7040000, 'NV003'),
('BL0029', '2025-06-10', 1980000, 300000, 500000, 200000, 2580000, 'NV004'),
('BL0030', '2025-06-10', 11160000, 1400000, 2000000, 800000, 13760000, 'NV005'),
('BL0031', '2025-06-10', 7560000, 1100000, 1500000, 700000, 9460000, 'NV006'),
('BL0032', '2025-06-10', 5400000, 1000000, 1100000, 600000, 6900000, 'NV007'),
('BL0033', '2025-06-10', 3420000, 800000, 800000, 300000, 4300000, 'NV008'),
('BL0034', '2025-06-10', 8460000, 1300000, 1700000, 600000, 10800000, 'NV009'),
('BL0035', '2025-06-10', 4680000, 700000, 950000, 600000, 5250000, 'NV010'),
('BL0036', '2025-06-10', 1980000, 400000, 300000, 100000, 2580000, 'NV011'),
('BL0037', '2025-06-10', 7200000, 900000, 1000000, 500000, 8600000, 'NV012'),
('BL0038', '2025-06-10', 3240000, 600000, 800000, 200000, 4200000, 'NV013'),
('BL0039', '2025-06-10', 9360000, 1300000, 1700000, 600000, 11800000, 'NV014'),
('BL0040', '2025-06-10', 5220000, 800000, 950000, 300000, 6370000, 'NV015'),
('BL0041', '2025-06-10', 7380000, 1100000, 1150000, 700000, 8520000, 'NV016'),
('BL0042', '2025-06-10', 3330000, 600000, 500000, 200000, 3900000, 'NV017'),
('BL0043', '2025-06-10', 5580000, 700000, 1000000, 300000, 6400000, 'NV018'),
('BL0044', '2025-06-10', 1980000, 200000, 400000, 100000, 2480000, 'NV019'),
('BL0045', '2025-06-10', 7560000, 1300000, 1500000, 800000, 9000000, 'NV020'),
('BL0046', '2025-06-10', 4680000, 700000, 850000, 300000, 5250000, 'NV021'),
('BL0047', '2025-06-10', 7740000, 950000, 1400000, 700000, 8890000, 'NV022'),
('BL0048', '2025-06-10', 2070000, 300000, 600000, 300000, 2670000, 'NV023'),
('BL0049', '2025-06-10', 7380000, 1000000, 1200000, 500000, 9080000, 'NV024'),
('BL0050', '2025-06-10', 6840000, 1000000, 1100000, 600000, 8340000, 'NV025');
GO
UPDATE BANGLUONG
SET NgayNhanLuong = '2025-05-10'
GO
ALTER TABLE BANGLUONG
ALTER COLUMN NgayNhanLuong DATE NOT NULL
GO
INSERT INTO DOTTUYENDUNG (MaDTD, MaNV, ViTriCanTuyen, PhongBan, SoLuongTuyen, NgayBatDau, NgayKetThuc)
VALUES
('DTD001', 'NV012', N'Nhân viên Marketing', N'PBMAR', 4, '2025-06-08', '2025-06-21'),
('DTD002', 'NV006', N'Kế toán', N'PBKTTC', 2, '2025-06-10', '2025-06-21'),
('DTD003', 'NV024', N'Kỹ sư sản xuất', N'PBKTSX', 3, '2025-06-14', '2025-07-03'),
('DTD004', 'NV006', N'Nhân viên tuyển dụng', N'PBHCNS', 4, '2025-06-14', '2025-07-04'),
('DTD005', 'NV012', N'QC kiểm định', N'PBQLCL', 5, '2025-06-06', '2025-06-25');
GO
INSERT INTO DOTTUYENDUNG (MaDTD, MaNV, ViTriCanTuyen, PhongBan, SoLuongTuyen, NgayBatDau, NgayKetThuc)
VALUES
('DTD006', 'NV012', N'Nhân viên phát triển sản phẩm', N'PBR&D', 4, '2025-07-08', '2025-07-21'),
('DTD007', 'NV006', N'Kiểm toán viên', N'PBKTTC', 2, '2025-07-25', '2025-08-20'),
('DTD008', 'NV006', N'Nhân viên thu mua', N'PBLOGI', 4, '2025-07-14', '2025-08-04');
GO
INSERT INTO DOTPHONGVAN (MaDPV, TenDPV, MaDTD, MaNV, SoLuongUV, NgayPV)
VALUES
('DPV001', N'Phỏng vấn đợt 1', 'DTD002', 'NV004', 6, '2025-06-14'),
('DPV002', N'Phỏng vấn đợt 1', 'DTD003', 'NV013', 5, '2025-06-16'),
('DPV003', N'Phỏng vấn đợt 1', 'DTD001', 'NV015', 5, '2025-06-15'),
('DPV004', N'Phỏng vấn đợt 1', 'DTD005', 'NV004', 6, '2025-06-19'),
('DPV005', N'Phỏng vấn đợt 2', 'DTD002', 'NV013', 4, '2025-06-20'),
('DPV006', N'Phỏng vấn đợt 2', 'DTD003', 'NV021', 7, '2025-06-20'),
('DPV007', N'Phỏng vấn đợt 2', 'DTD001', 'NV013', 6, '2025-06-19'),
('DPV008', N'Phỏng vấn đợt 3', 'DTD002', 'NV021', 3, '2025-06-17'),
('DPV009', N'Phỏng vấn đợt 1', 'DTD004', 'NV013', 8, '2025-06-25'),
('DPV010', N'Phỏng vấn đợt 2', 'DTD003', 'NV015', 8, '2025-06-28');
GO
INSERT INTO DOTPHONGVAN (MaDPV, TenDPV, MaDTD, MaNV, SoLuongUV, NgayPV)
VALUES
('DPV011', N'Phỏng vấn đợt 1', 'DTD006', 'NV012', 6, '2025-07-20'),
('DPV012', N'Phỏng vấn đợt 2', 'DTD006', 'NV012', 5, '2025-07-19'),
('DPV013', N'Phỏng vấn đợt 1', 'DTD007', 'NV006', 5, '2025-08-10'),
('DPV014', N'Phỏng vấn đợt 1', 'DTD008', 'NV006', 6, '2025-07-25'),
('DPV015', N'Phỏng vấn đợt 2', 'DTD008', 'NV006', 4, '2025-08-02');
GO
INSERT INTO DOTPHONGVAN (MaDPV, TenDPV, MaDTD, MaNV, SoLuongUV, NgayPV)
VALUES
('DPV001', N'Phỏng vấn đợt 1', 'DTD002', 'NV004', 6, '2025-06-14'),
('DPV002', N'Phỏng vấn đợt 1', 'DTD003', 'NV013', 5, '2025-06-16'),
('DPV003', N'Phỏng vấn đợt 1', 'DTD001', 'NV015', 5, '2025-06-15'),
('DPV004', N'Phỏng vấn đợt 1', 'DTD005', 'NV004', 6, '2025-06-19'),
('DPV005', N'Phỏng vấn đợt 2', 'DTD002', 'NV013', 4, '2025-06-20'),
('DPV006', N'Phỏng vấn đợt 2', 'DTD003', 'NV021', 7, '2025-06-20'),
('DPV007', N'Phỏng vấn đợt 2', 'DTD001', 'NV013', 6, '2025-06-19'),
('DPV008', N'Phỏng vấn đợt 3', 'DTD002', 'NV021', 3, '2025-06-17'),
('DPV009', N'Phỏng vấn đợt 1', 'DTD004', 'NV013', 8, '2025-06-25'),
('DPV010', N'Phỏng vấn đợt 2', 'DTD003', 'NV015', 8, '2025-06-28');
GO
INSERT INTO UNGVIEN (MaUV, HoUV, TenUV, GioiTinh_UV, NgaySinh_UV, Sdt_UV, Email_UV)
VALUES
('UV00001', N'Nguyễn Văn', N'An', N'Nam', '1995-06-14', '0912345678', N'an.nguyen95@gmail.com'),
('UV00002', N'Lê Thị', N'Thảo', N'Nữ', '1997-09-22', '0934567890', N'thao.le97@yahoo.com'),
('UV00003', N'Trần Minh', N'Tuấn', N'Nam', '1993-12-01', '0908765432', N'minhtuan.tran@gmail.com'),
('UV00004', N'Phạm Hoàng', N'Hưng', N'Nam', '1990-03-11', '0987654321', N'hung.pham90@gmail.com'),
('UV00005', N'Đỗ Thị', N'Lan', N'Nữ', '1996-08-09', '0972345678', N'lan.do96@hotmail.com'),
('UV00006', N'Vũ Văn', N'Thành', N'Nam', '1992-05-20', '0911222333', N'thanh.vu92@gmail.com'),
('UV00007', N'Ngô Thị', N'Mai', N'Nữ', '1994-11-05', '0922333444', N'mai.ngo94@gmail.com'),
('UV00008', N'Hoàng', N'Dũng', N'Nam', '1989-07-15', '0933444555', N'dung.hoang89@yahoo.com'),
('UV00009', N'Phan Thị', N'Yến', N'Nữ', '1998-01-30', '0944555666', N'yen.phan98@gmail.com'),
('UV00010', N'Tô Minh', N'Phúc', N'Nam', '1991-04-12', '0955666777', N'phuc.to91@gmail.com'),
('UV00011', N'Bùi Thị', N'Trinh', N'Nữ', '1996-06-25', '0966777888', N'trinh.bui96@hotmail.com'),
('UV00012', N'Huỳnh Văn', N'Hải', N'Nam', '1993-03-18', '0977888999', N'hai.huynh93@gmail.com'),
('UV00013', N'Cao Thị', N'Linh', N'Nữ', '1995-12-08', '0988999000', N'linh.cao95@yahoo.com'),
('UV00014', N'Đặng Quốc', N'Toàn', N'Nam', '1990-10-03', '0999000111', N'toan.dang90@gmail.com'),
('UV00015', N'Trương Mỹ', N'Duyên', N'Nữ', '1997-02-14', '0900111222', N'duyen.truong97@gmail.com'),
('UV00016', N'Lâm Nhật', N'Trường', N'Nam', '1994-08-27', '0910234567', N'truong.lam94@gmail.com'),
('UV00017', N'Hồ Thị', N'Như', N'Nữ', '1999-09-09', '0920345678', N'nhu.ho99@gmail.com'),
('UV00018', N'Tống Văn', N'Khoa', N'Nam', '1992-01-17', '0930456789', N'khoa.tong92@gmail.com'),
('UV00019', N'Mai Thị', N'Hồng', N'Nữ', '1996-05-05', '0940567890', N'hong.mai96@gmail.com'),
('UV00020', N'Lương Bảo', N'Ngọc', N'Khác', '1995-07-07', '0950678901', N'ngoc.luong95@gmail.com');
GO 
INSERT INTO UNGVIEN (MaUV, HoUV, TenUV, GioiTinh_UV, NgaySinh_UV, Sdt_UV, Email_UV)
VALUES
('UV00021', N'Nguyễn Thị', N'Bích', N'Nữ', '1995-02-12', '0901001001', N'bich.nguyen95@gmail.com'),
('UV00022', N'Trần Văn', N'Tiến', N'Nam', '2000-06-18', '0902002002', N'tien.tran90@gmail.com'),
('UV00023', N'Lê Thị', N'Cẩm', N'Nữ', '1998-09-25', '0903003003', N'cam.le93@gmail.com'),
('UV00024', N'Phạm Quang', N'Huy', N'Nam', '2002-11-09', '0904004004', N'huy.pham91@gmail.com'),
('UV00025', N'Vũ Thị', N'Thúy', N'Nữ', '1997-03-03', '0905005005', N'thuy.vu96@gmail.com'),
('UV00026', N'Ngô Văn', N'Đạt', N'Nam', '2003-12-20', '0906006006', N'dat.ngo89@gmail.com'),
('UV00027', N'Hoàng Thị', N'Nhung', N'Nữ', '1998-08-08', '0907007007', N'nhung.hoang98@gmail.com'),
('UV00028', N'Bùi Minh', N'Trí', N'Nam', '1994-01-01', '0908008008', N'tri.bui94@gmail.com'),
('UV00029', N'Tô Thị', N'Diễm', N'Nữ', '1997-10-15', '0909009009', N'diem.to92@gmail.com'),
('UV00030', N'Huỳnh Văn', N'Tân', N'Nam', '1995-05-30', '0910101010', N'tan.huynh95@gmail.com'),
('UV00031', N'Cao Thị', N'Hà', N'Nữ', '1996-04-14', '0911111111', N'ha.cao96@gmail.com'),
('UV00032', N'Lâm Quốc', N'Thịnh', N'Nam', '2000-07-19', '0912121212', N'thinh.lam93@gmail.com'),
('UV00033', N'Mai Thị', N'Trâm', N'Nữ', '2003-01-23', '0913131313', N'tram.mai90@gmail.com'),
('UV00034', N'Đỗ Văn', N'Khánh', N'Nam', '1997-12-10', '0914141414', N'khanh.do97@gmail.com'),
('UV00035', N'Lý Thị', N'Mỹ', N'Nữ', '1995-06-06', '0915151515', N'my.ly94@gmail.com'),
('UV00036', N'Trịnh Công', N'Duy', N'Nam', '1994-09-14', '0916161616', N'duy.trinh92@gmail.com'),
('UV00037', N'Châu Thị', N'Thương', N'Nữ', '1993-02-27', '0917171717', N'thuong.chau91@gmail.com'),
('UV00038', N'Đinh Văn', N'Tiến', N'Nam', '1995-08-05', '0918181818', N'tien.dinh95@gmail.com'),
('UV00039', N'Nguyễn Thị', N'Thắm', N'Nữ', '1999-03-11', '0919191919', N'tham.nguyen93@gmail.com'),
('UV00040', N'Hồ Văn', N'Long', N'Nam', '1994-07-21', '0920202020', N'long.ho90@gmail.com'),
('UV00041', N'Trần Thị', N'Thùy', N'Nữ', '1999-04-04', '0921212121', N'thuy.tran94@gmail.com'),
('UV00042', N'Lê Minh', N'Hoàng', N'Nam', '2001-11-17', '0922222222', N'hoang.le96@gmail.com'),
('UV00043', N'Phan Thị', N'Ngân', N'Nữ', '2002-06-30', '0923232323', N'ngan.phan92@gmail.com'),
('UV00044', N'Võ Văn', N'Tiệp', N'Nam', '2000-09-03', '0924242424', N'tiep.vo91@gmail.com'),
('UV00045', N'Nguyễn Thị', N'Tuyết', N'Nữ', '1997-01-25', '0925252525', N'tuyet.nguyen97@gmail.com'),
('UV00046', N'Đặng Quốc', N'Thái', N'Nam', '2001-10-10', '0926262626', N'thai.dang90@gmail.com'),
('UV00047', N'Tống Thị', N'Hạnh', N'Nữ', '1995-03-05', '0927272727', N'hanh.tong95@gmail.com'),
('UV00048', N'Lâm Văn', N'Hiếu', N'Nam', '1993-08-29', '0928282828', N'hieu.lam93@gmail.com'),
('UV00049', N'Tạ Thị', N'Trúc', N'Nữ', '1996-12-12', '0929292929', N'truc.ta96@gmail.com'),
('UV00050', N'Bạch Văn', N'Tuấn', N'Khác', '1994-07-07', '0930303030', N'tuan.bach94@gmail.com');
GO
INSERT INTO UV_THAMGIA (MaUV, MaDPV, ViTriUngTuyen, KetQuaPV)
VALUES
('UV00001', 'DPV001', N'Kế toán', N'Đạt'),
('UV00002', 'DPV002', N'Kỹ sư sản xuất', N'Đạt'),
('UV00003', 'DPV003', N'Nhân viên Marketing', N'Không đạt'),
('UV00004', 'DPV004', N'QC kiểm định', N'Đạt'),
('UV00005', 'DPV005', N'Kế toán', N'Không đạt'),
('UV00006', 'DPV006', N'Kỹ sư sản xuất', N'Đạt'),
('UV00007', 'DPV007', N'Nhân viên Marketing', N'Đạt'),
('UV00008', 'DPV003', N'Nhân viên Marketing', N'Không đạt'),
('UV00009', 'DPV004', N'QC kiểm định', N'Đạt'),
('UV00010', 'DPV005', N'Kế toán', N'Không đạt'),
('UV00011', 'DPV001', N'Kế toán', N'Đạt'),
('UV00012', 'DPV002', N'Kỹ sư sản xuất', N'Không đạt'),
('UV00013', 'DPV008', N'Kế toán', N'Đạt'),
('UV00014', 'DPV009', N'Nhân viên tuyển dụng', N'Đạt'),
('UV00015', 'DPV010', N'Kỹ sư sản xuất', N'Không đạt'),
('UV00016', 'DPV001', N'Kế toán', N'Đạt'),
('UV00017', 'DPV002', N'Kỹ sư sản xuất', N'Không đạt'),
('UV00018', 'DPV003', N'Nhân viên Marketing', N'Đạt'),
('UV00019', 'DPV004', N'QC kiểm định', N'Đạt'),
('UV00020', 'DPV005', N'Kế toán', N'Không đạt');
GO
INSERT INTO UV_THAMGIA (MaUV, MaDPV, ViTriUngTuyen, KetQuaPV)
VALUES
('UV00021', 'DPV006', N'Kế toán', N'Đạt'),
('UV00022', 'DPV007', N'Kỹ sư sản xuất', N'Không đạt'),
('UV00023', 'DPV008', N'Nhân viên Marketing', N'Đạt'),
('UV00024', 'DPV009', N'QC kiểm định', N'Không đạt'),
('UV00025', 'DPV010', N'Kế toán', N'Đạt'),
('UV00026', 'DPV001', N'Kỹ sư sản xuất', N'Đạt'),
('UV00027', 'DPV002', N'Nhân viên Marketing', N'Không đạt'),
('UV00028', 'DPV003', N'QC kiểm định', N'Đạt'),
('UV00029', 'DPV004', N'Kế toán', N'Không đạt'),
('UV00030', 'DPV005', N'Kỹ sư sản xuất', N'Đạt'),
('UV00031', 'DPV006', N'Nhân viên Marketing', N'Không đạt'),
('UV00032', 'DPV007', N'QC kiểm định', N'Đạt'),
('UV00033', 'DPV008', N'Nhân viên tuyển dụng', N'Đạt'),
('UV00034', 'DPV009', N'Kế toán', N'Không đạt'),
('UV00035', 'DPV010', N'Kỹ sư sản xuất', N'Đạt'),
('UV00036', 'DPV001', N'Nhân viên Marketing', N'Không đạt'),
('UV00037', 'DPV002', N'QC kiểm định', N'Đạt'),
('UV00038', 'DPV003', N'Kế toán', N'Đạt'),
('UV00039', 'DPV004', N'Kỹ sư sản xuất', N'Không đạt'),
('UV00040', 'DPV005', N'Nhân viên Marketing', N'Đạt'),
('UV00041', 'DPV006', N'QC kiểm định', N'Không đạt'),
('UV00042', 'DPV007', N'Kế toán', N'Đạt'),
('UV00043', 'DPV008', N'Kỹ sư sản xuất', N'Đạt'),
('UV00044', 'DPV009', N'Nhân viên Marketing', N'Không đạt'),
('UV00045', 'DPV010', N'QC kiểm định', N'Đạt'),
('UV00046', 'DPV001', N'Kế toán', N'Không đạt'),
('UV00047', 'DPV002', N'Kỹ sư sản xuất', N'Đạt'),
('UV00048', 'DPV003', N'Nhân viên tuyển dụng', N'Không đạt'),
('UV00049', 'DPV004', N'Nhân viên Marketing', N'Đạt'),
('UV00050', 'DPV005', N'QC kiểm định', N'Không đạt');
GO
INSERT INTO LOAICHUNGCHI (MaCC, TenCC)
VALUES
('CC0001', N'TOEIC'),
('CC0002', N'IELTS'),
('CC0003', N'Chứng chỉ MOS'),
('CC0004', N'Tin học văn phòng B'),
('CC0005', N'Chứng chỉ tiếng Nhật N3'),
('CC0006', N'Chứng chỉ tiếng Trung HSK 4'),
('CC0007', N'Chứng chỉ Quản lý dự án PMI');
GO
INSERT INTO LOAIBANGCAP (MaBC, TenBC)
VALUES
('BC000001', N'Trung cấp'),
('BC000002', N'Cao đẳng'),
('BC000003', N'Đại học'),
('BC000004', N'Kỹ sư'),
('BC000005', N'Cử nhân'),
('BC000006', N'Thạc sĩ'),
('BC000007', N'Tiến sĩ'),
('BC000008', N'Cao học'),
('BC000009', N'Bằng nghề sơ cấp'),
('BC000010', N'Bằng liên thông đại học');
GO
INSERT INTO CHUNGCHI_UV (MaUV, MaCC, KetQua, DonViCap, NgayCapCC, ThoiHan)
VALUES
('UV00001', 'CC0001', N'850 điểm', N'TOEIC Việt Nam', '2022-06-15', 24),
('UV00003', 'CC0003', N'Word Specialist', N'Microsoft', '2021-11-11', 36),
('UV00005', 'CC0005', N'N3', N'JLPT Nhật Bản', '2022-07-01', 60),
('UV00006', 'CC0001', N'780 điểm', N'IIG Việt Nam', '2023-03-01', 24),
('UV00007', 'CC0006', N'HSK 4', N'Hanban', '2021-04-20', 60),
('UV00008', 'CC0004', N'Khá', N'Trung tâm Tin học ACB', '2021-01-01', 48),
('UV00009', 'CC0002', N'7.0', N'British Council', '2023-06-01', 24),
('UV00010', 'CC0001', N'820 điểm', N'TOEIC Việt Nam', '2022-08-08', 24),
('UV00010', 'CC0003', N'PowerPoint Specialist', N'Microsoft', '2022-08-08', 36),
('UV00011', 'CC0004', N'Giỏi', N'Trường ĐH Bách Khoa', '2023-05-05', 60),
('UV00012', 'CC0003', N'Access Expert', N'Microsoft', '2020-10-10', 36),
('UV00013', 'CC0005', N'N3', N'Tổ chức JLPT', '2022-12-12', 60),
('UV00014', 'CC0006', N'HSK 4', N'Hanban', '2021-06-06', 60),
('UV00015', 'CC0002', N'6.0', N'IDP', '2023-03-03', 24),
('UV00016', 'CC0007', N'PMP', N'PMI Global', '2021-11-11', 60),
('UV00017', 'CC0001', N'750 điểm', N'TOEIC Việt Nam', '2023-04-04', 24),
('UV00018', 'CC0004', N'Trung bình', N'Trung tâm Tin học XYZ', '2020-09-09', 48),
('UV00019', 'CC0005', N'N3', N'JLPT', '2021-08-08', 60),
('UV00020', 'CC0001', N'800 điểm', N'IIG Việt Nam', '2023-02-02', 24),
('UV00020', 'CC0006', N'HSK 4', N'Trung tâm Hán ngữ Hoa Ngữ', '2022-06-06', 60);
GO
INSERT INTO BANGCAP_UV (MaUV, MaBC, NgayCap, TruongCap, NamTN)
VALUES
('UV00001', 'BC000003', '2017-07-15', N'Đại học Bách Khoa Hà Nội', '2017'),
('UV00007', 'BC000005', '2019-08-20', N'Đại học Kinh tế Quốc dân', '2018'),
('UV00003', 'BC000004', '2015-07-10', N'Đại học Giao thông Vận tải', '2015'),
('UV00016', 'BC000006', '2018-11-01', N'Đại học Quốc gia Hà Nội', '2017'),
('UV00010', 'BC000003', '2013-06-25', N'Đại học Bách Khoa TP.HCM', '2013'),
('UV00005', 'BC000002', '2016-07-20', N'Cao đẳng FPT Polytechnic', '2016'),
('UV00002', 'BC000009', '2014-05-05', N'Trung tâm dạy nghề quận 3', '2013'),
('UV00008', 'BC000001', '2015-08-15', N'Trường Trung cấp nghề Nguyễn Hữu Cảnh', '2015'),
('UV00012', 'BC000010', '2017-09-30', N'Đại học Mở TP.HCM', '2016'),
('UV00009', 'BC000003', '2020-07-12', N'Đại học Ngoại thương', '2020');
GO
INSERT INTO CHUNGCHI_NV (MaNV, MaCC, KetQua, DonViCap, NgayCapCC, ThoiHan)
VALUES
('NV001', 'CC0001', N'900 điểm', N'IIG Việt Nam', '2018-05-10', 60),
('NV006', 'CC0007', N'PMP', N'PMI Institute', '2019-03-01', 60),
('NV015', 'CC0003', N'Excel Specialist', N'Microsoft', '2017-08-01', 48),
('NV002', 'CC0002', N'7.0', N'British Council', '2020-07-01', 36),
('NV010', 'CC0006', N'HSK 4', N'Hanban', '2021-06-15', 60),
('NV023', 'CC0005', N'N3', N'JLPT Nhật Bản', '2022-02-10', 60),
('NV007', 'CC0007', N'PMP', N'PMI Global', '2021-11-11', 60),
('NV021', 'CC0003', N'PowerPoint Specialist', N'Microsoft', '2021-08-01', 36),
('NV013', 'CC0001', N'820 điểm', N'IIG Việt Nam', '2019-09-01', 60),
('NV017', 'CC0007', N'CAPM', N'PMI', '2020-11-01', 60),
('NV003', 'CC0003', N'Word Specialist', N'Microsoft', '2022-01-10', 36),
('NV016', 'CC0002', N'6.5', N'IDP', '2021-04-01', 36),
('NV011', 'CC0002', N'7.0', N'IIG Việt Nam', '2023-06-01', 24),
('NV022', 'CC0006', N'HSK 4', N'Trung tâm Hán ngữ Bắc Kinh', '2022-12-01', 60),
('NV019', 'CC0005', N'N3', N'JLPT Nhật Bản', '2021-10-10', 60);
GO
INSERT INTO BANGCAP_NV (MaNV, MaBC, NgayCap, TruongCap, NamTN)
VALUES
('NV001', 'BC000003', '2002-07-10', N'ĐH Bách Khoa Hà Nội', '2002'),
('NV001', 'BC000006', '2005-09-15', N'ĐH Quốc gia Hà Nội', '2005'),
('NV002', 'BC000005', '2007-08-20', N'ĐH Kinh tế Quốc dân', '2006'),
('NV003', 'BC000003', '2017-07-05', N'ĐH Đà Nẵng', '2016'),
('NV004', 'BC000002', '2023-08-01', N'CĐ FPT Polytechnic', '2022'),
('NV005', 'BC000003', '2000-06-15', N'ĐH Kinh tế TP.HCM', '2000'),
('NV005', 'BC000006', '2003-10-01', N'ĐH Quốc gia TP.HCM', '2002'),
('NV006', 'BC000005', '2008-09-10', N'ĐH KHXH & NV', '2008'),
('NV007', 'BC000003', '2013-06-25', N'ĐH Thương mại', '2012'),
('NV008', 'BC000002', '2020-08-20', N'CĐ Công nghệ TP.HCM', '2019'),
('NV009', 'BC000003', '2005-07-20', N'ĐH Bách Khoa Đà Nẵng', '2005'),
('NV010', 'BC000003', '2016-09-15', N'ĐH Công nghiệp TP.HCM', '2016'),
('NV011', 'BC000001', '2024-06-15', N'Trường Trung cấp nghề CT', '2023'),
('NV012', 'BC000005', '2010-08-05', N'ĐH Sư phạm Kỹ thuật', '2009'),
('NV013', 'BC000002', '2022-08-10', N'CĐ Công nghệ Sài Gòn', '2021'),
('NV014', 'BC000004', '2006-07-15', N'ĐH Giao thông Vận tải', '2005'),
('NV015', 'BC000003', '2015-08-01', N'ĐH Thủy lợi', '2014'),
('NV016', 'BC000005', '2009-07-01', N'ĐH Công nghệ', '2008'),
('NV017', 'BC000002', '2022-07-10', N'CĐ Kinh tế Kỹ thuật BD', '2022'),
('NV018', 'BC000003', '2013-06-01', N'ĐH Bách Khoa Huế', '2012'),
('NV019', 'BC000001', '2024-10-10', N'Trường Trung cấp nghề AG', '2023'),
('NV020', 'BC000004', '2010-07-01', N'ĐH Giao thông TP.HCM', '2009'),
('NV021', 'BC000003', '2016-06-30', N'ĐH Khoa học Tự nhiên', '2015'),
('NV022', 'BC000005', '2007-08-15', N'ĐH Mở TP.HCM', '2006'),
('NV023', 'BC000001', '2024-11-01', N'Trường TC Nghề TP.HCM', '2023'),
('NV024', 'BC000003', '2008-09-01', N'ĐH Tiền Giang', '2007'),
('NV025', 'BC000003', '2014-06-30', N'ĐH Khoa học Tự nhiên', '2013');

INSERT INTO HOPDONGLAODONG (MaHD, TenHD, LoaiHD, NgayKyKet, NgayBatDau, NgayKetThuc, MaNV)
VALUES
('HD0002', N'Hợp đồng lao động của NV002', N'Chính thức', '2015-06-01', '2015-06-10', '2018-06-10', 'NV002'),
('HD0003', N'Hợp đồng lao động của NV003', N'Thử việc', '2020-01-01', '2020-01-15', '2021-01-15', 'NV003'),
('HD0004', N'Hợp đồng lao động của NV005', N'Chính thức', '2012-04-20', '2012-05-01', '2017-05-01', 'NV005'),
('HD0005', N'Hợp đồng lao động của NV006', N'Chính thức', '2016-08-15', '2016-09-01', '2019-09-01', 'NV006'),
('HD0006', N'Hợp đồng lao động của NV007', N'Thử việc', '2018-03-01', '2018-03-10', '2019-03-10', 'NV007'),
('HD0007', N'Hợp đồng lao động của NV008', N'Thử việc', '2024-07-25', '2024-08-01', '2025-08-01', 'NV008'),
('HD0008', N'Hợp đồng lao động của NV009', N'Chính thức', '2013-04-10', '2013-04-20', '2016-04-20', 'NV009'),
('HD0009', N'Hợp đồng lao động của NV010', N'Thử việc', '2021-05-25', '2021-06-01', '2022-06-01', 'NV010'),
('HD0010', N'Hợp đồng lao động của NV012', N'Chính thức', '2017-09-01', '2017-09-15', '2020-09-15', 'NV012'),
('HD0011', N'Hợp đồng lao động của NV013', N'Thời vụ', '2024-10-15', '2024-11-01', '2025-11-01', 'NV013'),
('HD0012', N'Hợp đồng lao động của NV014', N'Chính thức', '2011-01-20', '2011-02-01', '2014-02-01', 'NV014'),
('HD0013', N'Hợp đồng lao động của NV015', N'Thử việc', '2020-04-01', '2020-04-15', '2022-04-15', 'NV015'),
('HD0014', N'Hợp đồng lao động của NV016', N'Chính thức', '2016-10-20', '2016-11-01', '2019-11-01', 'NV016'),
('HD0015', N'Hợp đồng lao động của NV017', N'Thử việc', '2024-11-25', '2024-12-01', '2026-12-01', 'NV017'),
('HD0016', N'Hợp đồng lao động của NV018', N'Chính thức', '2019-07-30', '2019-08-10', '2022-08-10', 'NV018'),
('HD0017', N'Hợp đồng lao động của NV020', N'Thời vụ', '2018-05-25', '2018-06-05', '2020-06-05', 'NV020'),
('HD0018', N'Hợp đồng lao động của NV021', N'Chính thức', '2021-02-10', '2021-02-20', '2024-02-20', 'NV021'),
('HD0019', N'Hợp đồng lao động của NV022', N'Thử việc', '2015-09-20', '2015-10-01', '2018-10-01', 'NV022'),
('HD0020', N'Hợp đồng lao động của NV024', N'Thời vụ', '2013-02-20', '2013-03-01', '2016-03-01', 'NV024'),
('HD0021', N'Hợp đồng lao động của NV025', N'Chính thức', '2016-05-01', '2016-05-15', '2019-05-15', 'NV025');

     --FORM NHÂN VIÊN
--TÌM NHÂN VIÊN THEO MÃ-- NV, QL
CREATE PROC SP_TIMTHEOMA (@MANV CHAR(5))
AS
BEGIN
	IF EXISTS (SELECT MaNV FROM NHANVIEN WHERE @MANV = MaNV)
	BEGIN
		SELECT MaNV, HoNV+' '+ TenNV, CCCD, GioiTinh, NgaySinh, Sdt_NV, Email_NV, DiaChi, NgayVaoLam, HeSoLuong
		FROM NHANVIEN
--THÊM DỮ LIỆU TỰ ĐỘNG
DECLARE @CurrentDate DATE = '2025-06-01';
DECLARE @EndDate DATE = '2025-06-30';

WHILE @CurrentDate <= @EndDate
BEGIN
    -- Chỉ chấm công từ thứ 2 đến thứ 6
    IF DATEPART(WEEKDAY, @CurrentDate) BETWEEN 2 AND 6
    BEGIN
        INSERT INTO BANGCHAMCONG (MaBCC, NgayChamCong, GioVaoLam, GioTanLam, MaNV)
        SELECT 
            CONCAT('CC', FORMAT(@CurrentDate, 'ddMMyy'), FORMAT(ROW_NUMBER() OVER (ORDER BY HDLD.MaNV), '000')) AS MaBCC,
            @CurrentDate,
            '08:30:00',
            '17:30:00',
            HDLD.MaNV
        FROM HOPDONGLAODONG HDLD
        WHERE 
            @CurrentDate BETWEEN HDLD.NgayBatDau AND HDLD.NgayKetThuc
            AND HDLD.MaNV NOT IN ('NV001', 'NV005'); -- Loại nhân viên NV001 và NV005
    END

    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END
GO
CREATE PROCEDURE sp_UngVienDat
    @MaDTD CHAR(10)
AS
BEGIN
    SELECT 
        uv.MaUV,
        uv.HoUV + ' ' + uv.TenUV AS HoTenUV,
        uv.Email_UV,
        uv.Sdt_UV,
        uv.GioiTinh_UV,
        uv.NgaySinh_UV,
        tg.ViTriUngTuyen,
        tg.KetQuaPV,
        dpv.MaDPV,
        dpv.NgayPV
    FROM UNGVIEN uv
    INNER JOIN UV_THAMGIA tg ON uv.MaUV = tg.MaUV
    INNER JOIN DOTPHONGVAN dpv ON tg.MaDPV = dpv.MaDPV
    INNER JOIN DOTTUYENDUNG dtd ON dpv.MaDTD = dtd.MaDTD
    WHERE dtd.MaDTD = @MaDTD AND tg.KetQuaPV = N'Đạt'
END

INSERT INTO NghiPhep (MaNP, MaNV, TuNgay, DenNgay, LyDo, TrangThai) VALUES
('NP007', 'NV002', '2025-11-15', '2025-11-16', N'Khám sức khỏe định kỳ', N'Được duyệt'),
('NP008', 'NV003', '2025-11-18', '2025-11-20', N'Đi du lịch', N'Được duyệt'),
('NP009', 'NV004', '2025-11-22', '2025-11-23', N'Đưa con đi khám', N'Được duyệt'),
('NP010', 'NV006', '2025-11-24', '2025-11-26', N'Nghỉ phép năm', N'Được duyệt'),
('NP011', 'NV007', '2025-11-28', '2025-11-30', N'Chuẩn bị công việc cuối năm', N'Được duyệt'),
('NP012', 'NV008', '2025-11-20', '2025-11-21', N'Ốm đau', N'Được duyệt'),
('NP013', 'NV009', '2025-11-22', '2025-11-22', N'Đi làm chứng minh thư', N'Được duyệt'),
('NP014', 'NV010', '2025-11-27', '2025-11-28', N'Tham gia đám cưới', N'Được duyệt'),
('NP015', 'NV011', '2025-11-29', '2025-11-30', N'Đưa ba mẹ đi bệnh viện', N'Được duyệt'),
('NP016', 'NV012', '2025-12-01', '2025-12-02', N'Nghỉ phép năm', N'Được duyệt'),
('NP017', 'NV013', '2025-12-03', '2025-12-03', N'Đi công chứng hợp đồng', N'Được duyệt'),
('NP018', 'NV014', '2025-12-08', '2025-12-09', N'Con ốm', N'Được duyệt'),
('NP019', 'NV015', '2025-11-11', '2025-11-13', N'Du lịch nghỉ dưỡng', N'Từ chối'),
('NP020', 'NV016', '2025-11-14', '2025-11-14', N'Đi giải quyết hồ sơ', N'Được duyệt'),
('NP021', 'NV017', '2025-11-17', '2025-11-18', N'Nghỉ bù ca đêm', N'Được duyệt'),
('NP022', 'NV018', '2025-11-19', '2025-11-19', N'Đi ngân hàng', N'Được duyệt'),
('NP023', 'NV019', '2025-11-21', '2025-11-22', N'Tham dự đám tang', N'Được duyệt'),
('NP024', 'NV020', '2025-12-25', '2025-12-27', N'Nghỉ cuối năm', N'Chờ duyệt'),
('NP025', 'NV021', '2025-11-18', '2025-11-19', N'Mệt mỏi cần nghỉ', N'Được duyệt'),
('NP026', 'NV022', '2025-11-23', '2025-11-24', N'Sửa chữa nhà cửa', N'Được duyệt'),
('NP027', 'NV023', '2025-11-26', '2025-11-26', N'Đi học tập', N'Được duyệt'),
('NP028', 'NV024', '2025-11-28', '2025-11-29', N'Giải quyết việc riêng', N'Được duyệt'),
('NP029', 'NV025', '2025-12-02', '2025-12-03', N'Đi khám bệnh', N'Được duyệt'),
('NP030', 'NV026', '2025-12-05', '2025-12-06', N'Về quê thăm ông bà', N'Được duyệt'),
('NP031', 'NV027', '2025-12-07', '2025-12-08', N'Tham gia hội nghị', N'Được duyệt'),
('NP032', 'NV028', '2025-12-09', '2025-12-09', N'Nghỉ phép cá nhân', N'Từ chối'),
('NP033', 'NV029', '2025-12-12', '2025-12-13', N'Đi làm visa', N'Chờ duyệt'),
('NP034', 'NV030', '2025-12-16', '2025-12-17', N'Con đau ốm', N'Chờ duyệt'),
('NP035', 'NV031', '2025-12-20', '2025-12-21', N'Tham gia sinh nhật gia đình', N'Được duyệt'),
('NP036', 'NV032', '2025-12-23', '2025-12-24', N'Chuẩn bị lễ hội', N'Chờ duyệt'),
('NP037', 'NV034', '2025-11-17', '2025-11-18', N'Đi thăm bệnh nhân', N'Được duyệt'),
('NP038', 'NV035', '2025-11-19', '2025-11-20', N'Sốt cao', N'Được duyệt'),
('NP039', 'NV036', '2025-11-21', '2025-11-22', N'Đưa vợ đi sinh', N'Được duyệt'),
('NP040', 'NV037', '2025-11-24', '2025-11-25', N'Tham gia đám giỗ', N'Được duyệt'),
('NP041', 'NV038', '2025-11-30', '2025-12-01', N'Nghỉ phép bù', N'Được duyệt'),
('NP042', 'NV039', '2025-12-04', '2025-12-05', N'Đi làm giấy tờ nhà đất', N'Được duyệt'),
('NP043', 'NV040', '2025-12-10', '2025-12-11', N'Tham gia lễ kỷ niệm', N'Chờ duyệt'),
('NP044', 'NV002', '2025-11-26', '2025-11-27', N'Nghỉ cuối tuần kéo dài', N'Từ chối'),
('NP045', 'NV003', '2025-12-29', '2025-12-31', N'Nghỉ đón năm mới', N'Chờ duyệt'),
('NP046', 'NV004', '2025-01-02', '2025-01-03', N'Nghỉ sau Tết', N'Từ chối'),
('NP047', 'NV006', '2025-12-15', '2025-12-17', N'Khám sức khỏe tổng quát', N'Chờ duyệt'),
('NP048', 'NV007', '2025-12-18', '2025-12-19', N'Đi công tác xa', N'Được duyệt'),
('NP049', 'NV008', '2025-12-22', '2025-12-23', N'Nghỉ bù giờ làm thêm', N'Chờ duyệt'),
('NP050', 'NV009', '2025-12-28', '2025-12-30', N'Chuẩn bị Tết', N'Chờ duyệt');
GO
INSERT INTO HOPDONGLAODONG (MaHD, TenHD, LoaiHD, NgayKyKet, NgayBatDau, NgayKetThuc, MaNV)
VALUES
-- Từ Thử việc sang Chính thức
('HD0033', N'Hợp đồng lao động của NV003', N'Chính thức', '2021-01-10', '2021-01-15', '2024-01-15', 'NV003'),
('HD0034', N'Hợp đồng lao động của NV007', N'Chính thức', '2019-03-05', '2019-03-10', '2022-03-10', 'NV007'),
('HD0035', N'Hợp đồng lao động của NV008', N'Chính thức', '2025-07-25', '2025-08-01', '2028-08-01', 'NV008'),
('HD0036', N'Hợp đồng lao động của NV009', N'Chính thức', '2022-06-01', '2022-06-15', '2025-06-01', 'NV009'),
('HD0037', N'Hợp đồng lao động của NV015', N'Chính thức', '2026-11-25', '2026-12-01', '2029-12-01', 'NV015'),
('HD0038', N'Hợp đồng lao động của NV023', N'Chính thức', '2024-03-10', '2024-03-15', '2027-03-15', 'NV023'),
('HD0039', N'Hợp đồng lao động của NV027', N'Chính thức', '2023-07-20', '2023-08-01', '2026-08-01', 'NV027'),
('HD0040', N'Hợp đồng lao động của NV031', N'Chính thức', '2023-05-15', '2023-05-20', '2026-05-20', 'NV031'),

-- Từ Thời vụ sang Chính thức
('HD0041', N'Hợp đồng lao động của NV011', N'Chính thức', '2025-10-25', '2025-11-01', '2028-11-01', 'NV011'),
('HD0042', N'Hợp đồng lao động của NV017', N'Chính thức', '2020-06-01', '2020-06-05', '2023-06-05', 'NV017'),
('HD0043', N'Hợp đồng lao động của NV020', N'Chính thức', '2024-09-01', '2024-09-05', '2027-09-05', 'NV020'),
('HD0044', N'Hợp đồng lao động của NV025', N'Chính thức', '2025-08-25', '2025-09-01', '2028-09-01', 'NV025'),
('HD0045', N'Hợp đồng lao động của NV029', N'Chính thức', '2024-11-20', '2024-12-01', '2027-12-01', 'NV029'),
-- Nhân viên có nhiều hợp đồng (hợp đồng thứ 2)
('HD0046', N'Hợp đồng lao động thứ 2 của NV002', N'Chính thức', '2025-06-15', '2025-07-01', '2028-07-01', 'NV002'),
('HD0047', N'Hợp đồng lao động thứ 2 của NV005', N'Chính thức', '2024-05-10', '2024-06-01', '2027-06-01', 'NV005'),
('HD0048', N'Hợp đồng lao động thứ 2 của NV010', N'Chính thức', '2025-07-01', '2025-08-01', '2028-08-01', 'NV010'),
('HD0049', N'Hợp đồng lao động thứ 2 của NV014', N'Chính thức', '2024-02-15', '2024-03-01', '2027-03-01', 'NV014'),
('HD0050', N'Hợp đồng lao động thứ 2 của NV018', N'Chính thức', '2025-08-20', '2025-09-01', '2028-09-01', 'NV018');
GO
INSERT INTO TIEUCHI (MaTC, TenTC, Loai, MoTa) VALUES
('TCKL06', N'Không bàn giao công việc đúng quy trình', N'KyLuat', N'Không thực hiện đầy đủ thủ tục bàn giao khi nghỉ phép hoặc chuyển công tác'),
('TCKL07', N'Gây mất đoàn kết nội bộ', N'KyLuat', N'Có hành vi gây xích mích, mâu thuẫn ảnh hưởng đến tập thể'),
('TCKL08', N'Sử dụng điện thoại trong giờ làm việc', N'KyLuat', N'Lạm dụng điện thoại cá nhân gây ảnh hưởng đến hiệu suất làm việc'),
('TCKL09', N'Trốn tránh trách nhiệm', N'KyLuat', N'Không nhận nhiệm vụ được phân công hoặc tránh né khi có lỗi sai'),
('TCKL10', N'Tuỳ tiện tiết lộ thông tin nội bộ', N'KyLuat', N'Cung cấp thông tin công ty cho bên ngoài mà chưa được phép');
GO
INSERT INTO TIEUCHI (MaTC, TenTC, Loai, MoTa) VALUES
('TCKT06', N'Đạt tỷ lệ chuyên cần 100%', N'KhenThuong', N'Không nghỉ phép hoặc đi trễ trong suốt kỳ đánh giá'),
('TCKT07', N'Cải thiện hiệu suất làm việc vượt bậc', N'KhenThuong', N'Tăng hiệu suất làm việc từ 20% trở lên so với kỳ trước'),
('TCKT08', N'Thực hiện xuất sắc nhiệm vụ đột xuất', N'KhenThuong', N'Hoàn thành tốt công việc phát sinh với thời gian gấp'),
('TCKT09', N'Được khách hàng/đối tác khen ngợi', N'KhenThuong', N'Nhận phản hồi tích cực từ khách hàng hoặc đối tác trong quá trình làm việc'),
('TCKT10', N'Tinh thần tự học và phát triển bản thân tốt', N'KhenThuong', N'Hoàn thành các khóa học nâng cao kỹ năng phục vụ công việc');
