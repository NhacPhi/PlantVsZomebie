using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Grid : MonoBehaviour
{
    [SerializeField]
    private GameObject prrefabSquare;

    private List<GameObject> gridSquares = new List<GameObject>();

    [SerializeField]
    private float distanceHorizontal;

    [SerializeField]
    private float distanceVertical;
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
       SetGridSquarePosition();
    }
    void CreateGrid()
    {
        SpawnGridSquare();
        SetGridSquarePosition();
    }
    void SpawnGridSquare()
    {
        int square_index = 0;
        for(int row = 0; row < SCR_Definition.ROW; row++)
        {
            for(int column = 0; column < SCR_Definition.COLUMN; column++)
            {
                gridSquares.Add(Instantiate(prrefabSquare) as GameObject);
                gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                gridSquares[gridSquares.Count - 1].GetComponent<SCR_Square>().indexSquare = square_index;
                square_index++;
            }
        }
    }
    void SetGridSquarePosition()
    {
        int column_number = 0;
        int row_number = 0;

        Vector2 square_gap_number = new Vector2(0, 0);

        foreach(GameObject square in gridSquares)
        {
            if(column_number + 1 > SCR_Definition.COLUMN)
            {
                //square_gap_number.x = 0;

                column_number = 0;

                row_number++;

            }

            square.gameObject.transform.localPosition = new Vector2(distanceHorizontal * column_number, distanceVertical * row_number);
            column_number++;
        }
    }
}
