using UnityEngine;
using System.Collections;

public class Selected : MonoBehaviour {

    public bool selected;
    public GameObject selectionIndicator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (selected)
        {
            selectionIndicator.SetActive(true);
        }
        else
        {
            selectionIndicator.SetActive(false);
        }
    }

    public void ThisSelected()
    {
        selected = true;
    }

    public void Unselected()
    {
        selected = false;
    }
}
