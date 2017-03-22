using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class GlobalStatistics
{
    public int SceneID;
    public float PositionX, PositionY, PositionZ;

    public bool ableToJump;
    public bool ableToLiftSmall;
    public bool ableToLiftBig;
    public bool ableToFloat;
    public bool ableToSpeedBoost;

    public int storyProgress;

    public int jc;

    public int level1OC;
    public int level1SC;
    public int level1HC;

    public int level2OC;
    public int level2SC;
    public int level2HC;
}
