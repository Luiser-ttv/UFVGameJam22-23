using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public List<string> dialogueLines;
    public float interactionRadius = 2.0f;
    public bool showDialogue = false;
    public bool dialogueFinished = false;
    public TMP_Text dialogueText;

    private int currentLineIndex = 0;
    private CharacterMovement characterMovement;

    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Interactable"))
                {
                    showDialogue = true;
                    characterMovement.enabled = false;
                    break;
                }
            }
        }

        if (showDialogue)
        {
            dialogueText.gameObject.SetActive(true);

            if (currentLineIndex < dialogueLines.Count)
            {
                dialogueText.text = dialogueLines[currentLineIndex];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentLineIndex++;
                }
            }
            else
            {
                dialogueFinished = true;
                showDialogue = false;
                characterMovement.enabled = true;
                dialogueText.gameObject.SetActive(false);
                currentLineIndex = 0;
            }
        }
    }
}
