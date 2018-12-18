using UnityEngine;

public class VRLazerPointer : MonoBehaviour
{
    [SerializeField]
    private Transform leftHandAnchor;
    [SerializeField]
    private Transform rightHandAnchor;
    [SerializeField]
    private Transform centerEyeAnchor;
    [SerializeField]
    private LineRenderer lazerPointerRenderer;

    public float maxLength = 100.0f;

    private Transform Pointer
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
        var pointer = Pointer;
        if (pointer == null || lazerPointerRenderer == null)
            return;

        Ray ray = new Ray(pointer.position, pointer.forward);
        lazerPointerRenderer.SetPosition(0, ray.origin);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, maxLength))
        {
            lazerPointerRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lazerPointerRenderer.SetPosition(1, ray.origin + ray.direction * maxLength);
        }
    }
}
