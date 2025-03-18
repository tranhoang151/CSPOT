using CSPOT.Services;
using CSPOT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace CSPOT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITongHopCspotService _tongHopCspotService;

        public HomeController(ITongHopCspotService tongHopCspotService)
        {
            _tongHopCspotService = tongHopCspotService;
        }

        public async Task<IActionResult> Index()
        {
            // Tính toán và lưu dữ liệu vào bảng TongHopCspot
            await _tongHopCspotService.CalculateAndSaveTongHopCspotAsync();

            // Lấy dữ liệu để hiển thị
            var data = await _tongHopCspotService.GetTongHopCspotDataAsync();

            // Tính tổng cộng
            var totals = new TongHopCspot
            {
                Ngay = null, // Không cần ngày cho dòng tổng
                SanLuongQm = data.Sum(t => t.SanLuongQm ?? 0),
                SanLuongQm1 = data.Sum(t => t.SanLuongQm1 ?? 0),
                SanLuongQm2 = data.Sum(t => t.SanLuongQm2 ?? 0),
                SanLuongTb = data.Sum(t => t.SanLuongTb ?? 0),
                SanLuongVt4 = data.Sum(t => t.SanLuongVt4 ?? 0),
                SanLuongVt4Mr = data.Sum(t => t.SanLuongVt4Mr ?? 0),
                SanLuongDh3Mr = data.Sum(t => t.SanLuongDh3Mr ?? 0),
                ChiPhiCm1 = data.Sum(t => t.ChiPhiCm1 ?? 0),
                ChiPhiCm2 = data.Sum(t => t.ChiPhiCm2 ?? 0),
                ChiPhiTb = data.Sum(t => t.ChiPhiTb ?? 0),
                ChiPhiVt4 = data.Sum(t => t.ChiPhiVt4 ?? 0),
                ChiPhiVt4Mr = data.Sum(t => t.ChiPhiVt4Mr ?? 0),
                ChiPhiDh3Mr = data.Sum(t => t.ChiPhiDh3Mr ?? 0),
                TongChiPhi = data.Sum(t => t.TongChiPhi ?? 0)
            };

            // Tạo ViewModel
            var viewModel = new TongHopCspotViewModel
            {
                TongHopCspotList = data,
                Totals = totals
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize] // Chỉ cho phép người dùng đã đăng nhập
        public async Task<IActionResult> ExportToCsv()
        {
            // Lấy dữ liệu
            var data = await _tongHopCspotService.GetTongHopCspotDataAsync();

            // Tạo StringBuilder để lưu trữ nội dung CSV
            var sb = new StringBuilder();

            // Thêm header
            sb.AppendLine("Ngày,Qm,Qm1,Qm2,TB,VT4,VT4-MR,DH3-MR,Cm1,Cm2,TB,VT4,VT4-MR,DH3-MR,Tổng Chi Phí");

            // Thêm dữ liệu
            foreach (var item in data)
            {
                sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                    item.Ngay?.ToString("MM/dd/yyyy") ?? "",
                    item.SanLuongQm?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SanLuongQm1?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SanLuongQm2?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SanLuongTb?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SanLuongVt4?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SanLuongVt4Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SanLuongDh3Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.ChiPhiCm1?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.ChiPhiCm2?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.ChiPhiTb?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.ChiPhiVt4?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.ChiPhiVt4Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.ChiPhiDh3Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.TongChiPhi?.ToString(CultureInfo.InvariantCulture) ?? ""
                ));
            }

            // Tính tổng các cột
            var totals = new TongHopCspot
            {
                SanLuongQm = data.Sum(t => t.SanLuongQm ?? 0),
                SanLuongQm1 = data.Sum(t => t.SanLuongQm1 ?? 0),
                SanLuongQm2 = data.Sum(t => t.SanLuongQm2 ?? 0),
                SanLuongTb = data.Sum(t => t.SanLuongTb ?? 0),
                SanLuongVt4 = data.Sum(t => t.SanLuongVt4 ?? 0),
                SanLuongVt4Mr = data.Sum(t => t.SanLuongVt4Mr ?? 0),
                SanLuongDh3Mr = data.Sum(t => t.SanLuongDh3Mr ?? 0),
                ChiPhiCm1 = data.Sum(t => t.ChiPhiCm1 ?? 0),
                ChiPhiCm2 = data.Sum(t => t.ChiPhiCm2 ?? 0),
                ChiPhiTb = data.Sum(t => t.ChiPhiTb ?? 0),
                ChiPhiVt4 = data.Sum(t => t.ChiPhiVt4 ?? 0),
                ChiPhiVt4Mr = data.Sum(t => t.ChiPhiVt4Mr ?? 0),
                ChiPhiDh3Mr = data.Sum(t => t.ChiPhiDh3Mr ?? 0),
                TongChiPhi = data.Sum(t => t.TongChiPhi ?? 0)
            };

            // Thêm dòng tổng
            sb.AppendLine(string.Format("Tổng,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                totals.SanLuongQm?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.SanLuongQm1?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.SanLuongQm2?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.SanLuongTb?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.SanLuongVt4?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.SanLuongVt4Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.SanLuongDh3Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.ChiPhiCm1?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.ChiPhiCm2?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.ChiPhiTb?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.ChiPhiVt4?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.ChiPhiVt4Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.ChiPhiDh3Mr?.ToString(CultureInfo.InvariantCulture) ?? "",
                totals.TongChiPhi?.ToString(CultureInfo.InvariantCulture) ?? ""
            ));

            // Chuyển đổi sang bytes
            byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());

            // Tạo tên file có thời gian hiện tại
            string fileName = $"TongHopCspot_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            // Trả về file CSV
            return File(buffer, "text/csv", fileName);
        }
    }
}