using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCFactory
{
    public abstract Enemy getEnemy(EnemyTypes type);
}
public class EnemyFactory : NPCFactory
{
    public override Enemy getEnemy(EnemyTypes type)
    {
        switch (type)
        {
            case EnemyTypes.low:
                return new LowPowerEnemy();
            case EnemyTypes.medium:
                return new MediumPowerEnemy();
            case EnemyTypes.high:
                return new HighPowerEnemy();
            default:
                return null;
        }
    }
}

public enum EnemyTypes
{
    low = 0,
    medium = 1,
    high = 2
}
