using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    //   [SerializeField]
//    [Range(0,1)]
//    private float _cutOff=.5f;

    [SerializeField] private Renderer _meshRenderer;

    [SerializeField] private GameObject _particleEffectGO;

    [SerializeField] private float _dissolveSpeed = 3f;

    private float _dissolveAmount = 1f;

    private bool _isDissolving = false;



    void Update()
    {
        //   _meshRenderer.material.SetFloat("_CutOff",_cutOff);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _isDissolving = !_isDissolving;
            
            _particleEffectGO.SetActive(true);
        }

        if (_isDissolving)
        {
            _dissolveAmount = Mathf.MoveTowards(_dissolveAmount, 0f, _dissolveSpeed * Time.deltaTime);
        }
        else
        {
            _dissolveAmount = Mathf.MoveTowards(_dissolveAmount, 1f, _dissolveSpeed * Time.deltaTime);
        }

        if (_dissolveAmount < .5f)
        {
            _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
        else
        {
            _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }

        _meshRenderer.material.SetFloat("_CutOff", _dissolveAmount);
    }
}