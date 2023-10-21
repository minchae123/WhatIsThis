using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingRod : MonoBehaviour
{
    [SerializeField] private Slider _throwPowerUI;

    [SerializeField] private bool _isThrow;

    private float _throwPower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !_isThrow)
        {

        }
        else if (Input.GetMouseButtonUp(0) && !_isThrow)
            ThrowBobber();

        _throwPowerUI.value = _throwPower;
    }

    void ThrowBobber()
    {
        _isThrow = true;
        Debug.Log(_throwPower);
    }
}
