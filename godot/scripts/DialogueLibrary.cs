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
		
		dialogueEvents["KohanaDialogue"] = new DialogueEvent(async () =>
		{

			//MC
			ui.PhraseBegin();
			await ui.DisplayLine("Uh- good morning. This might be a little strange, but…");
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("[My gosh, what am I even doing?]");
			await ui.DisplayLine("[Have I actually gone insane?]");
			await ui.DisplayLine("[There is no way any of this is real. My mother cannot actually be here, it’s impossible. I’m going to look crazy doing this.]");
			await ui.DisplayLine("[Is this what one’s final hours-]");
			await ui.PhraseEnd();
			
			//Kohana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Hey! Are you [MC_NAME]?");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(7);
			await ui.DisplayLine("…How did you know that?");
			await ui.PhraseEnd();
			
			//Kohana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Through your mom, silly. She told me you could help!");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Help with… what exactly?");
			await ui.PhraseEnd();
			
			//Kohana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("My sister… Hana… she means a lot to me.");
			await ui.DisplayLine("She was my role model… who I wanted to be when I grew up…");
			await ui.DisplayLine("But, I got really really sick. I would hear the doctor whisper to her that what I had was… I think he said faytal?");
			await ui.DisplayLine("I don’t know, they use too many big fancy words. But, what I knew was that it wasn’t good. My body didn’t feel good.");
			await ui.DisplayLine("Hana had so many big dreams she wanted to do, like going to study outside of Japan. How crazy is that?!");
			await ui.DisplayLine("I wish I had the chance to do it…");
			await ui.DisplayLine("Hana didn’t send her… what was it? Apuhlekchon? The thing she needed to send to go study far far away. She wasn’t able to send it in time cause she was looking after me.");
			await ui.DisplayLine("That made me feel really, really sad.");
			await ui.DisplayLine("She couldn’t do her biggest wish, all because I needed someone taking care of me.");
			await ui.DisplayLine("Eventually, my body couldn’t take it anymore. One day I woke up and could see my body in front of me, like if I had left it there.");
			await ui.DisplayLine(". . .");
			await ui.DisplayLine("She was very sad. Very very sad for some time.");
			await ui.DisplayLine("I was sad, too. I couldn’t talk to her anymore. It was like I was invisible.");
			await ui.DisplayLine("I couldn’t understand the thoughts she was having. I always thought mind reading powers would be so cool, but they’re hard to understand. She had lots of thoughts every second of the day, and some were really really sad ones.");
			await ui.DisplayLine("One day, she became so sad that she threw this necklace with a picture of us into the sea. I don’t know why she did it. She just sounded very angry and sad.");
			await ui.DisplayLine("She was like this for a bit. And there was nothing I could do.");
			await ui.DisplayLine("A few months later, I noticed she seemed a little happier. Little by little.");
			await ui.DisplayLine("She also got to leave our home and explore the world! It looked like so so much fun. I wish she would have seen me there with her.");
			await ui.DisplayLine("I’m happy she’s doing better. Very very happy. But, I still notice she touches her neck now and then. I think she misses this.");
			inventory.AddItem("Amulet");
			bool hasTestItem = inventory.HasItem("Amulet");
			if (hasTestItem)
			{
				await ui.DisplayLine("That’s the only thing I’ve been able to grab ever since I left my body. Maybe if you give it to her, she will be super duper happy!");
				await ui.DisplayLine("Could you do me this favor? Pretty please?");
			}
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine(". . . Sure, what does your sister look like?");
			await ui.PhraseEnd();
			
			//Kohana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Oh, I forgot! She has dark, black hair and usually has a flower pin just like me!");
			await ui.DisplayLine("She’ll be getting on at the next station. Her name is Hana.");
			await ui.DisplayLine("She’ll be on for a bit, probably until Station 7. Look for her throughout the carts. Thank you so much for your help, miss!");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Yeah, sure. . .");
			//Kohana sprite fades away
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Okay, I’ve totally lost it.");
			await ui.DisplayLine("This can’t be normal. I am talking to ghosts. Everyone in this train must think I’m insane.");
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("And now I have this amulet? How is this possible?");
			ui.ChangeTextSpeed(16);
			await ui.DisplayLine("Whatever, I’ll think of it as my final quest, before my life is ov-");
			await ui.PhraseEnd();
			
			//Train Intercom
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Asahibashi. We have arrived at Asahibashi, station number 2.");
			await ui.DisplayLine("Please exit the train from the right.");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("Well, let’s get this done.");
			await ui.PhraseEnd();
		});
		
		dialogueEvents["KohanaRepeat"] = new DialogueEvent(async () =>
		{

			//Kohana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("In case you forgot, Hana has dark hair and a similar flower pin. Thank you miss!");
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
