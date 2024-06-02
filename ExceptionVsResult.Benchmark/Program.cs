// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ExceptionVsResult.Benchmark;

var summary = BenchmarkRunner.Run<Benchmarks>();
