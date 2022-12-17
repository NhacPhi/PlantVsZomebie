using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : MonoBehaviour, IPlant
{
    private bool isActive;

    public int value;
    // Start is called before the first frame update
    void Start()
    {
        value = SCR_Definition.COST_CABBAGE;
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
