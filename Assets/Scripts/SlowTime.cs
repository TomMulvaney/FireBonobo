using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour 
{
	[SerializeField]
	private float m_slowTimeScale = 0.2f;

	// Update is called once per frame
	void Update () 
	{
		Time.timeScale = MyInput.GetSlowTime () ? m_slowTimeScale : 1;
	}
}
