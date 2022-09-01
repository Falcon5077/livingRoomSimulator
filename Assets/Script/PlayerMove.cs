using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    public bool isMove = false;
    public float moveSpeed = 10.0f;
    public float turnSpeed = 2.5f;
    private float xRotate = 0.0f;
    private GameObject Cam;
    private float vertical;
    private float horizontal;
    private Rigidbody rb;
    public float maxVelocityChange = 10f;
    public static bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        //마우스 커서가 보이지 않게 함        
        Cursor.lockState = CursorLockMode.Locked;
        //마우스 커서를 고정시킴
        Cam = Camera.main.gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove)
        {
            rb.velocity = Vector3.zero;
            return;
        }
            

        if (transform.parent == null)
            KeyboardMove();

        if (Input.GetMouseButton(1))
            return;

        MouseRotation();
    }

    void MouseRotation()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate2 = transform.eulerAngles.y + yRotateSize;
        float yRotate = Cam.transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        if(isMove == true)
        {
            Input.ResetInputAxes();
            xRotate = 0;

            isMove = false;
        }    
        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(0, yRotate2, 0);
        Cam.transform.eulerAngles = new Vector3(xRotate, yRotate2, 0);
    }    

    void KeyboardMove()
    {
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

        //transform.Translate(targetVelocity * moveSpeed * Time.deltaTime);

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        /*
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 velocity = (transform.forward * vertical) * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        */

    }

}
