using CSPOT.Data;
using CSPOT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSPOT.Services
{
    public class TongHopCspotService : ITongHopCspotService
    {
        private readonly QmCspotContext _context;

        public TongHopCspotService(QmCspotContext context)
        {
            _context = context;
        }

        public async Task CalculateAndSaveTongHopCspotAsync()
        {
            // Xóa dữ liệu cũ trong bảng TongHopCspot
            _context.TongHopCspots.RemoveRange(_context.TongHopCspots);
            await _context.SaveChangesAsync();

            // Lấy danh sách ngày duy nhất từ các bảng liên quan
            var distinctDates = _context.Qm1Cspot1s.Select(q => q.Ngày)
                .Union(_context.Qm2TbCspot2s.Select(q => q.Ngày))
                .Distinct()
                .ToList();

            foreach (var date in distinctDates)
            {
                if (date.HasValue)
                {
                    var tongHop = new TongHopCspot
                    {
                        Ngay = date.Value,
                        // Sản lượng Qm1 (Phú Mỹ)
                        SanLuongQm1 = (long?)_context.Qm1Cspot1s
                            .Where(q => q.Ngày == date)
                            .Sum(q => q.Tổng) ?? 0,

                        // Sản lượng chi tiết của Qm2
                        SanLuongTb = (long?)_context.Qm2TbCspot2s
                            .Where(q => q.Ngày == date)
                            .Sum(q => q.Tổng) ?? 0,
                        SanLuongVt4 = (long?)_context.Qm2Vt4Cspot2s
                            .Where(q => q.Ngày == date)
                            .Sum(q => q.Tổng) ?? 0,
                        SanLuongVt4Mr = (long?)_context.Qm2Vt4mrCspot2s
                            .Where(q => q.Ngày == date)
                            .Sum(q => q.Tổng) ?? 0,
                        SanLuongDh3Mr = (long?)_context.Qm2Dh3mrCspot2s
                            .Where(q => q.Ngày == date)
                            .Sum(q => q.Tổng) ?? 0,

                        // Chi phí Cm1 (Phú Mỹ)
                        ChiPhiCm1 = (long?)_context.CspotPmCspot1s
                            .Where(p => p.Ngày == date)
                            .Sum(p => p.Tổng) ?? 0,

                        // Chi phí chi tiết của Cm2
                        ChiPhiTb = (long?)_context.CspotTbCsport2s
                            .Where(c => c.Ngày == date)
                            .Sum(c => c.Tổng) ?? 0,
                        ChiPhiVt4 = (long?)_context.CspotVt4Cspot2s
                            .Where(c => c.Ngày == date)
                            .Sum(c => c.Tổng) ?? 0,
                        ChiPhiVt4Mr = (long?)_context.CspotVt4mrCspot2s
                            .Where(c => c.Ngày == date)
                            .Sum(c => c.Tổng) ?? 0,
                        ChiPhiDh3Mr = (long?)_context.CspotDh3mrCspot2s
                            .Where(c => c.Ngày == date)
                            .Sum(c => c.Tổng) ?? 0
                    };

                    // Tính tổng Qm2 và Qm
                    tongHop.SanLuongQm2 = tongHop.SanLuongTb + tongHop.SanLuongVt4 + tongHop.SanLuongVt4Mr + tongHop.SanLuongDh3Mr;
                    tongHop.SanLuongQm = tongHop.SanLuongQm1 + tongHop.SanLuongQm2;

                    // Tính tổng Cm2 và tổng chi phí
                    tongHop.ChiPhiCm2 = tongHop.ChiPhiTb + tongHop.ChiPhiVt4 + tongHop.ChiPhiVt4Mr + tongHop.ChiPhiDh3Mr;
                    tongHop.TongChiPhi = tongHop.ChiPhiCm1 + tongHop.ChiPhiCm2;

                    _context.TongHopCspots.Add(tongHop);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<TongHopCspot>> GetTongHopCspotDataAsync()
        {
            return await _context.TongHopCspots
                .OrderBy(t => t.Ngay)
                .ToListAsync();
        }
    }
}