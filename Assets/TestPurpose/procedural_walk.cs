using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class procedural_walk : MonoBehaviour
{

    [SerializeField] Transform[] _targetLegs;
    [SerializeField] Vector3[] _defaultLegPos;
    [SerializeField]
    Vector3[] _lastlegPos;

    [Header("Raycasting")]
    [SerializeField] Transform[] _RaycastTarget;

    [Header("distances")]
    [SerializeField] float _distance;

    private void Start()
    {
        _defaultLegPos = new Vector3[_targetLegs.Length];
        _lastlegPos=new Vector3[_targetLegs.Length];
        for (int i = 0; i < _targetLegs.Length; i++)
        {
            _defaultLegPos[i] = _targetLegs[i].position;
        }
        for (int i = 0; i < _targetLegs.Length; i++)
        {
            _lastlegPos[i] = _targetLegs[i].position;
        }
    }
    private void FixedUpdate()
    {

         _distance = Vector3.Distance(_RaycastTarget[0].position, _targetLegs[0].position);
        if(_distance>.5f)
        {
            _targetLegs[0].position = _RaycastTarget[0].position;
            _lastlegPos[0] = _RaycastTarget[0].position;
        }


        for (int i = 0; i < _targetLegs.Length; i++)
        {
            _targetLegs[i].position = _lastlegPos[i];
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i=0;i<_targetLegs.Length;i++)
        {
            Gizmos.DrawSphere(_RaycastTarget[i].position, .1f);
        }
        for(int i=0;i<_targetLegs.Length;i++)
        {
            Gizmos.DrawLine(_targetLegs[i].position, _RaycastTarget[i].position);
        }
    }

}
