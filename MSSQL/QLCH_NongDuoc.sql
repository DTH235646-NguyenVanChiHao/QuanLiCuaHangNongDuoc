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
    MaVaiTro CHAR(10) PRIMARY KEY NOT NULL,
    VaiTro NVARCHAR(100) NOT NULL,
    MoTaVaiTro NVARCHAR(255)
);

CREATE TABLE NhanVien (
    MaNhanVien CHAR(10) PRIMARY KEY NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    MaVaiTro CHAR(10) NOT NULL,
    TenNhanVien NVARCHAR(100) NOT NULL,
    TrangThaiTaiKhoan NVARCHAR(50),
    LamLaiToken NVARCHAR(255),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);

-- Main App Tables
CREATE TABLE NhaCC (
    MaNhaCC CHAR(10) PRIMARY KEY NOT NULL,
    TenNhaCC NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT CHAR(10),
    Email NVARCHAR(100)
);

--Constrail cho enum - validator
ALTER TABLE NhaCC
ADD CONSTRAINT NhaCC_Email_CK
CHECK (Email LIKE '%_@__%.__%');

CREATE TABLE KhachHang (
    MaKH CHAR(10) PRIMARY KEY NOT NULL,
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
    MaSP char(10) PRIMARY KEY NOT NULL,
    TenSP NVARCHAR(100) NOT NULL,
    MoTaSP NVARCHAR(255),
    GiaMua DECIMAL(18,2),
    GiaBan DECIMAL(18,2) NOT NULL,
    SoLuongConLai INT,
    DonViTinh NVARCHAR(50), -- KG - bịch - chai ...
    TrangThai NVARCHAR(50) -- ConHang - SapHetHang - HetHang
);



CREATE TABLE HoaDon (
    MaHD CHAR(10) PRIMARY KEY NOT NULL,
    NgayNhap DATETIME NOT NULL,
    MaNhanVien CHAR(10) NOT NULL,
    MaKH CHAR(10),
    PhanTramGiam DECIMAL(5,2) DEFAULT 0,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
MaPhieuNhap NgayNhap MaNhanVien(invisible) TenNhanVien MaNhaCC(invisible) TenNhaCC SoLuong ThanhTien

CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap CHAR(10) NOT NULL,
    MaSP CHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(18,2), -- GiaMua * SoLuong
    PRIMARY KEY (MaPhieuNhap, MaSP),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
CREATE TABLE PhieuNhap (
    MaPhieuNhap CHAR(10) PRIMARY KEY NOT NULL,
    NgayNhap DATETIME NOT NULL, -- 'YYYY-MM-DDThh:mm:ss'
    MaNhanVien CHAR(10) NOT NULL,
    MaNhaCC CHAR(10) NOT NULL, 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNhaCC) REFERENCES NhaCC(MaNhaCC)
);

CREATE TABLE ChiTietHoaDon (
    MaHD  CHAR(10) NOT NULL,
    MaSP CHAR(10) NOT NULL,
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

Select TenNhanVien from NhanVien where MaNhanVien = 

Mã hoá đơn (MaHD) - Ngày nhập (NgayNhap) - Tên Nhân Viên (TenNhanVien) - Mã Nhân Viên  (MaNhanVien) - Phần trăm giảm (PhanTramGiam) - Mã sản phẩm (MaSP) - Số lượng (SoLuong) - Phần trăm giảm (PhanTramGiam) - ThanhTien
--3. Delete 
--Delete users

delete from ChiTietPhieuNhap where MaPhieuNhap IN (Select MaPhieuNhap from PhieuNhap where MaNhanVien = );

delete from PhieuNhap where MaNhanVien = ;

alter table SanPham
delete column HinhAnh


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
where MaNhanVien =  '' --@MaNhanVien

DBCC CHECKIDENT ('NhanVien', RESEED, 1);


---------------------



---
 SELECT 
                        hd.MaHD,
                        hd.NgayNhap,    
                        nv.MaNhanVien,
                        nv.TenNhanVien,
                        hd.PhanTramGiam,
                        sp.MaSP,
                        sp.TenSP,
                        sp.GiaBan,
                        ct.SoLuong,
                        ct.ThanhTien,
                        kh.MaKH,
                        kh.TenKH,
                        kh.SDT,
                        sp.GiaMua   
                    FROM HoaDon hd
                    INNER JOIN ChiTietHoaDon as ct ON hd.MaHD = ct.MaHD
                    LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                    LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                    LEFT JOIN SanPham sp ON sp.MaSP = ct.MaSP
                    WHERE hd.MaHD LIKE '' --@MaHD--
                    ORDER BY hd.NgayNhap DESC
---


--Thêm dữ liệu
-- 1. Bảng VaiTro (12 vai trò)
INSERT INTO VaiTro (MaVaiTro, VaiTro, MoTaVaiTro) VALUES
('VT001', N'Quản lý', N'Quản lý toàn bộ hệ thống'),
('VT002', N'Nhân viên bán hàng', N'Phụ trách bán hàng và tư vấn khách hàng'),
('VT003', N'Nhân viên kho', N'Quản lý kho và nhập hàng'),
('VT004', N'Kế toán', N'Quản lý tài chính và báo cáo'),
('VT005', N'Thu ngân', N'Phụ trách thanh toán'),
('VT006', N'Bảo vệ', N'Bảo vệ an ninh cửa hàng'),
('VT007', N'Trưởng phòng kinh doanh', N'Quản lý bộ phận kinh doanh'),
('VT008', N'Nhân viên marketing', N'Phụ trách quảng cáo và khuyến mãi'),
('VT009', N'Nhân viên IT', N'Hỗ trợ kỹ thuật hệ thống'),
('VT010', N'Giám đốc', N'Điều hành toàn bộ công ty'),
('VT011', N'Nhân viên chăm sóc khách hàng', N'Hỗ trợ và chăm sóc khách hàng'),
('VT012', N'Thủ kho', N'Kiểm soát xuất nhập kho');

-- 2. Bảng NhanVien (12 nhân viên)
INSERT INTO NhanVien (MaNhanVien, Email, MatKhau, MaVaiTro, TenNhanVien, TrangThaiTaiKhoan, LamLaiToken) VALUES
('NV001', 'nguyenvana@company.com', 'hash123456', 'VT010', N'Nguyễn Văn A', N'Hoạt động', NULL),
('NV002', 'tranthib@company.com', 'hash234567', 'VT001', N'Trần Thị B', N'Hoạt động', NULL),
('NV003', 'levanc@company.com', 'hash345678', 'VT002', N'Lê Văn C', N'Hoạt động', NULL),
('NV004', 'phamthid@company.com', 'hash456789', 'VT003', N'Phạm Thị D', N'Hoạt động', NULL),
('NV005', 'hoangvane@company.com', 'hash567890', 'VT004', N'Hoàng Văn E', N'Hoạt động', NULL),
('NV006', 'vuthif@company.com', 'hash678901', 'VT005', N'Vũ Thị F', N'Hoạt động', NULL),
('NV007', 'dovanang@company.com', 'hash789012', 'VT002', N'Đỗ Văn G', N'Tạm khóa', NULL),
('NV008', 'ngothih@company.com', 'hash890123', 'VT006', N'Ngô Thị H', N'Hoạt động', NULL),
('NV009', 'buivani@company.com', 'hash901234', 'VT007', N'Bùi Văn I', N'Hoạt động', NULL),
('NV010', 'dangthik@company.com', 'hash012345', 'VT008', N'Đặng Thị K', N'Hoạt động', NULL),
('NV011', 'lyvanl@company.com', 'hash112345', 'VT009', N'Lý Văn L', N'Hoạt động', NULL),
('NV012', 'duongthim@company.com', 'hash212345', 'VT011', N'Dương Thị M', N'Hoạt động', NULL);

-- 3. Bảng NhaCC (12 nhà cung cấp)
INSERT INTO NhaCC (MaNhaCC, TenNhaCC, DiaChi, SDT, Email) VALUES
('NCC001', N'Công ty TNHH Thực phẩm An Phát', N'123 Nguyễn Văn Linh, Q.7, TP.HCM', '0901234567', 'anphat@food.vn'),
('NCC002', N'Công ty CP Nông sản Xanh', N'456 Trần Hưng Đạo, Q.1, TP.HCM', '0902345678', 'nongsanxanh@farm.vn'),
('NCC003', N'Nhà phân phối Vinamilk', N'789 Lê Lợi, Q.3, TP.HCM', '0903456789', 'contact@vinamilk.vn'),
('NCC004', N'Công ty Bia Sài Gòn', N'321 Võ Văn Tần, Q.3, TP.HCM', '0904567890', 'saigonbeer@company.vn'),
('NCC005', N'Công ty TNHH Masan Consumer', N'654 Điện Biên Phủ, Q.10, TP.HCM', '0905678901', 'masan@consumer.vn'),
('NCC006', N'Nhà cung cấp Nutifood', N'987 Cách Mạng Tháng 8, Q.3, TP.HCM', '0906789012', 'sales@nutifood.vn'),
('NCC007', N'Công ty Acecook Việt Nam', N'147 Hai Bà Trưng, Q.1, TP.HCM', '0907890123', 'acecook@vietnam.vn'),
('NCC008', N'Công ty Pepsi Việt Nam', N'258 Nam Kỳ Khởi Nghĩa, Q.3, TP.HCM', '0908901234', 'pepsi@vn.com'),
('NCC009', N'Công ty Unilever Việt Nam', N'369 Nguyễn Thị Minh Khai, Q.3, TP.HCM', '0909012345', 'unilever@vietnam.vn'),
('NCC010', N'Công ty CP Kido', N'741 Xô Viết Nghệ Tĩnh, Q.BT, TP.HCM', '0900123456', 'kido@group.vn'),
('NCC011', N'Công ty Tân Hiệp Phát', N'852 Quốc lộ 1A, Bình Chánh, TP.HCM', '0911234567', 'thp@beverage.vn'),
('NCC012', N'Công ty TNHH Sagota', N'963 Lý Thường Kiệt, Q.10, TP.HCM', '0912345678', 'sagota@oil.vn');

-- 4. Bảng KhachHang (12 khách hàng)
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, SDT, Email, TrangThai) VALUES
('KH001', N'Nguyễn Thị Lan', N'12 Nguyễn Trãi, Q.1, TP.HCM', '0981234567', 'lan.nguyen@gmail.com', N'Thân thiết'),
('KH002', N'Trần Văn Nam', N'34 Lê Duẩn, Q.3, TP.HCM', '0982345678', 'nam.tran@yahoo.com', N'Thân thiết'),
('KH003', N'Lê Thị Hoa', N'56 Pasteur, Q.1, TP.HCM', '0983456789', 'hoa.le@outlook.com', N'Không thân thiết'),
('KH004', N'Phạm Văn Hùng', N'78 Hai Bà Trưng, Q.3, TP.HCM', '0984567890', 'hung.pham@gmail.com', N'Thân thiết'),
('KH005', N'Hoàng Thị Mai', N'90 Võ Thị Sáu, Q.3, TP.HCM', '0985678901', 'mai.hoang@yahoo.com', N'Không thân thiết'),
('KH006', N'Vũ Văn Tuấn', N'12 Cống Quỳnh, Q.1, TP.HCM', '0986789012', 'tuan.vu@gmail.com', N'Thân thiết'),
('KH007', N'Đỗ Thị Linh', N'34 Trần Quang Khải, Q.1, TP.HCM', '0987890123', 'linh.do@outlook.com', N'Không thân thiết'),
('KH008', N'Ngô Văn Đức', N'56 Nguyễn Đình Chiểu, Q.3, TP.HCM', '0988901234', 'duc.ngo@yahoo.com', N'Thân thiết'),
('KH009', N'Bùi Thị Phương', N'78 Lý Tự Trọng, Q.1, TP.HCM', '0989012345', 'phuong.bui@gmail.com', N'Không thân thiết'),
('KH010', N'Đặng Văn Tùng', N'90 Đồng Khởi, Q.1, TP.HCM', '0980123456', 'tung.dang@outlook.com', N'Thân thiết'),
('KH011', N'Lý Thị Nga', N'12 Mạc Đĩnh Chi, Q.1, TP.HCM', '0991234567', 'nga.ly@yahoo.com', N'Không thân thiết'),
('KH012', N'Dương Văn Quân', N'34 Phạm Ngũ Lão, Q.1, TP.HCM', '0992345678', 'quan.duong@gmail.com', N'Thân thiết');

-- 5. Bảng SanPham (12 sản phẩm)
INSERT INTO SanPham (MaSP, TenSP, MoTaSP, GiaMua, GiaBan, SoLuongConLai, DonViTinh, TrangThai) VALUES
('SP001', N'Gạo ST25', N'Gạo thơm đặc sản', 18000.00, 22000.00, 500, N'KG', N'ConHang'),
('SP002', N'Sữa tươi Vinamilk', N'Sữa tươi thanh trùng hộp 1L', 28000.00, 35000.00, 200, N'Hộp', N'ConHang'),
('SP003', N'Nước ngọt Coca Cola', N'Lon 330ml', 6000.00, 9000.00, 1000, N'Lon', N'ConHang'),
('SP004', N'Dầu ăn Neptune', N'Chai 1L', 35000.00, 45000.00, 150, N'Chai', N'ConHang'),
('SP005', N'Mì gói Hảo Hảo', N'Thùng 30 gói', 65000.00, 85000.00, 80, N'Thùng', N'ConHang'),
('SP006', N'Trứng gà tươi', N'Vỉ 10 quả', 28000.00, 35000.00, 50, N'Vỉ', N'SapHetHang'),
('SP007', N'Bia Sài Gòn', N'Thùng 24 lon', 230000.00, 280000.00, 100, N'Thùng', N'ConHang'),
('SP008', N'Nước mắm Nam Ngư', N'Chai 650ml', 25000.00, 32000.00, 120, N'Chai', N'ConHang'),
('SP009', N'Đường trắng Biên Hòa', N'Bịch 1KG', 18000.00, 23000.00, 200, N'Bịch', N'ConHang'),
('SP010', N'Bánh quy Cosy', N'Gói 200g', 12000.00, 18000.00, 30, N'Gói', N'SapHetHang'),
('SP011', N'Sữa rửa mặt Senka', N'Tuýp 100g', 45000.00, 65000.00, 60, N'Tuýp', N'ConHang'),
('SP012', N'Giấy vệ sinh Pulppy', N'Lốc 10 cuộn', 32000.00, 42000.00, 150, N'Lốc', N'ConHang');

-- 6. Bảng PhieuNhap (12 phiếu nhập)
INSERT INTO PhieuNhap (MaPhieuNhap, NgayNhap, MaNhanVien, MaNhaCC) VALUES
('PN001', '2025-01-15T08:30:00', 'NV004', 'NCC001'),
('PN002', '2025-01-18T09:15:00', 'NV004', 'NCC002'),
('PN003', '2025-01-22T10:00:00', 'NV004', 'NCC003'),
('PN004', '2025-01-25T14:30:00', 'NV004', 'NCC004'),
('PN005', '2025-02-01T08:00:00', 'NV004', 'NCC005'),
('PN006', '2025-02-05T11:20:00', 'NV004', 'NCC006'),
('PN007', '2025-02-10T09:45:00', 'NV004', 'NCC007'),
('PN008', '2025-02-15T13:30:00', 'NV004', 'NCC008'),
('PN009', '2025-02-20T10:15:00', 'NV004', 'NCC009'),
('PN010', '2025-02-25T15:00:00', 'NV004', 'NCC010'),
('PN011', '2025-03-01T08:45:00', 'NV004', 'NCC011'),
('PN012', '2025-03-05T11:00:00', 'NV004', 'NCC012');

-- 7. Bảng HoaDon (12 hóa đơn)
INSERT INTO HoaDon (MaHD, NgayNhap, MaNhanVien, MaKH, PhanTramGiam) VALUES
('HD001', '2025-03-10T10:30:00', 'NV003', 'KH001', 10.00),
('HD002', '2025-03-11T11:45:00', 'NV006', 'KH002', 10.00),
('HD003', '2025-03-12T14:20:00', 'NV003', NULL, 0.00),
('HD004', '2025-03-13T09:15:00', 'NV006', 'KH004', 10.00),
('HD005', '2025-03-14T15:30:00', 'NV003', NULL, 0.00),
('HD006', '2025-03-15T10:00:00', 'NV006', 'KH006', 10.00),
('HD007', '2025-03-16T13:45:00', 'NV003', NULL, 0.00),
('HD008', '2025-03-17T11:20:00', 'NV006', 'KH008', 10.00),
('HD009', '2025-03-18T16:00:00', 'NV003', NULL, 0.00),
('HD010', '2025-03-19T09:30:00', 'NV006', 'KH010', 10.00),
('HD011', '2025-03-20T14:15:00', 'NV003', NULL, 0.00),
('HD012', '2025-03-21T10:45:00', 'NV006', 'KH012', 10.00);

-- 8. Bảng ChiTietPhieuNhap (12 chi tiết phiếu nhập)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, ThanhTien) VALUES
('PN001', 'SP001', 100, 1800000.00),
('PN002', 'SP002', 50, 1400000.00),
('PN003', 'SP003', 200, 1200000.00),
('PN004', 'SP004', 30, 1050000.00),
('PN005', 'SP005', 20, 1300000.00),
('PN006', 'SP006', 40, 1120000.00),
('PN007', 'SP007', 25, 5750000.00),
('PN008', 'SP008', 50, 1250000.00),
('PN009', 'SP009', 80, 1440000.00),
('PN010', 'SP010', 60, 720000.00),
('PN011', 'SP011', 30, 1350000.00),
('PN012', 'SP012', 50, 1600000.00);

-- 9. Bảng ChiTietHoaDon (12 chi tiết hóa đơn)
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, ThanhTien) VALUES
('HD001', 'SP001', 5, 99000.00),      -- 5 * 22000 * 0.9 = 99000
('HD002', 'SP002', 3, 94500.00),      -- 3 * 35000 * 0.9 = 94500
('HD003', 'SP003', 10, 90000.00),     -- 10 * 9000 = 90000
('HD004', 'SP004', 2, 81000.00),      -- 2 * 45000 * 0.9 = 81000
('HD005', 'SP005', 1, 85000.00),      -- 1 * 85000 = 85000
('HD006', 'SP006', 4, 126000.00),     -- 4 * 35000 * 0.9 = 126000
('HD007', 'SP007', 2, 560000.00),     -- 2 * 280000 = 560000
('HD008', 'SP008', 3, 86400.00),      -- 3 * 32000 * 0.9 = 86400
('HD009', 'SP009', 5, 115000.00),     -- 5 * 23000 = 115000
('HD010', 'SP010', 4, 64800.00),      -- 4 * 18000 * 0.9 = 64800
('HD011', 'SP011', 2, 130000.00),     -- 2 * 65000 = 130000
('HD012', 'SP012', 3, 113400.00);     -- 3 * 42000 * 0.9 = 113400