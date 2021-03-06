﻿using UnityEngine;
using System.Collections;

public class ClickEvent : MonoBehaviour 
{
	public delegate void SingleClick(ClickEvent behaviour); // Pass this script just in case we want to add member variables in the future
	public event SingleClick OnSingleClick;

	[SerializeField]
	private int m_int;

	public int GetInt()
	{
		return m_int;
	}

	public void SetInt(int i)
	{
		m_int = i;
	}

    [SerializeField]
    private string m_string;

    public string GetString()
    {
        return m_string;
    }

    public void SetString(string s)
    {
        m_string = s;
    }

	void OnClick()
	{
		if(OnSingleClick != null)
		{
			OnSingleClick(this);
		}
	}

	public void EnableCollider(bool enable)
	{
		collider.enabled = enable;
	}
}
