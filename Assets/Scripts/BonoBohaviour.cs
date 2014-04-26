using UnityEngine;
using System.Collections;

public class BonoBohaviour : MonoBehaviour 
{
	public virtual void On() {}
	public virtual void Off() {}

	public Vector3 pos
	{
		get
		{
			return transform.position;
		}
		set
		{
			transform.position = value;
		}
	}
	
	public float posX
	{
		get
		{
			return transform.position.x;
		}
	}
	
	public float posY
	{
		get
		{
			return transform.position.y;
		}
	}
	
	public float posZ
	{
		get
		{
			return transform.position.z;
		}
	}

	public Vector3 localPos
	{
		get
		{
			return transform.localPosition;
		}
	}
	
	public float localPosX
	{
		get
		{
			return transform.localPosition.x;
		}
	}
	
	public float localPosY
	{
		get
		{
			return transform.localPosition.y;
		}
	}
	
	public float localPosZ
	{
		get
		{
			return transform.localPosition.z;
		}
	}

	public Vector3 euler
	{
		get
		{
			return transform.eulerAngles;
		}
		set
		{
			transform.eulerAngles = value;
		}
	}

	public float eulerX
	{
		get
		{
			return transform.eulerAngles.x;
		}
	}

	public float eulerY
	{
		get
		{
			return transform.eulerAngles.y;
		}
		set
		{
			Vector3 newEuler = transform.eulerAngles;
			newEuler.y = value;
			transform.eulerAngles = newEuler;
		}
	}

	public float eulerZ
	{
		get
		{
			return transform.eulerAngles.z;
		}
	}

	public Vector3 localEuler
	{
		get
		{
			return transform.eulerAngles;
		}
	}
	
	public float localEulerX
	{
		get
		{
			return transform.localEulerAngles.x;
		}
	}
	
	public float localEulerY
	{
		get
		{
			return transform.localEulerAngles.y;
		}
	}
	
	public float localEulerZ
	{
		get
		{
			return transform.localEulerAngles.z;
		}
	}

	public Quaternion rot
	{
		get
		{
			return transform.rotation;
		}
	}
	
	public float rotX
	{
		get
		{
			return transform.rotation.x;
		}
	}
	
	public float rotY
	{
		get
		{
			return transform.rotation.y;
		}
	}
	
	public float rotZ
	{
		get
		{
			return transform.rotation.z;
		}
	}

	public Quaternion localRot
	{
		get
		{
			return transform.localRotation;
		}
	}

	public float localRotX
	{
		get
		{
			return transform.localRotation.x;
		}
	}

	public float localRotY
	{
		get
		{
			return transform.localRotation.y;
		}
	}

	public float localRotZ
	{
		get
		{
			return transform.rotation.z;
		}
	}

	public Vector3 sca
	{
		get
		{
			return transform.lossyScale;
		}
	}
	
	public float scaX
	{
		get
		{
			return transform.lossyScale.x;
		}
	}
	
	public float scaY
	{
		get
		{
			return transform.lossyScale.y;
		}
	}
	
	public float scaZ
	{
		get
		{
			return transform.lossyScale.z;
		}
	}

	public Vector3 localSca
	{
		get
		{
			return transform.localScale;
		}
	}

	public float localScaX
	{
		get
		{
			return transform.localScale.x;
		}
	}
	
	public float localScaY
	{
		get
		{
			return transform.localScale.y;
		}
	}
	
	public float localScaZ
	{
		get
		{
			return transform.localScale.z;
		}
	}
}
