using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public interface IGenericRepo
    {
        G Add<T,G>(T model, G data);
    }
}
