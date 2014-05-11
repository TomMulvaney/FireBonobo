using UnityEngine;
using System.Collections;
using Wingrove;

public class Gun : BonoBohaviour 
{
	[SerializeField]
	protected Transform m_forward;
	[SerializeField]
	private GameObject m_projectilePrefab;
	[SerializeField]
	protected float m_cooldown;
	[SerializeField]
	private string[] m_bulletTags;

	bool m_canFire = true;

	public void Fire(Vector3 direction)
	{
		if (m_canFire) 
		{
			Debug.Log("Firing - " + Time.time);
			GameObject newProjectile = SpawningHelpers.InstantiateUnderWithIdentityTransforms (m_projectilePrefab, transform);
			newProjectile.transform.parent = null;
			//Debug.Log("fireDirection: " + direction);

			Projectile projectileBehaviour = newProjectile.GetComponent<Projectile> () as Projectile;
			projectileBehaviour.On (direction);
			foreach(string tag in m_bulletTags)
			{
				projectileBehaviour.AddTag(tag);
			}

			m_canFire = false;
			StartCoroutine (ResetCanFire ());
		}
	}

	IEnumerator ResetCanFire()
	{
		yield return new WaitForSeconds (m_cooldown);
		m_canFire = true;
	}
}
