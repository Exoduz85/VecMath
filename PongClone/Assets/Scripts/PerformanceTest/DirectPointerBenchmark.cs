using UnityEngine;
using NativeVector;
using DirectVector;
using System.Diagnostics;
using System.Text;

namespace PerformanceTest
{
    public class DirectPointerBenchmark : MonoBehaviour
    {
        [Header("Benchmark Settings")]
        public int iterations = 1000000;
        public bool runOnStart;
        
        [Header("Results")]
        [TextArea(30, 40)]
        public string benchmarkResults = "Press 'Run Benchmark'";

        StringBuilder results;
        
        void Start()
        {
            if (runOnStart)
            {
                RunBenchmark();
            }
        }
        
        [ContextMenu("Run Benchmark")]
        public void RunBenchmark()
        {
            results = new StringBuilder();
            
            results.AppendLine("=========================================");
            results.AppendLine("|   Vector Math Performance Benchmark    |");
            results.AppendLine("|   Struct (ref) vs Direct Pointer       |");
            results.AppendLine("=========================================\n");
            
            results.AppendLine($"Iterations: {iterations:N0}\n");
            results.AppendLine("".PadRight(60, '='));
            
            results.AppendLine("\n=== Vec2 Benchmarks ===\n");
            BenchmarkVec2PropertyAccess();
            BenchmarkVec2Add();
            BenchmarkVec2Subtract();
            BenchmarkVec2Scale();
            BenchmarkVec2Magnitude();
            BenchmarkVec2Normalize();
            BenchmarkVec2Dot();
            BenchmarkVec2Reflect();
            BenchmarkVec2Distance();
            
            results.AppendLine("\n=== Vec3 Benchmarks ===\n");
            BenchmarkVec3PropertyAccess();
            BenchmarkVec3Add();
            BenchmarkVec3Subtract();
            BenchmarkVec3Scale();
            BenchmarkVec3Magnitude();
            BenchmarkVec3Normalize();
            BenchmarkVec3Dot();
            BenchmarkVec3Cross();
            BenchmarkVec3Reflect();
            BenchmarkVec3Distance();
            
            results.AppendLine("\n" + "".PadRight(60, '='));
            results.AppendLine("\n Benchmark Complete!");
            
            benchmarkResults = results.ToString();
            UnityEngine.Debug.Log(benchmarkResults);
        }
        
        void BenchmarkVec2PropertyAccess()
        {
            var structVec = new Vec2(3.5f, 4.2f);
            var ptrVec = new DirectVec2(3.5f, 4.2f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var x = structVec.x;
                var y = structVec.y;
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var x = ptrVec.x;
                var y = ptrVec.y;
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrVec.Dispose();
            PrintResult("Property Access (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Add()
        {
            var structA = new Vec2(3.5f, 4.2f);
            var structB = new Vec2(1.1f, 2.3f);
            
            var ptrA = new DirectVec2(3.5f, 4.2f);
            var ptrB = new DirectVec2(1.1f, 2.3f);
            var ptrResult = new DirectVec2(0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Add(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrA.x;
                ptrResult.y = ptrA.y;
                ptrResult.Add(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Add (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Subtract()
        {
            var structA = new Vec2(5.5f, 7.2f);
            var structB = new Vec2(2.1f, 3.3f);
            
            var ptrA = new DirectVec2(5.5f, 7.2f);
            var ptrB = new DirectVec2(2.1f, 3.3f);
            var ptrResult = new DirectVec2(0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Subtract(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrA.x;
                ptrResult.y = ptrA.y;
                ptrResult.Subtract(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Subtract (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Scale()
        {
            var structV = new Vec2(3.0f, 4.0f);
            var ptrV = new DirectVec2(3.0f, 4.0f);
            var ptrResult = new DirectVec2(0, 0);
            var scalar = 2.5f;
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Scale(structV, scalar);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrV.x;
                ptrResult.y = ptrV.y;
                ptrResult.Scale(scalar);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrV.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Scale (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Magnitude()
        {
            var structV = new Vec2(3.0f, 4.0f);
            var ptrV = new DirectVec2(3.0f, 4.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Magnitude(structV);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrV.Magnitude();
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrV.Dispose();
            PrintResult("Magnitude (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Normalize()
        {
            var structV = new Vec2(3.0f, 4.0f);
            var ptrV = new DirectVec2(3.0f, 4.0f);
            var ptrResult = new DirectVec2(0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Normalize(structV);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrV.x;
                ptrResult.y = ptrV.y;
                ptrResult.Normalize();
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrV.Dispose();
            ptrResult.Dispose();
            PrintResult("Normalize (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Dot()
        {
            var structA = new Vec2(3.0f, 4.0f);
            var structB = new Vec2(2.0f, 1.0f);
            
            var ptrA = new DirectVec2(3.0f, 4.0f);
            var ptrB = new DirectVec2(2.0f, 1.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Dot(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrA.Dot(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            PrintResult("Dot (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Reflect()
        {
            var structIncident = new Vec2(1.0f, -1.0f);
            var structNormal = new Vec2(0.0f, 1.0f);
            
            var ptrIncident = new DirectVec2(1.0f, -1.0f);
            var ptrNormal = new DirectVec2(0.0f, 1.0f);
            var ptrResult = new DirectVec2(0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Reflect(structIncident, structNormal);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrIncident.x;
                ptrResult.y = ptrIncident.y;
                ptrResult.Reflect(ptrNormal);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrIncident.Dispose();
            ptrNormal.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Reflect (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec2Distance()
        {
            var structA = new Vec2(0.0f, 0.0f);
            var structB = new Vec2(3.0f, 4.0f);
            
            var ptrA = new DirectVec2(0.0f, 0.0f);
            var ptrB = new DirectVec2(3.0f, 4.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Distance(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrA.Distance(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            PrintResult("Distance (Vec2)", structTime, ptrTime);
        }
        
        void BenchmarkVec3PropertyAccess()
        {
            var structVec = new Vec3(3.5f, 4.2f, 2.1f);
            var ptrVec = new DirectVec3(3.5f, 4.2f, 2.1f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var x = structVec.x;
                var y = structVec.y;
                var z = structVec.z;
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var x = ptrVec.x;
                var y = ptrVec.y;
                var z = ptrVec.z;
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrVec.Dispose();
            PrintResult("Property Access (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Add()
        {
            var structA = new Vec3(3.5f, 4.2f, 2.1f);
            var structB = new Vec3(1.1f, 2.3f, 3.2f);
            
            var ptrA = new DirectVec3(3.5f, 4.2f, 2.1f);
            var ptrB = new DirectVec3(1.1f, 2.3f, 3.2f);
            var ptrResult = new DirectVec3(0, 0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Add(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrA.x;
                ptrResult.y = ptrA.y;
                ptrResult.z = ptrA.z;
                ptrResult.Add(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Add (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Subtract()
        {
            var structA = new Vec3(5.5f, 7.2f, 4.3f);
            var structB = new Vec3(2.1f, 3.3f, 1.2f);
            
            var ptrA = new DirectVec3(5.5f, 7.2f, 4.3f);
            var ptrB = new DirectVec3(2.1f, 3.3f, 1.2f);
            var ptrResult = new DirectVec3(0, 0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Subtract(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrA.x;
                ptrResult.y = ptrA.y;
                ptrResult.z = ptrA.z;
                ptrResult.Subtract(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Subtract (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Scale()
        {
            var structV = new Vec3(3.0f, 4.0f, 2.0f);
            var ptrV = new DirectVec3(3.0f, 4.0f, 2.0f);
            var ptrResult = new DirectVec3(0, 0, 0);
            var scalar = 2.5f;
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Scale(structV, scalar);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrV.x;
                ptrResult.y = ptrV.y;
                ptrResult.z = ptrV.z;
                ptrResult.Scale(scalar);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrV.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Scale (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Magnitude()
        {
            var structV = new Vec3(3.0f, 4.0f, 5.0f);
            var ptrV = new DirectVec3(3.0f, 4.0f, 5.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Magnitude(structV);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrV.Magnitude();
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrV.Dispose();
            PrintResult("Magnitude (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Normalize()
        {
            var structV = new Vec3(3.0f, 4.0f, 5.0f);
            var ptrV = new DirectVec3(3.0f, 4.0f, 5.0f);
            var ptrResult = new DirectVec3(0, 0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Normalize(structV);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrV.x;
                ptrResult.y = ptrV.y;
                ptrResult.z = ptrV.z;
                ptrResult.Normalize();
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrV.Dispose();
            ptrResult.Dispose();
            PrintResult("Normalize (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Dot()
        {
            var structA = new Vec3(3.0f, 4.0f, 2.0f);
            var structB = new Vec3(2.0f, 1.0f, 3.0f);
            
            var ptrA = new DirectVec3(3.0f, 4.0f, 2.0f);
            var ptrB = new DirectVec3(2.0f, 1.0f, 3.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Dot(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrA.Dot(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            PrintResult("Dot (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Cross()
        {
            var structA = new Vec3(1.0f, 0.0f, 0.0f);
            var structB = new Vec3(0.0f, 1.0f, 0.0f);
            
            var ptrA = new DirectVec3(1.0f, 0.0f, 0.0f);
            var ptrB = new DirectVec3(0.0f, 1.0f, 0.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Cross(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrA.Cross(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            
            PrintResult("Cross (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Reflect()
        {
            var structIncident = new Vec3(1.0f, -1.0f, 0.0f);
            var structNormal = new Vec3(0.0f, 1.0f, 0.0f);
            
            var ptrIncident = new DirectVec3(1.0f, -1.0f, 0.0f);
            var ptrNormal = new DirectVec3(0.0f, 1.0f, 0.0f);
            var ptrResult = new DirectVec3(0, 0, 0);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Reflect(structIncident, structNormal);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                ptrResult.x = ptrIncident.x;
                ptrResult.y = ptrIncident.y;
                ptrResult.z = ptrIncident.z;
                ptrResult.Reflect(ptrNormal);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrIncident.Dispose();
            ptrNormal.Dispose();
            ptrResult.Dispose();
            
            PrintResult("Reflect (Vec3)", structTime, ptrTime);
        }
        
        void BenchmarkVec3Distance()
        {
            var structA = new Vec3(0.0f, 0.0f, 0.0f);
            var structB = new Vec3(3.0f, 4.0f, 5.0f);
            
            var ptrA = new DirectVec3(0.0f, 0.0f, 0.0f);
            var ptrB = new DirectVec3(3.0f, 4.0f, 5.0f);
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                var result = VecHelper.Distance(structA, structB);
            }
            sw.Stop();
            var structTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                var result = ptrA.Distance(ptrB);
            }
            sw.Stop();
            var ptrTime = sw.ElapsedTicks;
            
            ptrA.Dispose();
            ptrB.Dispose();
            PrintResult("Distance (Vec3)", structTime, ptrTime);
        }
        
        void PrintResult(string name, long structTicks, long ptrTicks)
        {
            var structMs = (structTicks * 1000.0) / Stopwatch.Frequency;
            var ptrMs = (ptrTicks * 1000.0) / Stopwatch.Frequency;
            
            var structNs = (structMs * 1000000.0) / iterations;
            var ptrNs = (ptrMs * 1000000.0) / iterations;
            
            var speedup = (double)structTicks / ptrTicks;
            
            results.AppendLine($"\n{name}:");
            results.AppendLine($"  Struct: {structNs:F2} ns/op");
            results.AppendLine($"  Pointer: {ptrNs:F2} ns/op");
            results.AppendLine($"  {(speedup > 1 ? " Pointer" : " Struct")} is {(speedup > 1 ? speedup : 1/speedup):F2}x faster");
        }
    }
}