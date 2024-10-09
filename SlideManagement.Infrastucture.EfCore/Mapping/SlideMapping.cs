using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlideManagement.Domain.SlideAgg;

namespace SlideManagement.Infrastucture.EfCore.Mapping
{
    public class SlideMapping:IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slide");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Picturethum).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureTitel).HasMaxLength(500).IsRequired();
            builder.Property(p => p.PictureAlte).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Heading).HasMaxLength(255);
            builder.Property(p => p.Titel).HasMaxLength(500);
            builder.Property(p => p.Text).HasMaxLength(1000);
            builder.Property(p => p.BtnText).HasMaxLength(100);

        }
    }
}
