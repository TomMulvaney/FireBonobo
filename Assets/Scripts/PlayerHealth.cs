using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField]
	private int m_maxHealth = 100;

	int m_health;

	void Awake()
	{
		m_health = m_maxHealth;
	}

	public void OnBulletHit()
	{
		m_health -= 5;
	}

	void OnGUI()
	{
		GUILayout.Label ("Health: " + m_health);
	}
}
