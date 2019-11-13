using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPowerEnemy : Enemy
{
    public HighPowerEnemy()
    {
    }
    public override int getAttPow()
    {
        return this.attPow;
    }
    public override int getHealth()
    {
        return this.health;
    }
    public override string getTag()
    {
        return this.tag;
    }
}
