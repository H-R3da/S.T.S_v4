using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Lerping : MonoBehaviour
{

    public GameObject cube;
    public Vector3 positionA;
    public Vector3 positionB;

    public Vector3 newPosition;
    public float smooth = 10;
    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            float W_middle = Screen.width / 2;

            if ((touch.position.x > W_middle) && touch.phase == TouchPhase.Began)
            {
                newPosition = positionA;
                Debug.Log("Right");
            }

            if ((touch.position.x < W_middle) && touch.phase == TouchPhase.Began)
            {
                newPosition = positionB;
                Debug.Log("Left");
            }
        }
        cube.transform.position = Vector3.MoveTowards(cube.transform.position, newPosition, Time.deltaTime * smooth);
    }
}
