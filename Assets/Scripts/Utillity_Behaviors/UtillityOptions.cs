using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtillityOptions : MonoBehaviour
{
    protected Utillity _utillityRef;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _utillityRef = GetComponent<Utillity>();
    }

    public virtual void Option1()
    {

    }

    public virtual void Option2()
    {

    }
}
