``` ini

BenchmarkDotNet=v0.11.2, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i5-3320M CPU 2.60GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.403
  [Host]  : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
  DryCore : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT

IterationCount=1  LaunchCount=1  RunStrategy=ColdStart  
UnrollFactor=1  WarmupCount=1  

```
|      Method |        Job | Platform | Runtime |      Mean | Error |
|------------ |----------- |--------- |-------- |----------:|------:|
| GettingHash | DryClr-X86 |      X86 |     Clr |        NA |    NA |
| GettingSalt | DryClr-X86 |      X86 |     Clr |        NA |    NA |
| GettingHash |    DryCore |      X64 |    Core | 37.096 ms |    NA |
| GettingSalt |    DryCore |      X64 |    Core |  4.596 ms |    NA |

Benchmarks with issues:
  BenchmarkServices.GettingHash: DryClr-X86(Platform=X86, Runtime=Clr, IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1)
  BenchmarkServices.GettingSalt: DryClr-X86(Platform=X86, Runtime=Clr, IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1)
