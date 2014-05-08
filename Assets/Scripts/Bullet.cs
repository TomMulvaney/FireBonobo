using UnityEngine;
using System.Collections;

public class Bullet : Projectile 
{
    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.SendMessage("Off");
		}

		Destroy (gameObject);
	}
}
