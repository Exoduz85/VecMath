namespace NativeVector
{
	public static class VecHelper
	{
        public static Vec2 Add(Vec2 a, Vec2 b)
        {
            NativeVectorMath.Vec2_Add(ref a, ref b, out var result);
            return result;
        }
        
        public static Vec2 Subtract(Vec2 a, Vec2 b)
        {
            NativeVectorMath.Vec2_Subtract(ref a, ref b, out var result);
            return result;
        }
        
        public static Vec2 Scale(Vec2 v, float scalar)
        {
            NativeVectorMath.Vec2_Scale(ref v, scalar, out var result);
            return result;
        }
        
        public static float Magnitude(Vec2 v)
        {
            return NativeVectorMath.Vec2_Magnitude(ref v);
        }
        
        public static float MagnitudeSquared(Vec2 v)
        {
            return NativeVectorMath.Vec2_MagnitudeSquared(ref v);
        }
        
        public static Vec2 Normalize(Vec2 v)
        {
            NativeVectorMath.Vec2_Normalize(ref v, out var result);
            return result;
        }
        
        public static float Dot(Vec2 a, Vec2 b)
        {
            return NativeVectorMath.Vec2_Dot(ref a, ref b);
        }
        
        public static Vec2 Reflect(Vec2 direction, Vec2 normal)
        {
            NativeVectorMath.Vec2_Reflect(ref direction, ref normal, out var result);
            return result;
        }
        
        public static float Distance(Vec2 a, Vec2 b)
        {
            return NativeVectorMath.Vec2_Distance(ref a, ref b);
        }
        
        public static float DistanceSquared(Vec2 a, Vec2 b)
        {
            return NativeVectorMath.Vec2_DistanceSquared(ref a, ref b);
        }
        
        public static Vec2 Lerp(Vec2 start, Vec2 end, float t)
        {
            NativeVectorMath.Vec2_Lerp(ref start, ref end, t, out var result);
            return result;
        }
        
        public static Vec2 ClampMagnitude(Vec2 v, float maxLength)
        {
            NativeVectorMath.Vec2_ClampMagnitude(ref v, maxLength, out var result);
            return result;
        }
        
        public static float AngleBetween(Vec2 a, Vec2 b)
        {
            return NativeVectorMath.Vec2_AngleBetween(ref a, ref b);
        }
        
        public static Vec3 Add(Vec3 a, Vec3 b)
        {
            NativeVectorMath.Vec3_Add(ref a, ref b, out var result);
            return result;
        }
        
        public static Vec3 Subtract(Vec3 a, Vec3 b)
        {
            NativeVectorMath.Vec3_Subtract(ref a, ref b, out var result);
            return result;
        }
        
        public static Vec3 Scale(Vec3 v, float scalar)
        {
            NativeVectorMath.Vec3_Scale(ref v, scalar, out var result);
            return result;
        }
        
        public static float Magnitude(Vec3 v)
        {
            return NativeVectorMath.Vec3_Magnitude(ref v);
        }
        
        public static float MagnitudeSquared(Vec3 v)
        {
            return NativeVectorMath.Vec3_MagnitudeSquared(ref v);
        }
        
        public static Vec3 Normalize(Vec3 v)
        {
            NativeVectorMath.Vec3_Normalize(ref v, out var result);
            return result;
        }
        
        public static float Dot(Vec3 a, Vec3 b)
        {
            return NativeVectorMath.Vec3_Dot(ref a, ref b);
        }
        
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            NativeVectorMath.Vec3_Cross(ref a, ref b, out var result);
            return result;
        }
        
        public static Vec3 Reflect(Vec3 direction, Vec3 normal)
        {
            NativeVectorMath.Vec3_Reflect(ref direction, ref normal, out var result);
            return result;
        }
        
        public static float Distance(Vec3 a, Vec3 b)
        {
            return NativeVectorMath.Vec3_Distance(ref a, ref b);
        }
        
        public static float DistanceSquared(Vec3 a, Vec3 b)
        {
            return NativeVectorMath.Vec3_DistanceSquared(ref a, ref b);
        }
        
        public static Vec3 Lerp(Vec3 start, Vec3 end, float t)
        {
            NativeVectorMath.Vec3_Lerp(ref start, ref end, t, out var result);
            return result;
        }
        
        public static Vec3 Slerp(Vec3 start, Vec3 end, float t)
        {
            NativeVectorMath.Vec3_Slerp(ref start, ref end, t, out var result);
            return result;
        }
        
        public static Vec3 ClampMagnitude(Vec3 v, float maxLength)
        {
            NativeVectorMath.Vec3_ClampMagnitude(ref v, maxLength, out var result);
            return result;
        }
        
        public static float AngleBetween(Vec3 a, Vec3 b)
        {
            return NativeVectorMath.Vec3_AngleBetween(ref a, ref b);
        }
	}
}