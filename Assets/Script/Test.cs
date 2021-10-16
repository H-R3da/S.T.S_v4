using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject shape = this.gameObject.transform.GetChild(2).gameObject;
        int[] position = shape.GetComponent<Shape_Properties>().position;
        position = new int[] { 0, 0 };

    }

    // Update is called once per frame
    void Update()
    {

    }
}
