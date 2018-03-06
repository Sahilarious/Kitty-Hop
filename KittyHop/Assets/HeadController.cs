using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// checks for collisions with the player's head and breakable objects and then tells SFXController to
/// create appropriate effect 
/// </summary>
public class HeadController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Breakable"))
        {
            transform.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            SFXController.instance.ShowCrateParticles(collider.transform.parent.position);
            Destroy(collider.transform.parent.gameObject);
        }
    }
}
