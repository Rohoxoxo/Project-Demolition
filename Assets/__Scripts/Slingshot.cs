using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projLinePrefab;
    public float velocityMult = 10f;

    public LineRenderer lineRenderer;
    public Transform leftArm;
    public Transform rightArm;

    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;

        lineRenderer = GetComponentInChildren<LineRenderer>();
        leftArm = transform.Find("LeftArm");
        rightArm = transform.Find("RightArm");

        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
        }
    }

    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        if (projectile != null) return;

        aimingMode = true;

        projectile = Instantiate(projectilePrefab);
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;

        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
        }
    }

    void Update()
    {
        if (!aimingMode || projectile == null) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = GetComponent<SphereCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, lineRenderer.transform.InverseTransformPoint(leftArm.position));
            lineRenderer.SetPosition(1, lineRenderer.transform.InverseTransformPoint(projectile.transform.position));
        }

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }

            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.isKinematic = false;
            projRB.collisionDetectionMode = CollisionDetectionMode.Continuous;
            projRB.velocity = -mouseDelta * velocityMult;

            FollowCam.SWITCH_VIEW(FollowCam.eView.slingshot);
            FollowCam.POI = projectile;

            if (projLinePrefab != null)
            {
                Instantiate(projLinePrefab, projectile.transform);
            }

            if (lineRenderer != null)
            {
                lineRenderer.enabled = false;
            }

            projectile = null;
            MissionDemolition.SHOT_FIRED();
        }
    }
}