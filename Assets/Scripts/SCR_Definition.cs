using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Plant
{
    FLOWER,
    PEA_SHOOTER,
    SNOW_PEA,
    MINE,
    WALL,
    CABBAGE,
    CHERRY_BOOM,
    NULL
}
public enum Zoombie
{
    TYPE1,
    TYPE2,
    TYPE3
}
public class SCR_Definition 
{
    // GRID
    public static int ROW = 5;
    public static int COLUMN = 9;

    // TIME
    public static float TIMING_SPAWN_SUN_FLOWER = 10;
    public static float TIMING_SPAWM_SUN = 12;

    // COST
    public static int COST_FLOWER = 50;

    //COUNT DOWN
}
