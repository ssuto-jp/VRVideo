using UnityEngine;

public class VRLazerPointer : MonoBehaviour
{
    [SerializeField] private Transform leftHandAnchor;
    [SerializeField] private Transform rightHandAnchor;
    [SerializeField] private Transform centerEyeAnchor;
    [SerializeField] private LineRenderer lazerPointerRenderer;
    [SerializeField] private VRPlayerInput playerInput;

    public float maxLength = 100.0f;

    private VRInteractiveItem _lastInteractible;
    private VRInteractiveItem _currentInteractible;
    public VRInteractiveItem CurrentInteractible
    {
        get { return _currentInteractible; }
    }

    private Transform Pointer
    {
        get
        {
            var controller = OVRInput.GetActiveController();

            if (controller == OVRInput.Controller.LTrackedRemote)
                return leftHandAnchor;

            if (controller == OVRInput.Controller.RTrackedRemote)
                return rightHandAnchor;

            //return centerEyeAnchor;
            return null;
        }
    }

    private void OnEnable()
    {
        playerInput.OnTouchpadUp += HandleTouchpadUp;
        playerInput.OnTouchpadDown += HandleTouchpadDown;
    }

    private void OnDisable()
    {
        playerInput.OnTouchpadUp -= HandleTouchpadUp;
        playerInput.OnTouchpadDown -= HandleTouchpadDown;
    }

    private void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        var pointer = Pointer;
        if (pointer == null || lazerPointerRenderer == null)
            return;

        Ray ray = new Ray(pointer.position, pointer.forward);
        lazerPointerRenderer.SetPosition(0, ray.origin);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, maxLength))
        {
            lazerPointerRenderer.SetPosition(1, hitInfo.point);

            var interactible = hitInfo.collider.GetComponent<VRInteractiveItem>();
            _currentInteractible = interactible;

            if (interactible && interactible != _lastInteractible)
                interactible.Over();

            if (interactible != _lastInteractible)
                DeactiveLastInteractible();

            _lastInteractible = interactible;
        }
        else
        {
            lazerPointerRenderer.SetPosition(1, ray.origin + ray.direction * maxLength);

            DeactiveLastInteractible();
            _currentInteractible = null;
        }
    }

    private void DeactiveLastInteractible()
    {
        if (_lastInteractible == null)
            return;

        _lastInteractible.Out();
        _lastInteractible = null;
    }

    private void HandleTouchpadUp()
    {
        if (_currentInteractible != null)
            _currentInteractible.TouchpadUp();
    }

    private void HandleTouchpadDown()
    {
        if (_currentInteractible != null)
            _currentInteractible.TouchpadDown();
    }
}
