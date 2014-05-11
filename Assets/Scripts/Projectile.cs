using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : BonoBohaviour 
{
	[SerializeField]
	private float m_speed;
	[SerializeField]
	protected List<string> m_tags = new List<string>();
	[SerializeField]
	protected bool m_tagsAreExceptions = false;

	Vector3 m_direction;

	bool m_hasAppliedForce = false;
	
	public virtual void On(Vector3 direction)
	{
		m_direction = direction.normalized;

		//Debug.Log ("ProjectileDirection: " + m_direction);
	}

	void FixedUpdate()
	{
		if (!m_hasAppliedForce) 
		{
			rigidbody.AddForce (m_direction * m_speed, ForceMode.VelocityChange);
			m_hasAppliedForce = true;
			//Debug.Log ("m_speed: " + m_speed);
			//Debug.Log ("m_direction: " + m_direction);
			//Debug.Log ("vel: " + rigidbody.velocity);
		}
	}

	public void AddTag(string tag)
	{
		m_tags.Add (tag);
	}
	
	public void RemoveTag(string tag)
	{
		m_tags.Remove (tag);
	}
}
