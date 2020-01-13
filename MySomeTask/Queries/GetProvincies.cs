using System.Collections.Generic;

namespace MySomeTask.Queries
{
  /// <summary>
  /// Запрос провинций страны
  /// </summary>
  public class GetProvincies : Query<IEnumerable<string>>
    {
      public string CountryCode { get; set; }
    }
}
