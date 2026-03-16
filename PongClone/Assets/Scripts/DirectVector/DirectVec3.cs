using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DirectVector
{
	public unsafe class DirectVec3 : IDisposable
	{
        IntPtr handle;
        bool disposed;
        
        public DirectVec3(float x, float y, float z)
        {
            handle = Vec3Direct.DirectVec3_Create(x, y, z);
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
        
        public float z
        {
            get => Ptr[2];
            set => Ptr[2] = value;
        }
        
        public void Add(DirectVec3 other)
        {
            Vec3Direct.DirectVec3_Add(handle, other.handle);
        }
        
        public void Subtract(DirectVec3 other)
        {
            Vec3Direct.DirectVec3_Subtract(handle, other.handle);
        }
        
        public void Scale(float scalar)
        {
            Vec3Direct.DirectVec3_Scale(handle, scalar);
        }
        
        public float Magnitude()
        {
            return Vec3Direct.DirectVec3_Magnitude(handle);
        }
        
        public void Normalize()
        {
            Vec3Direct.DirectVec3_Normalize(handle);
        }
        
        public float Dot(DirectVec3 other)
        {
            return Vec3Direct.DirectVec3_Dot(handle, other.handle);
        }
        
        public DirectVec3 Cross(DirectVec3 other)
        {
            var result = new DirectVec3(0, 0, 0);
            Vec3Direct.DirectVec3_Cross(result.handle, handle, other.handle);
            return result;
        }
        
        public void Reflect(DirectVec3 normal)
        {
            Vec3Direct.DirectVec3_Reflect(handle, normal.handle);
        }
        
        public float Distance(DirectVec3 other)
        {
            return Vec3Direct.DirectVec3_Distance(handle, other.handle);
        }
        
        public Vector3 ToUnity()
        {
            return new Vector3(x, y, z);
        }
        
        public static DirectVec3 FromUnity(Vector3 v)
        {
            return new DirectVec3(v.x, v.y, v.z);
        }
        
        public void Dispose()
        {
            if (!disposed)
            {
                Vec3Direct.DirectVec3_Destroy(handle);
                handle = IntPtr.Zero;
                disposed = true;
            }
        }
        
        ~DirectVec3()
        {
            Dispose();
        }
        
        public override string ToString()
        {
            return $"({x:F2}, {y:F2}, {z:F2})";
        }
	}
    
    public static class Vec3Direct
    {
        const string DLL_NAME = "VecMath";
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DirectVec3_Create(float x, float y, float z);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Destroy(IntPtr ptr);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Add(IntPtr a, IntPtr b);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Subtract(IntPtr a, IntPtr b);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Scale(IntPtr v, float scalar);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern float DirectVec3_Magnitude(IntPtr v);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Normalize(IntPtr v);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern float DirectVec3_Dot(IntPtr a, IntPtr b);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Cross(IntPtr result, IntPtr a, IntPtr b);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DirectVec3_Reflect(IntPtr v, IntPtr normal);
    
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern float DirectVec3_Distance(IntPtr a, IntPtr b);
    }
}