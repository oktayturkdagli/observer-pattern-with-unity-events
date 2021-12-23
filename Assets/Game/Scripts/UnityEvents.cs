using UnityEngine;
using UnityEngine.Events;
using System;

public class UnityEvents : MonoBehaviour
{
    public static UnityEvents current;

    private void Awake()
    {
        current = this;
    }

    [Serializable] public class OneParameter : UnityEvent<int> { } //Event Type

    public OneParameter onWallTriggerEnter; //Event Name
    public OneParameter onWallTriggerExit; 

}
