using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Event : MonoBehaviour {

    // the text that will be shown on the button leading to this Event
    public string optionText = "Continue";  // could be a property so we can put variables in it?

    // this variable is set in the Editor. If it is set the children of this event's transform will be added to its options list.
    public bool addChildrenToOptions;
    public List<Event> options;

    void Awake ()
    {
        // there should be only one Event per GameObject. The custom Editor should enforce this.
        if (this != transform.GetComponents<Event>()[0])
            Destroy(this);
        else
            this.gameObject.SetActive(false);
    }

    void OnEnable ()
    {

    }
}
