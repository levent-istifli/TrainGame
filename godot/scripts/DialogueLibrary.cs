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

			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Oh, sorry. Let me move to make more space for you —");
			ui.ChangeTextSpeed(7);
			await ui.DisplayLine("M-Mom?!");
			await ui.DisplayLine("How? How are you here?");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("You’ve been dead for the past 12 years of my life.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("What are you doing here?");
			await ui.PhraseEnd();

			//Mother
			ui.PhraseBegin();
			await ui.DisplayLine("Oh dear...");
			await ui.DisplayLine("I know I have a lot to explain, but not much time.");
			await ui.DisplayLine("But I have only one chance of meeting you again in my afterlife, and I wanted to correct some things before you repeat the same mistakes and regrets in life that I had.");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			await ui.DisplayLine("What??");
			await ui.DisplayLine("I still don’t get it.");
			await ui.DisplayLine("What do you want me to even do?");
			await ui.DisplayLine("I-");
			await ui.DisplayLine("(sigh*)I don’t think I’m capable of doing that right now.");
			await ui.PhraseEnd();
			
			//Mother
			ui.PhraseBegin();
			await ui.DisplayLine("I know what you’re going through right now.");
			await ui.DisplayLine("This is my only chance to help you avoid making the same decisions I made in the past.");
			await ui.DisplayLine("I’m here to guide you one last time.");
			await ui.DisplayLine("I don’t have much time to explain more, but you have to listen to me.");
			await ui.DisplayLine("I know what you are planning at the end of this stop.");
			await ui.DisplayLine("I’m not here to shame or criticize you.");
			await ui.DisplayLine("This train will soon make a stop at station 2, and there is a certain someone you need to speak to.");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			await ui.DisplayLine("What?");
			await ui.DisplayLine("Why do I need to talk to someone?");
			await ui.PhraseEnd();
			
			//Mother
			ui.PhraseBegin();
			await ui.DisplayLine("I can only say this much.");
			await ui.DisplayLine("You need to interact with the few spirits who will be aboard this train.");
			await ui.DisplayLine("These are lingering spirits from the afterlife.");
			await ui.DisplayLine("They need your help communicating with past relatives to fix unresolved feelings from the past.");
			await ui.PhraseEnd();
			
			//Train intercom
			ui.PhraseBegin();
			await ui.DisplayLine("Asahibashi. We have arrived at Asahibashi, station number 2.");
			await ui.DisplayLine("Please exit the train from the right.");
			await ui.PhraseEnd();
			
			//Mother
			ui.PhraseBegin();
			await ui.DisplayLine("It has begun.");
			await ui.DisplayLine("To help you start, you need to look for the guided spirit named Kohana. She has a small flower in her hair.");
			await ui.DisplayLine("She needs your help relaying information, so please talk to her.");
			await ui.PhraseEnd();
		});
		
		dialogueEvents["MotherKohanaRepeat"] = new DialogueEvent(async () =>
		{

			//Mother
			ui.PhraseBegin();
			await ui.DisplayLine("Kohana needs your help relaying information, so please talk to her.");
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
