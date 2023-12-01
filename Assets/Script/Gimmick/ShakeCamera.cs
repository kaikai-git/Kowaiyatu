using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {

    [SerializeField] GameObject _cam;
    public float shakeTime = 0.5f;
    public Vector3 shakeRange = new Vector3(0.2f, 0.2f, 0f);

    private float _shakeTime;
    private float _timer;

    private Vector3 _originPos;
    private bool _onShakeEnd;

	void Start () {
        //init
        _shakeTime = -1f;
        _timer = 0f;
        _originPos = _cam.transform.localPosition;
        _onShakeEnd = false;
        Debug.Log(_originPos);
	}
	
	void Update () {
        if (_timer <= _shakeTime) {
            _onShakeEnd = true;
            _timer += Time.deltaTime;
            _cam.transform.localPosition = _originPos + MulVector3(shakeRange, Random.insideUnitSphere);
        } 
        else {
            if (_onShakeEnd) {
               _cam.transform.localPosition = _originPos;
                _onShakeEnd = false;
            }
            _originPos = _cam.transform.localPosition;
        }
	}
    public void Shake() {
        _timer = 0f;
        _shakeTime = shakeTime;
    }

    private Vector3 MulVector3(Vector3 a, Vector3 b) {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
}
