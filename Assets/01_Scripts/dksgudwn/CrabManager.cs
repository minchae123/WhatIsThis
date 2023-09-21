using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabManager : MonoBehaviour
{
    //  Singleton Instance ����
    private static CrabManager instance = null;

    // Singleton Instance�� �����ϱ� ���� ������Ƽ
    public static CrabManager Instance
    {
        get
        {
            return instance;
        }
    }

    // GameManager ���� ��� �ϴ� ������
    public int CrabLayer;
    public CrabSO[] CrabData;

    [SerializeField]
    private GameObject crabPrefab;

    void Awake()
    {
        // Scene�� �̹� �ν��Ͻ��� ���� �ϴ��� Ȯ�� �� ó��
        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }

        // instance�� ���� ������Ʈ�� �����
        instance = this;

        // Scene �̵� �� ���� ���� �ʵ��� ó��
        DontDestroyOnLoad(this.gameObject);

    }
    public void MergeCrab(int v, Vector3 pos)
    {
        crabPrefab.GetComponent<Crab>().crabData = CrabData[v];
        print("����");
        GameObject crab = Instantiate(crabPrefab, transform.position, Quaternion.identity);
        crab.transform.position = pos;
    }
}
