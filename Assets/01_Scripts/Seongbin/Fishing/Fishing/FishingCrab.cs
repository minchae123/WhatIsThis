using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    [SerializeField] private float _minCastingTime;
    [SerializeField] private float _maxCastingTime;

    [SerializeField] private float _minBiteTime;
    [SerializeField] private float _maxBiteTime;

    public bool _isFishing;

    public FISHINGSTATE curState;
       

    private void Update()
    {
        Fishing();
    }

    void Fishing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (curState == FISHINGSTATE.NONE) curState = FISHINGSTATE.CASTING;

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
            StartCoroutine(Catch());
        else
            StartCoroutine(Miss());
        _isFishing = false;
    }

    private IEnumerator Catch()
    {
        yield return new WaitForSeconds(1);
        curState = FISHINGSTATE.NONE;
        //랜덤 돌려서 게 잡음
    }

    private IEnumerator Miss()
    {
        yield return null;
        curState = FISHINGSTATE.NONE;
        //놓침
    }
}
