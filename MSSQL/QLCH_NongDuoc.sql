use QLCH_NongDuoc

--================================Overview==================================-
'''
nvarchar (50 - 100)
id -> int  + tự động tăng khi nhập 
giá bán -> decimal (18,2)
sdt -> char(10)
allow null ngoại trừ id

--Authorization
table NhanVien:	MaNhanVien Email MatKhau MaVaiTro TenNhanVien TrangThaiTaiKhoan HinhAnh LamLaiToken
table VaiTro: MaVaiTro VaiTro MoTaVaiTro 


--Main App
table SanPham: masp tensp MoTasp giamua giaban soluongconlai hinhanh ĐơnVịTinh(KG - bịch - chai ...) TrangThai(ConHang - SapHetHang - HetHang)
table HoaDon: MaHD NgayNhap MaNhanVien MaKH  PhanTramGiam 
table	PhieuNhap: MaPhieuNhap NgayNhap MaNhanVien MaNhaCC
table NhaCC: manhcc tennhacc diachi sdt email
table KhachHang: makh tenkh diachi sdt email trangthai (Thaan thiet - khong than thiet )
table	ChiTietHoaDon: SoLuong ThanhTien(giaban * Soluong *PhanTramGiam) MaHD MaSP
table ChiTietPhieuNhap: SoLuong ThanhTien (giamua * soluong)	MaPhieuNhap MaSP


PhieuNhap(Manv) -> NhanVien(MaNV)
ChiTietPhieuNhap(MaNhacc) -> PhieuNhap(MaNhacc)
ChiTietPhieuNhap(MaSP) -> PhieuNhap(MaSP)

hoadon(manv) -> nv(manv)
Chitiethoadon(masp) -> sp (masp)
chitiethoadon(makh) -> khachhang(makh)

NhanVien(MaVaiTro) -> VaiTro(MaVaiTro)
(localdb)\\MSSQLLocalDB

'''

-- Authorization Tables
CREATE TABLE VaiTro (
    MaVaiTro INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    VaiTro NVARCHAR(100) NOT NULL,
    MoTaVaiTro NVARCHAR(255)
);

CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    MaVaiTro INT NOT NULL,
    TenNhanVien NVARCHAR(100) NOT NULL,
    TrangThaiTaiKhoan NVARCHAR(50),
    HinhAnh NVARCHAR(255),
    LamLaiToken NVARCHAR(255),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);

-- Main App Tables
CREATE TABLE NhaCC (
    MaNhaCC INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    TenNhaCC NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT CHAR(10),
    Email NVARCHAR(100)
);

CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    TenKH NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT CHAR(10),
    Email NVARCHAR(100),
    TrangThai NVARCHAR(50) -- Thân thiết - Không thân thiết
);

CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    TenSP NVARCHAR(100) NOT NULL,
    MoTaSP NVARCHAR(255),
    GiaMua DECIMAL(18,2),
    GiaBan DECIMAL(18,2) NOT NULL,
    SoLuongConLai INT,
    HinhAnh NVARCHAR(255),
    DonViTinh NVARCHAR(50), -- KG - bịch - chai ...
    TrangThai NVARCHAR(50) -- ConHang - SapHetHang - HetHang
);

CREATE TABLE PhieuNhap (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    NgayNhap DATETIME NOT NULL,
    MaNhanVien INT NOT NULL,
    MaNhaCC INT NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNhaCC) REFERENCES NhaCC(MaNhaCC)
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    NgayNhap DATETIME NOT NULL,
    MaNhanVien INT NOT NULL,
    MaKH INT,
    PhanTramGiam DECIMAL(5,2) DEFAULT 0,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(18,2), -- GiaMua * SoLuong
    PRIMARY KEY (MaPhieuNhap, MaSP),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(18,2), -- GiaBan * SoLuong * PhanTramGiam
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

--================================Tables==================================-
--================================Function==================================-
--1. Search
--2. Insert
--3. Delete 
--4. Update