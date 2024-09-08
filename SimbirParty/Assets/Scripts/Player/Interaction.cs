using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject info;

    private bool IsQueueInteraction = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "queuePos")
        {
            var queueHandler = other.GetComponent<QueueHandler>();
            if (queueHandler.GetState())
            {
                IsQueueInteraction = true;
                info.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "queuePos")
        {
            var queueHandler = other.GetComponent<QueueHandler>();
            queueHandler?.ReleasePlace();
            info.SetActive(false);
            IsQueueInteraction = false;
        }
    }
}
