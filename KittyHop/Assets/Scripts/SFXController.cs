using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController instance; // allows other scripts to access public methods in this class with
    public SFX sfx;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }


    /// <summary>
    /// Shows the coin sparkle effect when the player collects the coin
    /// </summary>
    public void ShowCoinSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_coin_pickup, pos, Quaternion.identity);
    }
    /// <summary>
    /// Shows the sparkle effect when player picks up a bullet powerup
    /// </summary>
    /// <param name="pos"></param>
    public void ShowBulletSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_bullet_pickup, pos, Quaternion.identity);
    }
    /// <summary>
    /// Shows the dirt puff when the player lands after a jump
    /// </summary>
    /// <param name="pos"></param>
    public void ShowPlayerLanding(Vector3 pos)
    {
        Instantiate(sfx.sfx_playerLands , pos, Quaternion.identity);
    }
    /// <summary>
    /// Shows crate breaking effect
    /// </summary>
    /// <param name="pos"></param>
    public void ShowCrateParticles(Vector3 pos)
    {
        Instantiate(sfx.sfx_crateFragments, pos, sfx.sfx_crateFragments.transform.rotation);
    }

    public void ShowSplash(Vector3 pos)
    {
        Instantiate(sfx.sfx_splash, pos, Quaternion.identity);
    }
}
