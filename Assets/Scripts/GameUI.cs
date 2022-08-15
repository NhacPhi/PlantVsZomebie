using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public static GameUI Instance { set; get; }

    [SerializeField]
    private Text numberSun;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameEvent.CheckNumberSun += UpdateNumberSun;
    }
    private void OnDisable()
    {
        GameEvent.CheckNumberSun -= UpdateNumberSun;
    }
    public void UpdateNumberSun()
    {
        numberSun.text = GameManager.Instance.numberSun.ToString();
    }
}
