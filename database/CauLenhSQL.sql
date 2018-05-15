create proc HOADONXUAT_ThemHoaDon(
@SoHDX nchar(10),
@NgayXuat date,
@ThanhTienXuat bigint,
@MaNV nchar(10),
@MaKH nchar(10)
)
as
begin
insert into HOADONXUAT values(@SoHDX,@NgayXuat,@ThanhTienXuat,@MaNV,@MaKH)
end
go

create proc HOADONXUAT_SuaHoaDon(
@SoHDX nchar(10),
@NgayXuat date,
@ThanhTienXuat bigint,
@MaNV nchar(10),
@MaKH nchar(10)
)
as
begin
update HAODONXUAT set SoHDX= @SoHDX, NgayXuat=@NgayXuat, ThanhTienXuat=@ThanhTienXuat,MaNV= @MaNV,MaKH = @MaKH where SoHDX = @SoHDX
end
go

create proc HOADONXUAT_XoaHoaDon(
@SoHDX nchar(10)
)
as
begin
delete HAODONXUAT  where SoHDX = @SoHDX
end
go


create proc CHITIETXUAT_ThemChiTietHoaDon(
@SoHDX nchar(10),
@MaLoai nchar(10),
@MaHang nchar(10),
@SoLuong int,
@DonGia bigint
)
as
begin
insert into CHITIETXUAT values(@SoHDX,@MaLoai,@MaHang,@SoLuong,@DonGia)
end
go

create proc CHITIETXUAT_SuaChiTietHoaDon(
@SoHDX nchar(10),
@MaLoai nchar(10),
@MaHang nchar(10),
@SoLuong int,
@DonGia bigint
)
as
begin
update CHITIETXUAT set SoHDX = @SoHDX, MaLoai= @MaLoai,MaHang =@MaHang, SoLuong= @SoLuong, DonGia=@DonGia where SoHDX = @SoHDX
end
go

create proc CHITIETXUAT_XoaChiTietHoaDon(
@ID INT
)
as
begin
delete CHITIETXUAT  where ID = @ID
end
go


select X.SoHDX, X.MaNV, X.MaKH, CTX.MaLoai, CTX.MaHang, X.NgayXuat, CTX.SoLuong, CTX.DonGia 
from HOADONXUAT X, CHITIETXUAT CTX
where X.SoHDX = CTX.SoHDX


select N.SoHDN, N.MaNV, N.MaNCC, CTN.MaLoai, CTN.MaHang, N.NgayNhap, CTN.SoLuongNhap, CTN.DonGiaN,N.ThanhTienNhap 
from HOADONNHAP N, CHITIETNHAP CTN 
where N.SoHDN = CTN.SoHDN


create proc HOADONNHAP_ThemHoaDonN(
@SoHDN nchar(10),
@NgayNhap date,
@ThanhTienNhap bigint,
@MaNV nchar(10),
@MaNCC nchar(10)
)
as
begin
insert into HOADONNHAP values(@SoHDN,@NgayNhap,@ThanhTienNhap,@MaNV,@MaNCC)
end
go

create proc HOADONNHAP_SuaHoaDonN(
@SoHDN nchar(10),
@NgayNhap date,
@ThanhTienNhap bigint,
@MaNV nchar(10),
@MaNCC nchar(10)
)
as
begin
update HOADONNHAP set SoHDN= @SoHDN, NgayNhap=@NgayNhap, ThanhTienNhap=@ThanhTienNhap,MaNV= @MaNV,MaNCC = @MaNCC where SoHDN = @SoHDN
end
go

create proc HOADONNHAP_XoaHoaDonN(
@SoHDN nchar(10)
)
as
begin
delete HOADONNHAP  where SoHDN = @SoHDN
end
go


create proc CHITIETNHAP_ThemChiTietHoaDonN(
@SoHDN nchar(10),
@MaLoai nchar(10),
@MaHang nchar(10),
@SoLuongNhap int,
@DonGiaN bigint,
@HSD date,
@NgaySX date
)
as
begin
insert into CHITIETNHAP values(@SoHDN,@MaLoai,@MaHang,@SoLuongNhap,@DonGiaN, @HSD, @NgaySX)
end
go

create proc CHITIETNHAP_SuaChiTietHoaDonN(
@SoHDN nchar(10),
@MaLoai nchar(10),
@MaHang nchar(10),
@SoLuongNhap int,
@DonGiaN bigint,
@HSD int,
@NgaySX date
)
as
begin
update CHITIETNHAP set SoHDN = @SoHDN, MaLoai= @MaLoai,MaHang =@MaHang, SoLuongNhap= @SoLuongNhap, DonGiaN=@DonGiaN, HSD=@HSD, NgaySX=@NgaySX  where SoHDN = @SoHDN
end
go

create proc CHITIETNHAP_XoaChiTietHoaDonN(
@ID INT
)
as
begin
delete CHITIETNHAP  where ID = @ID
end
go