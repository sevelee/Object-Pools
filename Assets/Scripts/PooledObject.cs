using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {

    public ObjectPool Pool { get; set; }

    // ???
    [System.NonSerialized]
    ObjectPool poolInstanceForPrefab;

    public void ReturnToPool ()
    {
        if (Pool)
        {
            Pool.AddObjectToPool(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public T GetPooledInstance<T> () where T : PooledObject
    {
        if (!poolInstanceForPrefab)
        {
            poolInstanceForPrefab = ObjectPool.GetPool(this);
        }
        return (T)poolInstanceForPrefab.GetObject();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
