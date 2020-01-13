using MySomeTask.Queries;
using System.Threading.Tasks;

namespace MySomeTask.QueryHandlers
{
    public interface IQueryHandler
    {
        
    }

    public interface IAsyncQueryHandler<TQuery, TDto>: IQueryHandler
        where TQuery: Query<TDto>
    {
		Task<TDto> ExecuteAsync(TQuery query);		
	}    

}
