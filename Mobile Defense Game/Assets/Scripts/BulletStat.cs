using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStat
{
    public float speed { get; set; }
    public int damage { get; set; }

    public BulletStat(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
  
}
