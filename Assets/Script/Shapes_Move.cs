using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes_Move : MonoBehaviour
{
    public Vector3[,] positionArray = new[,] {
        { new Vector3(2.25f, -0.546f, 5.859375f), new Vector3(1.125f, -1.193f, 5.859375f), new Vector3(0f,-1.84f,5.859375f), new Vector3(-1.125f,-2.487f,5.859375f), new Vector3(-2.25f,-3.1340000000000003f,5.859375f) },
        { new Vector3(2.25f,-3.1340000000000003f,5.859375f), new Vector3(1.125f,-2.487f,5.859375f), new Vector3(0f,-1.84f,5.859375f), new Vector3(-1.125f,-1.193f,5.859375f), new Vector3(-2.25f,-0.546f,5.859375f) } };

    public GameObject[,] shapes = new GameObject[2, 3];
    public int[,] shapes_positions = new int[5, 2];

    public Vector3 nextposition;
    public int[] currentmove = new int[] { 0, 0 };
    public int[] nextmove = new int[] { 0, 0 };
    public float smooth = 10;
    public bool is_moving = false;

    public bool is_limit = false;

    public int[] shapes_positions_aux;

    public Queue<int[]> moves = new Queue<int[]>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject shapes_aux;
        //int[] shapes_positions_aux;
        for (int i = 0; i < 5; i++)
        {
            shapes_aux = this.gameObject.transform.GetChild(i).gameObject;
            shapes_positions_aux = shapes_aux.GetComponent<Shape_Properties>().position;
            shapes_positions[i, 0] = shapes_positions_aux[0];
            shapes_positions[i, 1] = shapes_positions_aux[1];
            shapes[shapes_positions[i, 0], shapes_positions[i, 1] - 1] = shapes_aux;
            if (shapes_positions[i, 1] == 2)
            {
                shapes[shapes_positions[i, 0] + 1, shapes_positions[i, 1]] = shapes_aux;
            }
        }
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
                    moves.Enqueue(new int[] { 0, -1 });
                }
                if (touch.position.x > W_middle && touch.position.y < H_middle)
                {
                    moves.Enqueue(new int[] { 1, -1 });
                }
                if (touch.position.x < W_middle && touch.position.y > H_middle)
                {
                    moves.Enqueue(new int[] { 1, 1 });
                }
                if (touch.position.x < W_middle && touch.position.y < H_middle)
                {
                    moves.Enqueue(new int[] { 0, 1 });
                }
            }
        }

        if (moves.Count != 0)
        {
            if (nextmove[0] == currentmove[0])
            {
                nextmove = moves.Dequeue();
                if (nextmove[0] == currentmove[0])
                {
                    currentmove = nextmove;
                }
            }
            else
            {
                if (is_moving == false)
                {
                    currentmove = nextmove;
                }
            }
        }

        if (currentmove[0] != 0 || currentmove[1] != 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (shapes_positions[i, 0] == currentmove[0] && (shapes_positions[i, 1] == 0 || shapes_positions[i, 1] == 4))
                {
                    is_limit = true;
                    break;
                }
                else
                {
                    is_limit = false;
                }
            }

            if (is_limit == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log(shapes_positions[shapes[currentmove[0], i].transform.GetSiblingIndex(), 0]);
                    if (shapes_positions[shapes[currentmove[0], i].transform.GetSiblingIndex(), 0] == currentmove[0])
                    {
                        nextposition = positionArray[shapes_positions[shapes[currentmove[0], i].transform.GetSiblingIndex(), 0], shapes_positions[shapes[currentmove[0], i].transform.GetSiblingIndex(), 1] + currentmove[1]];

                        shapes[currentmove[0], i].transform.position = Vector3.MoveTowards(shapes[currentmove[0], i].transform.position, nextposition, Time.deltaTime * smooth);
                        if (shapes[currentmove[0], i].transform.position == nextposition)
                        {
                            currentmove = new int[] { 0, 0 };
                        }
                    }
                }
            }
        }
        else
        {
            is_moving = false;
        }
    }
}
