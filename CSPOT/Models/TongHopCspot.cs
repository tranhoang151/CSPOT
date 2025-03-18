using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSPOT.Models;

[Table("TongHopCspot")]
public partial class TongHopCspot
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ngay", TypeName = "datetime")]
    public DateTime? Ngay { get; set; }

    [Column("san_luong_qm")]
    public long? SanLuongQm { get; set; }

    [Column("san_luong_qm1")]
    public long? SanLuongQm1 { get; set; }

    [Column("san_luong_qm2")]
    public long? SanLuongQm2 { get; set; }

    [Column("san_luong_tb")]
    public long? SanLuongTb { get; set; }

    [Column("san_luong_vt4")]
    public long? SanLuongVt4 { get; set; }

    [Column("san_luong_vt4_mr")]
    public long? SanLuongVt4Mr { get; set; }

    [Column("san_luong_dh3_mr")]
    public long? SanLuongDh3Mr { get; set; }

    [Column("chi_phi_cm1")]
    public long? ChiPhiCm1 { get; set; }

    [Column("chi_phi_cm2")]
    public long? ChiPhiCm2 { get; set; }

    [Column("chi_phi_tb")]
    public long? ChiPhiTb { get; set; }

    [Column("chi_phi_vt4")]
    public long? ChiPhiVt4 { get; set; }

    [Column("chi_phi_vt4_mr")]
    public long? ChiPhiVt4Mr { get; set; }

    [Column("chi_phi_dh3_mr")]
    public long? ChiPhiDh3Mr { get; set; }

    [Column("tong_chi_phi")]
    public long? TongChiPhi { get; set; }
}
