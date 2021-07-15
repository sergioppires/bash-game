using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject controllerSystem;
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject leftButton;
    private bool active = false;

    bool EmitLeft = false, EmitRight = false;

    void Start() {
        Events.current.onEmitFireworksLeft += EmitNoteLeft;
        Events.current.onEmitFireworksRight += EmitRightNote;
        
    }
    void Update () { 
        ControllerInputListener();
     }

     void ControllerInputListener(){
        if(Input.GetMouseButtonDown (0)){
            if (Input.mousePosition.x > Screen.width / 2) {
                RightButtonClicked();
            }     
            else {
                LeftButtonClicked();
            }
         }
     }
    public void LeftButtonClicked(){
        Events.current.PressLeftButton();
    }

    public void RightButtonClicked(){
        Events.current.PressRightButton();
    }

    void EmitRightNote(Fireworks fireworks){     
        GameObject newNote = InstantiateNote();
        newNote.transform.SetParent(controllerSystem.transform);
        newNote.GetComponent<Note>().SyncWithFirework(fireworks);        
    }

    void EmitNoteLeft(Fireworks fireworks){
        GameObject newNote = InstantiateNote();
        newNote.transform.SetParent(controllerSystem.transform);
        newNote.GetComponent<Note>().SyncWithFirework(fireworks);
    }

    private GameObject InstantiateNote(){
        return Instantiate(note, note.transform.position, note.transform.rotation);
    }

}















/*  void ColocarQuandoForLançar() {
      if (Input.touchCount > 0)
      {
          var touch = Input.GetTouch(0);
          if (touch.position.x < Screen.width/2)
          {
             if(Input.GetTouch(0).phase == TouchPhase.Began)
             {
                 Debug.Log("Left click");
             }
          }
          else if (touch.position.x > Screen.width/2)
          {
             if (Input.GetTouch(0).phase == TouchPhase.Began)
             {
                 Debug.Log("Right click");
             }
         }
      }
  }
  */
