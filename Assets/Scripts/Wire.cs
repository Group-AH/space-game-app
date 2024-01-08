using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // variables for references to other objects
    private Image _image;
    private LineRenderer _lineRenderer;
    private Canvas _canvas;
    private WireTask _wireTask;

    // variables 
    private bool isDragStarted = false;
    public bool isLeft;
    public bool isSuccess = false;
    public Color color;

    void Awake() {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();
    }

    void Update() {
        if (isDragStarted) {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos
            );

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        } else {
            if (!isSuccess) {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);

        if (isHovered) {
            _wireTask.currentHoveredWire = this;
        }
    }

    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        this.color = color;
    }

    public void OnDrag(PointerEventData eventData) {

    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (!isLeft) return;
        if (isSuccess) return;
        isDragStarted = true;
        _wireTask.CurrentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (_wireTask.currentHoveredWire != null) {
            if (_wireTask.currentHoveredWire.color == this.color && !_wireTask.currentHoveredWire.isLeft) {
                isSuccess = true;
            }
        }

        isDragStarted = false;
        _wireTask.CurrentDraggedWire = null;

    }
}
