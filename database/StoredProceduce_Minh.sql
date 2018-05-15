--thủ tục kiểm tra đăng nhập là admin
CREATE PROCEDURE KiemTraDangNhap
@TenDN char(10),
@MK char(10)
AS
BEGIN
 SELECT TenDangNhap,MatKhau FROM QLNguoiDung WHERE TenDangNhap=@TenDN AND MatKhau=@MK AND QuyenTruyCap ='admin'
END
--thủ tục kiểm tra đăng nhập là nhân viên
CREATE PROCEDURE KiemTraDangNhapNhanVien
@TenDN char(10),
@MK char(10)
AS
BEGIN
 SELECT TenDangNhap,MatKhau FROM QLNguoiDung WHERE TenDangNhap=@TenDN AND MatKhau=@MK AND QuyenTruyCap ='nv'
END
drop  PROCEDURE KiemTraDangNhapNhanVien
-- thủ tục sửa user
CREATE PROC UPDATE_USER @AccBanDau char(10),@TenDangNhap CHAR(10),@TenNguoiDung nvarCHAR(50),@MatKhau char(10),@HinhAnh nvarchar(50),
@QuyenTruyCap nvarchar(50)
AS
BEGIN
	UPDATE QLNGUOIDUNG SET TenDangNhap=@TenDangNhap,TenNguoiDung=@TenNguoiDung,MatKhau=@MatKhau,HinhAnh=@HinhAnh,QuyenTruyCap=@QuyenTruyCap WHERE TenDangNhap=@AccBanDau
END
--thủ tục xóa user
CREATE PROC DELETE_USER @TenDangNhap CHAR(10)
AS
BEGIN
	DELETE FROM QLNGUOIDUNG WHERE TenDangNhap=@TenDangNhap
END
--thủ tục tạo mới user
CREATE PROC ADD_USER @TenDangNhap CHAR(10),@TenNguoiDung nvarCHAR(50),@MatKhau char(10),@HinhAnh nvarchar(50),
@QuyenTruyCap nvarchar(50)
AS
BEGIN
	INSERT INTO QLNGUOIDUNG(TenDangNhap,TenNguoiDung,MatKhau,HinhAnh,QuyenTruyCap)
	VALUES(@TenDangNhap,@TenNguoiDung,@MatKhau,@HinhAnh,@QuyenTruyCap)
END
--Thêm nv
CREATE PROC ADD_NV @MaNV NCHAR(10),@HoTenNV nvarCHAR(50),@DiaChiNV nvarchar(150),@ChucVu nvarchar(50),@GioiTinh nchar(10),@SdtNV nchar(15),@NgaySinh date
AS
BEGIN
	INSERT INTO NHANVIEN(MaNV,HoTenNV,DiaChiNV,ChucVu,GioiTinh,SdtNV,NgaySinh)
	VALUES(@MaNV, @HoTenNV, @DiaChiNV, @ChucVu, @GioiTinh, @SdtNV, @NgaySinh)
END
--sửa nv
CREATE PROC UPDATE_NHANVIEN  @MaNV NCHAR(10),@HoTenNV nvarCHAR(50),@DiaChiNV nvarchar(150),@ChucVu nvarchar(50),@GioiTinh nchar(10),@SdtNV nchar(15),@NgaySinh date
AS
BEGIN
	UPDATE NHANVIEN SET  HoTenNV = @HoTenNV, DiaChiNV = @DiaChiNV, ChucVu = @ChucVu , GioiTinh = @GioiTinh, SdtNV = @SdtNV, NgaySinh = @NgaySinh
	WHERE MaNV = @MaNV
END
--Xóa nv
CREATE PROC DELETE_NV @MaNV NCHAR(10)
AS
BEGIN
	DELETE FROM NHANVIEN WHERE MaNV=@MaNV
END
--Thêm kh
CREATE PROC ADD_KH @MaKH NCHAR(10),@TenKH nvarCHAR(50),@DiaChiKH nvarchar(150),@SdtKH nchar(15)
AS
BEGIN
	INSERT INTO KHACHHANG(MaKH,TenKH,DiaChiKH,SdtKH)
	VALUES(@MaKH,@TenKH,@DiaChiKH,@SdtKH)
END
--Xóa KH 
CREATE PROC DELETE_KH @MaKH NCHAR(10)
AS
BEGIN
	DELETE FROM KHACHHANG WHERE MaKH=@MaKH
END
--Sửa KH
CREATE PROC UPDATE_KH @MaBanDau NCHAR(10),@MaKH NCHAR(10),@TenKH nvarCHAR(50),@DiaChiKH nvarchar(150),@SdtKH nchar(15)
AS
BEGIN
	UPDATE KHACHHANG SET MaKH = @MaKH , TenKH = @TenKH, DiaChiKH = @DiaChiKH, SdtKH = @SdtKH 
	where MaKH = @MaBanDau
END
