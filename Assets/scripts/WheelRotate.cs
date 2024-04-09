using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{

    public Transform rueda;

    bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    int dir = 120;
    // Update is called once per frame
    void Update()
    {


        if (isRotating) rueda.transform.Rotate(new Vector3(dir, 0, 0), 1000 * Time.deltaTime);
        //rueda.transform.Rotate(new Vector3(dir, 0, 0), 100 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow)) { dir = 20; isRotating = true; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { dir = 20; isRotating = true; }
        //this.transform.Rotate(new Vector3(1, 0, 0), 15);


        else if (Input.GetKeyDown(KeyCode.DownArrow)) { dir = -20; isRotating = true; }

        if (Input.GetKeyUp(KeyCode.DownArrow)) isRotating = false;
        if (Input.GetKeyUp(KeyCode.UpArrow)) isRotating = false;

    }
}
