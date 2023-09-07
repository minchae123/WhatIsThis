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
}
