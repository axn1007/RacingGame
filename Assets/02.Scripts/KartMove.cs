using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMove : MonoBehaviour
{
    public static KartMove instance;
    
    // ���� ���ݶ��̴�
    public WheelCollider[] wheels = new WheelCollider[4];
    GameObject[] wheelMesh = new GameObject[4];

    private string h = "Horizontal";
    private string v = "Vertical";
    private float hInput;
    private float vInput;

    public float radius = 6f;

    [Tooltip("������ �������� �ִ� ��ũ")]
    public float maxTorque = 7000f;
    [Tooltip("������ �ִ� ���Ⱒ")]
    public float maxAngle = 30f;
    [Tooltip("������ �������� �ִ� ���� ��ũ")]
    public float brakeTorque = 10000f;
    [Tooltip("������ �������� ���ӵ�")]
    public float power  = 1000f;

    public float KPH;

    Rigidbody rb;
    public float downForce;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        
    }

    void Start()
    {
        // ���� ���� ��ũ�� ���� �ڵ����� ã�ƿ´�.
        wheelMesh = GameObject.FindGameObjectsWithTag("WHEELMESH");

        for(int i = 0; i < wheelMesh.Length; i++)
        {
            wheels[i].transform.position = wheelMesh[i].transform.position;
        }


        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);
    }

    private void FixedUpdate()
    {
        WheelMeshposAni();
        kartInput();
    }

    // īƮ ���� Input
    void kartInput()
    {
        if (GameManager.instance.isGreen == false) return;

        //rb.AddForce(transform.rotation * new Vector3(vInput * 0, 0, power));
        rb.AddRelativeForce(Vector3.forward * power * vInput);
        rb.AddForce(-transform.up * downForce * rb.velocity.magnitude);

        hInput = Input.GetAxis(h);
        vInput = Input.GetAxis(v);

        float handBrake = Input.GetKey(KeyCode.Space) ? brakeTorque : 0;

        // �ڵ��� ���� (4��)
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = maxTorque * vInput;
            wheels[i].brakeTorque = handBrake;
        }
        // ��, ��
        for (int i = 0; i < wheels.Length -2; i++)
        {
            if (hInput > 0)
            {   // rear tracks size is set to 1.5f          wheel base has been set to 2.55f
                wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * hInput;
                wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * hInput;
            }
            else if (hInput < 0)
            {
                wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * hInput;
                wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * hInput;
                // transform.Rotate(Vector3.up * steerHelping)
            }
            else
            {
                wheels[0].steerAngle = 0;
                wheels[1].steerAngle = 0;
            }

            //wheels[i].steerAngle = maxAngle * hInput;
        }

        if (Input.GetKey(KeyCode.LeftShift) && maxTorque < 10000)
        {
            maxTorque += power;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxTorque = 3000f;
        }

        KPH = rb.velocity.magnitude * 3.6f;

        //if(wheels[wheels.Length].transform.localPosition.z < 0)
        //{
        //    wheels[wheels.Length].brakeTorque = handBrake;
        //}
    }


    // ���ݶ��̴� ��ġ�� ����ְ� Animation �����ֱ� ���ؼ�
    void WheelMeshposAni()
    {
        Quaternion quat = Quaternion.identity;
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < wheelMesh.Length; i++)
        {
            wheels[i].GetWorldPose(out pos, out quat);
            wheelMesh[i].transform.position = pos;
            wheelMesh[i].transform.rotation = quat;
        }
    }
}
