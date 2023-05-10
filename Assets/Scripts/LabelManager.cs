using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabelManager : MonoBehaviour
{
    public GameObject labelCanvas;
    private LineRenderer lr;
    private GameObject currentObj;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        lr.startWidth = 0.014f;
        lr.endWidth = 0.01f;

        lr.startColor = Color.grey;
        lr.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        labelCanvas.transform.LookAt(Camera.main.transform);

        if (currentObj)
        {
            lr.SetPosition(0, currentObj.transform.position);
            lr.SetPosition(1, labelCanvas.transform.position);
        }
    }

    public void UpdateLabel(GameObject obj)
    {
        currentObj = obj;

        labelCanvas.transform.SetParent(obj.transform);
        labelCanvas.transform.localPosition = Vector3.zero;

        Vector3 pos = labelCanvas.transform.localPosition;
        pos.y = -2.5f;
        pos.z = 2f;
        labelCanvas.transform.localPosition = pos;

        labelCanvas.GetComponentInChildren<TextMeshProUGUI>().text = obj.name;
    }
}
