using UnityEngine;
using System.Collections;

public class PlayerGun : Gun 
{
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
			Fire(m_forward.forward);
		}
		
		float delay = isFiring ? m_cooldown : 0;
		yield return new WaitForSeconds (delay);
		
		StartCoroutine(CheckFire ());
	}
}
