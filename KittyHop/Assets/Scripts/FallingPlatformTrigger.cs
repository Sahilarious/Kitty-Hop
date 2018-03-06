using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// makes the platform drop on delay when the player steps on it
/// </summary>
public class FallingPlatformTrigger : MonoBehaviour
{

    public float dropDelay = 0.5f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = transform.GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Invoke("SetToDynamic", dropDelay);
        }
    }

    void SetToDynamic()
    {
        rb.isKinematic = false;
    }


}
