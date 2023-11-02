using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FishingCrab : MonoBehaviour
{
    #region FishingSetting
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

    public bool _isThrow;
    public bool _isFishing;

    public FISHINGSTATE curState;

    private LineRenderer _fishingLine;

    [SerializeField] private Transform _fishingRodPos;
    [SerializeField] private Transform _CatchPos;
    [SerializeField] private Transform _bobber;

    private Animator _anim;
    #endregion

    #region FishingBar
    [Header("FishingBar")]
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
    #endregion

    #region SetUp
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _fishingLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Resize();
        _fishingLine.SetPosition(0, _fishingRodPos.position);
        _fishingLine.SetPosition(1, _bobber.position);
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
    #endregion

    #region MainLogic
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

    void Fishing()
    {
        _fishingLine.SetPosition(1, _bobber.position);

        if (Input.GetMouseButtonDown(0))
        {
            if (curState == FISHINGSTATE.NONE) curState = FISHINGSTATE.CASTING;

            else if (curState == FISHINGSTATE.CASTING) FishReset();

            else if (curState == FISHINGSTATE.BITE) curState = FISHINGSTATE.CATCH;
        }

        //������ �־�
        if (curState == FISHINGSTATE.NONE)
        {
            _isThrow = false;
            _bobber.transform.eulerAngles = Vector3.zero;
            _anim.SetBool("Throw", false);
            _anim.SetBool("Bite", false);

            if (Vector3.Distance(_CatchPos.position, _bobber.position) < 0.3f)
                _bobber.position = _CatchPos.position;
            else
                _bobber.position += 5 * Time.deltaTime * (_CatchPos.position - _bobber.position);
        }
        //������
        if (curState == FISHINGSTATE.CASTING && !_isThrow)
        {
            _anim.SetBool("Throw", true);
            _isThrow = true;
        }

        //�����Դ�
        if (curState == FISHINGSTATE.BITE)
            _anim.SetBool("Bite", true);
        //������ 
        if (curState == FISHINGSTATE.CASTING && !_isFishing) StartCoroutine(FishingStart());
    }

    private IEnumerator FishingStart()
    {
        _isFishing = true;
        //��ŸƮ �ڷ�ƾ �����ʸ��� ĳ�������϶� ����Ʈ�� �Ǿ��� ��������

        float biteTime = UnityEngine.Random.Range(_minBiteTime, _maxBiteTime);
        float castingTime = UnityEngine.Random.Range(_minCastingTime, _maxCastingTime);


        yield return new WaitForSeconds(castingTime);
        curState = FISHINGSTATE.BITE;
        yield return new WaitForSeconds(biteTime);

        //if (curState == FISHINGSTATE.CATCH)
        //{
        //    Debug.Log("������");
        //    //���� �������� �ٲ�ߵ�
        //}
        //else
        //    StartCoroutine(Miss());

        if (curState != FISHINGSTATE.CATCH)
            StartCoroutine(Miss());
    }

    private IEnumerator Catch()
    {
        _isFishing = false;
        _anim.SetBool("Catch", true);
        Debug.Log("����");
        _fishingLine.SetPosition(0, _CatchPos.position);
        yield return new WaitForSeconds(.9f);
        _anim.SetBool("Catch", false);
        yield return new WaitForSeconds(.1f);
        FishReset();
        //������ ���� �ø��� �����̼� ��¦ ������ 1�� �ִٰ� �ٽ� �������
    }

    private IEnumerator Miss()
    {
        Debug.Log("��ħ");
        FishReset();
        yield return null;
        //��ħ
    }

    private void FishReset()
    {
        _fishingLine.SetPosition(0, _fishingRodPos.position);
        _failTimer = 10;
        _hookProgress = 0;
        curState = FISHINGSTATE.NONE;
        StopAllCoroutines();
        _isFishing = false;
    }
    #endregion

    #region FishingBar
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
    #endregion
}
