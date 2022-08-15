using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour, IPlant
{
    [SerializeField]
    private GameObject prefabSun;

    [SerializeField]
    private Transform positionSpawn;

    private bool isActive;

    [SerializeField]
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        //StartCoroutine(TimeToSpawnSun());
        //SpawnSun();
        value = SCR_Definition.COST_FLOWER;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSun()
    {
        GameObject ob = Instantiate(prefabSun, positionSpawn.position, Quaternion.identity);
        ob.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 1f) * 20);
    }

    public void ActivePlant()
    {
        Debug.Log("Active Flower");
        isActive = true;
        StartCoroutine(TimeToSpawnSun());
    }
    IEnumerator TimeToSpawnSun()
    {
       while(true)
        {
            yield return new WaitForSeconds(SCR_Definition.TIMING_SPAWN_SUN_FLOWER);
            SpawnSun();
        }

    }

    public int GetValue()
    {
        return value;
    }
}
