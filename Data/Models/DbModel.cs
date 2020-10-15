using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Dont forget to import
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema; // Dont forget to import

namespace BangTestDemo2.Data.Models
{
    // Important note, The classes below do not include constructors,
    // however you can include them

    // Additionally, any changes to the below classes would require you to Add-Migration from the
    // Package Manager console. After successfully Adding a Migration, you would then use the 
    // Update-Database command from the PackageManager console. 

    public class Package
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageType { get; set; }
        public string PackageLocation { get; set; }
        public string PackageHash { get; set; }
        public bool IsReleased { get; set; }
        public int PackageFileCount { get; set; }
        public int RunCount { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class CabSet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CabsetId { get; set; }
        public string CabsetName { get; set; }
        public int CabCount { get; set; }
        public string CabConfigLocation { get; set; }
        public string CabTypes { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Run
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RunId { get; set; }
        public int BasePackageId { get; set; }
        public string BasePackageName { get; set; }
        public int ComparisonPackageId { get; set; }
        public string ComparisonPackageName { get; set; }
        public int CabsetId { get; set; }
        public string CabsetName { get; set; }
        public int TotalCabCount { get; set; }
        public int CabsCompleted { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime SubmissionTime { get; set; }
    }

    public class Results
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ResultKey { get; set; }
        [ForeignKey("RunId")]
        public int RunId { get; set; }
        [ForeignKey("PackageId")]
        public int PackageId { get; set; }
        [ForeignKey("PackageName")]
        public string PackageName { get; set; }
        [ForeignKey("CabsetId")]
        public int CabsetId { get; set; }
        public int CabId { get; set; }
        public string FailureString { get; set; }
        public bool HasSymbolIssue { get; set; }
        public int TotalElapsedMs { get; set; }
        public int TotalCpuMs { get; set; }
        public string XmlPath { get; set; }
        public DateTime RegisteredTime { get; set; }
    }
}
