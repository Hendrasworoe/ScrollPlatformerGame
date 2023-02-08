using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private CanvasGroupController _inventoryUIController;
    [SerializeField] private GameObject _exclamationBubbleText;

    private SpriteRenderer _itsRenderer;
    private Rigidbody2D _itsRigidbody;
    private Animator _itsAnimator;
    private BoxCollider2D _itsCollider;

    private float _freezeInteract = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _itsRenderer = GetComponent<SpriteRenderer>();
        _itsRigidbody = GetComponent<Rigidbody2D>();
        _itsAnimator = GetComponent<Animator>();
        _itsCollider = GetComponent<BoxCollider2D>();


    }

    private void FixedUpdate()
    {
        Move();
        OpenInventory();

        if (_freezeInteract > 0)
        {
            _freezeInteract -= 0.1f * Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out iInteractable interactable))
        {
            _exclamationBubbleText.SetActive(true);

            if (Input.GetButton("Submit") && _freezeInteract <= 0)
            {
                interactable.IntractIt();

                _freezeInteract = 0.1f;

                _exclamationBubbleText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _exclamationBubbleText.SetActive(false);
    }

    private void Move()
    {
        var dir = _moveSpeed * Input.GetAxisRaw("Horizontal");
        // flipping the sprite
        switch (dir)
        {
            case > 0: _itsRenderer.flipX = false; break;
            case < 0: _itsRenderer.flipX = true; break;
        }
        _itsRigidbody.MovePosition(_itsRigidbody.position + dir * Vector2.right * Time.deltaTime);

        _itsAnimator.SetBool("Running", Mathf.Abs(dir) > 0.01f);
    }

    private void OpenInventory()
    {
        if (Input.GetKey(KeyCode.I))
        {
            _inventoryUIController.ShowCanvas(true);
        }
    }
}
