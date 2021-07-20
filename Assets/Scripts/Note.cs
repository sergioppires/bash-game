using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;

    [SerializeField] private GameObject leftFireworks;
    [SerializeField] private GameObject rightFireworks;
    [SerializeField] private GameObject controller;
    private float speedEnumerator = 100;
    private float time = 0f, speed = 1.0f;
    private float yOffset = -7f, heightOffset = -11.41f;
    bool active = false, isLeftReadyToPress = false, isRightReadyToPress = false;

    

    private Fireworks fireworks;

    void Start(){
        Events.current.onPressLeftButton += LeftButtonpress;
        Events.current.onPressRightButton += RightButtonPress;
    }

    void LateUpdate()
    {
        if(active){
            time += Time.deltaTime/(speed*speedEnumerator);
            UpdatePosition();
            VerifyToDestroy(fireworks.isLeft);     
            VerifyToClick(fireworks.isLeft);       
        }        
    }

    void UpdatePosition(){
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z), time);
    }

    void VerifyToDestroy(bool isLeft){
        if(transform.localPosition.y <= (leftButton.transform.localPosition.y + 0.1f)){
            Destroy(gameObject);
            if(isLeft){
                isLeftReadyToPress = false;                
            } else {
                isRightReadyToPress = false; 
            }
            controller.GetComponent<Controller>().Fail();
        }
    }

    void VerifyToClick(bool isLeft){
        if(transform.localPosition.y <= (leftButton.transform.localPosition.y + 3f)){
            if(isLeft){
                isLeftReadyToPress = true;
            } else {
                isRightReadyToPress = true;
            }
        }
    }

    void LeftButtonpress(){
        if(isLeftReadyToPress){
            controller.GetComponent<Controller>().Score();
            Destroy(gameObject);
            isLeftReadyToPress = false;
        } 
    }

    void RightButtonPress(){
        if(isRightReadyToPress){
            controller.GetComponent<Controller>().Score();
            Destroy(gameObject);
            isRightReadyToPress = false;
        }
    }
    public void SyncWithFirework(Fireworks firework){
        this.fireworks = firework;
        speed = firework.speed;
        SetInitialPosition(firework.isLeft);
        Activate();
    }

    private void Activate(){
        active = true;        
    }

    public void SetSpeed(float newSpeed){
        speed = newSpeed;
    }

    private void SetInitialPosition(bool isLeft){
        if(isLeft){
            transform.localPosition = new Vector3(leftButton.transform.localPosition.x, transform.localPosition.y + yOffset, transform.localPosition.z);
        } else {
            transform.localPosition = new Vector3(rightButton.transform.localPosition.x, transform.localPosition.y + yOffset, transform.localPosition.z);
        }
    }

}
