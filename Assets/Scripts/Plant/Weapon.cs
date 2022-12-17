using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isDetect;
    // Start is called before the first frame update
    void Start()
    {
        isDetect = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            if (collision.gameObject.GetComponent<Zombies>().isOnGrass)
            {
                isDetect = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Detect Exit");
            isDetect = false ;
        }
    }
}
