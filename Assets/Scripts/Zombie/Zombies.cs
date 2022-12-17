using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [SerializeField]
    private GameObject headBone;

    [SerializeField]
    private GameObject handBone;
    [SerializeField]
    private GameObject hand;

    [SerializeField]
    private GameObject headZoobie;

    [SerializeField]
    private GameObject handZoobie;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float walkSpeed;

    public int heart;

    ZombieState currentState;

    private BoxCollider2D collider;

    Vector3 startPos;

    public bool isOnGrass;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        animator.SetBool("isWalk", true);
        heart = 20;
        currentState = ZombieState.WALK;
        collider = GetComponent<BoxCollider2D>();
        isOnGrass = false;
        startPos = transform.position;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case ZombieState.IDLE:
                {
                    transform.position -= transform.right * walkSpeed * Time.deltaTime;
                    //Debug.Log("Walk : " + transform.position.x);
                }
                break;
            case ZombieState.WALK:
                {
                    transform.position -= transform.right * walkSpeed * Time.deltaTime;
                    //Debug.Log("Walk : " + transform.position.x);
                }
                break;
            case ZombieState.EAT:
                {
                    //Debug.Log("Eat");
                    animator.SetBool("isEat", true);

                }
                break;
            case ZombieState.DEATH:
                {

                }
                break;
        }
    }

    public void DestroyHandZoobie()
    {
        //hand.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //handBone.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        hand.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        handBone.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        handZoobie.gameObject.SetActive(true);
        StartCoroutine(DeystroyObject(handZoobie));
    }
    public void DestroyHeadZoobie()
    {
        headBone.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        Debug.Log("HeadBone : " + headBone.gameObject.name);
        headZoobie.gameObject.SetActive(true);
        headZoobie.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * 100);
        StartCoroutine(DeystroyObject(headZoobie));
    }
    IEnumerator DeystroyObject(GameObject ob)
    {
        yield return new WaitForSeconds(1f);
        ob.transform.position = startPos;
        Destroy(ob);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Detect!");
    //    if (collision.gameObject.tag == "Plant")
    //    {
    //        currentState = ZombieState.EAT;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detect!");
        if (collision.gameObject.tag == "Plant")
        {
            currentState = ZombieState.EAT;
            animator.SetBool("isWalk", false);
        }
        if(collision.gameObject.tag == "Board")
        {
            isOnGrass = true;
        }
        if (collision.gameObject.tag == "Bullet")
        {

            heart -= collision.gameObject.GetComponent<Bullet>().damgeBullet;
            Debug.Log("Detect bullet");
            if(heart == 6)
            {
                DestroyHandZoobie();
            }
            if(heart == 2)
            {
                DestroyHeadZoobie();
            }

            if(heart == 0)
            {
                animator.SetBool("isDie", true);
                //collider.enabled = false;
                currentState = ZombieState.DEATH;
                isDead = true;
                StartCoroutine(DeystroyObject(gameObject));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plant")
        {
            Debug.Log("Exit Plant");
            currentState = ZombieState.WALK;
            animator.SetBool("isWalk", true);
            animator.SetBool("isEat", false);
        }
    }
}
