using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System;

public class PathPointHandler
{
    private PathPoint currentPoint;
    public PathPoint targetPoint;
    private float TimeRemaining;
    private float MaxSpeed;
    private bool ready = false;
    public bool Ready
    {
        get => ready;
        set
        {
            var PM = PathManager.Instance;
            if (PM.handlers.Contains(this))
            {
                ready = value;
                if (ready)
                {
                    request = null;
                    PM.takenPoints.Add(targetPoint);
                    PathManager.Instance.UnregistHandler(this);
                }
            }
            else return;

        }
    }
    public PathManager.PointValidRequest request;
    public PathPointHandler(PathPoint currentPoint, GameObject who = null)
    {
        this.currentPoint = currentPoint;
        this.TimeRemaining = PathManager.Instance.timeRemaining;
        this.MaxSpeed = PathManager.Instance.maxSpeed;
        PathManager.Instance.RegistHandler(this);
        //Debug.Log(PathManager.Instance.name);
    }

    public void RandomNextPoint()
    {
        List<PathPoint> targetList = currentPoint.ApproachablePoints.ToList();
        targetList.Add(currentPoint);
        int rd = UnityEngine.Random.Range(0, targetList.Count);
        targetPoint = targetList[rd];
    }
    public void RequestDestinationValidation()
    {
        request = new PathManager.PointValidRequest(() => PathManager.Instance.NextPointValidation(this));
    }
    public void RemoveCurrentPointOnTakenList()
    {
        PathManager.Instance.takenPoints.Remove(currentPoint);
    }

    public void PlanPath()
    {
        RandomNextPoint();
        if (targetPoint == currentPoint) 
        {
            ready = true;
        }
        else
        {
            RemoveCurrentPointOnTakenList();
            RequestDestinationValidation();
        }
    }

    private ushort CalculateTargetPointRadius()
    {
        ushort radius = (ushort)(MaxSpeed * TimeRemaining);
        return radius;
    }
}
