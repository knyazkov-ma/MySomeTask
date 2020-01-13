using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySomeTask.DataBase.Entities
{

  /// <summary>
  /// Учетная запись пользователя
  /// </summary>
  [Table("Accounts")]
  public class Account
  {
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Дата/время создания записи
    /// </summary>        
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата/время изменения записи
    /// </summary>        
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Дата/время активации записи
    /// </summary>        
    public DateTime? ActivatedAt { get; set; }

    /// <summary>
    /// IP с которого зарегистрирован пользователь
    /// </summary>
    [StringLength(20)]
    public string IP { get; set; }

    
    /// <summary>
    /// Email (уникальное), используется как логин
    /// </summary>        
    [Required]
    [StringLength(128)]
    public string Email { get; set; }

    
    /// <summary>
    /// Пароль (хэш)
    /// </summary>
    [StringLength(128)]
    [Required]
    public string Password { get; set; }
    
  }
}
