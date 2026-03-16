# Unity Pong - Native Vector Math Library

An implementation of Pong using a native vector math library to explore P/Invoke performance characteristics.

## Overview

For the course **Vector Mathematics in Game Programming**, I gave my students the assignment of creating a custom native vector library that could be used in Unity to create a clone of Pong.

I found this assignment so intriguing that I decided to create my own implementation.

For the project, I was also interested in seeing the benefits and drawbacks of native structures using raw pointers versus references. I set my target to implement both approaches and added tests and benchmarking to compare the performance of native vectors against Unity's built-in vectors.

The results were fascinating and showed that a native implementation could in some cases outperform Unity, and that a blend of reference and pointer versions could achieve performance almost equal to Unity's optimized implementation.

The reference/struct-based Vec2 was used to create the Pong implementation.

---

## Project Structure

```
VecMath/
├── VecMath/                                    # C++ DLL Project
│   ├── Vec2.h                                  # Vec2 struct + ref-based function declarations
│   ├── Vec2.cpp                                # Vec2 struct + ref-based implementations
│   ├── Vec3.h                                  # Vec3 struct + ref-based function declarations
│   ├── Vec3.cpp                                # Vec3 struct + ref-based implementations
│   ├── DirectVec2.h                            # Vec2 pointer-based API declarations
│   ├── DirectVec2.cpp                          # Vec2 pointer-based implementations
│   ├── DirectVec3.h                            # Vec3 pointer-based API declarations
│   ├── DirectVec3.cpp                          # Vec3 pointer-based implementations
│   └── dllmain.cpp                             # DLL entry point
│
├── VecMathTests/                               # C++ Test Project
│   ├── Vec2Tests.h                             # Vec2 tests
│   ├── Vec3Tests.h                             # Vec3 tests
│   └── VecMathTests.cpp                        # Test console project
│
├── PongClone/                                  # Unity Project
│   ├── Assets/
│   │   ├── Plugins/
│   │   │   └── x64/
│   │   │       └── VecMath.dll                 # Compiled native library
│   │   ├── Scripts/
│   │   │   ├── NativeVector/                   # Ref-based (struct) approach
│   │   │   │   ├── Vec2.cs                     # Vec2 struct (matches C++)
│   │   │   │   ├── Vec3.cs                     # Vec3 struct (matches C++)
│   │   │   │   ├── NativeVectorMath.cs         # P/Invoke declarations
│   │   │   │   └── VecHelper.cs                # C# wrapper methods
│   │   │   ├── DirectVector/                   # Pointer-based (DirectVec) approach
│   │   │   │   ├── DirectVec2.cs               # Pointer-based Vec2 wrapper
│   │   │   │   ├── DirectVec3.cs               # Pointer-based Vec3 wrapper
│   │   │   │   ├── Vec2Native.cs               # P/Invoke for pointer API
│   │   │   │   └── Vec3Native.cs               # P/Invoke for pointer API
│   │   │   ├── Balls/
│   │   │   │   └── Ball.cs                     # Ball physics (uses native Vec2)
│   │   │   ├── Paddles/
│   │   │   │   └── Paddle.cs                   # Paddle movement (uses native Vec2)
│   │   │   ├── Walls/
│   │   │   │   └── Wall.cs                     # Wall component
│   │   │   ├── Goals/
│   │   │   │   └── Goal.cs                     # Goal zone component
│   │   │   ├── PerformanceTest/
│   │   │   │   ├── DirectPointerBenchmark.cs   # Pointer vs Struct benchmark
│   │   │   │   └── PerformanceBenchmark.cs     # Struct vs Unity benchmark
│   │   │   └── Manager/
│   │   │       └── GameManager.cs              # Game state management
│   │   └── Tests/
│   │       ├── Vec2/
│   │       │   ├── DirectVec2Tests.cs          # Vec2 pointer tests
│   │       │   └── Vec2UnityTests.cs           # Vec2 ref-based tests
│   │       └── Vec3/
│   │           ├── DirectVec3Tests.cs          # Vec3 pointer tests
│   │           └── Vec3UnityTests.cs           # Vec3 ref-based tests
│   └── Scenes/
│       ├── BenchmarkScene.unity                # Benchmark tests scene
│       └── PongScene.unity                     # Main game scene
└── README.md                                   # This file
```

---

## Vector Math Operations

### Implemented Operations:

#### **Vec2 (13 operations):**
- `Add`, `Subtract`, `Scale`
- `Magnitude`, `MagnitudeSquared`
- `Normalize`
- `Dot`
- `Reflect`
- `Distance`, `DistanceSquared`
- `Lerp`
- `ClampMagnitude`
- `AngleBetween`

#### **Vec3 (15 operations):**
- All Vec2 operations in 3D
- `Cross`
- `Slerp`

#### **DirectVec2 (8 operations):**
- `Add`, `Subtract`, `Scale`
- `Magnitude`
- `Normalize`
- `Dot`
- `Reflect`
- `Distance`

#### **DirectVec3 (9 operations):**
- All DirectVec2 operations in 3D
- `Cross`

---

## Two Implementation Approaches

This project implements **two different P/Invoke patterns** to demonstrate trade-offs:

#### **1. Ref-Based Approach (Vec2/Vec3)**

```csharp
Vec2 a = new Vec2(3, 4);
Vec2 b = new Vec2(1, 2);
Vec2 result = VecHelper.Add(a, b);  // Clean, simple API
```

**Pros:**
- Simple to use
- No manual memory management
- Good for most operations

**Cons:**
- P/Invoke overhead on every call
- Struct marshaling cost

---

#### **2. Pointer-Based Approach (DirectVec2/DirectVec3)**

```csharp
DirectVec2 a = new DirectVec2(3, 4);  // Allocates native memory
DirectVec2 b = new DirectVec2(1, 2);

a.Add(b);  // Modifies in-place

a.Dispose();  // Manual cleanup required
b.Dispose();
```

**Pros:**
- Fast for read-only operations (Magnitude, Dot, Distance)
- Direct memory access via unsafe code

**Cons:**
- Requires unsafe code
- Manual memory management
- Slower for operations requiring data copying

---

## Performance Analysis & Results

I benchmarked three approaches with **1 million iterations** per operation:
1. **Unity's built-in Vector2/Vector3** (Burst-compiled, SIMD-optimized)
2. **Native ref-based Vec2/Vec3** (P/Invoke with struct marshaling)
3. **Native pointer-based DirectVec2/DirectVec3** (Direct memory access)

---

### Key Findings:

#### **1. Unity Often Wins Simple Operations**

Unity's Burst compiler and SIMD optimizations dominate for simple arithmetic:

| Operation | Unity | Native Ref | Winner |
|-----------|-------|------------|--------|
| **Add (Vec2)** | 19.28 ns | 22.74 ns | Unity 1.18x faster |
| **Subtract (Vec2)** | 19.42 ns | 22.11 ns | Unity 1.14x faster |
| **Scale (Vec2)** | 19.34 ns | 22.06 ns | Unity 1.14x faster |
| **Dot (Vec2)** | 13.75 ns | 23.06 ns | Unity 1.68x faster |

**Why?** P/Invoke overhead (~5-10ns per call) negates any native advantage for fast operations.

---

#### **2. Native Wins Complex/Multi-Step Operations**

For operations requiring multiple steps or those not hardware-accelerated:

| Operation | Unity | Native Ref | Winner |
|-----------|-------|------------|--------|
| **Normalize (Vec2)** | 38.19 ns | 28.53 ns | **Native 1.34x faster** |
| **Distance (Vec2)** | 37.21 ns | 26.96 ns | **Native 1.38x faster** |
| **Normalize (Vec3)** | 43.39 ns | 25.47 ns | **Native 1.70x faster** |
| **Lerp (Vec3)** | 29.36 ns | 23.44 ns | **Native 1.25x faster** |

**Why?** Multistep calculations benefit from staying in native code and avoiding multiple P/Invoke calls.

---

#### **3. Unity Dominates Hardware-Accelerated Operations**

Unity uses CPU intrinsics (SIMD) for certain operations:

| Operation | Unity | Native Ref | Winner |
|-----------|-------|------------|--------|
| **Magnitude (Vec2)** | 9.26 ns | 26.02 ns | Unity 2.81x faster |
| **Magnitude (Vec3)** | 9.91 ns | 27.11 ns | Unity 2.74x faster |

**Why?** Unity uses hardware SQRT instructions via SIMD; standard C++ `sqrtf()` can't compete.

---

#### **4. Pointer API Performance: Mixed Results**

The pointer-based `DirectVec2/DirectVec3` showed results I did not expect:

| Operation | Ref-Based | Pointer-Based | Winner |
|-----------|-----------|---------------|--------|
| **Property Access** | 3.02 ns | 22.14 ns | Ref 7.34x faster  |
| **Add (Vec2)** | 23.62 ns | 49.87 ns | Ref 2.11x faster  |
| **Magnitude (Vec2)** | 28.71 ns | 18.11 ns | **Pointer 1.59x faster** |
| **Dot (Vec2)** | 25.74 ns | 17.95 ns | **Pointer 1.43x faster** |
| **Distance (Vec2)** | 29.65 ns | 17.39 ns | **Pointer 1.70x faster** |

**Why pointer is slower for Add/Subtract:**
```csharp
// Pointer version must copy values via P/Invoke:
ptrResult.x = ptrA.x;  // P/Invoke call
ptrResult.y = ptrA.y;  // P/Invoke call
ptrResult.Add(ptrB);   // P/Invoke call
// Total: 3 P/Invoke calls!

// Ref version: Just one P/Invoke call
Vec2 result = VecHelper.Add(a, b);
```

**Why pointer is faster for Magnitude/Dot/Distance:**  
These operations only **read** data, no copying needed, just one P/Invoke call.

---

## Performance Insights

#### **1. P/Invoke Has Overhead (~5-10ns)**
Every call across the managed/unmanaged boundary costs time.

#### **2. Unity's Burst Compiler Is Fast**
For simple operations, Unity's optimizations are hard to beat.

#### **3. Native Shines for Complex Operations**
Multistep calculations benefit from staying in native code.

#### **4. Hardware Acceleration Matters**
Unity's SIMD optimizations (Magnitude) significantly outperform standard C++.

#### **5. Pointer API Needs Careful Use**
Only faster when you can avoid copying data between calls.

---

## Optimal Strategy: Hybrid Approach

**Use Unity Vector2/Vector3 for:**
- Simple arithmetic (Add, Subtract, Scale)
- Hardware-accelerated operations (Magnitude)
- Prototyping and general gameplay code

**Use Native Ref-Based Vec2/Vec3 for:**
- Complex operations (Normalize, Distance, Lerp)
- Custom algorithms not available in Unity's API
- Educational purposes (learning P/Invoke patterns)

**Use Native Pointer-Based DirectVec2/DirectVec3 for:**
- Read-only operations (Magnitude, Dot, Distance)
- Long-lived vectors accessed frequently
- Advanced optimization scenarios

**Avoid Native for:**
- Simple single operations in hot loops
- Operations Unity has hardware-accelerated

---

## Learning Value

While the performance gains are minimal, this project demonstrates:
- How to build and integrate native C++ libraries in Unity
- Understanding P/Invoke overhead and optimization strategies
- The power of Unity's Burst compiler and SIMD optimizations
- When to (and when not to) use native code
- Real-world performance benchmarking methodology

**Great for education, not necessary for production!**

---

## Conclusion

**In short: Stick with Unity!**

It's fun to create a project to test native implementations, but the overhead of creating and integrating it into Unity far outweighs the benefits of just using what Unity provides.

Unless you need a super-performant game that has proven bottlenecks, stick with Unity!

_"Premature optimization is the root of all evil!"_ -- **Donald Knuth**

---