using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy
{
    public int health;
    public int attPow;
    public string tag;
    public int score;
    public abstract int getAttPow();
    public abstract int getHealth();
    public abstract string getTag();

    public abstract int getScore();
}
