using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBoom : MonoBehaviour, IPlant
{
    private bool isActive;

    public int value;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        value = SCR_Definition.COST_CHERRY_BOOM;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivePlant()
    {
        isActive = true;
    }

    public int GetValue()
    {
        return value;
    }
}
