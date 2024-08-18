using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class CraneController : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _moveHorizontalRate = 2;
    [SerializeField] private float _moveVerticalRate = 1;
    [SerializeField] private float _moveZRate = 1;
    
    [SerializeField] private float _minimumPositionZ;
    [SerializeField] private float _maximumPositionZ;
    
    [SerializeField] private float _minimumPositionY;
    [SerializeField] private float _maximumPositionY;
    
    [SerializeField] private float _minimumPositionX;
    [SerializeField] private float _maximumPositionX;

    public void SetPosition(Vector3 pos)
    {
        // pos.x = Mathf.Clamp(pos.x, _minimumPositionX, _maximumPositionX);
        // pos.y = Mathf.Clamp(pos.y, _minimumPositionY, _maximumPositionY);
        // pos.z = Mathf.Clamp(pos.z, _minimumPositionZ, _maximumPositionZ);
        //
        // _targetPoint.DOLocalMove(pos, 1f);
        _targetPoint.DOMove(pos, 1f);
    }
    
    void Update()
    {
        float vInput = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vInput = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vInput = -1;
        }
        
        float hInput = 0;

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hInput = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hInput = 1;
        }
        
        float zAxis = 0;
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            zAxis = -1;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            zAxis = 1;
        }

        Vector3 targetPosition = _targetPoint.localPosition + new Vector3(hInput * _moveHorizontalRate, vInput * _moveVerticalRate, zAxis * _moveZRate) * Time.deltaTime;
        
        targetPosition.x = Mathf.Clamp(targetPosition.x, _minimumPositionX, _maximumPositionX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, _minimumPositionY, _maximumPositionY);
        targetPosition.z = Mathf.Clamp(targetPosition.z, _minimumPositionZ, _maximumPositionZ);
        
        _targetPoint.localPosition = targetPosition;
    }
}