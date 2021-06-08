namespace DataLayer.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Configuration;

    public partial class vdrControlCenterContext : DbContext
    {
        public vdrControlCenterContext()
        {
            
        }

        public vdrControlCenterContext(DbContextOptions<vdrControlCenterContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Channels> Channels { get; set; }
        public virtual DbSet<Epg> Epg { get; set; }
        public virtual DbSet<Recordings> Recordings { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<StatusInfo> StatusInfo { get; set; }
        public virtual DbSet<SystemSettings> SystemSettings { get; set; }
        public virtual DbSet<Timers> Timers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(ConfigurationManager.ConnectionStrings["vdrControlCenterDatabase"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channels>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.Property(e => e.Apid)
                    .HasColumnName("APID")
                    .HasMaxLength(50);

                entity.Property(e => e.Caid)
                    .HasColumnName("CAID")
                    .HasMaxLength(50);

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasColumnName("ChannelID")
                    .HasMaxLength(50);

                entity.Property(e => e.ChannelName).HasMaxLength(100);

                entity.Property(e => e.Modtime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Nid)
                    .HasColumnName("NID")
                    .HasMaxLength(50);

                entity.Property(e => e.Parameter).HasMaxLength(50);

                entity.Property(e => e.Params).HasMaxLength(256);

                entity.Property(e => e.ProviderName).HasMaxLength(50);

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasMaxLength(50);

                entity.Property(e => e.Sid)
                    .HasColumnName("SID")
                    .HasMaxLength(50);

                entity.Property(e => e.SignalSource).HasMaxLength(10);

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .HasMaxLength(50);

                entity.Property(e => e.Tpid)
                    .HasColumnName("TPID")
                    .HasMaxLength(50);

                entity.Property(e => e.Vpid)
                    .HasColumnName("VPID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Epg>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("EPG");

                entity.HasIndex(e => new { e.ChannelRecId, e.EventId })
                    .HasDatabaseName("NCI_EventID");

                entity.HasIndex(e => new { e.ChannelRecId, e.StartTime })
                    .HasDatabaseName("NCI_ChannelRecId_StartTime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.GenreCodes).HasMaxLength(100);

                entity.Property(e => e.Modtime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.ShortDescription).HasMaxLength(256);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasColumnName("Duration");

                entity.Property(e => e.Stream).HasMaxLength(1024);

                entity.Property(e => e.TableId)
                    .HasColumnName("TableID")
                    .HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.Version).HasMaxLength(10);

                entity.Property(e => e.Vps)
                    .HasColumnName("VPS")
                    .HasColumnType("datetime");

                entity.Property(e => e.Favourite)
                    .HasColumnName("Favourite")
                    .HasColumnType("bit");

                entity.HasOne(d => d.ChannelRec)
                    .WithMany(p => p.Epg)
                    .HasForeignKey(d => d.ChannelRecId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EPG_Channels");

                entity.Property(e => e.DurationComputed)
                    .HasColumnType("int")
                    .HasComputedColumnSql("([Duration] / (60))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.EndTimeComputed)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(dateadd(second, isnull([Duration], (0)), [StartTime])")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Epg>().Ignore(c => c.ChannelNameComputed);

            modelBuilder.Entity<Recordings>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.Property(e => e.Modtime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.RecordingPath).HasMaxLength(255);

                entity.Property(e => e.RecordingTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.HasIndex(e => e.HostAddress)
                    .HasDatabaseName("IX_Stations")
                    .IsUnique();

                entity.HasIndex(e => e.StationType)
                    .HasDatabaseName("NCI_StationType");

                entity.Property(e => e.EnableWol).HasColumnName("EnableWOL");

                entity.Property(e => e.HostAddress)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.MacAddress).HasMaxLength(17);

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PathToRecordings).HasMaxLength(255);

                entity.Property(e => e.SambaPassword).HasMaxLength(30);

                entity.Property(e => e.SambaUserName).HasMaxLength(30);

                entity.Property(e => e.Sshpassword)
                    .HasColumnName("SSHPassword")
                    .HasMaxLength(30);

                entity.Property(e => e.Sshport).HasColumnName("SSHPort");

                entity.Property(e => e.SshuserName)
                    .HasColumnName("SSHUserName")
                    .HasMaxLength(30);

                entity.Property(e => e.Svdrpport).HasColumnName("SVDRPPort");

                entity.Property(e => e.VdradminPassword)
                    .HasColumnName("VDRAdminPassword")
                    .HasMaxLength(30);

                entity.Property(e => e.VdradminPort).HasColumnName("VDRAdminPort");

                entity.Property(e => e.VdradminUserName)
                    .HasColumnName("VDRAdminUserName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<StatusInfo>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.Property(e => e.UsedPercent).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.SystemSettingsRec)
                    .WithMany(p => p.StatusInfo)
                    .HasForeignKey(d => d.SystemSettingsRecId)
                    .HasConstraintName("FK_StatusInfo_SystemSettingsRecId");
            });

            modelBuilder.Entity<SystemSettings>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.Property(e => e.LastUpdateChannels).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateEpg)
                    .HasColumnName("LastUpdateEPG")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateRecordings).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateStatus).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateTimers).HasColumnType("datetime");

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PathToChannelLogos).HasMaxLength(255);
            });

            modelBuilder.Entity<Timers>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.HasIndex(e => e.ChannelRecId)
                    .HasDatabaseName("NCI_ChannelRecId");

                entity.HasIndex(e => new { e.Title, e.StartTime, e.EndTime })
                    .HasDatabaseName("NCI_Title_StartTime_EndTime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Modtime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.ChannelRec)
                    .WithMany(p => p.Timers)
                    .HasForeignKey(d => d.ChannelRecId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Timers_Channels");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
      
    }
}
