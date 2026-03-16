using NativeVector;
using UnityEngine;

namespace Walls
{
	public class Wall : MonoBehaviour
	{
		[Header("Wall Settings")]
		[Tooltip("Normal direction for reflection (should point away from wall)")]
		public Vector2 normalDirection = Vector2.up;
        
		[Header("Debug")]
		[Tooltip("Show normal direction in Scene view")]
		public bool showDebugNormal = true;

		Vec2 normal;
        
		void Start()
		{
			normal = Vec2.FromUnity(normalDirection);
			normal = VecHelper.Normalize(normal);
		}
        
		public Vec2 GetNormal()
		{
			return normal;
		}
        
		void OnValidate()
		{
			if (normalDirection.sqrMagnitude > 0.0001f)
			{
				normalDirection = normalDirection.normalized;
			}
		}
        
		void OnDrawGizmos()
		{
			if (!showDebugNormal) return;
            
			Gizmos.color = Color.cyan;
			var start = transform.position;
			var end = start + (Vector3)normalDirection * 2f;
            
			Gizmos.DrawLine(start, end);
            
			var right = Vector3.Cross(normalDirection, Vector3.forward).normalized * 0.3f;
			Gizmos.DrawLine(end, end - (Vector3)normalDirection * 0.5f + right);
			Gizmos.DrawLine(end, end - (Vector3)normalDirection * 0.5f - right);
		}
	}
}