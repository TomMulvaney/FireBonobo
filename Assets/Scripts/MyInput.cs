using UnityEngine;
using System.Collections;

public class MyInput : MonoBehaviour 
{
	public static bool GetJump()
	{
		return Input.GetKeyDown (KeyCode.Space);
	}

	public static float GetMoveX()
	{
		float moveX = 0;

		if(Input.GetKey (KeyCode.D))
		{
			moveX += 1;
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			moveX -= 1;
		}

		return moveX;
	}

	public static float GetMoveZ()
	{
		float moveZ = 0;
		
		if (Input.GetKey (KeyCode.W)) 
		{
			moveZ += 1;
		}

		if(Input.GetKey (KeyCode.S))
		{
			moveZ -= 1;
		}
		
		return moveZ;
	}

	public static bool GetFire0Down()
	{
		return Input.GetMouseButtonDown (0);
	}

	public static bool GetFire1Down()
	{
		return Input.GetMouseButtonDown (1);
	}

	public static bool GetFire0()
	{
		return Input.GetMouseButton (0);
	}
	
	public static bool GetFire1()
	{
		return Input.GetMouseButton (1);
	}

	public static bool GetSlowTime()
	{
		return Input.GetKey (KeyCode.LeftShift);
	}
}
