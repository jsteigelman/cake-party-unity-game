using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    // [SerializeField] Color32 cakeOnPlateColor = new Color32 (1, 1, 1, 1);
    // [SerializeField] Color32 emptyPlateColor = new Color32 (1, 0, 1, 0);

    public bool serverHasSlice = false;
    int cakesDelivered; 

    SpriteRenderer spriteRenderer;

    public Sprite Server_Black_Empty;
    public Sprite Server_Black_Full;

    // tests below
    public GameObject plateOneGameObject;
    public GameObject plateTwoGameObject;
    public GameObject plateThreeGameObject;
    public GameObject plateFourGameObject;
    public GameObject plateSixGameObject;
    public GameObject plateSevenGameObject;
    public GameObject plateEightGameObject;
    public GameObject plateNineGameObject;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // hide cakes on plates
        plateOneGameObject.GetComponent<Renderer>().enabled = false;
        plateTwoGameObject.GetComponent<Renderer>().enabled = false;
        plateThreeGameObject.GetComponent<Renderer>().enabled = false;
        plateFourGameObject.GetComponent<Renderer>().enabled = false;
        plateSixGameObject.GetComponent<Renderer>().enabled = false;
        plateSevenGameObject.GetComponent<Renderer>().enabled = false;
        plateEightGameObject.GetComponent<Renderer>().enabled = false;
        plateNineGameObject.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        // when server reaches plate, show cake

        if (other.tag == "CakeStand"  && !serverHasSlice) {
            Debug.Log("Cake slice picked up!");
            serverHasSlice = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Server_Black_Full;
        }

        if (other.tag == "Plate" && serverHasSlice) {
            Debug.Log("Cake slice delivered to plate!");

            // update server to empty
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Server_Black_Empty;
            serverHasSlice = false;

            // Destroy(other.gameObject, destroyDelay);
            other.GetComponent<Renderer>().enabled = true;
            other.enabled = false;

            cakesDelivered++;
        }

        if (cakesDelivered == 8) {
            Debug.Log("Won GAME!");
        }
    }
}

