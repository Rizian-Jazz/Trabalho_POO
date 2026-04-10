using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public abstract class ActionModel : MonoBehaviour
{
    public Rigidbody2D rb;
    protected bool canUseAction = true;
    protected virtual void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }   
    public virtual bool CanUseAction()
    {
       return canUseAction;
    }
    public abstract void Use();
}
