using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player's bullet movement and collisions with enemies
/// </summary>

public class PlayerBulletController : MonoBehaviour
{
	public Vector2 speed;
	public float bulletLifeTime;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();

		rb.velocity = speed;

		Invoke("DestroyBullet", bulletLifeTime);
	}
	
	void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
