using UnityEngine;
using UnityEngine.EventSystems;

public class VRRayTransform : MonoBehaviour
{
    [SerializeField] private Transform leftHandAnchor;
    [SerializeField] private Transform rightHandAnchor;
    [SerializeField] private Transform centerEyeAnchor;
    [SerializeField] private OVRInputModule ovrInputModule;
    [SerializeField] private OVRGazePointer ovrGazePointer;

    public Transform RayTransform
    {
        get
        {
            var controller = OVRInput.GetActiveController();

            if (controller == OVRInput.Controller.LTrackedRemote)
                return leftHandAnchor;

            if (controller == OVRInput.Controller.RTrackedRemote)
                return rightHandAnchor;

            return centerEyeAnchor;
        }
    }

    private void Update()
    {
        var rayTransform = RayTransform;
        ovrInputModule.rayTransform = rayTransform;
        ovrGazePointer.rayTransform = rayTransform;
    }
}
