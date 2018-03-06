using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles voin behavior when the player interacts with it
/// </summary>
public class CoinController : MonoBehaviour
{
    public enum CoinFX
    {
        Vanish,
        Fly
    }
    public CoinFX coinFX;
    public bool SFXOn = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            if(SFXOn)
                SFXController.instance.ShowCoinSparkle(transform.position);
            if(coinFX == CoinFX.Vanish)
                Destroy(gameObject);
        }
    }
}
