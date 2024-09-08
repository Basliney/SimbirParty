using System.Collections;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject info;
    [SerializeField] private ReactionPlayer _reactionPlayer;
    private HealthController _healthController;
    private PlayerMovement _playerMovement;
    private QueueHandler _target;

    private bool IsQueueInteraction = false;

    private void Start()
    {
        _healthController = GetComponent<HealthController>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsQueueInteraction)
            {
                var queueTarget = _target.GetComponent<QueueTarget>();
                if (queueTarget != null)
                {
                    _healthController.Add(queueTarget.typeTarget);
                    return;
                }
                transform.position = _target.transform.position;
                StartCoroutine(PauseBeforeGame());
                _playerMovement.canMove = false;
            }
            info.SetActive(false);
        }
        if (!_playerMovement.canMove)
        {
            transform.position = _target.transform.position;
        }
    }

    public void SliderInteract(SliderValues value)
    {
        switch (value)
        {
            case SliderValues.Bad:
                _playerMovement.canMove = true;
                _target = null;
                break;
            case SliderValues.Normal:
                _target.humanControls.ReleaseCurrentTarget();
                break;
            case SliderValues.Great:
                _target.humanControls?.ReleaseCurrentTarget();
                _healthController.Add(TypeTarget.Food);
                _healthController.Add(TypeTarget.Alko);
                break;

        }
    }

    public void ReleaseMove()
    {
        _playerMovement.canMove = true;
        _target = null;
    }

    private IEnumerator PauseBeforeGame()
    {
        yield return new WaitForSeconds(Random.Range(0, 4));

        _reactionPlayer.StartGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "queuePos")
        {
            var queueHandler = other.GetComponent<QueueHandler>();
            if (queueHandler.GetState())
            {
                _target = queueHandler;
                IsQueueInteraction = true;
                info.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "queuePos" && other.gameObject.GetComponent<QueueTarget>() != null)
        {
            var queueHandler = other.GetComponent<QueueHandler>();
            queueHandler?.ReleasePlace();
            info.SetActive(false);
            IsQueueInteraction = false;
        }
    }
}
