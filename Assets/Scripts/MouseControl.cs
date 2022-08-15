using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public static MouseControl Instance;


    Vector3 posMouse;

    public bool isDetect;

    public bool isActiveShadow;

    [SerializeField]
    public GameObject shadow;

    [SerializeField]
    private GameObject imageShadow;

    public List<GameObject> plantArray;

    public Dictionary<Plant, GameObject> plants = new Dictionary<Plant, GameObject>();

    public Plant currentPlantShadow = Plant.FLOWER;

    private Vector3 startPositon;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isDetect = false;
        //currentPlant = Plant.FLOWER;
        plants.Add(Plant.FLOWER, plantArray[0]);
        plants.Add(Plant.PEA_SHOOTER, plantArray[1]);
        plants.Add(Plant.SNOW_PEA, plantArray[2]);
        plants.Add(Plant.MINE, plantArray[3]);
        plants.Add(Plant.WALL, plantArray[4]);
        plants.Add(Plant.CABBAGE, plantArray[5]);
        plants.Add(Plant.CHERRY_BOOM, plantArray[6]);
        isActiveShadow = false;
        startPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(posMouse.x, posMouse.y, 0);
        if(!isDetect && SCR_GameControl.Instance.isTakeCard)
        {
            //imageRed.gameObject.transform.position = new Vector3(posMouse.x, posMouse.y, 0);
            shadow.transform.position = new Vector3(posMouse.x, posMouse.y, 0);
        }
        if(!SCR_GameControl.Instance.isTakeCard)
        {
            transform.position = startPositon;
        }

        if(isActiveShadow)
        {
            imageShadow.gameObject.GetComponent<SpriteRenderer>().sprite = plants[currentPlantShadow].gameObject.GetComponent<SpriteRenderer>().sprite;
            imageShadow.gameObject.GetComponent<SpriteRenderer>().color = plants[currentPlantShadow].gameObject.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            imageShadow.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Square")
        {
            //Debug.Log("Dectect collision");
            isDetect = true;
            //imageRed.gameObject.transform.position = collision.transform.position;
            shadow.transform.position = collision.transform.position;
        }
        //else
        //{
        //    imageRed.gameObject.transform.position = new Vector3(posMouse.x, posMouse.y, 0);
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Square")
        {
            //Debug.Log("Dectect collision");
            isDetect = true;
            //imageRed.gameObject.transform.position = collision.transform.position;
            shadow.transform.position = collision.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Square")
        {
            isDetect = false;
        }
    }
}
