use QLCH_NongDuoc  -- Library
use QuanLiCuaHangNongDuoc -- My devices

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
    LamLaiToken NVARCHAR(255),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);

-- Đổi hình ảnh từ nvarchar -> varbinary
--Implicit conversion from data type nvarchar to varbinary(max) is not allowed. Use the CONVERT function to run this query.
ALTER TABLE NhanVien
ALTER COLUMN HinhAnh VARBINARY(MAX);

--> xoá và làm lại
-- 1️⃣ Tạo cột mới để lưu ảnh nhị phân
ALTER TABLE NhanVien
ADD HinhAnh VARBINARY(MAX);

-- 2️⃣ (Tùy chọn) Nếu bạn có dữ liệu đường dẫn, có thể xử lý bằng code C# để đọc ảnh và ghi lại ở đây.

-- 3️⃣ Xóa cột cũ
ALTER TABLE NhanVien
DROP COLUMN HinhAnh;







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
--Constrail cho enum - validator
ALTER TABLE KhachHang
ADD CONSTRAINT CK_TrangThai
CHECK (TrangThai IN (N'Thân thiết', N'Không thân thiết'));



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
select * from dbo.NhanVien

select * from KhachHang

-- 
    SELECT 
    nv.MaNhanVien, 
    nv.TenNhanVien, 
    nv.Email, 
    vt.VaiTro, 
    nv.TrangThaiTaiKhoan
FROM NhanVien AS nv
INNER JOIN VaiTro AS vt 
    ON nv.MaVaiTro = vt.MaVaiTro
WHERE 
    (nv.MaNhanVien LIKE '%' + @search + '%' OR nv.TenNhanVien LIKE '%' + @search + '%' OR nv.Email LIKE '%' + @search + '%' OR
     vt.VaiTro LIKE '%' + @search + '%' OR nv.TrangThaiTaiKhoan LIKE '%' + @search + '%')
ORDER BY nv.MaNhanVien DESC
OFFSET @offset ROWS
FETCH NEXT @fetch ROWS ONLY;

--Giải thích : offset + fetch là dùng cho phân trang -> không tải cùng lúc các dữ liệu -> gây chậm
-- offset: số trang bị bỏ qua ban đầu -> fetch là lấy từ trang bị bỏ
--ví dụ : offset = 10 , fetch 11 : bỏ qua 10 dòng đầu : lấy 11 dòng tiếp the0

--2. Insert


-- Insert - Nhan Vien
INSERT INTO NhanVien (Email, MatKhau, MaVaiTro, TenNhanVien, TrangThaiTaiKhoan, LamLaiToken)
VALUES (N'example@gmail.com', N'123456', 1, N'Nguyen Van A', N'Hoạt động', N'Token123');


INSERT INTO KhachHang (TenKH, DiaChi, SDT, Email, TrangThai)
VALUES (N'Nguyễn Văn B', N'123 Lê Lợi, TP.HCM', '0909123456', N'b@example.com', N'Thân thiết');

INSERT INTO KhachHang (TenKH, DiaChi, SDT, Email, TrangThai)
VALUES (N'Nguyễn Văn Hao', N'1234 Lê Lợi, HN', '0909123456', N'A@example.com', N'Thân thiết');

-- Roles
-- Vai trò cơ bản trong hệ thống
INSERT INTO VaiTro (VaiTro, MoTaVaiTro)
VALUES 
(N'Quản trị viên', N'Quản lý toàn bộ hệ thống và người dùng'),
(N'Nhân viên bán hàng', N'Thực hiện nghiệp vụ bán hàng và xuất hóa đơn'),
(N'Nhân viên kho', N'Quản lý hàng hóa, phiếu nhập, và nhà cung cấp');

-- Thêm nhân viên (có liên kết đến VaiTro)
INSERT INTO NhanVien (Email, MatKhau, MaVaiTro, TenNhanVien, TrangThaiTaiKhoan, LamLaiToken)
VALUES 
(N'admin@nongsan.com', N'admin123', 1, N'Nguyễn Văn Quản', N'Hoạt động', N'TokenAdmin'),
(N'nhanvien1@nongsan.com', N'123456', 2, N'Lê Thị Hoa', N'Hoạt động', N'TokenHoa'),
(N'nhanvien2@nongsan.com', N'654321', 3, N'Trần Minh Khôi', N'Hoạt động', N'TokenKhoi');

-- Nhacc
INSERT INTO NhaCC (TenNhaCC, DiaChi, SDT, Email)
VALUES
(N'Công ty Nông Dược Xanh', N'23 Nguyễn Trãi, TP.HCM', '0909000111', N'contact@nongduocxanh.vn'),
(N'Công ty Vật Tư Nông Nghiệp Bình An', N'45 Lê Duẩn, Đà Nẵng', '0909555666', N'support@binhan.com'),
(N'Công ty Phân Bón Miền Tây', N'12 Quốc Lộ 1A, Cần Thơ', '0911222333', N'mientay@gmail.com');


--Khach Hang
INSERT INTO KhachHang (TenKH, DiaChi, SDT, Email, TrangThai)
VALUES
(N'Nguyễn Văn Bình', N'123 Lê Lợi, TP.HCM', '0909123456', N'binh@gmail.com', N'Thân thiết'),
(N'Phạm Thị Hoa', N'56 Nguyễn Huệ, TP.HCM', '0911222333', N'hoapt@gmail.com', N'Không thân thiết'),
(N'Lê Minh Tuấn', N'12 Hai Bà Trưng, Hà Nội', '0988777666', N'tuanle@gmail.com', N'Thân thiết');


-- San pham
INSERT INTO SanPham (TenSP, MoTaSP, GiaMua, GiaBan, SoLuongConLai, HinhAnh, DonViTinh, TrangThai)
VALUES
(N'Thuốc trừ sâu Focamex 100EC', N'Dùng để trừ sâu cuốn lá, sâu đục thân', 35000, 50000, 120, N'img/focamex.jpg', N'chai', N'Còn hàng'),
(N'Phân bón NPK 16-16-8', N'Thúc đẩy sinh trưởng và tăng năng suất cây trồng', 200000, 250000, 80, N'img/npk16-16-8.jpg', N'bao', N'Sắp hết hàng'),
(N'Bình phun thuốc 16L', N'Dụng cụ phun thuốc bảo vệ thực vật', 180000, 230000, 20, N'img/binhphun16l.jpg', N'cái', N'Hết hàng');


-- Phieu nhap
INSERT INTO PhieuNhap (NgayNhap, MaNhanVien, MaNhaCC)
VALUES
('2025-10-10', 3, 1),
('2025-10-15', 3, 2),
('2025-10-20', 3, 3);


-- Chitiet phieu nhap
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, ThanhTien)
VALUES
(1, 1, 100, 100 * 35000),
(1, 2, 50, 50 * 200000),
(2, 3, 10, 10 * 180000);


-- Hoa don
INSERT INTO HoaDon (NgayNhap, MaNhanVien, MaKH, PhanTramGiam)
VALUES
('2025-10-25', 2, 1, 5.0),
('2025-10-28', 2, 2, 0),
('2025-10-30', 2, 3, 10.0);


-- Chi tiet hoa don
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, ThanhTien)
VALUES
(1, 1, 2, 2 * 50000 * (1 - 0.05)),  -- Giảm 5%
(2, 2, 1, 1 * 250000),
(3, 3, 1, 1 * 230000 * (1 - 0.10));  -- Giảm 10%


-- check
SELECT * FROM VaiTro;
SELECT * FROM NhanVien;
SELECT * FROM NhaCC;
SELECT * FROM KhachHang;
SELECT * FROM SanPham;
SELECT * FROM PhieuNhap;
SELECT * FROM ChiTietPhieuNhap;
SELECT * FROM HoaDon;
SELECT * FROM ChiTietHoaDon;


--3. Delete 
--Delete users

delete from ChiTietPhieuNhap where MaPhieuNhap IN (Select MaPhieuNhap from PhieuNhap where MaNhanVien = )

delete from PhieuNhap where MaNhanVien = 




-- Step 1: Delete invoice details related to that employee's invoices
DELETE FROM ChiTietHoaDon
WHERE MaHD IN (
    SELECT MaHD
    FROM HoaDon
    WHERE MaNhanVien = 2
);

-- Step 2: Delete invoices of that employee
DELETE FROM HoaDon
WHERE MaNhanVien = 2;

-- Step 3: Finally delete the employee record
DELETE FROM NhanVien
WHERE MaNhanVien = 2;

--4. Update\
SELECT distinct TrangThaiTaiKhoan FROM  NhanVien

update NhanVien set Email = @Email, MatKhau = @MatKhau , TenNhanVien = @TenNhanVien,MaVaiTro = @MaVaiTro, TrangThaiTaiKhoan = @TrangThaiTaiKhoan
where MaNhanVien = @MaNhanVien

DBCC CHECKIDENT ('NhanVien', RESEED, 1);

select *
from NhanVien
order by MaNhanVien 
desc