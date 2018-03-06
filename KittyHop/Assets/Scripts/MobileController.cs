using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// routes mobile input to the correct methods in the PlayerController script
/// </summary>
public class MobileController : MonoBehaviour
{

    public GameObject player;

    PlayerController playerCtrl;

	void Start ()
    {
        playerCtrl = player.GetComponent<PlayerController>();
    }

    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }
    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();

    }
    public void MobileStop()
    {
        playerCtrl.MobileStop();

    }

    public void MobileJump()
    {
        playerCtrl.MobileJump();
    }
    public void MobileShootBullet()
    {
        playerCtrl.MobileShootBullet();
    }


}
