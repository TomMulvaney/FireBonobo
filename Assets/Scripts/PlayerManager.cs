using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
	void Start () 
	{
		Enemy[] enemies = Object.FindObjectsOfType (typeof(Enemy)) as Enemy[];

		foreach (Enemy enemy in enemies) 
		{
			enemy.SetTarget(transform);
		}
	}
}
