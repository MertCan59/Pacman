using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class GhostBehaviour : MonoBehaviour
{
    public Ghost ghost { get; private set; }
    public float duration;
    private void Awake()
    {
        ghost = GetComponent<Ghost>();
        enabled=false;
    }

    public void Enable()
    {
        Enable(this.duration);
    }

    public virtual void Enable(float duration)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        this.enabled=false;
        CancelInvoke();
    }
}
