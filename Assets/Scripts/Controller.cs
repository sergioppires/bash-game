using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject controllerSystem;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject leftButton;
    [SerializeField] private TextMeshProUGUI scoreTM;
    [SerializeField] private Animator anim;
    bool isLeftReadyToPress = false, isRightReadyToPress = false;

    int score = 0;

    void Start() {
        Events.current.onEmitFireworks += EmitNote;    
        Events.current.onHitButtonRightTime += Score; 
        Events.current.onEndGame += GameOver;  
    }

    void Update () { 
        ControllerInputListener();
     }

     void GameOver(){
         controllerSystem.SetActive(false);
         gameOverUI.SetActive(true);
         anim.Play("Die", 0, 0.25f);
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
        if(isLeftReadyToPress){
            Debug.Log("Deu certo");
        }
    }

    public void RightButtonClicked(){
        Events.current.PressRightButton();
        if(isRightReadyToPress){
            Debug.Log("Deu certo");
        }
    }

    void EmitNote(Fireworks fireworks){     
        GameObject newNote = InstantiateNote();
        newNote.transform.SetParent(controllerSystem.transform);
        newNote.GetComponent<Note>().SyncWithFirework(fireworks);
        anim.Play("Attack01", 0, 0.25f);
        }
    private GameObject InstantiateNote(){
        return Instantiate(note, note.transform.position, note.transform.rotation);
    }

    public void Score(bool isLeft){
        score += 10;
        scoreTM.text = score.ToString();
    }
    public void Fail(){
        // Events.current.ExplodeFireworks(false);
    }

    public void ActivateLeft(){
        isLeftReadyToPress = true;
    }

    public void DeactivateLeft(){
        isLeftReadyToPress = false;
        Fail();
    }

    public void ActivateRight(){
        isRightReadyToPress = true;
    }

    public void DeactivateRight(){
        isRightReadyToPress = false;
        Fail();
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
