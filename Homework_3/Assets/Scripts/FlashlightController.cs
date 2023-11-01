using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    public GameObject flashLightHolder;
    public Slider batteryBar;
    public GameObject flashlight;
    public GameObject lightSource;

    public bool hasFlashlight = false;

    public float battery = 5f;
    public float coolDownTime = 1f;

    private float outOfCombatTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!hasFlashlight)
        {
            flashLightHolder.SetActive(false);
            flashlight.SetActive(false);
            batteryBar.gameObject.SetActive(false);
            return;
        }

        batteryBar.value = battery / 5f;

        RotateFlashlight();

        //Player holds mouse 1 to turn on flashlight and flashlight turns off when mouse 1 is released
        if (Input.GetMouseButton(0) && hasFlashlight)
        {
            outOfCombatTimer = 0f;
            lightSource.SetActive(true);
            battery -= Time.deltaTime;
        }
        else
        {
            lightSource.SetActive(false);
            outOfCombatTimer += Time.deltaTime;

            //Gradually recharge battery when flashlight is off and player is out of combat
            if (outOfCombatTimer >= 1f)
            {
                StartCoroutine(RechargeBattery());
            }
        }

        //Flashlight turns off when lightTime reaches 0
        if (battery <= 0)
        {
            lightSource.SetActive(false);
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator RechargeBattery()
    {
        while (battery < 5)
        {
            battery += Time.deltaTime;
            yield return null;
        }
    }

    //Flashlight cannot be turned on for coolDownTime seconds
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        //Gradually recharge battery after coolDownTime seconds
        while (battery < 5)
        {
            battery += Time.deltaTime;
            yield return null;
        }
    }

    public void PickUpFlashlight()
    {
        hasFlashlight = true;
        flashLightHolder.SetActive(true);
        flashlight.SetActive(true);
        batteryBar.gameObject.SetActive(true);
    }

    private void RotateFlashlight()
    {
        //Rotate flashlight to face mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(flashLightHolder.transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        flashLightHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
