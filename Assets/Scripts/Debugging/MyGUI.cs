using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour 
{
	void OnGUI()
	{
		if (SM.Instance != null) 
		{
			GUILayout.Label ("State: " + SM.Instance.state);
		}

		if (MoveRB.Instance != null) 
		{
			GUILayout.Label ("Force: " + MoveRB.Instance.force);
			GUILayout.Label ("Impulse: " + MoveRB.Instance.impulse);
			GUILayout.Label ("Velocity: " + MoveRB.Instance.rigidbody.velocity);
			GUILayout.Label ("Speed: " + MoveRB.Instance.rigidbody.velocity.magnitude);
		}

		if (MoveCC.Instance != null) 
		{
			GUILayout.Label ("LocalMove: " + MoveCC.Instance.localMove);
			GUILayout.Label ("GlobalMove: " + MoveCC.Instance.globalMove);
			//GUILayout.Label ("isGrounded: " + MoveCC.Instance.isGrounded);
		}

		if (CollisionDetection.Instance != null) 
		{
			GUILayout.Label ("isGrounded: " + CollisionDetection.Instance.isGrounded);
		}
	}
}
