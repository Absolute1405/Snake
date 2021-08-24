using System;
using System.Collections.Generic;
using UnityEngine;

public class AppleSystem : MonoBehaviour
{
    [SerializeField]
    private List<Apple> _apples;

    private void Awake()
    {
        if (_apples is null)
            throw new ArgumentNullException(nameof(_apples));
        if (_apples.Contains(null))
            throw new ArgumentNullException(nameof(_apples));
    }

    public void Reload() => _apples.ForEach(x => x.Reload());
}
