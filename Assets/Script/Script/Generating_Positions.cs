using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generating_Positions : MonoBehaviour
{
    public Vector3 centerPoint = new Vector3(-1.158784f, 0.2955393f, 5.859375f);
    public Vector3[,] positionsArrays = new Vector3[5, 2];
    public float[] gap = new float[2];

    public Vector3 newPoint;

    // Start is called before the first frame update
    //why the fuck my commit won't work
    void Start()
    {
        positionsArrays[2, 0] = centerPoint;
        positionsArrays[2, 1] = centerPoint;
        gap[0] = 1.129216f;
        gap[1] = 0.6415393f;
        newPoint = new Vector3(centerPoint.x + gap[0], centerPoint.y + gap[1], centerPoint.z);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                positionsArrays[2 + (j + 1), i] = new Vector3(positionsArrays[2, i].x + Mathf.Pow(-1, i) * (gap[0] * j + 1), positionsArrays[2, i].y + (gap[1] * j + 1), positionsArrays[2, i].z);
                positionsArrays[2 - (j + 1), i] = new Vector3(positionsArrays[2, i].x - Mathf.Pow(-1, i) * (gap[0] * j + 1), positionsArrays[2, i].y - (gap[1] * j + 1), positionsArrays[2, i].z);
            }
        }
        Debug.Log("hello");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {

                Debug.Log(positionsArrays[j, i]);

            }
        }
        Debug.Log(positionsArrays[2, 0]);
        Debug.Log(positionsArrays[2, 1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
