using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMove : MonoBehaviour
{
    public static KartMove instance;
    
    public WheelCollider[] wheels = new WheelCollider[4];
    public Transform[]      tires = new Transform[4];

    private string h = "Horizontal";
    private string v = "Vertical";
    private float hInput;
    private float vInput;

    [Tooltip("바퀴에 가해지는 최대 토크")]
    public float maxTorque = 1500f;
    [Tooltip("바퀴의 최대 조향각")]
    public float maxAngle = 40f;
    [Tooltip("바퀴에 가해지는 최대 제동 토크")]
    public float brakeTorque = 10000f;
    [Tooltip("바퀴에 가해지는 가속도")]
    public float power  = 500f;

    public float KPH;

    Rigidbody rb;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        ShowTire();
    }

    private void FixedUpdate()
    {
        kartInput();
    }

    void kartInput()
    {
        if (GameManager.instance.isGreen == false) return;

        //rb.AddForce(transform.rotation * new Vector3(vInput * 0, 0, power));
        //rb.AddRelativeForce(Vector3.forward * power * vInput);

        hInput = Input.GetAxis(h);
        vInput = Input.GetAxis(v);

        float handBrake = Input.GetKey(KeyCode.Space) ? brakeTorque : 0;

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = maxTorque * vInput;
            wheels[i].brakeTorque = handBrake;
        }
        for (int i = 0; i < wheels.Length - 2; i++)
        {
            wheels[i].steerAngle = maxAngle * hInput;
        }

        if (Input.GetKey(KeyCode.LeftShift) && maxTorque < 7000)
        {
            maxTorque += power;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxTorque = 5000f;
        }

        KPH = rb.velocity.magnitude * 3.6f;

        //if(wheels[wheels.Length].transform.localPosition.z < 0)
        //{
        //    wheels[wheels.Length].brakeTorque = handBrake;
        //}
    }

    void ShowTire()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat = Quaternion.identity;
            Vector3 pos = Vector3.zero;
            wheels[i].GetWorldPose(out pos, out quat);
            tires[i].position = pos;
            tires[i].rotation = quat;
        }
    }
}
