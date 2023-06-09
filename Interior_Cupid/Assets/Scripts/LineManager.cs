using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;
using TMPro;
using UnityEngine.EventSystems;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public ARPlacementInteractable placementInteractable;
    public TextMeshPro mText;
    private int pointCount = 0;
    LineRenderer line;
    public bool continuous;
    public TextMeshProUGUI buttonTxt;
    private List<TextMeshPro> distanceTexts = new List<TextMeshPro>();

    void Start()
    {
        placementInteractable.objectPlaced.AddListener(DrawLine);
    }

    public void ToggleBetweenDiscreteAndContinuous()
    {
        if (continuous)
        {
            buttonTxt.text = "Discrete";
            continuous = false;
        }
        else
        {
            buttonTxt.text = "Continuous";
            continuous = true;
        }
    }

    void DrawLine(ARObjectPlacementEventArgs args)
    {
        
        pointCount++;

        if (pointCount < 2)
        {
            line = Instantiate(lineRenderer);
            line.positionCount = 1;
        }
        else
        {
            line.positionCount = pointCount;
            if (!continuous)
            {
                pointCount = 0;
            }
        }

        line.SetPosition(line.positionCount - 1, args.placementObject.transform.position);

        if (line.positionCount > 1)
        {
            Vector3 pointA = line.GetPosition(line.positionCount - 1);
            Vector3 pointB = line.GetPosition(line.positionCount - 2);
            float dist = Vector3.Distance(pointA, pointB);

            TextMeshPro distText = Instantiate(mText);
            distText.text = dist.ToString("F2") + " m";
            distanceTexts.Add(distText);

            Vector3 directionVector = (pointB - pointA);
            Vector3 normal = args.placementObject.transform.up;

            Vector3 upd = Vector3.Cross(directionVector, normal).normalized;
            Quaternion rotation = Quaternion.LookRotation(-normal, upd);

            distText.transform.rotation = rotation;
            distText.transform.position = (pointA + directionVector * 0.5f) + upd * 0.05f;
        }
    }

    public void ClearLines()
    {
        foreach (TextMeshPro distText in distanceTexts)
        {
            Destroy(distText.gameObject);
        }
        distanceTexts.Clear();

        // Destroy all the line objects
        LineRenderer[] lines = FindObjectsOfType<LineRenderer>();
        foreach (LineRenderer line in lines)
        {
            Destroy(line.gameObject);
        }

        pointCount = 0;
    }

}