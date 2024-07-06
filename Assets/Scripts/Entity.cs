using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody rb {  get; private set; }
    public Animator anim {  get; private set; }

    [Header("Collision detail")]
    [SerializeField] protected Transform attackChecker;
    [SerializeField] protected float attackRadius;
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        
    }
}
