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
    public float maxTorque = 6000f;
    [Tooltip("������ �ִ� ���Ⱒ")]
    public float maxAngle = 30f;
    [Tooltip("������ �������� �ִ� ���� ��ũ")]
    public float brakeTorque = 10000f;
    [Tooltip("������ �������� ���ӵ�")]
    public float power  = 600f;

    Rigidbody rb;
    public float downForce;
    // �����
    public float KPH;

    // īƮ ���� ����
    private float startVolume = 0.5f;
    private float maxVolume = 0.7f;

    private float startPitch = 0.5f;
    private float maxPitch = 1.0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // ���� ���� �±׸� ���� �ڵ����� ã�ƿ´�.
        wheelMesh = GameObject.FindGameObjectsWithTag("WHEELMESH");

        for(int i = 0; i < wheelMesh.Length; i++)
        {
            wheels[i].transform.position = wheelMesh[i].transform.position;
        }


        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);

        // īƮ ���� �ʱ� ����
        SoundManager.instance.driveAudio.volume = startVolume;
        SoundManager.instance.driveAudio.pitch = startPitch;
    }

    private void FixedUpdate()
    {
        WheelMeshposAni();
        kartInput();
        KartDriveSound();
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

        // �극��ũ
        float handBrake = Input.GetKeyDown(KeyCode.Space) ? brakeTorque : 0;

        // �ڵ��� ���� (4��)
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = maxTorque * vInput;
            wheels[i].brakeTorque = handBrake;
        }
        // ��, �� // ��Ŀ�� ��Ƽ� ���� (��, ��� �̵��� �� ���ϰ� �̲������� ���� �����̶� ����)
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

        //if(GameManager.instance.isGreen == true & Input.GetKey(KeyCode.W))
        //{
        //    SoundManager.instance.eftAudio.volume = 0.5f;
        //    SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_kartGo);
        //}
        if(Input.GetKeyDown(KeyCode.Space))
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

        // �����
        // rigidbody �ӷ��� KPH�� �ٲ��ִ� ����  = 3.6�� (60 * 60 / 1000)
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

    // īƮ ���� ����
    void KartDriveSound()
    {
        SoundManager.instance.driveAudio.volume = Mathf.Lerp(startVolume, maxVolume, KPH / 200);
        SoundManager.instance.driveAudio.pitch = Mathf.Lerp(startPitch, maxPitch, KPH / 200);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            //Destroy(other);
            GameManager.isGoal1 = true;
            print("1�ε�");
        }
        else if (other.CompareTag("Goal2"))
        {
            //Destroy(other);
            GameManager.isGoal2 = true;
            print("2�ε�");
        }
    }
}
