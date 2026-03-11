using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static List<ProjectileLine> PROJ_LINES = new List<ProjectileLine>();
    private const float DIM_MULT = 0.75f;

    private LineRenderer _line;
    private bool _drawing = true;
    private Projectile _projectile;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _projectile = GetComponentInParent<Projectile>();
        ADD_LINE(this);
    }

    void Update()
    {
        if (_drawing)
        {
            if (_projectile == null)
            {
                _drawing = false;
                return;
            }

            int numPositions = _line.positionCount;
            _line.positionCount = numPositions + 1;
            _line.SetPosition(numPositions, _projectile.transform.position);
        }
    }

    private void OnDestroy()
    {
        PROJ_LINES.Remove(this);
    }

    static void ADD_LINE(ProjectileLine newLine)
    {
        Color col;

        foreach (ProjectileLine pl in PROJ_LINES)
        {
            col = pl._line.startColor;
            col = col * DIM_MULT;
            pl._line.startColor = pl._line.endColor = col;
        }

        PROJ_LINES.Add(newLine);
    }
}