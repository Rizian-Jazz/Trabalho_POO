using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Transform))]
public abstract class ActionModel : MonoBehaviour
{
    public Rigidbody2D rb;
    Transform Componenttransform;
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
