using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanacakObje : MonoBehaviour
{
    void Update()
    {
        if (CompareTag("yem"))
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        if (CompareTag("gold"))
        {
            transform.Rotate(new Vector3(0, 0, 50) * Time.deltaTime);
        }
    }
}
