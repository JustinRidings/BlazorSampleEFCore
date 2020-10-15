using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration.Json;
using BangTestDemo2.Data.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BangTestDemo2.Data
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Run> RunDatabase { get; set; }
        public DbSet<CabSet> CabsetDatabase { get; set; }
        public DbSet<Package> PackageDatabase { get; set; }
        public DbSet<Results> ResultsDatabase { get; set; }

        public SqlDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot _config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            optionsBuilder.UseSqlServer(_config["sql:ConnectionString"]);
        }

        public async Task<List<Run>> GetTop100RunsAsync()
        {
            var result = RunDatabase.Where<Run>(run => run.SubmissionTime < DateTime.UtcNow);
            var ordered = result.OrderByDescending(r => r.SubmissionTime);
            var top100 = ordered.Take<Run>(100);
            return await top100.ToListAsync<Run>();
        }

        public async Task<int> GetPackageIdByName(string name)
        {
            var package = await PackageDatabase.Where<Package>(p => p.PackageName == name).FirstOrDefaultAsync<Package>();
            return package.PackageId;
        }

        public async Task<int> GetCabsetCount(string name)
        {
            var result = await CabsetDatabase.Where<CabSet>(c => c.CabsetName == name).FirstOrDefaultAsync<CabSet>();
            return result.CabCount;
        }

        public async Task<int> GetCabsetIdByName(string name)
        {
            var result = await CabsetDatabase.Where<CabSet>(c => c.CabsetName == name).FirstOrDefaultAsync<CabSet>();
            return result.CabsetId;
        }

        public async Task<bool> AddNewRun(Run newRun)
        {
            try
            {
                await RunDatabase.AddAsync(newRun);
                await SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddNewPackage(Package newPackage)
        {
            try
            {
                await PackageDatabase.AddAsync(newPackage);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddNewCabset(CabSet newCabset)
        {
            try
            {
                await CabsetDatabase.AddAsync(newCabset);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Run> GetRunById(int runId)
        {
            try
            {
                var run = await RunDatabase.Where<Run>(r => r.RunId == runId).FirstOrDefaultAsync<Run>();
                return run;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<CabSet> GetCabsetById(int cabsetId)
        {
            try
            {
                var cabset = await CabsetDatabase.Where<CabSet>(c => c.CabsetId == cabsetId).FirstOrDefaultAsync();
                return cabset;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Package> GetPackageById(int packageId)
        {
            try
            {
                var package = await PackageDatabase.Where<Package>(p => p.PackageId == packageId).FirstOrDefaultAsync();
                return package;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
