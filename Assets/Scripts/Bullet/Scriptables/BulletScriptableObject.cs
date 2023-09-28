using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="BulletScriptable",menuName = "BulletScriptable/BulletType")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletCategory bulletcategory;
    public int poolId;
    public string BulleteName;
    public BulletType bulletType;
    public float speed;
    public int damageCapacity;
    public Color color;
    public int selfDestructionTime;
}
