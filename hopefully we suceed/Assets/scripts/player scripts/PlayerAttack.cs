using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private WeaponManager weapon_Manager;
    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    private bool is_Aiming;

   // [SerializeField]
   // private GameObject arrow_Prefab, spear_Prefab; 

   // [SerializeField]
   // private Transform arrow_Bow_StartPosition;

    private void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();

        //zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInAndOut();

    }

    void WeaponShoot()
    {
        if (weapon_Manager.GetCurrentSelectWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectWeapon().ShootAnimation();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weapon_Manager.GetCurrentSelectWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_Manager.GetCurrentSelectWeapon().ShootAnimation();
                }

                if (weapon_Manager.GetCurrentSelectWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectWeapon().ShootAnimation();


                }
                else
                {
                    if (is_Aiming)
                    {
                        weapon_Manager.GetCurrentSelectWeapon().ShootAnimation();

                        if (weapon_Manager.GetCurrentSelectWeapon().bulletType == WeaponBulletType.ARROW)
                        {
                            //ThrowArrowOrSpear(true);
                        }
                        else if(weapon_Manager.GetCurrentSelectWeapon().bulletType==WeaponBulletType.SPEAR)
                        {
                           // ThrowArrowOrSpear(false);
                        }

                    }
                }
            }
        }
    }

    void ZoomInAndOut()
    {
        if (weapon_Manager.GetCurrentSelectWeapon().weapon_aim == WeaponAim.AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crosshair.SetActive(false);
            }

            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crosshair.SetActive(true);
            }

        }
        if (weapon_Manager.GetCurrentSelectWeapon().weapon_aim == WeaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weapon_Manager.GetCurrentSelectWeapon().Aim(true);
                is_Aiming = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                weapon_Manager.GetCurrentSelectWeapon().Aim(false);
                is_Aiming = false;

            }
        }


    }

  /*  void ThrowArrowOrSpear(bool throwArrow)
    {
        if (throwArrow)
        {
            GameObject arrow = Instantiate(arrow_Prefab);
            arrow.transform.position = arrow_Bow_StartPosition.position;

            arrow.GetComponent<ArrowBowScript>().launch(mainCam);
        }
        else
        {
            GameObject spear = Instantiate(spear_Prefab);
            spear.transform.position = arrow_Bow_StartPosition.position;

            spear.GetComponent<ArrowBowScript>().launch(mainCam);

        }
    }  */
}
