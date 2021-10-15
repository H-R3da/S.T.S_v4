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
    public int[] nextposition;
    public float smooth = 10;
    public int[] position;
    public Queue<int[]> callerIds = new Queue<int[]>();
    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject.transform.GetChild(0).gameObject;
        position = cube.GetComponent<Cube_properties>().position;
        Debug.Log(position);
        callerIds.Enqueue(new int[] { 1, 3 });
        callerIds.Enqueue(new int[] { 1, 3 });
        callerIds.Enqueue(new int[] { 1, 3 });
        callerIds.Enqueue(new int[] { 1, 3 });

        foreach (var id in callerIds)
            Debug.Log(id); //prints 1234
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float H_middle = Screen.height / 3;
            float W_middle = Screen.width / 2;
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > W_middle && touch.position.y > H_middle)
                {
                    callerIds.Enqueue(new int[] { 0, 1 });
                    Debug.Log("Right");
                }
                if (touch.position.x > W_middle && touch.position.y < H_middle)
                {
                    callerIds.Enqueue(new int[] { 1, 1 });
                    Debug.Log("Right");
                }
                if (touch.position.x < W_middle && touch.position.y > H_middle)
                {
                    callerIds.Enqueue(new int[] { 1, -1 });
                    Debug.Log("left");
                }
                if (touch.position.x < W_middle && touch.position.y < H_middle)
                {
                    callerIds.Enqueue(new int[] { 0, -1 });
                    Debug.Log("Left");
                }
            }
        }
        if (cube.transform.position != newPosition)
        {
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, newPosition, Time.deltaTime * smooth);
            //Debug.Log("is moving");
            if (cube.transform.position == newPosition)
            {
                position = callerIds.Dequeue();
            }
        }
        else if (callerIds.Count != 0)
        {
            //Debug.Log("stopped mobing");
            nextposition = callerIds.Dequeue();
            newPosition = positionArray[nextposition[0], position[1] + nextposition[1]];
        }
    }
}
