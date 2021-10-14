using UnityEngine;
using System.Collections;

public class Shapes_Mouvement : MonoBehaviour
{
    //positionsArrays contains the two ordered lists of positions that the shapes may occupy 
    //the 0 list represents the ordered / line of positions starting from the far right
    //the 1 list represents the ordered \ line of positions starting from the far right
    private Vector3[,] positionsArrays = new Vector3[5, 2];

    //i need to add lerping on the shapes but i'm following a git contibution per day programme i wasted the whole day today so i might just cheat
    public Rigidbody2D rb;

    public float Max_distance = 1;

    public float position_x_one;
    public float position_x_two;
    public float position_y_one;
    public float position_y_two;

    //int mouvement_Phase = 0;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float speed = rb.velocity.magnitude;

        position_x_two = rb.transform.position.x;
        position_y_two = rb.transform.position.y;

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            float H_middle = Screen.height / 3;
            float W_middle = Screen.width / 2;


            if ((touch.phase == TouchPhase.Began) && (speed == 0))
            {
                position_x_one = rb.transform.position.x;
                position_y_one = rb.transform.position.y;
            }

            if ((touch.position.x > W_middle) && touch.phase == TouchPhase.Began && (touch.position.y > H_middle) && (speed == 0))
            {

                Move_Up_Right();

            }

            if ((touch.position.x < W_middle) && touch.phase == TouchPhase.Began && (touch.position.y < H_middle) && (speed == 0))
            {

                Move_Down_Left();

            }

            if ((touch.position.x < W_middle) && touch.phase == TouchPhase.Began && (touch.position.y > H_middle) && (speed == 0))
            {

                Move_UP_Left();

            }

            if ((touch.position.x > W_middle) && touch.phase == TouchPhase.Began && (touch.position.y < H_middle) && (speed == 0))
            {

                Move_Down_Right();

            }
        }

        float distance_x = position_x_two - position_x_one;
        float distance_y = position_y_two - position_y_one;
        float pow_distance_x = Mathf.Pow(distance_x, 2);
        float pow_distance_y = Mathf.Pow(distance_y, 2);
        float sum_distance = pow_distance_x + pow_distance_y;
        float distance = Mathf.Sqrt(sum_distance);

        Debug.Log(distance);

        if (distance >= Max_distance)
        {

            SetVelocity_Zero();

        }

    }

    public void Move_Up_Right()
    {
        rb.velocity = new Vector2(2f, 2f);
    }

    public void Move_UP_Left()
    {
        rb.velocity = new Vector2(-2f, 2f);
    }

    public void Move_Down_Right()
    {
        rb.velocity = new Vector2(2f, -2f);
    }

    public void Move_Down_Left()
    {
        rb.velocity = new Vector2(-2f, -2f);
    }

    public void SetVelocity_Zero()
    {
        rb.velocity = Vector2.zero;
    }

}