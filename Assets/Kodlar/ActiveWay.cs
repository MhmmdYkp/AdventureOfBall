using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWay : MonoBehaviour
{
    Animator activeWay;

    private void Start()
    {
        activeWay = transform.GetComponent<Animator>();
                
    }

    private void Update()
    {
        activeWay.SetInteger(ActiveButton.buttonString, ActiveButton.buttonInt);
    }

}
