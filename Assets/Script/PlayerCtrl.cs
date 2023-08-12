using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
   [SerializeField] GameObject PauseCanvas;
   [SerializeField] GameObject KaityuDentou;
    float x, z;
    public float speed = 0.1f;
    bool IsPause; //ポーズ判定
    bool flashlightOn = false; // 懐中電灯の状態を記録する変数
    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 2.5f, Ysensityvity = 0.3f;
    float RotateSpeed = 170f;
    bool cursorLock = true;

    float minX = -90f, maxX = 90f;
    //bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        
        characterRot = transform.localRotation;
         
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = 
        (cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        RotatePlayer();
        UpdateCursorLock();
        Kaityudentou();
        pause();
        
        // if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        // {
        //     isWalking = true;
        // }
        // else
        // {
        //     isWalking = false;
        // }

        
    }

    void RotatePlayer()
    {
        float rotationAmount = Input.GetAxisRaw("Horizontal") * RotateSpeed * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationAmount);
        characterRot *= deltaRotation;
    }

    private void FixedUpdate()
    {
        z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        if (z != 0)
        {
            Vector3 moveDirection = transform.forward * z;
            moveDirection.y = 0f;
            moveDirection = moveDirection.normalized;

            transform.position += moveDirection * speed;

            // if (isWalking && !footstepSound.isPlaying)
            // {
            //     footstepSound.Play();
            // }
        }
        // else
        // {
        //     footstepSound.Stop();
        // }
    }

     //カーソルロック
    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    void Kaityudentou()
    {
        // Fキーが押されたら懐中電灯の表示/非表示を切り替える
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightOn = !flashlightOn; // 状態を反転させる
            KaityuDentou.SetActive(flashlightOn); // 状態に基づいて懐中電灯を表示/非表示にする
        }
        // 懐中電灯の位置をカメラの位置に合わせる
        if (KaityuDentou != null)
        {
            KaityuDentou.transform.position = cam.transform.position;
            KaityuDentou.transform.rotation = cam.transform.rotation;
        }
    }

    public void pause()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPause == false)
        {
           
            IsPause = true;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
            
        }
        else if (Input.GetKeyDown(KeyCode.E) && IsPause == true)
        {
            IsPause = false;
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
        }
    }
   
}
