using System;
using System.Collections.Generic;
using CSPOT.Models;
using Microsoft.EntityFrameworkCore;

namespace CSPOT.Data;

public partial class QmCspotContext : DbContext
{
    public QmCspotContext()
    {
    }

    public QmCspotContext(DbContextOptions<QmCspotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CspotDh3mrCspot2> CspotDh3mrCspot2s { get; set; }

    public virtual DbSet<CspotPmCspot1> CspotPmCspot1s { get; set; }

    public virtual DbSet<CspotTbCsport2> CspotTbCsport2s { get; set; }

    public virtual DbSet<CspotVt4Cspot2> CspotVt4Cspot2s { get; set; }

    public virtual DbSet<CspotVt4mrCspot2> CspotVt4mrCspot2s { get; set; }

    public virtual DbSet<PmCspot1> PmCspot1s { get; set; }

    public virtual DbSet<PmCspot2> PmCspot2s { get; set; }

    public virtual DbSet<Qm1Cspot1> Qm1Cspot1s { get; set; }

    public virtual DbSet<Qm2Dh3mrCspot2> Qm2Dh3mrCspot2s { get; set; }

    public virtual DbSet<Qm2TbCspot2> Qm2TbCspot2s { get; set; }

    public virtual DbSet<Qm2Vt4Cspot2> Qm2Vt4Cspot2s { get; set; }

    public virtual DbSet<Qm2Vt4mrCspot2> Qm2Vt4mrCspot2s { get; set; }

    public virtual DbSet<TongHopCspot> TongHopCspots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-409OOSHC\\SQLEXPRESS;Initial Catalog=QmCspot;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TongHopCspot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TongHopC__3214EC2791524868");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
