namespace DataLayer.Models;

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

        modelBuilder.Entity<FakeEpgGuide>(entity =>
        {
            entity.HasNoKey();
            entity.Property(e => e.CurrentDate);
            entity.Property(e => e.BlockCounter);
            entity.Property(e => e.RowCounter);
            entity.Property(e => e.ChannelRecId_1);
            entity.Property(e => e.ChannelName_1);
            entity.Property(e => e.ChannelImage_1);
            entity.Property(e => e.EpgRecId_1);
            entity.Property(e => e.EpgEventId_1);
            entity.Property(e => e.EpgStartTime_1);
            entity.Property(e => e.EpgDuration_1);
            entity.Property(e => e.EpgTitle_1);
            entity.Property(e => e.EpgShortDescription_1);
            entity.Property(e => e.EpgDescription_1);
            entity.Property(e => e.ChannelRecId_2);
            entity.Property(e => e.ChannelName_2);
            entity.Property(e => e.ChannelImage_2);
            entity.Property(e => e.EpgRecId_2);
            entity.Property(e => e.EpgEventId_2);
            entity.Property(e => e.EpgStartTime_2);
            entity.Property(e => e.EpgDuration_2);
            entity.Property(e => e.EpgTitle_2);
            entity.Property(e => e.EpgShortDescription_2);
            entity.Property(e => e.EpgDescription_2);
            entity.Property(e => e.ChannelRecId_3);
            entity.Property(e => e.ChannelName_3);
            entity.Property(e => e.ChannelImage_3);
            entity.Property(e => e.EpgRecId_3);
            entity.Property(e => e.EpgEventId_3);
            entity.Property(e => e.EpgStartTime_3);
            entity.Property(e => e.EpgDuration_3);
            entity.Property(e => e.EpgTitle_3);
            entity.Property(e => e.EpgShortDescription_3);
            entity.Property(e => e.EpgDescription_3);
            entity.Property(e => e.ChannelRecId_4);
            entity.Property(e => e.ChannelName_4);
            entity.Property(e => e.ChannelImage_4);
            entity.Property(e => e.EpgRecId_4);
            entity.Property(e => e.EpgEventId_4);
            entity.Property(e => e.EpgStartTime_4);
            entity.Property(e => e.EpgDuration_4);
            entity.Property(e => e.EpgTitle_4);
            entity.Property(e => e.EpgShortDescription_4);
            entity.Property(e => e.EpgDescription_4);
            entity.Property(e => e.ChannelRecId_5);
            entity.Property(e => e.ChannelName_5);
            entity.Property(e => e.ChannelImage_5);
            entity.Property(e => e.EpgRecId_5);
            entity.Property(e => e.EpgEventId_5);
            entity.Property(e => e.EpgStartTime_5);
            entity.Property(e => e.EpgDuration_5);
            entity.Property(e => e.EpgTitle_5);
            entity.Property(e => e.EpgShortDescription_5);
            entity.Property(e => e.EpgDescription_5);
            entity.Property(e => e.ChannelRecId_6);
            entity.Property(e => e.ChannelName_6);
            entity.Property(e => e.ChannelImage_6);
            entity.Property(e => e.EpgRecId_6);
            entity.Property(e => e.EpgEventId_6);
            entity.Property(e => e.EpgStartTime_6);
            entity.Property(e => e.EpgDuration_6);
            entity.Property(e => e.EpgTitle_6);
            entity.Property(e => e.EpgShortDescription_6);
            entity.Property(e => e.EpgDescription_6);
            entity.Property(e => e.ChannelRecId_7);
            entity.Property(e => e.ChannelName_7);
            entity.Property(e => e.ChannelImage_7);
            entity.Property(e => e.EpgRecId_7);
            entity.Property(e => e.EpgEventId_7);
            entity.Property(e => e.EpgStartTime_7);
            entity.Property(e => e.EpgDuration_7);
            entity.Property(e => e.EpgTitle_7);
            entity.Property(e => e.EpgShortDescription_7);
            entity.Property(e => e.EpgDescription_7);
        });
    }
}

