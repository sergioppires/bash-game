using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;

    [SerializeField] private GameObject leftFireworks;
    [SerializeField] private GameObject rightFireworks;
    [SerializeField] private float speedEnumerator;

    private float time = 0f, speed = 1.0f;
    private float yOffset = -7f, heightOffset = -11.41f;
    bool active = false; 

    // Update is called once per frame
    void Update()
    {
        if(active){
            time += Time.deltaTime/(speed*speedEnumerator);
            UpdatePosition();
            VerifyToDestroy();            
        }        
    }

    void UpdatePosition(){
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z), time);
    }

    void VerifyToDestroy(){
        if(transform.localPosition.y <= (leftButton.transform.localPosition.y + 0.1f)){
            Destroy(gameObject);
        }
    }

    public void SyncWithFirework(Fireworks firework){
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
