using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem interactiveItem;
    [SerializeField] string video;

    public static string videoName;
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
        {
            videoName = video;
            SceneManager.LoadScene("PlayVideo");
        }
    }
}
