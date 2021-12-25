using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        UnityEventManager.current.onWallTriggerEnter.Invoke(id);
    }

    private void OnTriggerExit(Collider other)
    {
        UnityEventManager.current.onWallTriggerExit.Invoke(id);
    }
}
