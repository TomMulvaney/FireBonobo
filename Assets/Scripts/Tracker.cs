using UnityEngine;
using System.Collections;

// TODO: Merge with VerticallyRestrictedTracker
public class Tracker : BonoBohaviour 
{
	[SerializeField]
	private Transform m_trackedObject;
	
	void Update()
	{
		pos = m_trackedObject.position;
		
		Vector3 newEuler = m_trackedObject.eulerAngles;
		
		euler = newEuler;
	}
}
