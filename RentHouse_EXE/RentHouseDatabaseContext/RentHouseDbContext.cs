using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Provinces;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;

namespace RentHouse_EXE.RentHouseDatabaseContext
{
    public class RentHouseDbContext : DbContext
    {
        public RentHouseDbContext(DbContextOptions<RentHouseDbContext> options) : base(options)
        {
            InitializeData();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountComments)
                .WithOne(c => c.AccountComment)
                .HasForeignKey(c => c.AdminCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AdminComments)
                .WithOne(c => c.AdminComment)
                .HasForeignKey(c => c.AccountCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountLikeComment)
                .WithOne(l => l.AccountLikeComment)
                .HasForeignKey(l => l.AccountLikeCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.CustomerSends)
                .WithOne(m => m.CustomerSend)
                .HasForeignKey(m => m.CustomerSendId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.CustomerReceives)
                .WithOne(m => m.CustomerReceive)
                .HasForeignKey(m => m.CustomerReceiveId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.CustomerPosts)
                .WithOne(p => p.CustomerPosts)
                .HasForeignKey(p => p.CustomerPostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AdminPosts)
                .WithOne(p => p.AdminPosts)
                .HasForeignKey(p => p.AdminPostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountReplyComments)
                .WithOne(r => r.AccountReplyComment)
                .HasForeignKey(r => r.AccountReplyCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentRealEstate>()
                .HasMany(c => c.LikeComments)
                .WithOne(l => l.CommentRealEstate)
                .HasForeignKey(l => l.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentRealEstate>()
                .HasMany(c => c.ReplyComments)
                .WithOne(r => r.CommentRealEstate)
                .HasForeignKey(r => r.ParentReplyCommentId)
                .OnDelete(DeleteBehavior.NoAction);           

            modelBuilder.Entity<ReplyComment>()
                .HasMany(r => r.ReplyComments)
                .WithOne(r => r.ParentReplyComment)
                .HasForeignKey(r => r.ParentReplyCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReplyComment>()
                .HasMany(r => r.LikeComments)
                .WithOne(l => l.ReplyComment)
                .HasForeignKey(l => l.ReplyCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Accounts)
                .WithOne(a => a.Role)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.Accounts)
                .WithOne(a => a.Status)
                .HasForeignKey(a => a.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.CommentRealEstates)
                .WithOne(c => c.Status)
                .HasForeignKey(c => c.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.ImageRealEstates)
                .WithOne(i => i.Status)
                .HasForeignKey(i => i.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.PostRealEstates)
                .WithOne(p => p.Statuses)
                .HasForeignKey(p => p.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TypeRealEstate>()
                .HasMany(t => t.PostRealEstates)
                .WithOne(p => p.TypeRealEstates)
                .HasForeignKey(p => p.TypeRealEstateId)
                .OnDelete(DeleteBehavior.NoAction);

            // Map Viet Nam
            modelBuilder.Entity<Administrative_regions>()
                .HasMany(a => a.Provinces)
                .WithOne(p => p.Administrative_regions)
                .HasForeignKey(p => p.Administrative_region_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Administrative_units>()
                .HasMany(a => a.Provinces)
                .WithOne(p => p.Administrative_units)
                .HasForeignKey(p => p.Administrative_unit_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Administrative_units>()
                .HasMany(a => a.Districts)
                .WithOne(d => d.Administrative_units)
                .HasForeignKey(d => d.Administrative_unit_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Administrative_units>()
                .HasMany(a => a.Wards)
                .WithOne(w => w.Administrative_units)
                .HasForeignKey(w => w.Administrative_unit_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Provinces>()
                .HasMany(p => p.Districts)
                .WithOne(d => d.Provinces)
                .HasForeignKey(d => d.Province_code)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Districts>()
                .HasMany(d => d.Wards)
                .WithOne(w => w.Districts)
                .HasForeignKey(w => w.District_code)
                .OnDelete(DeleteBehavior.NoAction);             

            modelBuilder.Entity<PostRealEstate>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<Account>()
                .Property(a => a.Wallet)
                .HasColumnType("decimal(18,0)");            

            modelBuilder.Entity<PriceDecreases>()
                .Property(p => p.PercentageDecrease)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PlanPrice>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<PostRealEstate>()
                .Property(p => p.Area)
                .HasColumnType("decimal(18,2)");

            // Define Primary Key
            modelBuilder.Entity<Administrative_regions>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Administrative_units>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Provinces>()
                .HasKey(p => p.Code);

            modelBuilder.Entity<Districts>()
                .HasKey(d => d.Code);

            modelBuilder.Entity<Wards>()
                .HasKey(w => w.Code);           
            
            modelBuilder.Entity<PostRealEstate>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<PaymentHistory>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,0)");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<CommentRealEstate> CommentRealEstates { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<ImageRealEstate> ImageRealEstates { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }
        public DbSet<Message> Messages { get; set; }        
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanDay> PlanDays { get; set; }
        public DbSet<PriceDecreases> PriceDecreases { get; set; }
        public DbSet<PlanPrice> PricePlans { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PostRealEstate> PostRealEstates { get; set; }
        public DbSet<TypeRealEstate> TypeRealEstates { get; set; }
        public DbSet<PriceUnit> PriceUnits { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        // Map Viet Nam
        public DbSet<Administrative_regions> Administrative_Regions { get; set; }
        public DbSet<Administrative_units> Administrative_Units { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Wards> Wards { get; set; }


        public void InitializeData()
        {
            if (!Roles.Any())
            {
                Roles.Add(new Role
                {
                    Id = Guid.NewGuid(),
                    RoleName = "ADMIN",
                    CreateDateTime = DateTime.Now
                });
                SaveChanges();
            }

            if (!Statuses.Any())
            {
                Statuses.Add(new Status
                {
                    Id = Guid.NewGuid(),
                    StatusName = "ACTIVE",
                    CreateDateTime = DateTime.Now
                });
                SaveChanges();
            }

            if (!Accounts.Any())
            {
                // Code to initialize Account data
                var passHash = CreatePassHashAndPassSalt("Admin@123", out byte[] passwordSalt);
                var roleId = Roles.FirstOrDefault(x => x.RoleName == "ADMIN");
                var statusId = Statuses.FirstOrDefault(x => x.StatusName == "ACTIVE");
                if (roleId == null || statusId == null)
                {
                    throw new Exception("Can not find role or status");
                }
                Accounts.Add(new Account
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@localhost.com",
                    PasswordHash = passHash,
                    PasswordSalt = Convert.ToBase64String(passwordSalt),
                    StatusId = statusId.Id,
                    RoleId = roleId.Id,
                    CreateDateTime = DateTime.Now
                });
                SaveChanges();
            }            
        }

        private static string CreatePassHashAndPassSalt(string pass, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            return System.Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass)));
        }
    }
}
