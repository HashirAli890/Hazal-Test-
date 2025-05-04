using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [Header("UI Input")]
    public Button shootButton;
    public Button reloadButton;
    public Joystick moveJoystick;

    [Header("Look Settings")]
    public float lookSensitivity = 0.1f;
    [Range(0f, 1f)] public float lookAreaPercentage = 0.5f; // right half

    public event Action OnShoot;
    public event Action OnReload;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    private int lookFingerId = -1;
    private Vector2 lastLookPos;

    void Start()
    {
        shootButton.onClick.AddListener(() => OnShoot?.Invoke());
        reloadButton.onClick.AddListener(() => OnReload?.Invoke());
    }

    void OnDisable()
    {
        shootButton.onClick.RemoveAllListeners();
        reloadButton.onClick.RemoveAllListeners();
    }

    void Update()
    {
        // Movement input from joystick
        MoveInput = moveJoystick != null ? new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical) : Vector2.zero;

        LookInput = Vector2.zero;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Handle look input only on the right side of the screen
            if (lookFingerId == -1 && touch.phase == TouchPhase.Began && touch.position.x > Screen.width * (1f - lookAreaPercentage))
            {
                lookFingerId = touch.fingerId;
                lastLookPos = touch.position;
            }

            if (touch.fingerId == lookFingerId)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 delta = (touch.position - lastLookPos) * lookSensitivity;
                    LookInput = new Vector2(delta.x, delta.y);
                    lastLookPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    lookFingerId = -1;
                    LookInput = Vector2.zero;
                }
            }
        }
    }
}
