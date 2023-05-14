using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDDD.Domain.Entities;

[Table("persons")]
public class PersonEntity
{
    [Key]
    [MaxLength(10)]
    [Column("identification")]
    public string Identification { get; set; }

    [Required]
    [MaxLength(128)]
    [Column("firstNames")]
    public string FirstNames { get; set; }

    [Required]
    [MaxLength(128)]
    [Column("lastNames")]
    public string LastNames { get; set; }

    [Required]
    [Column("age")]
    public int Age { get; set; }

    [Required]
    [MaxLength(16)]
    [Column("gender")]
    public string Gender { get; set; }
}