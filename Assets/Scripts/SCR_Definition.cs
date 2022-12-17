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

public enum ZombieState
{
    IDLE,
    WALK,
    EAT,
    DEATH
}
public enum  GameState
{

}
public class SCR_Definition 
{
    // GRID
    public static int ROW = 5;
    public static int COLUMN = 9;

    // TIME
    public static float TIMING_SPAWN_SUN_FLOWER = 10;
    public static float TIMING_SPAWM_SUN = 12;
    public static float TIMING_MINE_ADULT = 5;
    public static float TIMING_SPAWN_BULLET = 1.5f;

    // COST
    public static int COST_FLOWER = 50;
    public static int COST_WALL = 50;
    public static int COST_PEASHOOTER = 100;
    public static int COST_MINE = 25;
    public static int COST_CABBAGE = 125;
    public static int COST_SNOWPEA = 175;
    public static int COST_CHERRY_BOOM = 200;
    //COUNT DOWN
}
