using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour{

    public Dialogue dialogue;
    public string upgradeName;
    public bool checkHasUpgrade;

    void Start(){
        if (upgradeName == null) {
            TriggerDialogue();
        }
        else if (checkHasUpgrade) {
            if(HasUpgrade()) {
                TriggerDialogue();
            }
        }
        else {
            if(!HasUpgrade()) {
                TriggerDialogue();
            }
        }
    }
    
    public void TriggerDialogue(){

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public bool HasUpgrade() {
        return PersistentData.upgrades.Contains(upgradeName);
    }
}
