using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReceiver : MonoBehaviour
{
    PlayerControls _playerControls;
    InputBuffer _inputBuffer;
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _inputBuffer = GetComponent<InputBuffer>();
    }
    void Start()
    {
        _playerControls.Gameplay.Direction.performed += context => OnDirection(context);
        _playerControls.Gameplay.Light.started += context => OnLight(context);
        _playerControls.Gameplay.Medium.started += context => OnMedium(context);
        _playerControls.Gameplay.Heavy.started += context => OnHeavy(context);
    }
    private void OnEnable()
    {
        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }
    void OnDirection(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();

        if (-1 < dir.x && dir.x < 0 && -1 < dir.y && dir.y < 0)
            _inputBuffer.AddInput(GameInputs.downback);
        else if (dir == new Vector2(0, -1))
            _inputBuffer.AddInput(GameInputs.down);
        else if (0 < dir.x && dir.x < 1 && -1 < dir.y && dir.y < 0)
            _inputBuffer.AddInput(GameInputs.downforward);

        else if (dir == new Vector2(-1,0))
            _inputBuffer.AddInput(GameInputs.back);
        else if (dir == new Vector2(0, 0))
            _inputBuffer.AddInput(GameInputs.nuetral);
        else if (dir == new Vector2(1, 0))
            _inputBuffer.AddInput(GameInputs.forward);

        else if (-1 < dir.x && dir.x < 0 && 0 < dir.y && dir.y < 1)
            _inputBuffer.AddInput(GameInputs.upback);
        else if (dir == new Vector2(0, 1))
            _inputBuffer.AddInput(GameInputs.up);
        else if (0 < dir.x && dir.x < 1 && 0 < dir.y && dir.y < 1)
            _inputBuffer.AddInput(GameInputs.upforward);
    }
    private void OnLight(InputAction.CallbackContext context)
    {
        _inputBuffer.AddInput(GameInputs.light);
    }
    private void OnMedium(InputAction.CallbackContext context)
    {
        _inputBuffer.AddInput(GameInputs.medium);
    }
    private void OnHeavy(InputAction.CallbackContext context)
    {
        _inputBuffer.AddInput(GameInputs.heavy);
    }
}
