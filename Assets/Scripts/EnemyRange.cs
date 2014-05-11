using UnityEngine;
using System.Collections;

public class EnemyRange : MonoBehaviour 
{
	[SerializeField]
	private Enemy m_enemy;

	void OnTriggerEnter(Collider other)
	{
		m_enemy.OnRangeEvent (other.transform, true);
	}
	
	void OnTriggerExit(Collider other)
	{
		m_enemy.OnRangeEvent (other.transform, false);
	}
}
