using System.Net.Http;

namespace CandidateWebLayer.Helper
{
    public interface IAPI
    {
        HttpClient Initial();
    }
}
