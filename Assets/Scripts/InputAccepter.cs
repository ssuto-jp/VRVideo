using UnityEngine;

public class InputAccepter : MonoBehaviour
{
    public GameObject sphere;

    private void OnEnable()
    {
        VRPlayerInput.OnTriggerUp += TriggerUp;
        VRPlayerInput.OnTriggerDown += TriggerDown;
        VRPlayerInput.OnTouchpadUp += TouchpadUp;
        VRPlayerInput.OnTouchpadDown += TouchpadDown;
    }

    private void OnDisable()
    {
        VRPlayerInput.OnTriggerUp -= TriggerUp;
        VRPlayerInput.OnTriggerDown -= TriggerDown;
        VRPlayerInput.OnTouchpadUp -= TouchpadUp;
        VRPlayerInput.OnTouchpadDown -= TouchpadDown;
    }

    private void TriggerUp()
    {
        sphere.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void TriggerDown()
    {
        sphere.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void TouchpadUp()
    {
        sphere.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    private void TouchpadDown()
    {
        sphere.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
