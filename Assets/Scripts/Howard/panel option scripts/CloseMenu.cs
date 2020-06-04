using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public GameObject panelRoot;
    
    //===== varibles for close to an anchor to internal UI (hand anchor) ==========
    public bool closeToInternalUi = false;
    public GameObject menuRanderer;
    public AnchorUiManager changeAnchor;
    public GameObject closedMenu;

    private bool isClosed = false;
    private Vector3 iniPosition;
    //=============================================================================

    void Awake()
    {
        closedMenu.SetActive(false);
        iniPosition = this.transform.localPosition;
    }
    

    //===== On Button Press =========================================================================
    /* Depending on the closeToInternalUi toggle, the panel will close to a ball and anchor
     * to the hand, or the panel gets destroyed. Place this script in the closed menu button object
     * the script will handle re-parenting the curent object placed in when anchoring. */
    //===============================================================================================
    private void OnTriggerEnter(Collider other)
    {
        if (closeToInternalUi) //This block of code determines if the panel is closed to the hand and displays a button to open it again
        {
            if (isClosed)
            {
                closedMenu.SetActive(false);
                menuRanderer.SetActive(true);

                //unparents the telemetry object
                changeAnchor.AnchorUi();
                //places close button back to menuRenderer parant
                this.transform.parent = menuRanderer.transform;
                //moves collider to the X button display
                this.transform.localPosition = iniPosition;
                
            }
            else
            {
                //Anchoring to the hand
                changeAnchor.AnchorUi();

                closedMenu.SetActive(true);
                menuRanderer.SetActive(false);
                //makes the close button a parent of the panel root, bringing it outside the menuRenderer object 
                //so that the menuRenderer can be set hidden having this script and collider running
                this.transform.parent = panelRoot.transform;
                //centers the button collider to the center of the telemetry object
                this.transform.localPosition = new Vector3(0, 0, 0);
            }
            isClosed = !isClosed;
        }
        else //Destroys the panel on button pressed
        {
            Destroy(panelRoot);
        }
    }
    
}
