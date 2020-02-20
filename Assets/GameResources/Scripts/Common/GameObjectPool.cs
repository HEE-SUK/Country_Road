using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 예시
// m_monsterPool = new GameObjectPool<Germs>(20, () => {
//             var obj = Instantiate(m_Germs) as GameObject;
//             obj.transform.SetParent(transform);
//             obj.SetActive(false);
//             var germs = obj.GetComponent<Germs>();
//             return germs;
//         });

public class GameObjectPool<T> where T : class
{
    short count;
    public delegate T Func();
    Func create_fn;
    // Instances.  
    Stack<T> objects;
    // Construct  
    public GameObjectPool(short count, Func fn)
    {
        this.count = count;
        this.create_fn = fn;        
        this.objects = new Stack<T>(this.count);
        allocate();

    }
    void allocate()
    {
        for (int i = 0; i < this.count; ++i)
        {
            this.objects.Push(this.create_fn());
        }
    }
    public T pop()
    {
        if (this.objects.Count <= 0)
        {
            allocate();
        }
        return this.objects.Pop();
    }
    public void push(T obj)
    {
        this.objects.Push(obj);
    }

}
