using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("JobCandidate", Schema = "HumanResources")]
    [Index(nameof(BusinessEntityId), Name = "IX_JobCandidate_BusinessEntityID")]
    public partial class JobCandidate
    {
        [Key]
        [Column("JobCandidateID")]
        public int JobCandidateId { get; set; }
        [Column("BusinessEntityID")]
        public int? BusinessEntityId { get; set; }
        [Column(TypeName = "xml")]
        public string Resume { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.JobCandidates))]
        public virtual Employee BusinessEntity { get; set; }
    }
}
