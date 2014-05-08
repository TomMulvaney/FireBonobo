using UnityEngine;
using System.Collections;
using Wingrove;

public class Gun : MonoBehaviour 
{
	[SerializeField]
	private Transform m_forward;
	[SerializeField]
	private GameObject m_projectilePrefab;
	[SerializeField]
	private float m_cooldown;
	[SerializeField]
	private bool m_isAutomatic;
	
	void Start()
	{
		StartCoroutine (CheckFire ());
	}

	IEnumerator CheckFire()
	{
		bool isFiring = m_isAutomatic ? MyInput.GetFire0 () : MyInput.GetFire0Down ();

		if (isFiring) 
		{
			GameObject newProjectile = SpawningHelpers.InstantiateUnderWithIdentityTransforms(m_projectilePrefab, transform);
			newProjectile.transform.parent = null;
			Debug.Log("gunForward: " + m_forward.forward);
			newProjectile.GetComponent<Projectile> ().On (m_forward.forward);
		}

		float delay = isFiring ? m_cooldown : 0;
		yield return new WaitForSeconds (delay);

		StartCoroutine(CheckFire ());
	}
}
