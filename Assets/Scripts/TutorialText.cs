using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public GameObject textPopUp;
    public Animator animator;
    public TMP_Text popUpText;
    [SerializeField]
    public string FirstTutorialText;

    public string[] levelDesc = {"alevin text", "fry text", "parr text", "smolt text", "adult text", "spawning text"};
    
    public void PopUp(string boxText) {
        textPopUp.SetActive(true);
        popUpText.text = boxText;
        animator.SetTrigger("pop");
    }

    void Start() {
        print("Started listener");
        this.PopUp(FirstTutorialText);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            print("Got Key Q");
            this.PopUp("ITS WORKING");
        } 
    }
}
