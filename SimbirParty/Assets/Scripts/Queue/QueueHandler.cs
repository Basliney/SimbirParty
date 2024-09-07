using UnityEngine;

public class QueueHandler : MonoBehaviour
{
    private QueueControls _queueControls;
    public HumanControls humanControls;
    [SerializeField] private bool IsFree = false;

    public void Awake()
    {
        _queueControls = GameObject.Find("QueuesOwner").GetComponent<QueueControls>();
    }

    public bool GetState() => IsFree;

    public bool TakePlace()
    {
        if (IsFree == false)
        {
            return false;
        }

        _queueControls.Remove(this.transform);
        IsFree = false;
        return true;
    }

    public void ReleasePlace()
    {
        IsFree = true;
        _queueControls.Add(this.transform);
    }

    public void SelfRelease()
    {
        if (!IsFree)
            ReleasePlace();

        if (humanControls == null) return;
        humanControls.ReleaseCurrentTarget();
        humanControls = null;
    }
}
