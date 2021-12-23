using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        UnityEvents.current.onWallTriggerEnter.Invoke(id);
    }

    private void OnTriggerExit(Collider other)
    {
        UnityEvents.current.onWallTriggerExit.Invoke(id);

    }
}
