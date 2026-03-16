using NativeVector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Paddles
{
	public class Paddle : MonoBehaviour
	{
		[Header("Paddle Settings")]
		public bool isLeftPad = true;
		public float moveSpeed = 8f;
		public float minY = -4f;
		public float maxY = 4f;
    
		KeyControl upKey;
		KeyControl downKey;
    
		void Start()
		{
			if (isLeftPad)
			{
				upKey = Keyboard.current.wKey;
				downKey = Keyboard.current.sKey;
			}
			else
			{
				upKey = Keyboard.current.upArrowKey;
				downKey = Keyboard.current.downArrowKey;
			}
		}
    
		void Update()
		{
			HandleMovement();
		}
    
		void HandleMovement()
		{
			var currentPos = Vec2.FromUnity(transform.position);
			var movement = new Vec2(0, 0);
        
			if (upKey.isPressed)
			{
				movement = new(0, 1);
			}
			else if (downKey.isPressed)
			{
				movement = new(0, -1);
			}
        
			if (movement.x != 0 || movement.y != 0)
			{
				movement = VecHelper.Normalize(movement);
            
				var scaledMovement = VecHelper.Scale(movement, moveSpeed * Time.deltaTime);
            
				var newPos = VecHelper.Add(currentPos, scaledMovement);
            
				newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
            
				transform.position = newPos.ToUnity();
			}
		}
	}
}