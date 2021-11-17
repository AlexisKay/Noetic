using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] Backgrounds; //list of backgrounds
    public float smoothing = 1f; //smoothness
    private float[] parallaxScales; //cam proportion
    private Transform cam; //main cam reference
    private Vector3 previousCamPos; //position of cam in previous frame

    private void Awake()
    {
        cam = Camera.main.transform;

    }

    private void Start()
    {
        previousCamPos = cam.position;
        parallaxScales = new float[Backgrounds.Length];
        for (int i = 0; i < Backgrounds.Length; i++) {
            parallaxScales[i] = Backgrounds[i].position.z * -1;
                }
    }

    private void Update()
    {
        for (int i = 0; i < Backgrounds.Length; i++) {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = Backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, Backgrounds[i].position.y, Backgrounds[i].position.z);

            //fade
            Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }
        previousCamPos = cam.position;

    }
    
}
