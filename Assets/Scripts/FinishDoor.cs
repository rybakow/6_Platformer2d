using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class FinishDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent _levelFinished;
    [SerializeField] private Text _coinTotalCollected;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlayerController player))
        {
            _animator.SetTrigger(AnimatorDoorController.Params.Open);

            _coinTotalCollected.text = player.Coins.ToString();

            _levelFinished.Invoke();
        }
    }
}
