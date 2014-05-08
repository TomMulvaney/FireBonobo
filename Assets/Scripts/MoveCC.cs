using UnityEngine;
using System.Collections;

public class MoveCC : Singleton<MoveCC> 
{
	[SerializeField]
	private CharacterController m_control;
	[SerializeField]
	private Transform m_forward;
	[SerializeField]
	private int m_jumpHeight = 6;
	[SerializeField]
	private float m_jumpTime = 1.5f;
	[SerializeField]
	private float m_gravity;
	[SerializeField]
	private Vector2 m_maxSpeed;

	float m_jumpSpeed
	{
		get
		{
			float jump = (((float)m_jumpHeight - (0.5f * m_gravity * m_jumpTime * m_jumpTime)) / m_jumpTime);
			return jump;
		}
	}

	Vector3 m_localMove;
	public Vector3 localMove
	{
		get
		{
			return m_localMove;
		}
	}

	float m_modAll
	{
		get
		{
			return Time.deltaTime;
		}
	}

	float m_mod
	{
		get
		{
			return 1;
		}
	}


	//////////////////////////////////////////////////////////////////////
	// TODO: These only need to be a member variable for debugging
	Vector3 m_globalMove;
	public Vector3 globalMove
	{
		get
		{
			return m_globalMove;
		}
	}

	public bool isGrounded
	{
		get
		{
			return m_control.isGrounded;
		}
	}
	//////////////////////////////////////////////////////////////////////


	// Update is called once per frame
	void Update () 
	{
		if (SM.Instance.state == SM.State.Grounded || SM.Instance.state == SM.State.Air) 
		{
			ApplyHorizontal();

			if(CollisionDetection.Instance.isGrounded)
			{
				CheckJump();
			}
			else
			{
				ApplyGravity();
			}
		}

		m_globalMove = m_forward.TransformDirection (m_localMove);

		if (!Mathf.Approximately (m_localMove.y, 0) && !CollisionDetection.Instance.isGrounded) 
		{
			//Debug.Log("localY: " + m_localMove.y);
		}

		m_control.Move (m_globalMove * m_modAll);
	}

	void ApplyHorizontal()
	{
		Vector3 horizontalMove = Vector3.zero;

		if (Input.GetKey (KeyCode.W)) 
		{
			horizontalMove.z = m_maxSpeed.x;
		} 
		else if (Input.GetKey (KeyCode.S)) 
		{
			horizontalMove.z = -m_maxSpeed.x;
		}
		
		if (Input.GetKey (KeyCode.A)) 
		{
			horizontalMove.x = -m_maxSpeed.x;
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			horizontalMove.x = m_maxSpeed.x;
		}

		if (horizontalMove.magnitude > m_maxSpeed.x) 
		{
			horizontalMove = horizontalMove.normalized * m_maxSpeed.x;
		}

		horizontalMove *= m_mod;

		m_localMove = new Vector3 (horizontalMove.x, m_localMove.y, horizontalMove.z);
	}

	void CheckJump()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			m_localMove.y = m_jumpSpeed * m_mod;

			m_numGravLogs = 5;

			StartCoroutine(LogMoveY(1));
		}
	}

	int m_numGravLogs = 0;

	void ApplyGravity()
	{
		//m_localMove.y += m_gravity * m_modAll;
		m_localMove.y += m_gravity * m_modAll;

		if (m_numGravLogs > 0) 
		{
			Debug.Log ("GRAV: " + m_gravity * m_modAll);
			Debug.Log ("post: " + m_localMove.y);
			--m_numGravLogs;
		}
	}

	IEnumerator LogMoveY(float delay)
	{
		yield return new WaitForSeconds(delay);

		Debug.Log ("moveY: " + m_localMove.y);
	}
}
