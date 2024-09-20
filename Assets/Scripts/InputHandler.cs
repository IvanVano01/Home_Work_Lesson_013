using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";

    private float _inputHorizontal;
    private float _inputVertical;

    public bool IsPressJump { get; private set; }
    public bool IsPressKeyRestart { get; private set; }

    private void Update()
    {
        InputKeysHandler();
    }

    public float InputHorizontal => _inputHorizontal;
    public float InputVertical => _inputVertical;

    private void InputKeysHandler()
    {
        _inputHorizontal = Input.GetAxisRaw(HorizontalAxis);
        _inputVertical = Input.GetAxisRaw(VerticalAxis);
        IsPressJump = Input.GetKey(KeyCode.Space);
        IsPressKeyRestart = Input.GetKeyDown(KeyCode.N);
    }


}
