using UnityEngine;
using System.Collections;

public class CollisionDetection : Singleton<CollisionDetection> 
{
	bool m_isGrounded;
	public bool isGrounded
	{
		get
		{
			return m_isGrounded;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckGrounded ();

		if (m_isGrounded && SM.Instance.state == SM.State.Air) 
		{
			SM.Instance.RequestChange (SM.State.Grounded);
		} 
		else if (!m_isGrounded && SM.Instance.state == SM.State.Grounded) 
		{
			SM.Instance.RequestChange (SM.State.Air);
		}
	}

	void CheckGrounded()
	{
		RaycastHit hit;

		m_isGrounded = Physics.Raycast (pos, Vector3.down, out hit, 1.1f);
	}
}
