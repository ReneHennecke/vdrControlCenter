namespace DataLayer.Models
{
    using Microsoft.EntityFrameworkCore;

    public partial class vdrControlCenterContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FakeEpg>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.RecId);
                entity.Property(e => e.Modtime);
                entity.Property(e => e.ChannelRecId);
                entity.Property(e => e.EventId);
                entity.Property(e => e.StartTime);
                entity.Property(e => e.Duration);
                entity.Property(e => e.TableId);
                entity.Property(e => e.Version);
                entity.Property(e => e.Title);
                entity.Property(e => e.ShortDescription);
                entity.Property(e => e.Description);
                entity.Property(e => e.GenreCodes);
                entity.Property(e => e.ParentalRating);
                entity.Property(e => e.Stream);
                entity.Property(e => e.Vps).HasColumnName("VPS");
                entity.Property(e => e.Favourite);
                entity.Property(e => e.EndTime);
                entity.Property(e => e.DurationMinutes);
                entity.Property(e => e.ChannelId);
                entity.Property(e => e.ChannelName);
                entity.Property(e => e.ChannelsRecId);
                entity.Property(e => e.VPID);
                entity.Property(e => e.TimersRecId);
                entity.Property(e => e.RecordingsRecId);
                entity.Property(e => e.SymbolIndex);
            });

            modelBuilder.Entity<FindEntry>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.RecId);
                entity.Property(e => e.SymbolIndex);
                entity.Property(e => e.ChannelRecId);
                entity.Property(e => e.StartTime);
                entity.Property(e => e.DurationMinutes);
                entity.Property(e => e.Title);
                entity.Property(e => e.ShortDescription);
                entity.Property(e => e.Description);
                entity.Property(e => e.Vps).HasColumnName("VPS");
                entity.Property(e => e.ChannelName);
                entity.Property(e => e.GenreCodes);
                entity.Property(e => e.ParentalRating);
            });

            modelBuilder.Entity<FakeTimer>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.RecId);
                entity.Property(e => e.Modtime);
                entity.Property(e => e.Number);
                entity.Property(e => e.Active);
                entity.Property(e => e.ChannelRecId);
                entity.Property(e => e.StartTime);
                entity.Property(e => e.EndTime);
                entity.Property(e => e.Priority);
                entity.Property(e => e.Duration);
                entity.Property(e => e.Title);
                entity.Property(e => e.ChannelName);
            });
        }
    }
}
