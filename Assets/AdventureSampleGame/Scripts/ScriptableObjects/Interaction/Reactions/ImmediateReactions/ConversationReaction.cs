using UnityEngine;
using DialogueEditor;

// This Reaction has a delay but is not a DelayedReaction.
// This is because the TextManager component handles the
// delay instead of the Reaction.
public class ConversationReaction : Reaction
{
    public NPCConversation conversation;                        // Reference to the NPC conversation component.

    private ConversationManager conversationManager;            // Reference to the component that take the conversation.


    protected override void SpecificInit()
    {
        conversationManager = FindObjectOfType<ConversationManager> ();
    }


    protected override void ImmediateReaction()
    {
        conversationManager.StartConversation(conversation);
    }
}