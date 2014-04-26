using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour 
{
	void OnGUI()
	{
		GUILayout.Label ("State: " + SM.Instance.state);
		GUILayout.Label ("Move: " + PlayerMove.Instance.move);
		GUILayout.Label ("Velocity: " + PlayerMove.Instance.rigidbody.velocity);
		GUILayout.Label ("Speed: " + PlayerMove.Instance.rigidbody.velocity.magnitude);
	}
}
