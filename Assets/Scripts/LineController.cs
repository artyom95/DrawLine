using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LineController : MonoBehaviour
{
     [SerializeField]
     private Color _startColor = Color.red;
     [SerializeField]
     private Color _endColor = Color.yellow;
     [SerializeField]
     private float _startWidth = 0.1f;
     [SerializeField]
     private float _endWidth = 0.1f;
    
     private LineRenderer _lineRenderer;
     private Vector2 _startPosition;
     private Vector2 _currentPosition;
     private bool _isLineDraw;
     // Start is called before the first frame update
  private  void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = _startWidth;
        _lineRenderer.endWidth = _endWidth;
        _lineRenderer.startColor = _startColor;
        _lineRenderer.endColor = _endColor;
        ClearLine();
    }

    // Update is called once per frame
   private void Update()
    {
        _currentPosition = GetMousePosition();
     
        if (Input.GetMouseButton(0)) 
        {
            if (_currentPosition == _startPosition)
            {
                return;
            }
            if (_isLineDraw)
            {
                ClearLine();
            } 
            DrawLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isLineDraw = true;
        }
    }

    private void ClearLine()
    {
        _lineRenderer.positionCount = 0;
        _isLineDraw = false;

    }

    private void DrawLine()
    {
        _startPosition = GetMousePosition();
        _lineRenderer.positionCount++; 
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1,new Vector3(_startPosition.x, _startPosition.y,0f)); 
        Debug.Log("first Line");

    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
}

