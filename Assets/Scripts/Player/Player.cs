using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int speed;

    #region State
    public PlayerStateMachine stateMachine {  get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerRunState runState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        runState = new PlayerRunState(this, stateMachine, "Run");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        RotatePlayerFollowMouse();

        stateMachine.currentState.Update();
    }

    private void RotatePlayerFollowMouse()
    {
        // Lay vi tri chuot tren man hinh
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Tao 1 tia tu vi tri chuot tren man hinh
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        //Tao mot mat phang 3d voi phap tuyen la vector (0,1,0) va goc toa do la (0,0,0)
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); 

        if (groundPlane.Raycast(ray, out float hitDistance))
        {
            //Lay vi tri cua tia va cham voi mat phang da tao
            Vector3 targetPosition = ray.GetPoint(hitDistance);

            // Tinh toan huong cua nhan vat va diem va cham
            Vector3 direction = targetPosition - transform.position;

            // Reset truc y = 0 de nhan vat khong quay truc y
            direction.y = 0;

            // TInh toan goc quay cho nhan vat
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Xoay nhan vat
            transform.rotation = rotation;
        }
    }
}
