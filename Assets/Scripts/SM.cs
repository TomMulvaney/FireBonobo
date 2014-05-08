using UnityEngine;
using System.Collections;

public class SM : Singleton<SM>
{
	public delegate void StateChanging(State state, State nextState);
	public event StateChanging StateChangingEventHandler;

	bool m_isLocked;

	// TODO: Merge Grounded and Air into single state "Run". Have ColliDet script return bool whether can jump because might be able to jump in Override
	public enum State
	{
		Grounded,
		Air,
		Override
	}

	State m_state;
	public State state
	{
		get
		{
			return m_state;
		}
	}

	State m_nextState;

	void Update()
	{
		if (m_nextState != m_state) 
		{
			if(StateChangingEventHandler != null)
			{
				StateChangingEventHandler(m_state, m_nextState);
			}

			m_state = m_nextState;
		}
	}

	public bool RequestChange(State nextState, bool useLock = false)
	{
		bool hasChanged = false;

		if (!m_isLocked || nextState < m_state) 
		{
			m_nextState = nextState;
			m_isLocked = useLock;
		}

		return hasChanged;
	}
}
