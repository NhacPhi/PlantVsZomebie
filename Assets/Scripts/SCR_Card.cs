using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Card : MonoBehaviour, IPointerClickHandler/*, IBeginDragHandler, IPointerUpHandler, IDragHandler*/
{
    [SerializeField]
    private int value;

    [SerializeField]
    private Plant typePlant;

    private Canvas canvas;

    [SerializeField]
    private GameObject prefabPlant;

    [SerializeField]
    private float timingCountDown;

    [SerializeField]
    private Slider slider;

    private bool isActive;

    private bool isPlace;

    private bool isSpawn;
    private GameObject ob;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        isActive = false;
        slider.value = 100;
        isPlace = false;
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            slider.value = slider.value - 100 / timingCountDown * Time.deltaTime;
            if(slider.value <= 0)
            {
                isActive = true;
            }
        }

        if(!isPlace && isSpawn)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ob.transform.position = new Vector3(pos.x,pos.y,0);
        }
        if(Input.GetMouseButton(0) && !isPlace && isSpawn)
        {
            isPlace = true;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //ob.transform.position = new Vector3(pos.x, pos.y, 0);
            ob.transform.position = MouseControl.Instance.shadow.transform.position;
            ob.gameObject.GetComponent<IPlant>().ActivePlant();
            MouseControl.Instance.isActiveShadow = false;
            SCR_GameControl.Instance.isTakeCard = false ;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("On Mouse Down: " + typePlant);
        if(isActive)
        {
            if (GameManager.Instance.numberSun >= prefabPlant.gameObject.GetComponent<IPlant>().GetValue())
            {
                Debug.Log("Purchase : " + prefabPlant.gameObject.GetComponent<IPlant>().GetValue());
                SCR_GameControl.Instance.isTakeCard = true;
                isActive = false;
                slider.value = 100;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject plant = Instantiate(prefabPlant, pos, Quaternion.identity);
                GameManager.Instance.numberSun -= plant.gameObject.GetComponent<IPlant>().GetValue();
                GameEvent.CheckNumberSun();
                ob = plant;
                isSpawn = true;
                isPlace = false;
                MouseControl.Instance.currentPlantShadow = typePlant;
                MouseControl.Instance.isActiveShadow = true;
            }

        }


    }

}
