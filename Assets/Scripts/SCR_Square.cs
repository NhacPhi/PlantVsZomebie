using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Square : MonoBehaviour
{
    public int indexSquare;

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        indexSquare = 0;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
