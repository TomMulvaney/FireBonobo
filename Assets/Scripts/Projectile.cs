using UnityEngine;
using System.Collections;

public class Projectile : BonoBohaviour 
{
	[SerializeField]
	private float m_speed;

	Vector3 m_direction;

	bool m_hasAppliedForce = false;
	
	public virtual void On(Vector3 direction)
	{
		m_direction = direction.normalized;

		Debug.Log ("ProjectileDirection: " + m_direction);
	}

	void FixedUpdate()
	{
		if (!m_hasAppliedForce) 
		{
			rigidbody.AddForce (m_direction * m_speed, ForceMode.VelocityChange);
			m_hasAppliedForce = true;
			Debug.Log ("projectileVel: " + rigidbody.velocity);
		}
	}
}
