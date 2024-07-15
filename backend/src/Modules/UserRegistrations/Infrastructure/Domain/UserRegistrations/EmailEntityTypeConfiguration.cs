using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Domain.UserRegistrations;

public class EmailEntityTypeConfiguration : IEntityTypeConfiguration<EmailMessage>
{
    public void Configure(EntityTypeBuilder<EmailMessage> builder)
    {
        builder.ToTable("Emails", "registrations");

        builder.HasKey(x => x.Id);

        builder.Property<string>("_content").HasColumnName("Content");
        builder.Property<string>("_subject").HasColumnName("Subject");
        builder.Property<string>("_receiver").HasColumnName("Receiver");
        builder.Property<bool>("_isSent").HasColumnName("IsSent");
        builder.Property<DateTime>("_enqueueDate").HasColumnName("EnqueueDate");
        builder.Property<DateTime?>("_sentDate").HasColumnName("SentDate");
    }
}