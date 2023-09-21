using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using System.Numerics;

public class ThirdPersonShooterController : MonoBehaviour
{

     private Animator _animator;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float NormalSensitivty;
    [SerializeField] private float AimSensitivty;
    [SerializeField] private LayerMask aimColliderLayerMask;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform BulletProjectile;
    [SerializeField] private Transform SpawnBulletPosition;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        UnityEngine.Vector3 mouseWorldPosition = UnityEngine.Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(AimSensitivty);
            thirdPersonController.SetRotateOnMove(false);

            UnityEngine.Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            UnityEngine.Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward =  UnityEngine.Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(NormalSensitivty);
            thirdPersonController.SetRotateOnMove(true);
        }

        if(starterAssetsInputs.shoot)
        {
            UnityEngine.Vector3 aimDir = (mouseWorldPosition - SpawnBulletPosition.position).normalized;
            Instantiate(BulletProjectile, SpawnBulletPosition.position, UnityEngine.Quaternion.LookRotation(aimDir, UnityEngine.Vector3.up ));
            starterAssetsInputs.shoot = false;
        }
    }
}
