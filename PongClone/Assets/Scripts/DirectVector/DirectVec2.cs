using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DirectVector
{
	public unsafe class DirectVec2 : IDisposable
	{
		IntPtr handle;
		bool disposed;
    
		public DirectVec2(float x, float y)
		{
			handle = Vec2Direct.DirectVec2_Create(x, y);
		}

		float* Ptr => (float*)handle.ToPointer();
    
		public float x
		{
			get => Ptr[0];
			set => Ptr[0] = value;
		}
    
		public float y
		{
			get => Ptr[1];
			set => Ptr[1] = value;
		}
    
		public void Add(DirectVec2 other)
		{
			Vec2Direct.DirectVec2_Add(handle, other.handle);
		}
    
		public void Subtract(DirectVec2 other)
		{
			Vec2Direct.DirectVec2_Subtract(handle, other.handle);
		}
    
		public void Scale(float scalar)
		{
			Vec2Direct.DirectVec2_Scale(handle, scalar);
		}
    
		public float Magnitude()
		{
			return Vec2Direct.DirectVec2_Magnitude(handle);
		}
    
		public void Normalize()
		{
			Vec2Direct.DirectVec2_Normalize(handle);
		}
    
		public float Dot(DirectVec2 other)
		{
			return Vec2Direct.DirectVec2_Dot(handle, other.handle);
		}
    
		public void Reflect(DirectVec2 normal)
		{
			Vec2Direct.DirectVec2_Reflect(handle, normal.handle);
		}
    
		public float Distance(DirectVec2 other)
		{
			return Vec2Direct.DirectVec2_Distance(handle, other.handle);
		}
    
		public Vector2 ToUnity()
		{
			return new Vector2(x, y);
		}
    
		public static DirectVec2 FromUnity(Vector2 v)
		{
			return new DirectVec2(v.x, v.y);
		}
    
		public void Dispose()
		{
			if (!disposed)
			{
				Vec2Direct.DirectVec2_Destroy(handle);
				handle = IntPtr.Zero;
				disposed = true;
			}
		}
    
		~DirectVec2()
		{
			Dispose();
		}
    
		public override string ToString()
		{
			return $"({x:F2}, {y:F2})";
		}
	}

	public static class Vec2Direct
	{
		const string DLL_NAME = "VecMath";
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr DirectVec2_Create(float x, float y);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void DirectVec2_Destroy(IntPtr ptr);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void DirectVec2_Add(IntPtr a, IntPtr b);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void DirectVec2_Subtract(IntPtr a, IntPtr b);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void DirectVec2_Scale(IntPtr v, float scalar);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern float DirectVec2_Magnitude(IntPtr v);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void DirectVec2_Normalize(IntPtr v);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern float DirectVec2_Dot(IntPtr a, IntPtr b);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void DirectVec2_Reflect(IntPtr v, IntPtr normal);
    
		[DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern float DirectVec2_Distance(IntPtr a, IntPtr b);
	}
}