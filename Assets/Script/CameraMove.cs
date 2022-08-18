using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 2.0f;
    private float xRotate = 0.0f;
    public GameObject Cam;
    Rigidbody rb;
    public bool isMove = false;

    private float vertical;
    private float horizontal;

    Vector3 moveDirection;
    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    /*
    void Temp()
    {
        float h = Input.GetAxis("Mouse X") * turnSpeed;
        float v = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 move = transform.forward * v;
        Vector3 rotate = new Vector3(0, h, 0);

        rb.velocity = move;
        rb.rotation *= Quaternion.Euler(rotate);
    }
    */

    // Update is called once per frame
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
    private void MyInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        MyInput();
        //KeyboardMove();
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
        /*Vector3 velocity = new Vector3(
            Input.GetAxis("Horizontal"), 
            0,
            Input.GetAxis("Vertical")
        );*/

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 velocity = (transform.forward * vertical) * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        //velocity *= moveSpeed;
        //rb.velocity = velocity;
        //transform.Translate(velocity * moveSpeed * Time.deltaTime);        
    }

}
