using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPowerEnemy : Enemy
{
    public MediumPowerEnemy()
    {
        this.attPow = 1;
        this.health = 2;
        this.score = 150;
        this.tag = "Medium Power Enemy";
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
