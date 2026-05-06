USE QUANLYNHANSU;
GO

-- =========== BẢNG NGHI PHÉP ===========
IF OBJECT_ID('dbo.NGHIPHEP','U') IS NULL
BEGIN
    CREATE TABLE dbo.NGHIPHEP (
        MaNP CHAR(8) NOT NULL CONSTRAINT PK_NGHIPHEP PRIMARY KEY,
        MaNV CHAR(5) NOT NULL,
        TuNgay DATE NOT NULL,
        DenNgay DATE NOT NULL,
        LyDo NVARCHAR(200) NULL,
        TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_NP_TrangThai DEFAULT N'Chờ duyệt',
        CONSTRAINT CK_NP_TrangThai CHECK (TrangThai IN (N'Chờ duyệt', N'Được duyệt', N'Từ chối')),
        CONSTRAINT CK_NP_KhoangNgay CHECK (TuNgay <= DenNgay),
        CONSTRAINT FK_NP_NV FOREIGN KEY (MaNV) REFERENCES dbo.NHANVIEN(MaNV)
    );
END
GO

-- =========== BẢNG TIÊU CHÍ KHEN THƯỞNG / KỶ LUẬT ===========
IF OBJECT_ID('dbo.TIEUCHI','U') IS NULL
BEGIN
    CREATE TABLE dbo.TIEUCHI (
        MaTC CHAR(6) NOT NULL CONSTRAINT PK_TIEUCHI PRIMARY KEY,
        TenTC NVARCHAR(100) NOT NULL,
        Loai NVARCHAR(15) NOT NULL,
        MoTa NVARCHAR(200) NULL,
        CONSTRAINT CK_TC_Loai CHECK (Loai IN (N'KhenThuong', N'KyLuat'))
    );
END
GO

-- =========== BẢNG KHEN THƯỞNG ===========
IF OBJECT_ID('dbo.KHENTHUONG','U') IS NULL
BEGIN
    CREATE TABLE dbo.KHENTHUONG (
        MaKT CHAR(8) NOT NULL CONSTRAINT PK_KHENTHUONG PRIMARY KEY,
        MaNV CHAR(5) NOT NULL,
        MaTC CHAR(6) NOT NULL,
        NgayKT DATE NOT NULL,
        GhiChu NVARCHAR(200) NULL,
        CONSTRAINT FK_KT_NV FOREIGN KEY (MaNV) REFERENCES dbo.NHANVIEN(MaNV),
        CONSTRAINT FK_KT_TC FOREIGN KEY (MaTC) REFERENCES dbo.TIEUCHI(MaTC)
    );
END
GO

-- =========== BẢNG KỶ LUẬT ===========
IF OBJECT_ID('dbo.KYLUAT','U') IS NULL
BEGIN
    CREATE TABLE dbo.KYLUAT (
        MaKL CHAR(8) NOT NULL CONSTRAINT PK_KYLUAT PRIMARY KEY,
        MaNV CHAR(5) NOT NULL,
        MaTC CHAR(6) NOT NULL,
        NgayKL DATE NOT NULL,
        GhiChu NVARCHAR(200) NULL,
        CONSTRAINT FK_KL_NV FOREIGN KEY (MaNV) REFERENCES dbo.NHANVIEN(MaNV),
        CONSTRAINT FK_KL_TC FOREIGN KEY (MaTC) REFERENCES dbo.TIEUCHI(MaTC)
    );
END
GO

IF OBJECT_ID('dbo.TIEUCHI','U') IS NOT NULL
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.TIEUCHI WHERE MaTC = 'TC0001')
        INSERT INTO dbo.TIEUCHI(MaTC, TenTC, Loai, MoTa)
        VALUES ('TC0001', N'Thanh tích xuất sắc', N'KhenThuong', N'Thanh tích tháng');

    IF NOT EXISTS (SELECT 1 FROM dbo.TIEUCHI WHERE MaTC = 'TC0002')
        INSERT INTO dbo.TIEUCHI(MaTC, TenTC, Loai, MoTa)
        VALUES ('TC0002', N'Vi phạm nội quy', N'KyLuat', N'Đi trễ/bỏ việc');
END
GO
