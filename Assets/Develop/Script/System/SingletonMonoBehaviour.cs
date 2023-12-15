using System;
using UnityEngine;

/// <summary> シングルトンにしたいクラスから継承する </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected abstract bool dontDestroyOnLoad { get; }

    private static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                Type t = typeof(T);
                instance = (T)FindObjectOfType(t);
                if (!instance)
                {
                    Debug.LogError(t + "のインスタンスがありません");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {

        //既にコンポーネントとして使用されている場合破棄する
        if (this != Instance)
        {
            Destroy(this);
            Debug.LogError(
            typeof(T) +
            " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
            " アタッチされているGameObjectは " + Instance.gameObject.name + " です.");
            return;
        }
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
