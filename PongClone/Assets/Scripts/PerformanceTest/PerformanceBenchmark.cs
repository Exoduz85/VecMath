using UnityEngine;
using NativeVector;
using System.Diagnostics;
using System.Text;

namespace PerformanceTest
{
    public class PerformanceBenchmark : MonoBehaviour
    {
        [Header("Benchmark Settings")]
        [Tooltip("Number of iterations per test")]
        public int iterations = 100000;
        
        [Tooltip("Run benchmark on Start()")]
        public bool runOnStart;
        
        [Header("Results")]
        [TextArea(20, 30)]
        public string benchmarkResults = "Press 'Run Benchmark' or call RunBenchmark()";
        
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
            
            results.AppendLine(" =========================================");
            results.AppendLine("|   Vector Math Performance Benchmark     |");
            results.AppendLine("|   Native Vec2 & 3 vs Unity Vector2 & 3  |");
            results.AppendLine(" =========================================\n");
            
            results.AppendLine($"Iterations per test: {iterations:N0}\n");
            results.AppendLine("".PadRight(60, '='));
            
            results.AppendLine("\n=== Vec2 Benchmarks ===\n");
            BenchmarkAdd();
            BenchmarkSubtract();
            BenchmarkScale();
            BenchmarkMagnitude();
            BenchmarkNormalize();
            BenchmarkDot();
            BenchmarkDistance();
            BenchmarkLerp();
            
            results.AppendLine("\n=== Vec3 Benchmarks ===\n");
            BenchmarkVec3Add();
            BenchmarkVec3Subtract();
            BenchmarkVec3Scale();
            BenchmarkVec3Magnitude();
            BenchmarkVec3Normalize();
            BenchmarkVec3Dot();
            BenchmarkVec3Cross();
            BenchmarkVec3Distance();
            BenchmarkVec3Lerp();
            
            results.AppendLine("\n" + "".PadRight(60, '='));
            results.AppendLine("\n Benchmark Complete!");
            
            benchmarkResults = results.ToString();
            UnityEngine.Debug.Log(benchmarkResults);
        }
        
        void BenchmarkAdd()
        {
            var nativeA = new Vec2(3.5f, 4.2f);
            var nativeB = new Vec2(1.1f, 2.3f);
            
            var unityA = new Vector2(3.5f, 4.2f);
            var unityB = new Vector2(1.1f, 2.3f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Add(nativeA, nativeB);
                _ = unityA + unityB;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Add(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityA + unityB;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Add (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkSubtract()
        {
            var nativeA = new Vec2(5.5f, 7.2f);
            var nativeB = new Vec2(2.1f, 3.3f);
            
            var unityA = new Vector2(5.5f, 7.2f);
            var unityB = new Vector2(2.1f, 3.3f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Subtract(nativeA, nativeB);
                _ = unityA - unityB;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Subtract(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityA - unityB;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Subtract (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkScale()
        {
            var nativeV = new Vec2(3.0f, 4.0f);
            var unityV = new Vector2(3.0f, 4.0f);
            var scalar = 2.5f;
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Scale(nativeV, scalar);
                _ = unityV * scalar;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Scale(nativeV, scalar);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityV * scalar;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Scale (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkMagnitude()
        {
            var nativeV = new Vec2(3.0f, 4.0f);
            var unityV = new Vector2(3.0f, 4.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Magnitude(nativeV);
                _ = unityV.magnitude;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Magnitude(nativeV);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityV.magnitude;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Magnitude (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkNormalize()
        {
            var nativeV = new Vec2(3.0f, 4.0f);
            var unityV = new Vector2(3.0f, 4.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Normalize(nativeV);
                _ = unityV.normalized;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Normalize(nativeV);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityV.normalized;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Normalize (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkDot()
        {
            var nativeA = new Vec2(3.0f, 4.0f);
            var nativeB = new Vec2(2.0f, 1.0f);
            
            var unityA = new Vector2(3.0f, 4.0f);
            var unityB = new Vector2(2.0f, 1.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Dot(nativeA, nativeB);
                _ = Vector2.Dot(unityA, unityB);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Dot(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector2.Dot(unityA, unityB);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Dot (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkDistance()
        {
            var nativeA = new Vec2(0.0f, 0.0f);
            var nativeB = new Vec2(3.0f, 4.0f);
            
            var unityA = new Vector2(0.0f, 0.0f);
            var unityB = new Vector2(3.0f, 4.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Distance(nativeA, nativeB);
                _ = Vector2.Distance(unityA, unityB);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Distance(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector2.Distance(unityA, unityB);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Distance (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkLerp()
        {
            var nativeStart = new Vec2(0.0f, 0.0f);
            var nativeEnd = new Vec2(10.0f, 10.0f);
            
            var unityStart = new Vector2(0.0f, 0.0f);
            var unityEnd = new Vector2(10.0f, 10.0f);
            
            var t = 0.5f;
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Lerp(nativeStart, nativeEnd, t);
                _ = Vector2.Lerp(unityStart, unityEnd, t);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Lerp(nativeStart, nativeEnd, t);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector2.Lerp(unityStart, unityEnd, t);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Lerp (Vec2)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Add()
        {
            var nativeA = new Vec3(3.5f, 4.2f, 2.1f);
            var nativeB = new Vec3(1.1f, 2.3f, 3.2f);
            
            var unityA = new Vector3(3.5f, 4.2f, 2.1f);
            var unityB = new Vector3(1.1f, 2.3f, 3.2f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Add(nativeA, nativeB);
                _ = unityA + unityB;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Add(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityA + unityB;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Add (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Subtract()
        {
            var nativeA = new Vec3(5.5f, 7.2f, 4.3f);
            var nativeB = new Vec3(2.1f, 3.3f, 1.2f);
            
            var unityA = new Vector3(5.5f, 7.2f, 4.3f);
            var unityB = new Vector3(2.1f, 3.3f, 1.2f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Subtract(nativeA, nativeB);
                _ = unityA - unityB;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Subtract(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityA - unityB;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Subtract (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Scale()
        {
            var nativeV = new Vec3(3.0f, 4.0f, 2.0f);
            var unityV = new Vector3(3.0f, 4.0f, 2.0f);
            var scalar = 2.5f;
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Scale(nativeV, scalar);
                _ = unityV * scalar;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Scale(nativeV, scalar);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityV * scalar;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Scale (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Magnitude()
        {
            var nativeV = new Vec3(3.0f, 4.0f, 5.0f);
            var unityV = new Vector3(3.0f, 4.0f, 5.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Magnitude(nativeV);
                _ = unityV.magnitude;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Magnitude(nativeV);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityV.magnitude;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Magnitude (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Normalize()
        {
            var nativeV = new Vec3(3.0f, 4.0f, 5.0f);
            var unityV = new Vector3(3.0f, 4.0f, 5.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Normalize(nativeV);
                _ = unityV.normalized;
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Normalize(nativeV);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = unityV.normalized;
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Normalize (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Dot()
        {
            var nativeA = new Vec3(3.0f, 4.0f, 2.0f);
            var nativeB = new Vec3(2.0f, 1.0f, 3.0f);
            
            var unityA = new Vector3(3.0f, 4.0f, 2.0f);
            var unityB = new Vector3(2.0f, 1.0f, 3.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Dot(nativeA, nativeB);
                _ = Vector3.Dot(unityA, unityB);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Dot(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector3.Dot(unityA, unityB);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Dot (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Cross()
        {
            var nativeA = new Vec3(1.0f, 0.0f, 0.0f);
            var nativeB = new Vec3(0.0f, 1.0f, 0.0f);
            
            var unityA = new Vector3(1.0f, 0.0f, 0.0f);
            var unityB = new Vector3(0.0f, 1.0f, 0.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Cross(nativeA, nativeB);
                _ = Vector3.Cross(unityA, unityB);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Cross(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector3.Cross(unityA, unityB);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Cross (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Distance()
        {
            var nativeA = new Vec3(0.0f, 0.0f, 0.0f);
            var nativeB = new Vec3(3.0f, 4.0f, 5.0f);
            
            var unityA = new Vector3(0.0f, 0.0f, 0.0f);
            var unityB = new Vector3(3.0f, 4.0f, 5.0f);
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Distance(nativeA, nativeB);
                _ = Vector3.Distance(unityA, unityB);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Distance(nativeA, nativeB);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector3.Distance(unityA, unityB);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Distance (Vec3)", nativeTime, unityTime);
        }
        
        void BenchmarkVec3Lerp()
        {
            var nativeStart = new Vec3(0.0f, 0.0f, 0.0f);
            var nativeEnd = new Vec3(10.0f, 10.0f, 10.0f);
            
            var unityStart = new Vector3(0.0f, 0.0f, 0.0f);
            var unityEnd = new Vector3(10.0f, 10.0f, 10.0f);
            
            var t = 0.5f;
            
            for (var i = 0; i < 1000; i++)
            {
                _ = VecHelper.Lerp(nativeStart, nativeEnd, t);
                _ = Vector3.Lerp(unityStart, unityEnd, t);
            }
            
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                _ = VecHelper.Lerp(nativeStart, nativeEnd, t);
            }
            sw.Stop();
            var nativeTime = sw.ElapsedTicks;
            
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                _ = Vector3.Lerp(unityStart, unityEnd, t);
            }
            sw.Stop();
            var unityTime = sw.ElapsedTicks;
            
            PrintResult("Lerp (Vec3)", nativeTime, unityTime);
        }
        
        void PrintResult(string operationName, long nativeTicks, long unityTicks)
        {
            var nativeMs = (nativeTicks * 1000.0) / Stopwatch.Frequency;
            var unityMs = (unityTicks * 1000.0) / Stopwatch.Frequency;
            
            var nativeNsPerOp = (nativeMs * 1000000.0) / iterations;
            var unityNsPerOp = (unityMs * 1000000.0) / iterations;
            
            var speedup = (double)unityTicks / nativeTicks;
            
            results.AppendLine($"\n{operationName}:");
            results.AppendLine($"  Native:  {nativeMs:F3} ms ({nativeNsPerOp:F2} ns/op)");
            results.AppendLine($"  Unity:   {unityMs:F3} ms ({unityNsPerOp:F2} ns/op)");

            results.AppendLine(
                speedup > 1.0
                    ? $"  Native is {speedup:F2}x faster"
                    : $"  Unity is {(1.0 / speedup):F2}x faster"
            );
        }
    }
}