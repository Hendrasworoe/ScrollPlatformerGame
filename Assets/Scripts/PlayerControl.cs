using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    private SpriteRenderer _itsRenderer;
    private Rigidbody2D _itsRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _itsRenderer = GetComponent<SpriteRenderer>();
        _itsRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        var dir = _moveSpeed * Input.GetAxisRaw("Horizontal");
        // flipping the sprite
        switch (dir)
        {
            case > 0: _itsRenderer.flipX = false; break;
            case < 0: _itsRenderer.flipX = true; break;
        }
        _itsRigidbody.MovePosition(_itsRigidbody.position + dir * Vector2.right * Time.deltaTime);
    }
}
