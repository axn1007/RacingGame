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
    private float startVolume = 0.7f;
    private float maxVolume = 1.0f;

    private float startPitch = 1.0f;
    private float maxPitch = 2.0f;

    // üũ ����Ʈ
    public GameObject[] checkPoint;
    bool[] check;

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

        // üũ ����Ʈ Ȯ��
        check = new bool[checkPoint.Length];

        // īƮ ���� �ʱ� ����
        SoundManager.instance.driveAudio.volume = startVolume;
        SoundManager.instance.driveAudio.pitch = startPitch;
    }

    private void FixedUpdate()
    {
        WheelMeshposAni();
        kartInput();
        CheckPoint();
        //if(KPH > 10)
        //{
        //    KartDriveSound();
        //}   
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
        float handBrake = Input.GetKey(KeyCode.Space) ? brakeTorque : 0;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.PlayEFT(SoundManager.EFT.EFT_Brake);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && maxTorque < 7000)
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
        SoundManager.instance.driveAudio.enabled = true;
        SoundManager.instance.driveAudio.Play();
        SoundManager.instance.driveAudio.volume = Mathf.Lerp(startVolume, maxVolume, KPH / 150);
        SoundManager.instance.driveAudio.pitch = Mathf.Lerp(startPitch, maxPitch, KPH / 150);
    }

    void CheckPoint()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (check[0] == false)
            {
                rb.velocity = Vector3.zero; // �÷��̾� ������ �ʱ�ȭ

                transform.position = checkPoint[0].transform.position; // �÷��̾� ��ġ �̵�
                transform.rotation = checkPoint[0].transform.rotation; // �÷��̾� ���� �̵�

                return;
            }
            else if(check[check.Length - 1] == true)
            {
                rb.velocity = Vector3.zero;

                transform.position = checkPoint[checkPoint.Length - 1].transform.position;
                transform.rotation = checkPoint[checkPoint.Length - 1].transform.rotation;

                return;
            }
            else
            {
                for(int i = 1; i < check.Length; i++)
                {
                    if(check[i] == false)
                    {
                        rb.velocity = Vector3.zero;

                        transform.position = checkPoint[i - 1].transform.position;
                        transform.rotation = checkPoint[i - 1].transform.rotation;

                        return;
                    }
                }
            }
        }
    }

    //üũ ����Ʈ �ε����� Ȯ���ϱ����ؼ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Check Point")
        {
            for (int i = 0; i < checkPoint.Length; i++)
            {
                if (checkPoint[i].gameObject == other.gameObject)
                {
                    check[i] = true;
                }
            }
        }
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
