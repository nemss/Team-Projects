namespace Library.Data.Configurations
{
    using Models;
    using System.Data.Entity.ModelConfiguration;

    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(u => u.Password)
                .IsRequired();
        }
    }
}