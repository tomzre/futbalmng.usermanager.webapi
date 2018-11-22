using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Running;
using UserManager.Infrastructure.Services;

namespace UserManager.Benchmarking
{
    [DryCoreJob, DryMonoJob, DryClrJob(Platform.X86)]
    [DisassemblyDiagnoser(printIL: true)]
    public class BenchmarkServices
    {
        Encrypter _encrypter = new Encrypter();
        [Benchmark]
        public string GettingHash()
        {
            return _encrypter.GetHash(value: "somestring", salt: "salt");
        }

        [Benchmark]
        public string GettingSalt()
        {
            return _encrypter.GetSalt(value: "somestring");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkServices>();
        }
    }
}
