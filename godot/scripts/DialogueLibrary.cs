using Godot;
using System;
using System.Collections.Generic;

public class DialogueLibrary
{
	private Dictionary<string, DialogueEvent> dialogueEvents = new Dictionary<string, DialogueEvent>();

	public DialogueLibrary()
	{

		DialogueBoxUI ui = DialogueBoxUI.Instance;
		PlayerInventory inventory = PlayerInventory.Instance;

		dialogueEvents["OpeningDialogue"] = new DialogueEvent(async () =>
		{

			//MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Another day...");
			await ui.DisplayLine("I wonder why I even bothered with this for so long. ");
			await ui.DisplayLine("Nothing has changed, and I’m still in the same place I once was 12 years ago.");
			await ui.DisplayLine("I wish I could just go back in time and start over again.");
			await ui.DisplayLine("If only it were that simple.");
			await ui.DisplayLine("Why do I wake up every day to do something I’m not even passionate about?");
			await ui.DisplayLine("For others.");
			await ui.DisplayLine("For myself?");
			await ui.DisplayLine(". . .");
			await ui.DisplayLine("It’s whatever.");
			await ui.DisplayLine("I’ve already decided this.");
			await ui.DisplayLine("This is my fate.");
			await ui.PhraseEnd();

			//Train intercom
			ui.PhraseBegin();
			await ui.DisplayLine("This subway will now be transitioning to the Onizuka Train Line.");
			await ui.DisplayLine("This train is local and will be stopping at all 12 stations, including Yami, Mei, and Yū.");
			await ui.DisplayLine("We will shortly be arriving at Midorigaoka. Station number 1.");
			await ui.PhraseEnd();
			
			//Back to MC
			ui.PhraseBegin();
			await ui.DisplayLine("Is this it?");
			await ui.DisplayLine("Is this all that is left for me?");
			await ui.DisplayLine("Am I sure that I can go through with this?");
			await ui.DisplayLine("Will I be happy with this outcome?");
			await ui.DisplayLine("Will I feel free?");
			await ui.DisplayLine(". . .");
			await ui.PhraseEnd();
			
			//Train intercom
			ui.PhraseBegin();
			await ui.DisplayLine("Midorigaoka. We have arrived at Midorigaoka, station number 1.");
			await ui.DisplayLine("Please exit the train from the right.");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			await ui.DisplayLine("11 more stops left.");
			await ui.DisplayLine("22 more minutes left.");
			await ui.DisplayLine("I don’t have any memories that I’ve cherished. No nostalgic memories of happiness.");
			await ui.DisplayLine("I miss the childhood days of being free and doing what I love.");
			await ui.DisplayLine("I had meaning and purpose in life, something I wish I still had.");
			await ui.DisplayLine("Maybe someday I can still find that.");
			await ui.DisplayLine("Maybe today I’ll find that answer.");
			await ui.PhraseEnd();
			
			//Train intercom
			ui.PhraseBegin();
			await ui.DisplayLine("The next stop is Asahibashi. Station number 2.");
			await ui.PhraseEnd();
		});
		
		dialogueEvents["FirstMotherDialogue"] = new DialogueEvent(async () =>
		{

			ui.PhraseBegin();
			await ui.DisplayLine("Another day...");
			//ui.ChangeTextSpeed(10);
			await ui.DisplayLine("second");
			await ui.DisplayLine("third");
			//ui.ChangeTextSpeed(40);
			await ui.DisplayLine("fourth");
			await ui.PhraseEnd();

			
			ui.PhraseBegin();
			await ui.DisplayLine("lorem ");
			await ui.DisplayLine("ipsum ");
			await ui.DisplayLine("dolor ");
			await ui.DisplayLine("sit");
			await ui.PhraseEnd();


			//Test Inventory Functionality
			inventory.AddItem("test");
			bool hasTestItem = inventory.HasItem("test");
			
			ui.PhraseBegin();

			if (hasTestItem)
			{
				await ui.DisplayLine("You got the item.");
			}
			else
			{
				await ui.DisplayLine("You didn't get the item.");
			}
			await ui.PhraseEnd();


			//Test Choices Functionality
			ui.PhraseBegin();
			int choice = await ui.DisplayChoice("Yes", "No");

			if (choice == 0)
				await ui.DisplayLine("You picked yes.");
			else
				await ui.DisplayLine("You picked no.");

			await ui.PhraseEnd();
		});
		
		dialogueEvents["OpeningDialogue"] = new DialogueEvent(async () =>
		{

			ui.PhraseBegin();
			await ui.DisplayLine("Another day...");
			//ui.ChangeTextSpeed(10);
			await ui.DisplayLine("second");
			await ui.DisplayLine("third");
			//ui.ChangeTextSpeed(40);
			await ui.DisplayLine("fourth");
			await ui.PhraseEnd();

			
			ui.PhraseBegin();
			await ui.DisplayLine("lorem ");
			await ui.DisplayLine("ipsum ");
			await ui.DisplayLine("dolor ");
			await ui.DisplayLine("sit");
			await ui.PhraseEnd();


			//Test Inventory Functionality
			inventory.AddItem("test");
			bool hasTestItem = inventory.HasItem("test");
			
			ui.PhraseBegin();

			if (hasTestItem)
			{
				await ui.DisplayLine("You got the item.");
			}
			else
			{
				await ui.DisplayLine("You didn't get the item.");
			}
			await ui.PhraseEnd();


			//Test Choices Functionality
			ui.PhraseBegin();
			int choice = await ui.DisplayChoice("Yes", "No");

			if (choice == 0)
				await ui.DisplayLine("You picked yes.");
			else
				await ui.DisplayLine("You picked no.");

			await ui.PhraseEnd();
		});
	}

	public DialogueEvent GetEvent(string id)
	{
		return dialogueEvents[id];
	}
}
