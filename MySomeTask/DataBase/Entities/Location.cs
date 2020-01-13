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
    public Guid Id { get; set; }
    
    /// <summary>
    /// Страна (наименование)
    /// </summary>
    [Required]
    [StringLength(200)]
    public string CountryName { get; set; }

    /// <summary>
    /// Страна (код)
    /// </summary>
    [Required]
    [StringLength(10)]
    public string CountryCode { get; set; }

    /// <summary>
    /// Провинция
    /// </summary>        
    [Required]
    [StringLength(200)]
    public string ProvinceName { get; set; }
        
  }
}
