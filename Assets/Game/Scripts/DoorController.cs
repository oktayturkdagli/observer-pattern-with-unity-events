using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        UnityEvents.current.onWallTriggerEnter.AddListener(OnDoorwayOpen);
        UnityEvents.current.onWallTriggerExit.AddListener(OnDoorwayClose);

    }

    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            transform.Translate(new Vector3(0, 1.6f, 0));
        }
    }

    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            transform.Translate(new Vector3(0, -1.6f, 0));
        }
    }


    public void OnDestroy()
    {
        UnityEvents.current.onWallTriggerEnter.RemoveListener(OnDoorwayOpen);
        UnityEvents.current.onWallTriggerExit.RemoveListener(OnDoorwayClose);
    }
}
