using BenchmarkDotNet.Attributes;

namespace ExceptionVsResult.Benchmark
{
    public class Benchmarks
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string TestWithResultUrl = "http://localhost:5220/TestWithResult/NoMatchingValue";
        private const string TestWithExceptionUrl = "http://localhost:5220/TestWithException/NoMatchingValue";
        private const string TestHasValueWithExceptionUrl = "http://localhost:5220/TestWithException/HasValue";
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

        [Benchmark]
        public async Task TestWithoutThrowExceptionController()
        {
            var response = await _httpClient.GetAsync(TestHasValueWithExceptionUrl);
            _ = await response.Content.ReadAsStringAsync();
        }

    }
}
