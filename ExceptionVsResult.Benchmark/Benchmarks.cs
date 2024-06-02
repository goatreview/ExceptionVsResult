using BenchmarkDotNet.Attributes;

namespace ExceptionVsResult.Benchmark
{
    public class Benchmarks
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string TestWithResultUrl = "http://localhost:5220/TestWithResult/NoMatchingValue";
        private const string TestWithExceptionUrl = "http://localhost:5220/TestWithException/NoMatchingValue";
        [GlobalSetup]
        public void Setup()
        {

        }


        [Benchmark]
        public async Task TestWithResultController()
        {
            var response = await _httpClient.GetAsync(TestWithResultUrl);
            _= await response.Content.ReadAsStringAsync();
        }

        [Benchmark]
        public async Task TestWithExceptionController()
        {
            var response = await _httpClient.GetAsync(TestWithExceptionUrl);
            _ = await response.Content.ReadAsStringAsync();
        }
    }
}
