using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Band.Data.Migrations
{
    public partial class addIdNhom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOAIANH",
                columns: table => new
                {
                    IdLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIANH", x => x.IdLoai);
                });

            migrationBuilder.CreateTable(
                name: "LOAIVE",
                columns: table => new
                {
                    IdLoaiVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChiTiet = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIVE", x => x.IdLoaiVe);
                });

            migrationBuilder.CreateTable(
                name: "NGANHANG",
                columns: table => new
                {
                    IdTaiKhoan = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(330)", maxLength: 330, nullable: false),
                    SoDu = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGANHANG", x => x.IdTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "NHOMNHAC",
                columns: table => new
                {
                    IdNhom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DebutDate = table.Column<DateTime>(type: "date", nullable: false),
                    CongTy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChiTiet = table.Column<string>(type: "ntext", nullable: true),
                    Spotify = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AppleMusic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Logo = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHOMNHAC", x => x.IdNhom);
                });

            migrationBuilder.CreateTable(
                name: "SHOW",
                columns: table => new
                {
                    IdShow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenShow = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ThoiDiemBieuDien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiDiemMoBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOW", x => x.IdShow);
                });

            migrationBuilder.CreateTable(
                name: "THANHVIEN",
                columns: table => new
                {
                    IdThanhVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgheDanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKhaiSinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    QuocTich = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DebutDate = table.Column<DateTime>(type: "date", nullable: false),
                    TieuSu = table.Column<string>(type: "ntext", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THANHVIEN", x => x.IdThanhVien);
                });

            migrationBuilder.CreateTable(
                name: "VAITRO",
                columns: table => new
                {
                    IdVaiTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITRO", x => x.IdVaiTro);
                    table.UniqueConstraint("AK_VAITRO_TenVaiTro", x => x.TenVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "HINHANH",
                columns: table => new
                {
                    IdAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anh = table.Column<byte[]>(type: "image", nullable: false),
                    IdLoai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINHANH", x => x.IdAnh);
                    table.ForeignKey(
                        name: "FK_HINHANH_LOAIANH_IdLoai",
                        column: x => x.IdLoai,
                        principalTable: "LOAIANH",
                        principalColumn: "IdLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETVE_SHOW",
                columns: table => new
                {
                    IdShow = table.Column<int>(type: "int", nullable: false),
                    IdLoaiVe = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "numeric", nullable: false),
                    SoLuongBanRa = table.Column<int>(type: "int", nullable: false),
                    ConLai = table.Column<int>(type: "int", nullable: false),
                    IdShowVsLoaiVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETVE_SHOW", x => new { x.IdLoaiVe, x.IdShow });
                    table.UniqueConstraint("AK_CHITIETVE_SHOW_IdShowVsLoaiVe", x => x.IdShowVsLoaiVe);
                    table.ForeignKey(
                        name: "FK_CHITIETVE_SHOW_LOAIVE_IdLoaiVe",
                        column: x => x.IdLoaiVe,
                        principalTable: "LOAIVE",
                        principalColumn: "IdLoaiVe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETVE_SHOW_SHOW_IdShow",
                        column: x => x.IdShow,
                        principalTable: "SHOW",
                        principalColumn: "IdShow",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "THANHVIEN_VAITRO",
                columns: table => new
                {
                    IdThanhVien = table.Column<int>(type: "int", nullable: false),
                    IdVaiTro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THANHVIEN_VAITRO", x => new { x.IdThanhVien, x.IdVaiTro });
                    table.ForeignKey(
                        name: "FK_THANHVIEN_VAITRO_THANHVIEN_IdThanhVien",
                        column: x => x.IdThanhVien,
                        principalTable: "THANHVIEN",
                        principalColumn: "IdThanhVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THANHVIEN_VAITRO_VAITRO_IdVaiTro",
                        column: x => x.IdVaiTro,
                        principalTable: "VAITRO",
                        principalColumn: "IdVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ANHTHANHVIEN",
                columns: table => new
                {
                    IdThanhVien = table.Column<int>(type: "int", nullable: false),
                    IdAnh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANHTHANHVIEN", x => new { x.IdAnh, x.IdThanhVien });
                    table.ForeignKey(
                        name: "FK_ANHTHANHVIEN_HINHANH_IdAnh",
                        column: x => x.IdAnh,
                        principalTable: "HINHANH",
                        principalColumn: "IdAnh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ANHTHANHVIEN_THANHVIEN_IdThanhVien",
                        column: x => x.IdThanhVien,
                        principalTable: "THANHVIEN",
                        principalColumn: "IdThanhVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHOW_HINHANH",
                columns: table => new
                {
                    IdShow = table.Column<int>(type: "int", nullable: false),
                    IdAnh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOW_HINHANH", x => new { x.IdAnh, x.IdShow });
                    table.ForeignKey(
                        name: "FK_SHOW_HINHANH_HINHANH_IdAnh",
                        column: x => x.IdAnh,
                        principalTable: "HINHANH",
                        principalColumn: "IdAnh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHOW_HINHANH_SHOW_IdShow",
                        column: x => x.IdShow,
                        principalTable: "SHOW",
                        principalColumn: "IdShow",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    IdHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SDT = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NgayGiaoDich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdShowVsLoaiVe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.IdHoaDon);
                    table.ForeignKey(
                        name: "FK_HOADON_CHITIETVE_SHOW_IdShowVsLoaiVe",
                        column: x => x.IdShowVsLoaiVe,
                        principalTable: "CHITIETVE_SHOW",
                        principalColumn: "IdShowVsLoaiVe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VE",
                columns: table => new
                {
                    MaSoVe = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    IDHoaDon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VE", x => x.MaSoVe);
                    table.ForeignKey(
                        name: "FK_VE_HOADON_IDHoaDon",
                        column: x => x.IDHoaDon,
                        principalTable: "HOADON",
                        principalColumn: "IdHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANHTHANHVIEN_IdThanhVien",
                table: "ANHTHANHVIEN",
                column: "IdThanhVien");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETVE_SHOW_IdShow",
                table: "CHITIETVE_SHOW",
                column: "IdShow");

            migrationBuilder.CreateIndex(
                name: "IX_HINHANH_IdLoai",
                table: "HINHANH",
                column: "IdLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_IdShowVsLoaiVe",
                table: "HOADON",
                column: "IdShowVsLoaiVe");

            migrationBuilder.CreateIndex(
                name: "IX_NGANHANG_IdTaiKhoan",
                table: "NGANHANG",
                column: "IdTaiKhoan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SHOW_HINHANH_IdShow",
                table: "SHOW_HINHANH",
                column: "IdShow");

            migrationBuilder.CreateIndex(
                name: "IX_THANHVIEN_VAITRO_IdVaiTro",
                table: "THANHVIEN_VAITRO",
                column: "IdVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_VE_IDHoaDon",
                table: "VE",
                column: "IDHoaDon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANHTHANHVIEN");

            migrationBuilder.DropTable(
                name: "NGANHANG");

            migrationBuilder.DropTable(
                name: "NHOMNHAC");

            migrationBuilder.DropTable(
                name: "SHOW_HINHANH");

            migrationBuilder.DropTable(
                name: "THANHVIEN_VAITRO");

            migrationBuilder.DropTable(
                name: "VE");

            migrationBuilder.DropTable(
                name: "HINHANH");

            migrationBuilder.DropTable(
                name: "THANHVIEN");

            migrationBuilder.DropTable(
                name: "VAITRO");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "LOAIANH");

            migrationBuilder.DropTable(
                name: "CHITIETVE_SHOW");

            migrationBuilder.DropTable(
                name: "LOAIVE");

            migrationBuilder.DropTable(
                name: "SHOW");
        }
    }
}
