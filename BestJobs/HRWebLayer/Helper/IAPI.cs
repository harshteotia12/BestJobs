using System.Net.Http;

namespace HRWebLayer.Helper
{
    public interface IAPI
    {
        HttpClient Initial();
    }
}
