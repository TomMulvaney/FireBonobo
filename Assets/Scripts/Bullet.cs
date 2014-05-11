using UnityEngine;
using System.Collections;

public class Bullet : Projectile 
{
    void OnCollisionEnter(Collision other)
	{
		if (!m_tagsAreExceptions && m_tags.Contains(other.gameObject.tag) || m_tagsAreExceptions && !m_tags.Contains(other.gameObject.tag)) 
		{
			other.gameObject.SendMessage("OnBulletHit");
		}

		Destroy (gameObject);
	}
}
