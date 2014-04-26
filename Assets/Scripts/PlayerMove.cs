using UnityEngine;
using System.Collections;

public class PlayerMove : Singleton<PlayerMove> 
{
	[SerializeField]
	private Transform m_forward;
	[SerializeField]
	private Vector3 m_maxVelocity;
	[SerializeField]
	private Vector2 m_acceleration;

	Vector3 m_move = Vector3.zero;
	public Vector3 move
	{
		get
		{
			return m_move;
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

		rigidbody.velocity = m_move;
	}

	void ClampMove()
	{
		Vector3 move = m_move;

		move.x = Mathf.Clamp (move.x, -m_maxVelocity.x, m_maxVelocity.x);
		move.y = Mathf.Clamp (move.y, -m_maxVelocity.y, m_maxVelocity.y);
		move.z = Mathf.Clamp (move.z, -m_maxVelocity.z, m_maxVelocity.z);
	}

	void MoveHorizontal()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			m_move += m_forward.forward * m_acceleration.x * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.S)) 
		{
			m_move -= m_forward.forward * m_acceleration.x * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			m_move -= m_forward.right * m_acceleration.y * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.D)) 
		{
			m_move += m_forward.right * m_acceleration.y * Time.deltaTime;
		}
	}

	void OnStateChange(SM.State state, SM.State nextState)
	{

	}
}
