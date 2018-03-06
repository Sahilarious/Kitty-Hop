using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Destroys gameObjects that fall into the collider, except the player.
///  Level reloads if player falls into the collider
/// </summary>
public class GarbageController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            Destroy(collider.gameObject);
        else
            GameController.instance.PlayerDied(collider.gameObject);


    }

}
