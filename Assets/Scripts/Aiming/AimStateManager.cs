using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimStateManager : MonoBehaviour
{
    public float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;
    [SerializeField] float mouseSense = 1;

    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [HideInInspector] public Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        SwitchState(Hip);
    }

    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        currentState.UpdateState(this);

    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z); 
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
