using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow :MonoBehaviour
{

    public Vector3 localPositionOffset;
    public Vector3 localrotationnOffset;

    public void CameraSetup(PlayerTankView player)
    {
        transform.SetParent(player.transform);
        transform.localPosition = localPositionOffset;  // new Vector3(1f, 5.9f, -11.9f);
        Vector3 rotationAngle = localrotationnOffset;  //new Vector3(10.14f, -5.5f, 0f);
        transform.localRotation = Quaternion.Euler(rotationAngle);

    }
}

