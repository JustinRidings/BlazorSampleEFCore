using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Make sure to also import EntityFrameworkCore.Design & EntityFrameworkCore.Tools
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
            // No need for constructor in this case
            // This database was made using a Code-First approach, so that the site
            // clearly reflects the user data that we would like to see. 
            //
            // For class reference, visit .\Data\Models\DBModel.cs
        }

        /// <summary>
        /// This is where you will initialize your DB connection. Because this is using EF Core, 
        /// you should be able to base the Database on Kusto, ADL, SQL, etc.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot _config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            optionsBuilder.UseSqlServer(_config["sql:ConnectionString"]);
        }

        /// <summary>
        /// Retrieves the most recent 100 Runs from Database, Time Filtered
        /// </summary>
        /// <returns>Top 100 most recent Runs</returns>
        public async Task<List<Run>> GetTop100RunsAsync()
        {
            var result = RunDatabase.Where<Run>(run => run.SubmissionTime < DateTime.UtcNow);
            var ordered = result.OrderByDescending(r => r.SubmissionTime);
            var top100 = ordered.Take<Run>(100);
            return await top100.ToListAsync<Run>();
        }

        /// <summary>
        /// Gets a Package ID based on name
        /// </summary>
        /// <param name="name">package name</param>
        /// <returns>Package ID</returns>
        public async Task<int> GetPackageIdByName(string name)
        {
            var package = await PackageDatabase.Where<Package>(p => p.PackageName == name).FirstOrDefaultAsync<Package>();
            return package.PackageId;
        }

        /// <summary>
        /// Returns count of CABS within Cabset
        /// </summary>
        /// <param name="name">Cabset Name</param>
        /// <returns> Count of Cabs </returns>
        public async Task<int> GetCabsetCount(string name)
        {
            var result = await CabsetDatabase.Where<CabSet>(c => c.CabsetName == name).FirstOrDefaultAsync<CabSet>();
            return result.CabCount;
        }

        /// <summary>
        /// Get a Cabset ID based on name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> GetCabsetIdByName(string name)
        {
            var result = await CabsetDatabase.Where<CabSet>(c => c.CabsetName == name).FirstOrDefaultAsync<CabSet>();
            return result.CabsetId;
        }

        /// <summary>
        /// Adds a run to the Database
        /// </summary>
        /// <param name="newRun">New Run</param>
        /// <returns>True if created, false else</returns>
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

        /// <summary>
        /// Adds a package to the Database
        /// </summary>
        /// <param name="newPackage">New Package</param>
        /// <returns>True if created, false else</returns>
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

        /// <summary>
        /// Adds a Cabset to the Database
        /// </summary>
        /// <param name="newCabset">New Cabset</param>
        /// <returns>True if created, false else</returns>
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

        /// <summary>
        /// Gets a Run based on RunID
        /// </summary>
        /// <param name="runId">Id of Run</param>
        /// <returns>Run</returns>
        public async Task<Run> GetRunById(int runId)
        {
            // Because EF Core does not support Thread-Reentry, we want to handle any possible failure 
            // cases within the method itself.
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

        /// <summary>
        /// Gets a Cabset based on CabsetID
        /// </summary>
        /// <param name="cabsetId">ID of Cabset</param>
        /// <returns>Cabset</returns>
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

        /// <summary>
        /// Gets a package based on PackageID
        /// </summary>
        /// <param name="packageId">ID of Package</param>
        /// <returns>Package</returns>
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
