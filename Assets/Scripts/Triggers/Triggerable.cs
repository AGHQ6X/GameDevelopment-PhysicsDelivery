using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    protected bool isTriggered = false;

    public void Trigger()
    {
        Activate();
        isTriggered = true;
    }

    protected virtual void Activate() {}
}
