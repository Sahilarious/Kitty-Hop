using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    public int delay = 5;
    private void Start()
    {
        Destroy(gameObject, delay);
    }

}
