using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerupController : MonoBehaviour {

    public bool SFXOn = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (SFXOn)
                SFXController.instance.ShowBulletSparkle(transform.position);
        }
    }
}
