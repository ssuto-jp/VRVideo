using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem interactiveItem;
    [SerializeField] private GameObject cube;

    private bool pointerOver;

    private void OnEnable()
    {
        interactiveItem.OnOver += HandleOver;
        interactiveItem.OnOut += HandleOut;
        interactiveItem.OnTouchpadDown += ActivateButton;
    }

    private void OnDisable()
    {
        interactiveItem.OnOver -= HandleOver;
        interactiveItem.OnOut -= HandleOut;
        interactiveItem.OnTouchpadDown -= ActivateButton;
    }

    private void HandleOver()
    {
        pointerOver = true;
    }

    private void HandleOut()
    {
        pointerOver = false;
    }

    private void ActivateButton()
    {
        if (pointerOver)
            cube.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
