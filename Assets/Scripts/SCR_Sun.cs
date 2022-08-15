using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Sun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown !");
        GameManager.Instance.numberSun += 25;
        GameEvent.CheckNumberSun();
        //GameUI.Instance.UpdateNumberSun();
        Destroy(gameObject);
    }
    
}
