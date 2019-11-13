using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPowerEnemy : Enemy
{
    public LowPowerEnemy()
    {
        this.attPow = 1;
        this.health = 4;
        this.score = 100;
        this.tag = "Low Power Enemy";
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
    public override int getScore()
    {
        return this.score;
    }
}
