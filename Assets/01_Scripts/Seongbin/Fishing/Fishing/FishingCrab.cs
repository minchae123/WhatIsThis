using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FishingCrab : MonoBehaviour
{
    public enum FISHINGSTATE
    {
        NONE,
        CASTING,
        BITE,
        CATCH
    }

    [Header("FishingSetting")]
    [SerializeField] private float _minCastingTime;
    [SerializeField] private float _maxCastingTime;

    [SerializeField] private float _minBiteTime;
    [SerializeField] private float _maxBiteTime;

    public bool _isFishing;

    public FISHINGSTATE curState;

    private LineRenderer _fishingLine;

    [SerializeField] private Transform _fishingRodPos;
    [SerializeField] private Transform _bobber;

    private Animator _anim;

    [Header("Fishing")]
    [SerializeField] private GameObject _fishingWindow;

    [SerializeField] private Transform _topPivot;
    [SerializeField] private Transform _bottomPivot;

    [SerializeField] private Transform _crab;

    private float _crabPosition;
    private float _crabDestination;

    private float _crabTimer;
    [SerializeField] private float _timerMultiplicator = 3f;

    private float _fishSpeed;
    [SerializeField] private float _smoothMotion = 1f;

    [SerializeField] private Transform _hook;
    private float _hookPosition;
    [SerializeField] private float _hookSize = 0.1f;
    [SerializeField] private float _hookPower = 0.5f;
    private float _hookProgress;
    private float _hookPullVelocity;
    [SerializeField] private float _hookPullPower = 0.01f;
    [SerializeField] private float _hookGravityPower = 0.005f;
    [SerializeField] private float _hookProgressDegradationPower = 1f;

    [SerializeField] private SpriteRenderer _hookSpriteRenderer;

    [SerializeField] private Transform _progressContainer;

    [SerializeField] private float _failTimer = 10f;


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _fishingLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Resize();
    }

    private void Resize()
    {
        Bounds b = _hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = _hook.localScale;
        float distance = Vector3.Distance(_topPivot.position, _bottomPivot.position);
        ls.y = (distance / ySize * _hookSize);
        _hook.localScale = ls;
    }

    private void Update()
    {
        Fishing();

        if (curState == FISHINGSTATE.CATCH)
        {
            _fishingWindow.SetActive(true);
            MoveCrab();
            Hook();
            ProgressCheck();
        }
        else _fishingWindow.SetActive(false);
    }

    private void ProgressCheck()
    {
        Vector3 ls = _progressContainer.localScale;
        ls.y = _hookProgress;
        _progressContainer.localScale = ls;

        float min = _hookPosition - _hookSize / 2;
        float max = _hookPosition + _hookSize / 2;

        if (min < _crabPosition && _crabPosition < max)
            _hookProgress += _hookPower * Time.deltaTime;
        else
        {
            _hookProgress -= _hookProgressDegradationPower * Time.deltaTime;

            _failTimer -= Time.deltaTime;
            if (_failTimer < 0)
            {
                StartCoroutine(Miss());
            }
        }

        if (_hookProgress >= 1f)
            StartCoroutine(Catch());

        _hookProgress = Mathf.Clamp(_hookProgress, 0f, 1f);
    }

    private void Hook()
    {
        if (curState == FISHINGSTATE.BITE)
        {
            //입질왔다
        }


        if (curState == FISHINGSTATE.CATCH && Input.GetMouseButton(0))
        {
            _hookPullVelocity += _hookPullPower * Time.deltaTime;
        }
        _hookPullVelocity -= _hookGravityPower * Time.deltaTime;

        _hookPosition += _hookPullVelocity;

        if (_hookPosition - _hookSize / 2 <= 0f && _hookPullVelocity < 0f ||
            _hookPosition + _hookSize / 2 >= 1f && _hookPullVelocity > 0f)
            _hookPullVelocity = 0;

        _hookPosition = Mathf.Clamp(_hookPosition, _hookSize / 2, 1 - _hookSize / 2);
        _hook.position = Vector3.Lerp(_bottomPivot.position, _topPivot.position, _hookPosition);
    }

    private void MoveCrab()
    {
        _crabTimer -= Time.deltaTime;
        if (_crabTimer < 0f)
        {
            _crabTimer = UnityEngine.Random.value * _timerMultiplicator;

            _crabDestination = UnityEngine.Random.value;
        }

        _crabPosition = Mathf.SmoothDamp(_crabPosition, _crabDestination, ref _fishSpeed, _smoothMotion);
        _crab.position = Vector3.Lerp(_bottomPivot.position, _topPivot.position, _crabPosition);
    }

    void Fishing()
    {
        _fishingLine.SetPosition(0, _fishingRodPos.position);
        _fishingLine.SetPosition(1, _bobber.position);

        if (Input.GetMouseButtonDown(0))
        {
            if (curState == FISHINGSTATE.NONE) curState = FISHINGSTATE.CASTING;

            else if (curState == FISHINGSTATE.CASTING) FishReset();

            else if (curState == FISHINGSTATE.BITE) curState = FISHINGSTATE.CATCH;
        }

        if (curState == FISHINGSTATE.CASTING && !_isFishing) StartCoroutine(FishingStart());
    }

    private IEnumerator FishingStart()
    {
        _isFishing = true;
        //스타트 코루틴 랜덤초마다 캐스팅중일때 바이트가 되었다 없어지게

        float biteTime = UnityEngine.Random.Range(_minBiteTime, _maxBiteTime);
        float castingTime = UnityEngine.Random.Range(_minCastingTime, _maxCastingTime);


        yield return new WaitForSeconds(castingTime);
        curState = FISHINGSTATE.BITE;
        yield return new WaitForSeconds(biteTime);

        if (curState == FISHINGSTATE.CATCH)
        {
            Debug.Log("물엇다");
            //낚시 진입으로 바꿔야됨
        }
        else
            StartCoroutine(Miss());
    }

    private IEnumerator Catch()
    {
        _anim.SetTrigger("Catch");
        Debug.Log("낚음");
        FishReset();
        yield return null;
        //낚시찌 위로 올리고 로테이션 살짝 돌리고 1초 있다가 다시 원래대로
    }

    private IEnumerator Miss()
    {
        Debug.Log("놓침");
        FishReset();
        yield return null;
        //놓침
    }

    private void FishReset()
    {
        _failTimer = 10;
        _hookProgress = 0;
        curState = FISHINGSTATE.NONE;
        StopAllCoroutines();
        _isFishing = false;
    }
}
