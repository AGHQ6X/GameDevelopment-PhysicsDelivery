using UnityEngine;
using TMPro;

public class ActiveManager : MonoBehaviour
{
    public GameManager active;

    void Start()
    {
        if (active != null) active.Activate();
    }
}
