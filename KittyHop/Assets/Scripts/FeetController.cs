using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// helps in showing dust particle effect when character lands
/// </summary>
public class FeetController : MonoBehaviour
{
    public Transform dustParticlePosition;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Feetland");
        if (collider.gameObject.CompareTag("Ground"))
            SFXController.instance.ShowPlayerLanding(dustParticlePosition.position);
    }

}
