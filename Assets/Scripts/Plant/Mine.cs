using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IPlant
{
    public int value;

    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        value = SCR_Definition.COST_MINE;
        isActive = false;
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
