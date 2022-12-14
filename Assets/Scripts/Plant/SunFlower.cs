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

    public int heart;

    private bool isBeActack;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        //StartCoroutine(TimeToSpawnSun());
        //SpawnSun();
        value = SCR_Definition.COST_FLOWER;
        heart = 5;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Detect be Actact!");
            if (!collision.gameObject.GetComponent<Zombies>().isDead)
            {
                isBeActack = true;
                StartCoroutine(TimingDecreaseHeart());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            isBeActack = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Detect be Actact!");
            if (!collision.gameObject.GetComponent<Zombies>().isDead)
            {
                isBeActack = true;
            }
        }
    }

    IEnumerator TimingDecreaseHeart()
    {
        if (isBeActack)
        {
            while (true)
            {
                if (isBeActack)
                {
                    yield return new WaitForSeconds(2);
                    heart -= 1;
                    if (heart == 0)
                    {
                        transform.position = new Vector3(100, 100, 0);
                        Destroy(gameObject);
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
        }
    }
}
