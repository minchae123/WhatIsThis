using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabManager : MonoBehaviour
{
    //  Singleton Instance 선언
    private static CrabManager instance = null;

    // Singleton Instance에 접근하기 위한 프로퍼티
    public static CrabManager Instance
    {
        get
        {
            return instance;
        }
    }

    // GameManager 에서 사용 하는 데이터
    public int CrabLayer;
    public CrabSO[] CrabData;

    [SerializeField]
    private GameObject crabPrefab;

    void Awake()
    {
        // Scene에 이미 인스턴스가 존재 하는지 확인 후 처리
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }

        // instance를 유일 오브젝트로 만든다
        instance = this;

        // Scene 이동 시 삭제 되지 않도록 처리
        DontDestroyOnLoad(this.gameObject);

    }
    public void MergeCrab(int v, Vector3 pos)
    {
        crabPrefab.GetComponent<Crab>().crabData = CrabData[v];
        print("생성");
        GameObject crab = Instantiate(crabPrefab, transform.position, Quaternion.identity);
        crab.transform.position = pos;
    }
}
