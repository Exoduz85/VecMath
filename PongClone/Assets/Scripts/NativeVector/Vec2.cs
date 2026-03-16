using System.Runtime.InteropServices;
using UnityEngine;

namespace NativeVector
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Vec2
	{
		public float x;
		public float y;
    
		public Vec2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vec2 FromUnity(Vector2 v)
		{
			return new Vec2(v.x, v.y);
		}
    
		public Vector2 ToUnity()
		{
			return new Vector2(x, y);
		}
    
		public override string ToString()
		{
			return $"({x:F2}, {y:F2})";
		}
	}
}