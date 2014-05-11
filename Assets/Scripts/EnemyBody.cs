using UnityEngine;
using System.Collections;

public class EnemyBody : MonoBehaviour 
{
	[SerializeField]
	private Enemy m_enemy;

	public void OnBulletHit()
	{
		m_enemy.OnBulletHit ();
	}
}
