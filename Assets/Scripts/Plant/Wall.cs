using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IPlant
{
    private bool isActive;

    public int value;

    public int heart;

    private bool isBeActack;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        value = SCR_Definition.COST_WALL;
        heart = 10;
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
        if(collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Detect be Actact!");
            if (!collision.gameObject.GetComponent<Zombies>().isDead)
            {
                isBeActack = true;
                StartCoroutine(TimingDecreaseHeart());
            }
        }
    }
    
    IEnumerator TimingDecreaseHeart()
    {
        if(isBeActack)
        {
            while(true)
            {
                if (isBeActack)
                {
                    yield return new WaitForSeconds(2);
                    heart -= 1;
                    if (heart == 6)
                    {
                        animator.SetBool("isMedium", true);
                    }
                    if (heart == 3)
                    {
                        animator.SetBool("isLow", true);
                    }
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
