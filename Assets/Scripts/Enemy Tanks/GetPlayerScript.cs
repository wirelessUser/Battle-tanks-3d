using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerScript : IGetPlayer
{

    public PlayerTankView playerView;
    public void GetPlayer()
    {
        PlayerTankSpawner.Instance.ReturnView();
    }
}
