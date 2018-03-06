using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Categorizes particle effects used in the game
/// </summary>

[Serializable]
public class SFX 
{
    public GameObject sfx_coin_pickup;      // shown when the player picks coins
    public GameObject sfx_bullet_pickup;    // shown when player picks up a bullet powerup
    public GameObject sfx_playerLands;      // shown when player lands after jumping
    public GameObject sfx_crateFragments;   // shown when player's head contacts the bottom of breakable crates
    public GameObject sfx_splash;

}
