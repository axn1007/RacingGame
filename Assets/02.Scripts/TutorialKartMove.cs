using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKartMove : MonoBehaviour
{
    public static TutorialKartMove instance;

    public WheelCollider[] wheels = new WheelCollider[4];
    public Transform[] tires = new Transform[4];

    private string h = "Horizontal";
    private string v = "Vertical";
    private float hInput;
    private float vInput;

    public float radius = 6f;

    public float maxTorque = 1500f;
    public float maxAngle = 40f;
    public float brakeTorque = 10000f;
    public float power = 500f;

    Rigidbody rb;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {
        hInput = Input.GetAxis(h);
        vInput = Input.GetAxis(v);

        float handBrake = Input.GetKey(KeyCode.Space) ? brakeTorque : 0;

        // ÀÚµ¿Â÷ ±¸µ¿ (4·û)
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = maxTorque * vInput;
            wheels[i].brakeTorque = handBrake;
        }
        // ÁÂ, ¿ì
        for (int i = 0; i < wheels.Length - 2; i++)
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

        if (Input.GetKey(KeyCode.W))
        {
            SoundManager.instance.eftAudio.volume = 0.5f;
            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_kartGo);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Brake);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && maxTorque < 8000)
        {
            maxTorque += power;

            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Accel);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxTorque = 4000f;
        }
    }

    void Update()
    {
        for (int i = 0; i < tires.Length; i++)
        {
            Quaternion quat = Quaternion.identity;
            Vector3 pos = Vector3.zero;
            wheels[i].GetWorldPose(out pos, out quat);
            tires[i].position = pos;
            tires[i].rotation = quat;
        }
    }


}
