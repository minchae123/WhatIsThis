using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolableMono
{
    private Stack<T> pool = new Stack<T>();
    private T prefab; // ���ڶ� �� �� �뵵
    private Transform parent; // ������ų �θ� 

    public Pool(T prefab, Transform parent, int count)
    {
        this.prefab = prefab;
        this.parent = parent;

        for(int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", ""); // Ŭ���̶�� �̸� �����
            obj.gameObject.SetActive(false);
            pool.Push(obj);
        }
    }

    public T Pop()
    {
        T obj = null;

        if(pool.Count <= 0) // ���ÿ� Ǯ���صа� �� �������� ���� �����
        {
            obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
        }
        else
        {
            obj = pool.Pop(); // ���ÿ� ������ �߿� ���� ���� ��
            obj.gameObject.SetActive(true); 
        }
        return obj;
    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }
}
