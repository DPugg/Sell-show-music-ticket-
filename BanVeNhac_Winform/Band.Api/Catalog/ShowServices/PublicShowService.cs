using Band.Data.EF;
using Band.Data.Entities;
using Band.ViewModels.Catalog.Show.Public;
using Band.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.Api.Catalog.ShowServices
{
    public class PublicShowService : IPublicShowService
    {
        private readonly BandDbContext _context;
        private static readonly string _from = "n18dccn157@student.ptithcm.edu.vn"; // Email của Sender (của bạn)
        private static readonly string _pass = "n18dccn157#140800"; // Mật khẩu Email của Sender (của bạn)
        public static string MaXacNhan;
        public static int AllowPayment = 0;
        public static string STK_nh ;
        public static string SDT;
        public static int SoLuong;
        public static ShowVsLoaiVe chiTietVe;
        public static decimal TotalCost;


        public PublicShowService(BandDbContext context)
        {
            _context = context;
        }
        public string layMaXacNhan()
        {
            string MaXacNhan;
            Random rd = new Random();
            MaXacNhan = rd.Next(100000, 999999).ToString();
            return MaXacNhan;
        }

        public string SendMail(string sendto, string subject, string content)
        {
            //sendto: Email receiver (người nhận)
            //subject: Tiêu đề email
            //content: Nội dung của email, bạn có thể viết mã HTML
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin l�-i
            MailMessage mail = new MailMessage();
            mail.From = new System.Net.Mail.MailAddress("n18dccn157@student.ptithcm.edu.vn");

            // The important part -- configuring the SMTP client
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            smtp.UseDefaultCredentials = false; // [3] Changed this
            smtp.Credentials = new NetworkCredential(_from, _pass);
            // [4] Added this. Note, first parameter is NOT string.
            smtp.Host = "smtp.gmail.com";

            //recipient address
            mail.To.Add(new MailAddress(sendto));

            //Formatted mail body
            mail.IsBodyHtml = true;
            string st = content;

            mail.Body = st;
            mail.Subject = subject;
            smtp.Send(mail);
            return content;
        }


        public async Task<List<PublicShowGetAllVm>> GetAll()
        {
            var dsShow = await _context.ShowDbo.Where(p => p.ThoiDiemBieuDien > DateTime.Now 
                            && p.ThoiDiemBieuDien < DateTime.Now.AddMonths(1)).
                            Select(p => new { p.IdShow, p.TenShow, p.DiaDiem, p.ThoiDiemBieuDien, p.ThoiDiemMoBan }).ToListAsync();
            
            var dsShowVm = new List<PublicShowGetAllVm>();

            //  var count = (dsShow.Count>3)? 3: dsShow.Count;
            var count = dsShow.Count;
            for (int i=0; i<count; i++)
            {
                var hinhAnhFromDb = (from sa in _context.ShowVsHinhAnhDbo
                                          join a in _context.HinhAnhDbo on sa.IdAnh equals a.IdAnh
                                            where sa.IdShow.Equals(dsShow[i].IdShow) && a.IdLoai.Equals((int)ImageType.IMG_SHOW)
                                            select a.Anh).FirstOrDefault();
                /*                var imgList = new List<byte[]>();
                                foreach (var i in dsHinhAnhFromDb)
                                {
                                    imgList.Add(i);
                                }*/
                var dsChiTietVeFromDb = await (from l in _context.LoaiVeDbo
                                               join sl in _context.ShowVsLoaiVeDbo on l.IdLoaiVe equals sl.IdLoaiVe
                                               where sl.IdShow.Equals(dsShow[i].IdShow)
                                               select new { l.IdLoaiVe, l.TenLoai, l.ChiTiet, sl.Gia, sl.ConLai }).ToListAsync();
                var dsChiTietVe = new List<PublicChiTietVeVm>();
                foreach (var x in dsChiTietVeFromDb)
                {
                    dsChiTietVe.Add(new PublicChiTietVeVm()
                    {
                        IdLoaiVe = x.IdLoaiVe,
                        TenLoai = x.TenLoai,
                        ChiTiet = x.ChiTiet,
                        Gia = x.Gia,
                        ConLai = x.ConLai
                    });
                }


                dsShowVm.Add(new PublicShowGetAllVm()
                {
                    IdShow = dsShow[i].IdShow,
                    TenShow = dsShow[i].TenShow,
                    DiaDiem = dsShow[i].DiaDiem,
                    DsLoaiVe = dsChiTietVe,
                    NgayBieuDien = dsShow[i].ThoiDiemBieuDien.Date,
                    ThoiDiemMoBan = dsShow[i].ThoiDiemMoBan,
                    HinhAnh = hinhAnhFromDb,
                    
                }) ;
            }

            return dsShowVm;
        }

        public async Task<PublicGetByIdShowVm> GetById(int idShow)
        {
            var show = await _context.ShowDbo.FindAsync(idShow);
            if (show == null) return null;
            var dsHinhAnhFromDb = await (from sa in _context.ShowVsHinhAnhDbo
                                   join a in _context.HinhAnhDbo on sa.IdAnh equals a.IdAnh
                                   where sa.IdShow.Equals(idShow) && a.IdLoai.Equals((int)ImageType.IMG_SHOW)
                                   select a.Anh).ToListAsync();

            var dsChiTietVeFromDb = await (from l in _context.LoaiVeDbo
                                           join sl in _context.ShowVsLoaiVeDbo on l.IdLoaiVe equals sl.IdLoaiVe
                                           where sl.IdShow.Equals(idShow)
                                           select new { l.IdLoaiVe,l.TenLoai, l.ChiTiet, sl.Gia, sl.ConLai }).ToListAsync();

            var dsChiTietVe = new List<PublicChiTietVeVm>();
            foreach (var x in dsChiTietVeFromDb)
            {
                dsChiTietVe.Add(new PublicChiTietVeVm()
                {
                    IdLoaiVe = x.IdLoaiVe,
                    TenLoai=x.TenLoai,
                    ChiTiet =x.ChiTiet,
                    Gia = x.Gia,
                    ConLai=x.ConLai
                });
            }

            var dsHinhAnh = new List<byte[]>();
            foreach (var x in dsHinhAnhFromDb)
            {
                dsHinhAnh.Add(x);
            }

            var showVm = new PublicGetByIdShowVm()
            {
                IdShow=show.IdShow,
                DiaDiem = show.DiaDiem,
                TenShow = show.TenShow,
                ThoiDiemBieuDien = show.ThoiDiemBieuDien,
                ThoiDiemMoBan = show.ThoiDiemMoBan,
                DsHinhAnh=dsHinhAnh,
                DsLoaiVe = dsChiTietVe,
            };
            return showVm;
        }

        public async Task<int> Booking(BookingRequest request)
        {
            Console.WriteLine("request:========================="+request);
            SDT = request.SDT;
            STK_nh = request.Account;
            SoLuong = request.SoLuong;

            var show = await _context.ShowDbo.FindAsync(request.IdShow);
            if (show.ThoiDiemMoBan > DateTime.Now || show.ThoiDiemBieuDien < DateTime.Now.AddHours(1)) return (int)BookingErrorCode.OFF_HOURS;
            var tmpHoaDon = await (from h in _context.HoaDonDbo
                                   join sl in _context.ShowVsLoaiVeDbo on h.IdShowVsLoaiVe equals sl.IdShowVsLoaiVe
                                   where sl.IdShow.Equals(request.IdShow) && h.SDT.Equals(request.SDT)
                                   select h).FirstOrDefaultAsync();
            if (tmpHoaDon != null) return (int)BookingErrorCode.BOOKED;


            chiTietVe = await (from h in _context.ShowVsLoaiVeDbo                            
                               where h.IdShow.Equals(request.IdShow) && h.IdLoaiVe.Equals(request.IdLoaiVe)
                               select h).FirstOrDefaultAsync();

            TotalCost = SoLuong * chiTietVe.Gia;

            if (chiTietVe.ConLai < SoLuong)
            {
                Console.WriteLine("===============con lai " + chiTietVe.ConLai + " so luong" + request.SoLuong);
                return (int)BookingErrorCode.SOLD_OUT;
            }


            //=====================gui mail ma xac nhan===============
            var STK = await (from bank in _context.BankDbo
                             where bank.IdTaiKhoan.Equals(request.Account)
                             select bank.IdTaiKhoan).FirstOrDefaultAsync();
            if(STK != null)
            {
                MaXacNhan = layMaXacNhan();
                SendMail(request.email, "Mã Xác Nhận", MaXacNhan);
                return 0;
            }
            else return (int)BankErrorCode.UNCORRECT_STK;

        }




        public async Task<HoaDonVm> GetHoaDonById(int idHoaDon)
        {
            var hoaDon = await _context.HoaDonDbo.FindAsync(idHoaDon);
            var dsVeFromDb = await (from h in _context.HoaDonDbo
                                    join v in _context.VeDbo on h.IdHoaDon equals v.IDHoaDon
                                    where h.IdHoaDon.Equals(idHoaDon)
                                    select v.MaSoVe).ToListAsync();
            var showVsLoaiVe = await (from sv in _context.ShowVsLoaiVeDbo
                              join s in _context.ShowDbo on sv.IdShow equals s.IdShow
                              where sv.IdShowVsLoaiVe.Equals(hoaDon.IdShowVsLoaiVe)
                              select new { s.DiaDiem, s.TenShow, s.ThoiDiemBieuDien, sv.Gia, sv.IdLoaiVe }).FirstOrDefaultAsync();
            var loaiVe = await _context.LoaiVeDbo.FindAsync(showVsLoaiVe.IdLoaiVe);
            var dsVe = new List<string>();
            foreach(var x in dsVeFromDb)
            {
                dsVe.Add(x);
            }
            var result = new HoaDonVm()
            {
                DiaDiem = showVsLoaiVe.DiaDiem,
                DsMaSoVe = dsVe,
                Gia = showVsLoaiVe.Gia,
                IdHoaDon = hoaDon.IdHoaDon,
                NgayGiaoDich = hoaDon.NgayGiaoDich,
                SDT = hoaDon.SDT,
                SoLuong = hoaDon.SoLuong,
                TenLoai = loaiVe.TenLoai,
                TenShow = showVsLoaiVe.TenShow,
                ThoiDiemBieuDien = showVsLoaiVe.ThoiDiemBieuDien
            };
            return result;
        }

        public async Task<int> ReceiveCode(ReceiveCodeRequest request)
        {
            if (request.MaXacNhan.Equals(MaXacNhan))
            {
                AllowPayment = 1;
                
                var srcAcc = await _context.BankDbo.FindAsync(STK_nh);
                if (srcAcc == null) return (int)BankErrorCode.LOGIN_FAILED;


 
                if (srcAcc.SoDu < TotalCost) return (int)BankErrorCode.BALANCE_NOT_ENOUGH;
                else
                {
                     srcAcc.SoDu = srcAcc.SoDu - TotalCost;
                    _context.BankDbo.Update(srcAcc);
                    _context.SaveChanges();

                    //  return await _context.SaveChangesAsync();

                    var hoaDon = new HoaDon()
                    {
                        SoLuong = SoLuong,
                        SDT = SDT,
                        IdShowVsLoaiVe = chiTietVe.IdShowVsLoaiVe,
                 //       ShowVsLoaiVe = chiTietVe,
                        NgayGiaoDich = DateTime.Now,
                        DsVe = new List<Ve>()
                    };
                  //  await _context.AddAsync(hoaDon);
                    //               await _context.SaveChangesAsync();
                    _context.HoaDonDbo.Add(hoaDon);
                    _context.SaveChanges();

                    Random ran = new Random();
                    int preRanNumber = -1;
                    for (int i = 0; i < SoLuong; i++)
                    {
                        int randomNum = ran.Next(1000);
                        while (randomNum == preRanNumber)
                            randomNum = ran.Next(1000);
                        hoaDon.DsVe.Add(new Ve()
                        {
                            IDHoaDon =hoaDon.IdHoaDon,
                       //     HoaDon = hoaDon,
                            MaSoVe = i.ToString() + hoaDon.NgayGiaoDich.ToString("MMddyyyyhhmmssfffffff") + $"{randomNum}".PadLeft(3, '0')
                        });
                        preRanNumber = randomNum;
                    }
                        chiTietVe.ConLai -= SoLuong;
                    //               await _context.SaveChangesAsync();
                    //await _context.AddRangeAsync();
                    _context.ShowVsLoaiVeDbo.Update(chiTietVe);
                    _context.SaveChanges();
                    return hoaDon.IdHoaDon;
                }
                
                
                

            }
            else
            {
                AllowPayment = 0;
                return (int)BookingErrorCode.UNCORRECT_VERIFICATION;
            }
        }
    }
}
