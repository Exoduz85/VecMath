using UnityEngine;

namespace Goals
{
	public class Goal : MonoBehaviour
	{
		[Header("Goal Settings")]
		[Tooltip("Which player scores when ball enters this goal (1 = left scores, 2 = right scores)")]
		public int scoringPlayer = 1;
        
		[Header("Debug")]
		public bool showDebugInfo = true;
        
		void OnDrawGizmos()
		{
			if (!showDebugInfo) return;
            
			Gizmos.color = scoringPlayer == 1 ? Color.blue : Color.red;
            
			if (TryGetComponent<BoxCollider2D>(out var boxCollider))
			{
				Gizmos.matrix = transform.localToWorldMatrix;
				Gizmos.DrawWireCube(boxCollider.offset, boxCollider.size);
			}
		}
	}
}