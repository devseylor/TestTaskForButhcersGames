using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DrawAndRun
{
    [ExecuteInEditMode]
    public class DrawingManager : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private Material _lineMaterial;
        [SerializeField] private RectTransform _drawingArea;
        [SerializeField] private float _lineThickness = 1f;
        [SerializeField] private float _camZ = 1f;
        [SerializeField] private float _threshHold = 0.1f;
        [SerializeField] private float _scaleFactor = 10;
        private float _zOffset = 25;
        private List<Vector3> _points = new List<Vector3>();
        private List<LineRenderer> _segments = new List<LineRenderer>();
        private LineRenderer _line;
        private int _linesCount = 0;
        private bool _isDrawing = false;
        private bool _takeInput = true;
        private void Awake()
        {
            if (_cam == null) _cam = FindObjectOfType<Camera>();
            GameManager.instance.eventsManager.mouseDown.AddListener(OnInputDown);
            GameManager.instance.eventsManager.mouseUp.AddListener(OnInputUp);
            GameManager.instance.eventsManager.LevelInit.AddListener(() => { _takeInput = true; });
            GameManager.instance.eventsManager.LevelEnd.AddListener(() => { _takeInput = false; });
        }
        private void OnInputDown()
        {
            if(_takeInput == false)
            {
                return;
            }
            Vector3 mousePosition = GameManager.instance.inputManager.GetMousePosition();
            _points.Clear();
            _linesCount = 0;
            _isDrawing = true;
            mousePosition.z = _camZ;
            mousePosition = _cam.ScreenToWorldPoint(mousePosition);
            _points.Add(mousePosition);

        }
        private void OnInputUp()
        {
            if (_takeInput == false)
            {
                return;
            }
            _isDrawing = false;
            foreach(LineRenderer rend in _segments)
            {
               Destroy(rend.gameObject);
            }
            _segments.Clear();

            List<Vector3> planeProjection = new List<Vector3>();
            foreach(Vector3 oldPoint in _points)
            {
                Vector3 newPoint = new Vector3(oldPoint.x * _scaleFactor, 0, _zOffset+ oldPoint.z + oldPoint.y * Mathf.Cos(_cam.transform.eulerAngles.x)) ;
                planeProjection.Add(newPoint);
            }
            GameManager.instance.clonesSpawner.ReArrangeClones( ClonesAlignment.instance.CreateAlignment(planeProjection) );
        }
        private void Update()
        {
            if (_isDrawing)
            {
                Vector3 mousePosition = GameManager.instance.inputManager.GetMousePosition();
                mousePosition.z = _camZ;
                mousePosition = _cam.ScreenToWorldPoint(mousePosition);
                float distance = (mousePosition - _points[_points.Count - 1]).magnitude;
                if(distance > _threshHold)
                {
                    _points.Add(mousePosition);
                    CreateSegment(_points[_points.Count -2], _points[_points.Count-1]);
                }
            }
        }
        private void CreateSegment(Vector3 p1, Vector3 p2)
        {
            _line = new GameObject("Line + " + _linesCount).AddComponent<LineRenderer>();
            _line.SetPosition(0, p1);
            _line.SetPosition(1, p2);
            _line.transform.parent = _cam.transform;
            _line.material = _lineMaterial;
            _line.startWidth = _lineThickness;
            _line.endWidth = _lineThickness;
            _line.useWorldSpace = false;
            _line.positionCount = 2;
            _segments.Add(_line);
        }
    }
}