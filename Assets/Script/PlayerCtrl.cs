
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject SettingCanvas;
    [SerializeField] GameObject KaityuDentou;

    public AudioClip LightOnOff;
    public AudioClip Suzu;

    [SerializeField] private AudioSource audioSourceFootSE;
    [SerializeField] private AudioSource audioSource;

    float x, z;
    public float speed = 0.1f;
    bool IsPause; //ポーズ判定
    bool IsSetting;//設定判定
    bool flashlightOn = false; // 懐中電灯の状態を記録する変数
    public GameObject cam;
    Quaternion cameraRot, characterRot;
    public float Xsensityvity = 2.5f, Ysensityvity = 0.3f;
    public float RotateSpeed = 170f;
    bool cursorLock = true;

    bool isWalking = false;
    Rigidbody rb;
    public static int CamMoveCtrl; //カメラ回転を止めるための変数
    float minX = -90f, maxX = 90f;
    //bool isWalking = false;

    void Start()
    {
        // audioSourceFootSE = GetComponent<AudioSource>();
        // audioSource = GetComponent<AudioSource>();
        RenderSettings.ambientIntensity = 0f;
        rb = GetComponent<Rigidbody>();
        cameraRot = cam.transform.localRotation;
        CamMoveCtrl = 1;
        characterRot = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(flashlightOn);
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity * CamMoveCtrl;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity * CamMoveCtrl;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
        //Debug.Log(audioSourceFootSE.isPlaying);

        ///うごいてるときだけ

        pause();
        Setting();
        CheckStairs();
        //RotatePlayer();
        //UpdateCursorLock();
        Kaityudentou();

    }

    private void FixedUpdate()
    {
        z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        //斜め移動
        if (z != 0 && x != 0)
        {
            // 斜め移動正規化
            Vector3 moveDirection = (transform.forward * z + transform.right * x).normalized;
            moveDirection.y = 0f;

            transform.position += moveDirection * speed;
            if (!audioSourceFootSE.isPlaying)
            {
                audioSourceFootSE.Play();
            }

        }
        //縦移動
        else if (z != 0)
        {
            Vector3 moveDirectionZ = transform.forward * z;
            moveDirectionZ.y = 0f;
            moveDirectionZ = moveDirectionZ.normalized;

            transform.position += moveDirectionZ * speed;
            if (!audioSourceFootSE.isPlaying)
            {
                audioSourceFootSE.Play();
            }

        }
        //横移動
        else if (x != 0)
        {
            Vector3 moveDirectionX = transform.right * x;
            moveDirectionX.y = 0f;
            moveDirectionX = moveDirectionX.normalized;

            transform.position += moveDirectionX * speed;
            if (!audioSourceFootSE.isPlaying)
            {
                audioSourceFootSE.Play();
            }
        }
        else
        {
            audioSourceFootSE.Stop();
        }
    }

    //カーソルロック
    public void UpdateCursorLock()
    {
        if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }
        //カーソルを中心に固定、視覚化
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
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 1)
        {
            audioSource.PlayOneShot(LightOnOff);
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

    public void Setting()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsSetting == false && Time.timeScale == 1)
        {

            //cam.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            audioSource.PlayOneShot(Suzu);
            IsSetting = true;
            audioSourceFootSE.Stop();
            Time.timeScale = 0;
            SettingCanvas.SetActive(true);


        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsSetting == true)
        {

            //cam.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            IsSetting = false;
            Time.timeScale = 1;
            SettingCanvas.SetActive(false);
        }
    }

    public void pause()
    {
        //とまってる
        if (Input.GetKeyDown(KeyCode.E) && IsPause == false && Time.timeScale == 1)
        {

            cam.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            audioSource.PlayOneShot(Suzu);
            IsPause = true;
            audioSourceFootSE.Stop();
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);


        }
        else if (Input.GetKeyDown(KeyCode.E) && IsPause == true)
        {

            cam.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            IsPause = false;
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
        }
    }

    //レイを飛ばして階段だったらキー入力がないときはyの値を変更しない
    public void CheckStairs()
    {
        float dist = 1.0f;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * dist, Color.red, 0.1f);
        if (!Physics.Raycast(ray, out hit, dist)) return;

        if ((hit.collider.tag == "Stair"))
        {
             //WASDの入力がある場合
            if (!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            else rb.constraints = RigidbodyConstraints.None;
        }
        else rb.constraints = RigidbodyConstraints.None;

        

       
    }
}
