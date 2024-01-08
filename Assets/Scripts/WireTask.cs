using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{

    public Camera _mainPlayerCamera;
    public Camera _taskCamera;

    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _leftWires = new List<Wire>();
    public List<Wire> _rightWires = new List<Wire>();

    public List<Color> _availableColors;
    public List<int> _availableLeftWireIndex;
    public List<int> _availableRightWireIndex;

    public Wire CurrentDraggedWire;
    public Wire currentHoveredWire;

    public bool isTaskCompleted = false;

    void Start()
    {
        _availableColors = new List<Color>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();
        
        for (int i = 0; i < _leftWires.Count; i++) {
            _availableLeftWireIndex.Add(i);
        }
        for (int i = 0; i < _rightWires.Count; i++) {
            _availableRightWireIndex.Add(i);
        }

        while (_availableColors.Count > 0 && _availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0 ) {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];

            int pickedLeftWire = Random.Range(0, _availableLeftWireIndex.Count);
            int pickedRightWire = Random.Range(0, _availableRightWireIndex.Count);

            _leftWires[_availableLeftWireIndex[pickedLeftWire]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWire]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWire);
            _availableRightWireIndex.RemoveAt(pickedRightWire);
        }
    }

    void Update() {
        
        if (!isTaskCompleted) {
            int successfulWires = 0;
            for (int i= 0; i < _leftWires.Count; i++) {
                if (_leftWires[i].isSuccess) successfulWires++;
            }

            if (successfulWires >= _leftWires.Count) {
                isTaskCompleted = true;
                Time.timeScale = 1;

                _mainPlayerCamera.enabled = true;
                _taskCamera.enabled = false;
                GameManager.Instance.setWin();
            }
        }
    }
}
