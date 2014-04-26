using UnityEngine;
using System.Collections;

public class VerticallyRestrictedTracker : BonoBohaviour 
{
	[SerializeField]
	private Transform m_trackedObject;

	void Update()
	{
		pos = m_trackedObject.position;

		Vector3 newEuler = m_trackedObject.eulerAngles;
		newEuler.x = 0;

		euler = newEuler;
	}
}
