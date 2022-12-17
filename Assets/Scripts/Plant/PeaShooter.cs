using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour, IPlant
{
    private bool isActive;

    public int value;

    [SerializeField]
    private Transform positionSpawnBullet;

    [SerializeField]
    private GameObject prefabBullet;

    [SerializeField]
    private Weapon weapon;

    private bool isCanShoot;

    public int heart;

    private bool isBeActack;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        value = SCR_Definition.COST_PEASHOOTER;
        isCanShoot = true;
        isBeActack = false;
        heart = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon.isDetect)
        {
            isCanShoot = true;
        }
        else
        {
            isCanShoot = false;
        }
    }

    public void ActivePlant()
    {
        isActive = true;
        StartCoroutine(TimeToSpawnBullet());
    }

    public int GetValue()
    {
        return value;
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
    void SpawnBullet()
    {
        GameObject ob = Instantiate(prefabBullet, positionSpawnBullet.position, Quaternion.identity);
    }
    IEnumerator TimeToSpawnBullet()
    {
        if (isCanShoot)
        {
            while (true)
            {
                yield return new WaitForSeconds(SCR_Definition.TIMING_SPAWN_BULLET);
                if (isCanShoot)
                {
                    SpawnBullet();
                }
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
