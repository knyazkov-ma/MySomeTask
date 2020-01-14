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
    public Guid Id { private set; get; }

    /// <summary>
    /// Дата/время создания записи
    /// </summary>        
    public DateTime CreatedAt { private set; get; }
    
    /// <summary>
    /// IP, с которого зарегистрирован пользователь
    /// </summary>
    [StringLength(20)]
    public string IP { private set; get; }
    
    /// <summary>
    /// Email (уникальное), используется как логин
    /// </summary>        
    [Required]
    [StringLength(128)]
    public string Email { private set; get; }
    
    /// <summary>
    /// Пароль (хэш)
    /// </summary>
    [StringLength(128)]
    [Required]
    public string Password { private set; get; }    

    /// <summary>
    /// Страна
    /// </summary>
    [StringLength(200)]
    [Required]
    public string Country { private set; get; }

    /// <summary>
    /// Провинция
    /// </summary>
    [StringLength(200)]
    [Required]
    public string Province { private set; get; }

    // For EF only
    private Account() { }

    public Account(DateTime createdAt,
      string ip,
      string email,
      string password,
      string country,
      string province)
    {
      Id = Guid.NewGuid();
      CreatedAt = createdAt;
      IP = ip;
      Email = email;
      Password = password;
      Country = country;
      Province = province;
    }

  }
}
