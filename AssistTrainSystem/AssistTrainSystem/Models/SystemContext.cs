using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistTrainSystem.Models;

namespace AssistTrainSystem.Models
{
    public class SystemContext:DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options):base(options)
        {

        }

        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
        public DbSet<AssistTrainSystem.Models.BodyAbility> BodyAbility { get; set; }
        public DbSet<AssistTrainSystem.Models.EnergyAbility> EnergyAbility { get; set; }

        public DbSet<AssistTrainSystem.Models.FlexibleAbility> FlexiableAbility { get; set; }

        public DbSet<AssistTrainSystem.Models.SpeedAbility> SpeedAbility { get; set; }

        public DbSet<AssistTrainSystem.Models.StaminaAbility> StaminaAbility { get; set; }

        public DbSet<AssistTrainSystem.Models.Horbara_Score> Horbara_Score { get; set; }

        public DbSet<AssistTrainSystem.Models.ComtrainAbilities> ComtrainAbilities { get; set; }

        public DbSet<AssistTrainSystem.Models.FourhurdleAbilities> FourhurdleAbilities { get; set; }
        public DbSet<AssistTrainSystem.Models.FiveoffroadAbilities> FiveoffroadAbilities { get; set; }
        public DbSet<AssistTrainSystem.Models.NormalTrain> NormalTrain { get; set; }
        public DbSet<AssistTrainSystem.Models.PersonalNormlTrain> PersonalNormlTrain { get; set; }

        public DbSet<AssistTrainSystem.Models.PersonalPay> PersonalPay { get; set; }

        public DbSet<AssistTrainSystem.Models.Pushup_Score> Pushup_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.pushupscore> pushupscore { get; set; }

        public DbSet<AssistTrainSystem.Models.Situp_Score> Situp_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Ontheroll_Score> Ontheroll_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Swingflex_Score> Swingflex_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Gunrun_Score> Gunrun_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Fourrun_Score> Fourrun_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Fourhurdle_Score> Fourhurdle_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Fiveoffroad_Score> Fiveoffroad_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Gunhurdle_Score> Gunhurdle_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Threeoffroad_Score> Threeoffroad_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Twohurdle_Score> Twohurdle_Score { get; set; }
        public DbSet<AssistTrainSystem.Models.Threehurdle_Score> Threehurdle_Score { get; set; }
       


    }
}
