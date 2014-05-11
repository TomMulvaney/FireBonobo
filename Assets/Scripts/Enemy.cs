using UnityEngine;
using System.Collections;

public class Enemy : BonoBohaviour 
{
	[SerializeField]
	private Transform m_target;
	[SerializeField]
	private Transform m_body;
	[SerializeField]
	private float m_targetCheckInterval = 5;
	[SerializeField]
	private Gun m_gun;

	bool m_targetInSight;

	public void SetTarget(Transform target)
	{
		m_target = target;
	}

	public void OnBulletHit()
	{
		StartCoroutine (OnBulletHitCo ());
	}

	IEnumerator OnBulletHitCo()
	{
		float tweenDuration = 0.5f;

		iTween.ScaleTo (gameObject, Vector3.zero, tweenDuration);

		yield return new WaitForSeconds (tweenDuration);

		Destroy (gameObject);
	}

	/*
	void OnTriggerEnter(Collider other)
	{
		if (other.transform == m_target) 
		{
			StartCoroutine (CheckForTarget ());
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.transform == m_target) 
		{
			StopAllCoroutines();
			m_targetInSight = false;
		}
	}
	*/

	public void OnRangeEvent(Transform tra, bool inRange)
	{
		if (tra == m_target) 
		{
			if (inRange) 
			{
				StartCoroutine (CheckForTarget ());
			} 
			else 
			{
				StopAllCoroutines ();
				m_targetInSight = false;
			}
		}
	}

	IEnumerator CheckForTarget()
	{
		RaycastHit hit;

		m_targetInSight = Physics.Raycast (pos, (m_target.position - pos).normalized, out hit) && hit.transform == m_target; 

		yield return new WaitForSeconds (m_targetCheckInterval);

		StartCoroutine (CheckForTarget ());
	}

	void Update()
	{
		if (m_targetInSight) 
		{
			Vector3 direction = (m_target.position - pos).normalized;
			m_gun.pos = pos + (direction * m_body.lossyScale.y * 1.2f);
			m_gun.Fire(direction);
		}
	}
}
