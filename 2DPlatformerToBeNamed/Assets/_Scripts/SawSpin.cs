using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpin : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -2f));
    }
}
