using UnityEngine;
using UnityEngine.Events;

public class VRInteractiveItem : MonoBehaviour
{
    public event UnityAction OnOver;
    public event UnityAction OnOut;
    public event UnityAction OnTouchpadUp;
    public event UnityAction OnTouchpadDown;

    protected bool _isOver;
    public bool IsOver
    {
        get { return _isOver; }
    }

    public void Over()
    {
        _isOver = true;
        if (OnOver != null)
            OnOver();
    }

    public void Out()
    {
        _isOver = false;
        if (OnOut != null)
            OnOut();
    }

    public void TouchpadUp()
    {
        if (OnTouchpadUp != null)
            OnTouchpadUp();
    }

    public void TouchpadDown()
    {
        if (OnTouchpadDown != null)
            OnTouchpadDown();
    }
}
