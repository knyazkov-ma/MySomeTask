using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySomeTask.DataBase.Entities
{

  /// <summary>
  /// Расположение пользователя (страна + провинция)
  /// </summary>
  [Table("Locations")]
  public class Location
  {
    [Key]
    public Guid Id { private set; get; }
    
    /// <summary>
    /// Страна (наименование)
    /// </summary>
    [Required]
    [StringLength(200)]
    public string CountryName { private set; get; }

    /// <summary>
    /// Страна (код)
    /// </summary>
    [Required]
    [StringLength(10)]
    public string CountryCode { private set; get; }

    /// <summary>
    /// Провинция
    /// </summary>        
    [Required]
    [StringLength(200)]
    public string ProvinceName { private set; get; }

    // For EF only
    private Location() { }
  }
}
