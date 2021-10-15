using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Lerping : MonoBehaviour
{
    public Vector3[,] positionArray = new[,] {
        { new Vector3(2.25f, -0.546f, 5.859375f), new Vector3(1.125f, -1.193f, 5.859375f), new Vector3(0f,-1.84f,5.859375f), new Vector3(-1.125f,-2.487f,5.859375f), new Vector3(-2.25f,-3.1340000000000003f,5.859375f) },
        { new Vector3(2.25f,-3.1340000000000003f,5.859375f), new Vector3(1.125f,-2.487f,5.859375f), new Vector3(0f,-1.84f,5.859375f), new Vector3(-1.125f,-1.193f,5.859375f), new Vector3(-2.25f,-0.546f,5.859375f) } };

    public GameObject cube;
    public Vector3 positionA;
    public Vector3 positionB;

    public Vector3 newPosition;
    public float smooth = 10;
    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject.transform.GetChild(0).gameObject;
        Debug.Log(cube.GetComponent<Cube_properties>().position);
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
        if (cube.transform.position != newPosition)
        {
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, newPosition, Time.deltaTime * smooth);
            //Debug.Log("is moving");
        }
        else
        {
            //Debug.Log("stopped mobing");
        }
    }
}
