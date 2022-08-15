using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SpawnSun : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabsSun;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimingToSpawnSun());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimingToSpawnSun()
    {
        while(true)
        {
            yield return new WaitForSeconds(SCR_Definition.TIMING_SPAWM_SUN);
            GameObject ob = Instantiate(prefabsSun, new Vector3(Random.Range(-6, 6), 8, 0), Quaternion.identity);
        }
    }
}
