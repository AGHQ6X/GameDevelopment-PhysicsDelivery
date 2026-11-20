using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    protected bool isTriggered = false;

    public void Trigger()
    {
        Debug.Log("Triggerable triggered!");
        Activate();
        isTriggered = true;
    }

    protected virtual void Activate() {}
}
