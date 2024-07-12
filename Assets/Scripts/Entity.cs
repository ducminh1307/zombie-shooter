using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody rb {  get; private set; }
    public Animator anim {  get; private set; }
    public Stats stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<Stats>();
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void Death()
    {
        
    }
}
