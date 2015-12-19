using UnityEngine;
using System.Collections;

public class WorldUtils : MonoBehaviour
{
	// Check collision between the object and the edges of the screen
	public static void StayInBounds(ref Rigidbody2D rb)
	{
		Vector3 viewportPosition = Camera.main.WorldToViewportPoint(rb.position);

		if(viewportPosition.x < 0.0f || viewportPosition.x > 1.0f)
		{
			rb.position = Camera.main.ViewportToWorldPoint(new Vector2(Mathf.Clamp01(viewportPosition.x), viewportPosition.y));
			rb.velocity = new Vector2(-rb.velocity.x * 0.75f, rb.velocity.y);
		}
	}

	public static float GetLeftEdge()
	{
		return Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
	}

	public static float GetRightEdge()
	{
		return Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f)).x;
	}
}
