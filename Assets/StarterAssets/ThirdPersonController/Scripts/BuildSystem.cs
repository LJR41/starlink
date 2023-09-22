using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using StarterAssets;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] Transform CamChild; 

    [SerializeField] Transform FenceBuild;

    [SerializeField] Transform FencePrefab;

    public bool isOpen;

    public static BuildSystem Instance {get;set;}
    RaycastHit Hit;

    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {   

        StartBuilding();

    }

    public void FlipIsOpen()
    {
        isOpen = true;
    }

    private void StartBuilding()
    {
        if(Physics.Raycast(CamChild.position,CamChild.forward,out Hit, 8f))
                    {
                        FenceBuild.position = new UnityEngine.Vector3(MathF.Round(Hit.point.x),MathF.Round(Hit.point.y),MathF.Round(Hit.point.z));
                    }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                BuildFence();
            }
    }
    private void BuildFence()
    {

        Instantiate(FencePrefab, FenceBuild.position, UnityEngine.Quaternion.identity);
    }
}
