using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Lerping_copy : MonoBehaviour
{
    public Vector3 positionA;
    public Vector3 positionB;

    public Vector3 newPosition;
    public Vector3 oldPosition;
    public float smooth = 10;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        positionA = new Vector3(1, 3, 0);
        positionB = new Vector3(-1, 3, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float W_middle = Screen.width / 2;
            if (touch.phase == TouchPhase.Began)
            {
                if ((touch.position.x > W_middle))
                {
                    newPosition = positionA;
                    oldPosition = positionB;
                    Debug.Log("Right");
                }

                if ((touch.position.x < W_middle))
                {
                    newPosition = positionB;
                    oldPosition = positionA;
                    Debug.Log("Left");

                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, smooth * Time.deltaTime);
    }
}
