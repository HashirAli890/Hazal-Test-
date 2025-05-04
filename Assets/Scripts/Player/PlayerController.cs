using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSensitivity = 2f;

    [SerializeField] private PlayerInput input;
  [SerializeField] private WeaponHandler weaponHandler;
    private float pitch;

    private void Awake()
    {
        if (input == null)
            input = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        input.OnShoot += weaponHandler.TryFire;
        input.OnReload += weaponHandler.TryReload;

         
    }
    private void Update()
    {
        HandleMovement();
        HandleLook();
    }

    private void HandleMovement()
    {
        Vector2 move = input.MoveInput;
        Vector3 dir = new Vector3(move.x, 0, move.y);
        Vector3 worldDir = transform.TransformDirection(dir);
        controller.Move(worldDir * moveSpeed * Time.deltaTime);
    }

    private void HandleLook()
    {
        Vector2 look = input.LookInput;
        transform.Rotate(Vector3.up, look.x * lookSensitivity);

        pitch -= look.y * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        cameraPivot.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }

}