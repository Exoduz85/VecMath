using System.Runtime.InteropServices;

namespace NativeVector
{
	public static class NativeVectorMath
	{
		const string DLL_NAME = "VecMath";
    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_Add(ref Vec2 a, ref Vec2 b, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_Subtract(ref Vec2 a, ref Vec2 b, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_Scale(ref Vec2 v, float scalar, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec2_Magnitude(ref Vec2 v);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec2_MagnitudeSquared(ref Vec2 v);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_Normalize(ref Vec2 v, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec2_Dot(ref Vec2 a, ref Vec2 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_Reflect(ref Vec2 direction, ref Vec2 normal, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec2_Distance(ref Vec2 a, ref Vec2 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec2_DistanceSquared(ref Vec2 a, ref Vec2 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_Lerp(ref Vec2 start, ref Vec2 end, float t, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec2_ClampMagnitude(ref Vec2 v, float maxLength, out Vec2 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec2_AngleBetween(ref Vec2 a, ref Vec2 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Add(ref Vec3 a, ref Vec3 b, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Subtract(ref Vec3 a, ref Vec3 b, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Scale(ref Vec3 v, float scalar, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec3_Magnitude(ref Vec3 v);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec3_MagnitudeSquared(ref Vec3 v);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Normalize(ref Vec3 v, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec3_Dot(ref Vec3 a, ref Vec3 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Cross(ref Vec3 a, ref Vec3 b, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Reflect(ref Vec3 direction, ref Vec3 normal, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec3_Distance(ref Vec3 a, ref Vec3 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec3_DistanceSquared(ref Vec3 a, ref Vec3 b);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Lerp(ref Vec3 start, ref Vec3 end, float t, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_Slerp(ref Vec3 start, ref Vec3 end, float t, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern void Vec3_ClampMagnitude(ref Vec3 v, float maxLength, out Vec3 result);
	    
	    [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
	    public static extern float Vec3_AngleBetween(ref Vec3 a, ref Vec3 b);
	}
}