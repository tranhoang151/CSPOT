using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSPOT.Models;

[Keyless]
[Table("CspotPM_Cspot1$$")]
public partial class CspotPmCspot1
{
    [Column(TypeName = "datetime")]
    public DateTime? Ngày { get; set; }

    [Column("0h30")]
    public double? _0h30 { get; set; }

    [Column("1h")]
    public double? _1h { get; set; }

    [Column("1h30")]
    public double? _1h30 { get; set; }

    [Column("2h")]
    public double? _2h { get; set; }

    [Column("2h30")]
    public double? _2h30 { get; set; }

    [Column("3h")]
    public double? _3h { get; set; }

    [Column("3h30")]
    public double? _3h30 { get; set; }

    [Column("4h")]
    public double? _4h { get; set; }

    [Column("4h30")]
    public double? _4h30 { get; set; }

    [Column("5h")]
    public double? _5h { get; set; }

    [Column("5h30")]
    public double? _5h30 { get; set; }

    [Column("6h")]
    public double? _6h { get; set; }

    [Column("6h30")]
    public double? _6h30 { get; set; }

    [Column("7h")]
    public double? _7h { get; set; }

    [Column("7h30")]
    public double? _7h30 { get; set; }

    [Column("8h")]
    public double? _8h { get; set; }

    [Column("8h30")]
    public double? _8h30 { get; set; }

    [Column("9h")]
    public double? _9h { get; set; }

    [Column("9h30")]
    public double? _9h30 { get; set; }

    [Column("10h")]
    public double? _10h { get; set; }

    [Column("10h30")]
    public double? _10h30 { get; set; }

    [Column("11h")]
    public double? _11h { get; set; }

    [Column("11h30")]
    public double? _11h30 { get; set; }

    [Column("12h")]
    public double? _12h { get; set; }

    [Column("12h30")]
    public double? _12h30 { get; set; }

    [Column("13h")]
    public double? _13h { get; set; }

    [Column("13h30")]
    public double? _13h30 { get; set; }

    [Column("14h")]
    public double? _14h { get; set; }

    [Column("14h30")]
    public double? _14h30 { get; set; }

    [Column("15h")]
    public double? _15h { get; set; }

    [Column("15h30")]
    public double? _15h30 { get; set; }

    [Column("16h")]
    public double? _16h { get; set; }

    [Column("16h30")]
    public double? _16h30 { get; set; }

    [Column("17h")]
    public double? _17h { get; set; }

    [Column("17h30")]
    public double? _17h30 { get; set; }

    [Column("18h")]
    public double? _18h { get; set; }

    [Column("18h30")]
    public double? _18h30 { get; set; }

    [Column("19h")]
    public double? _19h { get; set; }

    [Column("19h30")]
    public double? _19h30 { get; set; }

    [Column("20h")]
    public double? _20h { get; set; }

    [Column("20h30")]
    public double? _20h30 { get; set; }

    [Column("21h")]
    public double? _21h { get; set; }

    [Column("21h30")]
    public double? _21h30 { get; set; }

    [Column("22h")]
    public double? _22h { get; set; }

    [Column("22h30")]
    public double? _22h30 { get; set; }

    [Column("23h")]
    public double? _23h { get; set; }

    [Column("23h30")]
    public double? _23h30 { get; set; }

    [Column("24h")]
    public double? _24h { get; set; }

    public double? Tổng { get; set; }
}
