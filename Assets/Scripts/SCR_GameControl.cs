using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameControl : MonoBehaviour
{
    public static SCR_GameControl Instance { get; set; }

    public Plant currentPlant = Plant.NULL;

    public bool isTakeCard;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isTakeCard = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
