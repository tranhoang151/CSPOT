using CSPOT.Services;
using CSPOT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

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
    }
}