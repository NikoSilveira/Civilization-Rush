using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPowerEnemy : Enemy
{
    public HighPowerEnemy()
    {
        this.attPow = 2;
        this.health = 14;
        this.score = 1000;
        this.tag = "High Power Enemy";
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
