using UnityEngine;
using System.Collections;

public class MoveRB : Singleton<MoveRB> 
{
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
	
	Vector3 m_force = Vector3.zero;
	public Vector3 force
	{
		get
		{
			return m_force;
		}
	}

	Vector3 m_impulse = Vector3.zero;
	public Vector3 impulse
	{
		get
		{
			return m_impulse;
		}
	}

	float m_jumpSpeed
	{
		get
		{
			//float jump = (((float)m_jumpHeight / m_jumpTime) - (m_gravity * m_jumpTime / 2f));
			float jump = (((float)m_jumpHeight - (float)(0.5f * (float)m_gravity * (float)m_jumpTime * (float)m_jumpTime)) / (float)m_jumpTime);
			Debug.Log("jump: " + jump);
			return jump;
			
			//return 5.5f;
		}
	}
	
	void Start()
	{
		SM.Instance.StateChangingEventHandler += OnStateChange;
	}
	
	void Update()
	{
		// Check jump
		switch (SM.Instance.state) 
		{
		case SM.State.Grounded:
			if(MyInput.GetJump())
			{
				m_applyJump = true;
			}
			break;
		default:
			break;
		}
	}

	bool m_applyJump = false;

	void FixedUpdate()
	{
		m_impulse = Vector3.zero;

		switch (SM.Instance.state) 
		{
		case SM.State.Grounded:
			m_impulse = new Vector3(-rigidbody.velocity.x, 0, -rigidbody.velocity.z); 
			//m_impulse = new Vector3(-m_impulse.x, 0, -m_impulse.z); 
			//CheckImpulseError();
			MoveHorizontal();
			break;
		case SM.State.Air:
			m_impulse = new Vector3(-rigidbody.velocity.x, 0, -rigidbody.velocity.z); 
			//m_impulse = new Vector3(-m_impulse.x, 0, -m_impulse.z); 
			MoveHorizontal();
			m_force.y += m_gravity;
			break;
		case SM.State.Override:
			break;
		default:
			break;
		}

		if (m_applyJump) 
		{
			m_impulse.y = m_jumpSpeed;
			m_applyJump = false;
		}

		if (m_force.x > 1 || m_force.z > 1) 
		{
			Debug.LogError("FORCE: " + m_force);
		}

		m_impulse = m_forward.TransformDirection (m_impulse);
		
		rigidbody.AddForce (m_impulse, ForceMode.Impulse);
		rigidbody.AddForce (m_force, ForceMode.Force);
	}
	
	void MoveHorizontal()
	{
		Vector3 horizontal = new Vector3 (MyInput.GetMoveX (), 0, MyInput.GetMoveZ ());
		//Debug.Log ("horizontal: " + horizontal);

		if (horizontal.magnitude > 1) 
		{
			horizontal.Normalize();
		}

		horizontal *= m_maxSpeed.x;

		//Debug.Log ("adjustedHorizontal: " + horizontal);

		if (horizontal.magnitude > m_maxSpeed.x * 2) 
		{
			Debug.LogError("HORIZONTAL: " + horizontal);
		}

		m_impulse += horizontal;
	}
	
	void OnStateChange(SM.State state, SM.State nextState)
	{
		Debug.Log ("OnStateChange: " + nextState);
		if (nextState == SM.State.Grounded) 
		{
			Debug.Log("Resetting force");
			m_force.y = 0f;
			Debug.Log("force: " + m_force);
		}
	}

	void CheckImpulseError()
	{
		if (m_impulse.magnitude > m_maxSpeed.x * 2) 
		{
			Debug.LogError("IMPULSE: " + m_impulse);
			Debug.LogError("Vel: " + rigidbody.velocity);
			Debug.LogError("State: " + SM.Instance.state);
		}
	}
}

/*
using UnityEngine;
using System.Collections;

public class MoveRB : Singleton<MoveRB> 
{
	[SerializeField]
	private Transform m_forward;
	[SerializeField]
	private Vector3 m_maxVelocity;
	[SerializeField]
	private Vector2 m_acceleration;

	Vector3 m_force = Vector3.zero;
	public Vector3 move
	{
		get
		{
			return m_force;
		}
	}

	void Start()
	{
		SM.Instance.StateChangingEventHandler += OnStateChange;
	}

	void FixedUpdate()
	{
		switch (SM.Instance.state) 
		{
		case SM.State.Grounded:
			MoveHorizontal();
			break;
		case SM.State.Air:
			MoveHorizontal();
			break;
		case SM.State.Override:
			break;
		default:
			break;
		}

		ClampMove ();

		rigidbody.velocity = m_force;
	}

	void ClampMove()
	{
		Vector3 move = m_force;

		move.x = Mathf.Clamp (move.x, -m_maxVelocity.x, m_maxVelocity.x);
		move.y = Mathf.Clamp (move.y, -m_maxVelocity.y, m_maxVelocity.y);
		move.z = Mathf.Clamp (move.z, -m_maxVelocity.z, m_maxVelocity.z);
	}

	void MoveHorizontal()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			m_force += m_forward.forward * m_acceleration.x * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.S)) 
		{
			m_force -= m_forward.forward * m_acceleration.x * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			m_force -= m_forward.right * m_acceleration.y * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			m_force += m_forward.right * m_acceleration.y * Time.deltaTime;
		}
	}

	void OnStateChange(SM.State state, SM.State nextState)
	{

	}
}
*/
