using System;
using TMPro;
using UnityEngine;

public class BenchInfoScript : MonoBehaviour
{
    private bool displayStatus;
    private Gun gunScript;
    private MagazineScript magazineScript;

    public GameObject button;

    public TMP_Text typeText;
    public TMP_Text rangeText;
    public TMP_Text cooldownText;
    public TMP_Text recoilText;
    public TMP_Text sgunSpreadText;
    public TMP_Text sgunPelletsText;
    public TMP_Text damageText;
    public TMP_Text maxAmmoText;
    public TMP_Text elementText;
    public TMP_Text magTypeText;
    public TMP_Text magCountText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GunInfo"))
        {
            displayStatus = true;
            gunScript = other.GetComponent<Gun>();
            magazineScript = other.GetComponent<MagazineScript>();

            typeText.text = gunScript.type.ToUpper();
            rangeText.text = "RANGE: " + gunScript.bulletRange.ToString();
            cooldownText.text = "COOLDOWN: " + gunScript.fireCooldown.ToString();
            recoilText.text = "RECOIL: " + (gunScript.verticalRecoil * -1).ToString();
            damageText.text = "DAMAGE: " + gunScript.damage.ToString();
            maxAmmoText.text = "MAX AMMO: " + gunScript.maxAmmo.ToString();
            elementText.text = gunScript.element.ToUpper();

            magTypeText.text = "MAG: " + magazineScript.magTypeString.ToUpper();
            magCountText.text = "MAG COUNT: " + magazineScript.magCount.ToString();

            if (typeText.text == "SHOTGUN" || typeText.text == "AUTO SHOTGUN")
            {
                sgunSpreadText.text = "SGUN SPREAD: " + gunScript.shotgunSpread.ToString();
                sgunPelletsText.text = "SGUN PELLETS: " + gunScript.shotgunPellets.ToString();
            }

            button.SetActive(false);


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GunInfo"))
        {
            gunScript = null;
            magazineScript = null;

            typeText.text = "";
            rangeText.text = "";
            cooldownText.text = "";
            recoilText.text = "";
            sgunSpreadText.text = "";
            sgunPelletsText.text = "";
            damageText.text = "";
            maxAmmoText.text = "";
            elementText.text = "";

            magTypeText.text = "";
            magCountText.text = "";

            button.SetActive(true);
        }        
    }
}