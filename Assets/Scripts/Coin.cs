using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speedOfAway;
    
    private AudioSource _audioSource;

    private bool isFlyingAway = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlayerController player))
        {
            _audioSource.Play();
            player.AddCoin();
            isFlyingAway = true;
        }
    }

    private void Update()
    {
        if (isFlyingAway)
        {
            Vector3 leftTopCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight));

            transform.position = Vector3.MoveTowards(transform.position, leftTopCorner, Time.deltaTime * _speedOfAway);

            if (transform.position == leftTopCorner)
                Destroy(this.gameObject);
        }
    }
}
