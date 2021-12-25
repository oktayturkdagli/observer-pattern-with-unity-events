using UnityEngine;
using UnityEngine.Events;
using System;

public class UnityEventManager : MonoBehaviour
{
    public static UnityEventManager current;

    private void Awake()
    {
        current = this;
    }

    //The event type is determined, I generally group them according to the number of parameters.
    [Serializable] public class OneParameter : UnityEvent<int> { }

    //Events are created
    public OneParameter onWallTriggerEnter;
    public OneParameter onWallTriggerExit;

}