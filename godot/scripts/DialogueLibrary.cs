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
			await ui.DisplayLine("The next stop is Mizunami. Station number 3.");
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
			await ui.DisplayLine("My sister. . .Hana. . .she means a lot to me.");
			await ui.DisplayLine("She was my role model. . .who I wanted to be when I grew up. . .");
			await ui.DisplayLine("But, I got really really sick. I would hear the doctor whisper to her that what I had was. . .I think he said faytal?");
			await ui.DisplayLine("I don’t know, they use too many big fancy words. But, what I knew was that it wasn’t good. My body didn’t feel good.");
			await ui.DisplayLine("Hana had so many big dreams she wanted to do, like going to study outside of Japan. How crazy is that?!");
			await ui.DisplayLine("I wish I had the chance to do it with her. . .");
			await ui.DisplayLine("Hana didn’t send her… what was it? Aplihkaechion? The thing she needed to send to go study far far away. She wasn’t able to send it in time cause she was looking after me.");
			await ui.DisplayLine("That made me feel really really sad.");
			await ui.DisplayLine("She couldn’t do her biggest wish, all because I needed someone taking care of me.");
			await ui.DisplayLine("Eventually, my body couldn’t take it anymore. One day I woke up and could see my body in front of me, like if I had left it there.");
			await ui.DisplayLine(". . .");
			await ui.DisplayLine("She was very sad. Very very sad for some time.");
			await ui.DisplayLine("I was sad, too. I couldn’t talk to her anymore. It was like I was invisible.");
			await ui.DisplayLine("I couldn’t understand the thoughts she was having. I always thought mind reading powers would be so cool, but they’re hard to understand. She had lots of thoughts every second of the day, and some were really really sad ones.");
			await ui.DisplayLine("One day, she became so sad that she threw this necklace with a picture of us into the sea. I don’t know why she did it. She just sounded very angry and sad.");
			await ui.DisplayLine("She was like this for a bit. And there was nothing I could do.");
			await ui.DisplayLine("Well, maybe there was something I was able to do. . .because after it, I finally saw my sister coming back.");
			await ui.DisplayLine("She also got to leave our home and explore the world! It looked like so so much fun. I wish she would have seen me there with her.");
			await ui.DisplayLine("I’m so so happy she’s doing better. Very very happy. She's been able to reach even more than she's dreamed of, and that's so so amazing!");
			await ui.DisplayLine("But, I still notice she touches her neck now and then. I think she misses this.");
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
			await ui.DisplayLine("She’ll be on for a bit, probably until station 7. Look for her throughout the carts. Thank you so much for your help, miss!");
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
			await ui.DisplayLine("Mizunami. We have arrived at Mizunami, station number 3.");
			await ui.DisplayLine("Please exit the train from the right.");
			await ui.DisplayLine("The next stop is Kasumigaura. Station number 4.");
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
		
		dialogueEvents["HanaDialogue"] = new DialogueEvent(async () =>
		{
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Um, excuse me. . ?");
			await ui.PhraseEnd();
			
			//Hana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Hm?");
			await ui.PhraseEnd();
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("Uh . . .");
			ui.DisplayLine("[shoot, what do I say?]");
			int choice = await ui.DisplayChoice("Your sister told me to give you this.", "Uh, I found this near a beach shore, and strangely enough you look like one of the girls in the picture.");
			inventory.RemoveItem("Amulet");
			if (choice == 0) 
			{
				await ui.PhraseEnd();
				
				//Hana
				ui.PhraseBegin();
				ui.ChangeTextSpeed(7);
				await ui.DisplayLine(". . .");
				await ui.DisplayLine("What?");
				await ui.PhraseEnd();
				
				//MC
				ui.PhraseBegin();
				ui.ChangeTextSpeed(12);
				await ui.DisplayLine("Oh, uh, sorry. . . that was probably insensitive, wasn’t it?");
				await ui.PhraseEnd();
				
				//Hana
				ui.PhraseBegin();
				ui.ChangeTextSpeed(7);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("How did you know I had a sister?");
				await ui.PhraseEnd();
				
				ui.PhraseBegin();
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine("I. . .");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("This is going to sound crazy, but I think her spirit wanted me to give this to you before resting. She said it would bring you peace.");
				await ui.PhraseEnd();
				
				//Hana
				ui.PhraseBegin();
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("Huh, interesting. Yeah, this is an amulet I had a few years ago of my sister and I.");
				await ui.DisplayLine("We were inseparable. Tied at the hip. But one day. . .");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine("One day she fell terminally ill.");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("I was the only one there to take care of her. I gave up everything I had for her. And yet . . .");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("Well, I’m sure you know what happened.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("On any regular occasion, I would call you insane. Lunatic. But this is no coincidence.");
				await ui.DisplayLine("If I had known she was by my side this whole time. . .");
				await ui.PhraseEnd();
				
				//MC
				ui.PhraseBegin();
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine(". . .");
				await ui.DisplayLine("If you don’t mind me asking, how did you get through that? I wouldn’t be able to.");
				await ui.PhraseEnd();
				
				//Hana
				ui.PhraseBegin();
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .it was hard.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("Each day felt like a day closer to joining her.");
				await ui.DisplayLine("I didn’t want to stay in this cruel, harsh world anymore. My sweet flower was taken away, for doing absolutely nothing wrong. She wasn’t even 10 years old, for crying out loud. Not even a teenager.");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("We both had dreams, goals, wishes. . .");
				await ui.DisplayLine("I wanted to explore the world, and she wanted to hear all about it.");
				await ui.DisplayLine("Actually, I had even thought about applying to this international program. It would be fully paid for if I got accepted, and I would be going to various different countries and exploring their different worlds.");
				await ui.DisplayLine("I . . . gave up on that dream, for some time. I thought it meant nothing if Kohana was not by my side. ");
				await ui.DisplayLine("But, right before her passing, she asked me why I hadn’t gone. She blamed herself for it.");
				await ui.DisplayLine("Of course, I would never blame her. And was distraught that she thought that way. She made me promise her I would send the application, even if it was late.");
				await ui.DisplayLine("Man. . . I don’t know how I managed to go through with it. Luckily, I had most of it done. So a few more tweaks to an essay on moments where I needed distraction and eventually I hit the send button.");
				await ui.DisplayLine("But I never thought twice about it. As a matter of fact, I did it for her, to keep the promise. But I had no desire to go any longer.");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				await ui.DisplayLine("I had no desire to do anything any longer.");
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("On a really bad day, I went out to a cliffside near our home. I had been thinking about it for weeks, months. I was ready. ");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine("I threw this. . .amulet, into the ocean. I was ready to go next.");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("But, just as I was about to do it, my phone buzzed. It was the application, I had been accepted.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("I fully broke down at that moment. It was like Kohana was reaching out, begging me to rethink my choices. I felt so much at that moment. Sadness, frustration, confusion. . . but also, hope.");
				await ui.DisplayLine("After being in this endless, dark void for so long, I finally began to feel hope. And I latched on to it with all my might.");
				await ui.DisplayLine("That day, I decided this world was too big to stay stuck in such a dark, desolate place. Kohana wanted me to continue living, to continue seeing the world. Leave our small hometown. See what else the world has to offer.");
				await ui.DisplayLine("Of course, it was hard. And now, a few years later, I still have relapses. The world is a rough place, but you have to find those small glimmers of hope and never let go. Only then will you make it through the voids.");
				await ui.PhraseEnd();
			}
			else 
			{
				await ui.PhraseEnd();
				
				//Hana
				ui.PhraseBegin();
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("Huh, interesting. Yeah, this is an amulet I had a few years ago of my sister and I.");
				await ui.DisplayLine("We were inseparable. Tied at the hip. But one day. . .");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine("One day she fell terminally ill.");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("I was the only one there to take care of her. I gave up everything I had for her. And yet . . .");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("Let’s just say she’s not with us anymore.");
				await ui.PhraseEnd();
				
				//MC
				ui.PhraseBegin();
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine(". . .");
				await ui.DisplayLine("If you don’t mind me asking, how did you get through that? I wouldn’t be able to.");
				await ui.PhraseEnd();
				
				//Hana
				ui.PhraseBegin();
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .it was hard.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("Each day felt like a day closer to joining her.");
				await ui.DisplayLine("I didn’t want to stay in this cruel, harsh world anymore. My sweet flower was taken away, for doing absolutely nothing wrong. She wasn’t even 10 years old, for crying out loud. Not even a teenager.");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("We both had dreams, goals, wishes. . .");
				await ui.DisplayLine("I wanted to explore the world, and she wanted to hear all about it.");
				await ui.DisplayLine("Actually, I had even thought about applying to this international program. It would be fully paid for if I got accepted, and I would be going to various different countries and exploring their different worlds.");
				await ui.DisplayLine("I . . . gave up on that dream, for some time. I thought it meant nothing if Kohana was not by my side. ");
				await ui.DisplayLine("But, right before her passing, she asked me why I hadn’t gone. She blamed herself for it.");
				await ui.DisplayLine("Of course, I would never blame her. And was distraught that she thought that way. She made me promise her I would send the application, even if it was late.");
				await ui.DisplayLine("Man. . . I don’t know how I managed to go through with it. Luckily, I had most of it done. So a few more tweaks to an essay on moments where I needed distraction and eventually I hit the send button.");
				await ui.DisplayLine("But I never thought twice about it. As a matter of fact, I did it for her, to keep the promise. But I had no desire to go any longer.");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine(". . .");
				await ui.DisplayLine("I had no desire to do anything any longer.");
				await ui.DisplayLine(". . .");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("On a really bad day, I went out to a cliffside near our home. I had been thinking about it for weeks, months. I was ready. ");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine("I threw this. . .amulet, into the ocean. I was ready to go next.");
				ui.ChangeTextSpeed(9);
				await ui.DisplayLine("But, just as I was about to do it, my phone buzzed. It was the application, I had been accepted.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("I fully broke down at that moment. It was like Kohana was reaching out, begging me to rethink my choices. I felt so much at that moment. Sadness, frustration, confusion. . . but also, hope.");
				await ui.DisplayLine("After being in this endless, dark void for so long, I finally began to feel hope. And I latched on to it with all my might.");
				await ui.DisplayLine("That day, I decided this world was too big to stay stuck in such a dark, desolate place. Kohana wanted me to continue living, to continue seeing the world. Leave our small hometown. See what else the world has to offer.");
				await ui.DisplayLine("Of course, it was hard. And now, a few years later, I still have relapses. The world is a rough place, but you have to find those small glimmers of hope and never let go. Only then will you make it through the voids.");
				await ui.PhraseEnd();
			}
			
			//MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Wow, that’s very. . . touching. Thank you for sharing.");
			await ui.PhraseEnd();
			
			//Hana
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("At the end of the day, we’re all trying to figure out how to get through this world together. As long as I can give others solace or inspiration through my experiences, I will continue sharing them.");
			await ui.PhraseEnd();
			
			//MC, Hana sprite fades away
			ui.PhraseBegin();
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine(". . .");
			await ui.DisplayLine("How bittersweet. . .");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I can’t seem to find Kohana anywhere. Maybe I’m not so crazy after all.");
			await ui.DisplayLine("Let me tell my mom this. I’m sure it’ll make her happy.");
			await ui.PhraseEnd();
		});
		
			
		dialogueEvents["MotherDialogueAfterHana"] = new DialogueEvent(async () =>
		{
			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Mom, I can’t believe it!");
			ui.ChangeTextSpeed(7);
			await ui.DisplayLine("That story was so. . . so touching. . . so bittersweet.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Kohana is so proud of what Hana has accomplished. She wanted her sister to do what she’s always dreamed of.");
			ui.ChangeTextSpeed(7);
			await ui.DisplayLine("But. . . but. . . Hana was really close to. . .a dark place.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I can’t imagine what she went through when she lost Kohana. To lose the most important person to you. The same person that you once shared all your memories with. To be left all alone.");
			await ui.DisplayLine("But Hana’s brave.");
			await ui.DisplayLine("She knew Kohana wanted the best for her, but didn’t realize that Kohana didn’t want to be a burden.");
			await ui.DisplayLine("Hana never saw her as that. She always enjoyed every moment spent with her. Not a single second they spent together was she thinking of her as a burden.");
			await ui.DisplayLine("Now Hana lives and works all over the world. They may not be together, but Kohana always watches over Hana. They're not together physically, but spiritually, Kohana was always watching over her.");
			await ui.DisplayLine("I was able to help Kohana speak to her sister for the last time.");
			await ui.PhraseEnd();


			// Mother Talking
			ui.PhraseBegin();
			await ui.DisplayLine("That's right. You were able to help her soul rest.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			await ui.DisplayLine("Does that mean...");
			await ui.PhraseEnd();

			// Mother Talking
			ui.PhraseBegin();
			await ui.DisplayLine("Her soul can rest peacefully now. She does not have to worry about looking after Hana.");
			await ui.DisplayLine("You allowed Kohana to speak to her sister. A spirit's last wish before they go to the spiritual afterworld. Kohana will no longer be able to watch over Hana, but you allowed her last wish to be granted. To give her sister the lost amulet. She can now rest without worrying about her sister.");
			await ui.DisplayLine("It's bittersweet, but you allowed the two to say their final goodbyes and move on in life.");
			await ui.DisplayLine("Kohana can rest peacefully knowing that she was never a burden and that her sister is happily living her dreams. Hana can now live life without feeling remorse about their argument before her sister’s passing and losing the amulet.");
			await ui.DisplayLine("Two sisters were destined differently, but that didn’t stop them from doing what they loved. In the flower of youth, flowers bloom without any control of how they will look or their lifespan. Some may be destined to sustain life within a vase where life will be cut shorter than that of those within the ground.");
			await ui.DisplayLine("Vase flowers don’t have the same support as grounded ones. Vase flowers can’t support themselves without someone tending to them, but that someone enjoys every second caring for them at the end of their life cycle.");
			await ui.DisplayLine("No matter how short life is, you must find a way to continue to bloom. Kohana may have been the vase flower, and Hana, the ground, but their bond and love for each other was strong, even until their separate ways.");
			await ui.DisplayLine("What I’m saying is that you’re the grounded flower that blooms longer, so you have options.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(7);
			await ui.DisplayLine(". . .could there really be something further for me. . .?");
			await ui.PhraseEnd();

			// Mother Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("You’ll know your answer by the end of this.");
			await ui.DisplayLine("I don’t have much time before we arrive at the next station, but you’ll be meeting someone else before they can rest peacefully.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			await ui.DisplayLine("I understand.");
			await ui.PhraseEnd();

			// Train Intercom
			ui.PhraseBegin();
			await ui.DisplayLine("Kasumigaura. We have arrived at Kasumigaura station number 4.");
			await ui.DisplayLine("Please exit the train from the left.");
			await ui.PhraseEnd();
			
			// Mother Talking
			ui.PhraseBegin();
			await ui.DisplayLine("Look for a man in a bright orange uniform. He wants to give someone one last message before he goes.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			await ui.DisplayLine("Thanks, mother.");
			await ui.PhraseEnd();
		});	

		// Repeat Dialogue for mother
		dialogueEvents["MotherYoruRepeat"] = new DialogueEvent(async () =>
		{
			// Mother
			ui.PhraseBegin();
			await ui.DisplayLine("Yoru needs your help relaying information, so please talk to him");
			await ui.PhraseEnd();
		});

		// new dialogue for Yoru and Hotaru
		dialogueEvents["YoruDialogue"] = new DialogueEvent(async () =>
		{
			// MC
			ui.PhraseBegin();
			await ui.DisplayLine("Hi sir. . .um. . .I’m here because I want to help you grant your final wishes to someone special to you.");
			await ui.PhraseEnd();

			// Yoru
			ui.PhraseBegin();
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("Thank goodness.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("That special someone is my daughter, Hotaru. I want to be able to speak to her about everything that I was never able to throughout the years.");
			await ui.PhraseEnd();

			// MC
			ui.PhraseBegin();
			await ui.DisplayLine("May I ask:");
			int choice = await ui.DisplayChoice("What’s the bond that you and your daughter share?", "What is your daughter like as a person?", "What does she do now?", "How did you end up passing away?");
			if (choice == 0)
			{
				await ui.PhraseEnd();
				
				ui.PhraseBegin();
				await ui.DisplayLine("It was only us from the beginning. Her mother, my wife, had complications during birth and passed away. So I took the responsibility of raising our little girl on my own.");
				await ui.DisplayLine("I made stupid mistakes as a father. I knew nothing about raising a little girl on my own. I was terrified of how she would end up.");
				await ui.DisplayLine("I never knew how to comfort her when others looked down on her, but she’s a strong-willed girl. Just like her mother was.");
				await ui.DisplayLine("While her mother was pregnant with her, her mother suffered from serious complications. We-we...we made an action plan of what to do if she...if one day she was gone.");
				await ui.DisplayLine("I didn’t take it seriously. I didn’t believe that I would lose my wife. My pride and joy. My partner who I was supposed to raise our beautiful daughter with.");
				await ui.DisplayLine("I wasn’t ready for it.");
				await ui.DisplayLine("But that didn’t matter, because our daughter, Hotaru, didn't care that I wasn’t ready. She would cry, scream, throw hissy fits, but most of all she was patient.");
				await ui.DisplayLine("She was patient with me.");
				await ui.DisplayLine("I made silly mistakes, but I learned.");
				await ui.DisplayLine("As she grew older, I couldn’t leave her at home, so I took her to work with me. She loved every second of it. She loved construction and building.");
				await ui.PhraseEnd();
			} else if (choice == 1)
			{
				ui.PhraseBegin();
				await ui.DisplayLine("She’s the same now as she ever was when she was younger. She never took no for an answer. She didn’t care what others had in mind about her.");
				await ui.DisplayLine("She just did what she wanted to do and that was work on construction.");
				await ui.DisplayLine("She was always upset when people would talk about how I was not parenting her well enough, that she’s a girl and doesn’t need to be at a construction site with her father. That a girl like her will have no future in front of her. That it's a man’s job, a woman shouldn’t be working an outside job.");
				await ui.DisplayLine("I always felt like I walked her down the wrong path.");
				await ui.DisplayLine("That I should have just left her at a daycare.");
				await ui.DisplayLine("Maybe she wouldn’t have to face the ridicule from others as a younger girl. She was hurt by those comments, but would always tell them off.");
				await ui.DisplayLine("She was really proud of me, her father. She was just like her mother. . .her mother had always believed that I could do it.");
				await ui.DisplayLine("");
				await ui.DisplayLine("");
				await ui.DisplayLine("");
				await ui.PhraseEnd();
			} else if (choice == 3)
			{
				ui.PhraseBegin();
				await ui.DisplayLine("She’s about to graduate from college. She’s graduating with her degree in Civil Engineering.");
				await ui.DisplayLine("Before I could have celebrated alongside her, I ended up passing away right before her high school graduation.");
				await ui.DisplayLine("One of the moments in life that she cherished was going to school. She loved middle school and high school years. She was so sad when I wasn’t able to accompany her at her graduation.");				
				await ui.DisplayLine("I wasn’t able to be there for her through all the pain she must have suffered going through everything alone when transitioning from high school to college. While I was watching over her, she would...she would sometimes cry all alone. But she was a tough cookie.");
				await ui.PhraseEnd();
			} else
			{
				ui.PhraseBegin();
				await ui.DisplayLine("From a construction machinery operation incident. It was a lot that day.");
				await ui.DisplayLine("Once it had already happened, I could see my soul floating away from my body. I didn’t know what to do since it all happened so fast.");
				await ui.DisplayLine("I immediately thought of Hotaru. I was no longer going to be there for her.");
				await ui.DisplayLine("Who would be by her side when she wanted someone to talk to, laugh with, or even cry to? That one person she heavily depended on was gone.");
				await ui.DisplayLine("It still haunts me to this day. I’ve only been able to watch over her. But today is my chance to change that.");
				await ui.PhraseEnd();
			}
			

			// MC Talking
			ui.PhraseBegin();
			await ui.DisplayLine("What’s your final wish you’d like to grant to your daughter?");
			await ui.PhraseEnd();

			// Yoru Talking (giving item)
			ui.PhraseBegin();
			await ui.DisplayLine("I want to give her this letter. Recently, she’s been sad again. No one is there to be with her during her graduation.");
			inventory.AddItem("Letter");
			bool hasTestItem = inventory.HasItem("Letter");
			
			await ui.DisplayLine("Also, I have this little firefly pin. She’s my little firefly.");
			inventory.AddItem("FireflyPin");
			hasTestItem = inventory.HasItem("FireflyPin");			
			
			// Yoru Talking
			await ui.DisplayLine("Life may be dark around her, but she still illuminates the night sky. It has our names on it.");
			
			// MC Talking
			ui.PhraseBegin();
			await ui.DisplayLine("That was. . .so beautiful. I also lost my mother at a young age, so I understand what she must have been feeling. She’s very brave.");
			await ui.DisplayLine("I also like construction, but.. .but.. .I’ve just been working an office job since that's what was always recommended to me by others, rather than manual labor.");
			await ui.DisplayLine("Thank you for sharing your story with me. I will let her know.");
			await ui.PhraseEnd();

			// Yoru Talking
			ui.PhraseBegin();
			await ui.DisplayLine("Thank you so much. I’ll be able to rest peacefully then. I’ll also finally be able to reunite with my wife.");
			await ui.DisplayLine("Oh, and just so you know, she has short, brown-ish hair. She’ll be wearing clothes similar to mine.");
			await ui.DisplayLine("Thanks again.");
			await ui.PhraseEnd();

		});


		dialogueEvents["HotaruDialogue"] = new DialogueEvent(async () =>
		{
			// MC
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Excuse me. . .umm, this might sound strange, but you’re Hotaru, aren't you? I-I actually have something to give you.");
			await ui.PhraseEnd();

			// Hotaru
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Uhh. . . yes, but, maybe you have the wrong person? I don’t recall us meeting each other before.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("You’re right, we’ve never met each other before, and this may sound crazy or insensitive but please just listen to me. I was just able to speak with your father.");
			await ui.PhraseEnd();

			// Hotaru Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("WHAT? What are you-");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Your father’s name is Yoru, right? ");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("He was a construction worker who unfortunately passed away from a machinery accident right before your high school graduation.");
			await ui.DisplayLine("You were left without your father and now you're about to graduate from college in Civil Engineering.");
			await ui.PhraseEnd();

			// Hotaru Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("How. . .");
			await ui.DisplayLine("How do you know all of that. . .");
			await ui.DisplayLine("my, my father is. . .");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("It might not make sense now, but I have something to give you. It’s a letter and pin from your father.");
			inventory.RemoveItem("Letter");
			inventory.RemoveItem("FireflyPin");
			await ui.DisplayLine("Your father has always been watching over you ever since that day.");
			await ui.DisplayLine("There isn’t a day that goes by that he isn’t wishing that he had done more to guide you through life, but he knows how strong you are, just like your mother.");
			await ui.PhraseEnd();

			// Hotaru Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("But...he’s always been the best father to me. He’s always done everything for me.");
			await ui.PhraseEnd();


			ui.PhraseBegin();
			ui.ChangeTextSpeed(15);
			await ui.DisplayLine("If it's okay, may I ask:");
			int choice = await ui.DisplayChoice("How did your father inspire you?", "How were you able to get over others' opinions about you and your father?", "How were you able to adapt on your own after your father's passing?");
			
			if (choice == 0)
			{
				await ui.PhraseEnd();

				// Hotaru Talking
				ui.PhraseBegin();
				ui.ChangeTextSpeed(12);
				await ui.DisplayLine("My father was my superhero! He always cared for me and put me first, no matter how ridiculous I would be.");
				await ui.DisplayLine("I was a stubborn little kid, and he didn’t mind that. He was patient with me.");
				await ui.DisplayLine("He never left me alone, he always took me to his work. His coworkers would always complain about letting a little girl run around in the workplace.");
				await ui.DisplayLine("But I’ve always thought it was fun and magical. He would teach me a lot of things, so the more and more I fell in love with it.");
				await ui.PhraseEnd();
			} else if (choice == 1)
			{
				// Hotaru Talking
				ui.PhraseBegin();
				ui.ChangeTextSpeed(12);
				await ui.DisplayLine("I didn’t care about people’s opinions towards me. I didn’t mind what they said because I’m doing what I love. I’m not going to let anyone change that.");
				ui.ChangeTextSpeed(8);
				await ui.DisplayLine("But...when people talked about my father...it would...really, really hurt.");
				ui.ChangeTextSpeed(12);
				await ui.DisplayLine("I know my father had sometimes felt guilty about me liking construction or felt like he hadn’t done enough for me as a girl growing up. But...but I-I was never able to tell him that wasn’t true.");
				ui.ChangeTextSpeed(14);
				await ui.DisplayLine("I loved every second of spending time working in construction.");
				await ui.DisplayLine("I loved every second I spent with him.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("And...after his death, word had spread quickly and people became more judgmental about taking on a job that my father had passed away from.");
				await ui.PhraseEnd();				
			} else if (choice == 2)
			{
				// Hotaru Talking
				ui.PhraseBegin();
				ui.ChangeTextSpeed(13);
				await ui.DisplayLine("I didn’t know how to continue living life after that. I may have looked unfazed, but day by day, I was falling apart.");
				await ui.DisplayLine("I was never left alone when I was with my father, but suddenly when...when I learned my father had passed, my world came crashing down.");
				await ui.DisplayLine("Suddenly, I was all alone. I didn’t know what to do. How to handle it all without him anymore.");
				ui.ChangeTextSpeed(15);
				await ui.DisplayLine("I was scared. So scared that I drove myself insane.");
				await ui.DisplayLine("I...I didn’t know if I could continue anymore. Without him by my side.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("My world felt like it had all collapsed. Everything went dark. I thought that if the only person I cared about was gone. Then why should I stay here as well?");
				ui.ChangeTextSpeed(12);
				await ui.DisplayLine("But I know my father. He always called me his bright light.");
				await ui.DisplayLine("That I would always light up the dark.");
				ui.ChangeTextSpeed(10);
				await ui.DisplayLine("He’s told me before that one day...if he were gone...that I’m strong just like my mother.");
				await ui.DisplayLine("I’m capable of taking care of myself and that even if he’s not physically present with me, he will always be watching over me. . . and I guess he was always right.");
				await ui.DisplayLine("It’s not easy for me to graduate alone, but I’m glad he taught me everything I needed to know before his time came to go.");
				await ui.DisplayLine("I no longer have anyone by my side, but I know both my mother and father would be proud of me.");
				await ui.DisplayLine("I know they would want me to move on in life. I have a construction job to look forward to after graduation!");
				await ui.DisplayLine("Even though my father isn’t here with me to share these new experiences, I believe that he’s proud of how far I’ve come and what I've accomplished.");
				await ui.PhraseEnd();
			}

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Hotaru, you’re exactly right.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Your father told me how proud of you he was and how much he wishes he could have told you that.");
			await ui.DisplayLine("He wasn’t able to be with you for your high school graduation, but he’s glad that you have continued with your life even when times were hard.");
			await ui.PhraseEnd();

			// Hotaru Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Thank you...");
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("Thank you so much.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I’m glad my father is proud of me. I’m glad I can walk that stage proudly, becoming a civil engineer.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I’m glad I was able to connect you guys for one last time.");
			await ui.PhraseEnd();

		});


		dialogueEvents["MotherFinalDialogue"] = new DialogueEvent(async () =>
		{
			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Mom, I’m so happy that they were able to connect them for the last time.");
			await ui.DisplayLine("She’s so strong. She was able to get through such a hard period in her life.");
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("I-I. . .felt like her in a way. . .");
			await ui.PhraseEnd();

			// Train Intercom Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("The next stop is Magen. Station number 11.");
			await ui.PhraseEnd();

			// Mother Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I know dear. I know it's been so hard for you to be all alone.");
			await ui.DisplayLine("I don’t have much time left, but I want to tell you this.");
			await ui.DisplayLine("I wish I could have been there for you. You’ve been all alone for a very long time from a young age, and I feel that now this is my chance to explain everything to you, my last chance to correct things.");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("My last wish as a spirit was to meet you again.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("From a young age, I wasn't actually sure what I wanted to do in life, and as I got older, I got more unsure of what was right for me.");
			await ui.DisplayLine("One thing that I had learned about myself for sure was that I wanted to travel. I wanted to live my life happily around the world. I wanted to discover other unknowns and make new everyday experiences.");
			await ui.DisplayLine("At the time, doing something like that wasn’t so common, so I continued through college learning something I wasn’t sure I really wanted to do.");
			await ui.DisplayLine("My family was very traditional and we lived in a rural area so wanting to leave the country was already out of the ordinary for them.");
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("But I really, really, wanted to do it.");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("I didn't have the funds or budget to do it at the time so I just worked jobs that could afford to pay for my living expenses.");
			await ui.DisplayLine("I was already going through a hard time, but then I met your father, and it felt like he was the key to all my problems.");
			await ui.DisplayLine("He was so charismatic and optimistic about life and the world, no matter how uncertain life may have seemed for him. It felt like time had stopped.");
			await ui.DisplayLine("I told him about my dream, and we instantly clicked. He had just finished flight school and told me he could take me for a flight. And we did.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("It was the most amazing feeling ever. Being able to see the landscape from far above. Looking at the beautiful clouds and feeling the winds high in the sky, and getting to move around from place to place, I loved it all so much.");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("He recommended me to become a flight attendant, which I didn’t even know what that was at the time.");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("I loved the job so much.");
			await ui.DisplayLine("He was the pilot, and I was the flight attendant.");
			await ui.DisplayLine("Around that time, I became pregnant with you. Your father and I were so happy to become a family. We lived happily like that for years.");
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("Until one day it felt like the life we built came crashing down.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine(". . .");
			await ui.DisplayLine("Your father had a heart attack.");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("I was so confused on why life had taken such a dramatic turn. It seemed like everything was perfect and that we were growing a happy family.");
			await ui.DisplayLine("I felt like I had lost a piece of me. I felt like I couldn’t live on anymore. I felt like I had lost myself.");
			await ui.DisplayLine("For months on end, I felt like my mind was deteriorating. I felt like I couldn’t be the best mother for you, so I sent you over to my mother’s home.");
			await ui.DisplayLine("Even with family support, I felt like I couldn’t continue on. I felt like I couldn’t escape the reality I was facing. At one point, it felt like I stopped being a mother and a wife.");
			await ui.DisplayLine("One day, I decided that enough was enough, and took a train like this to end it once and for all.");
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("And I did.");
			await ui.PhraseEnd();

			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(14);
			await ui.DisplayLine("Mom. . .");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Mom I’m so sorry. I didn’t know the full truth. I didn’t know you went through all of this.");
			await ui.PhraseEnd();

			// Mother Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Dear...I wish I could go back in time and realize that there was more to life in front of me.");
			await ui.DisplayLine("There’s hope in this world, and you can find it.");
			await ui.DisplayLine("You’ve listened to these stories and have helped the spirits talk to their loved ones for the last time.");
			await ui.DisplayLine("I want you to know that I was in your exact position, but I realized too late that there was more to live for. Life may throw punches at you, but you need to try to get back up.");
			await ui.DisplayLine("My final wish was to talk to you for one last time. The train will be stopping soon, and once it does, I will be gone.");
			await ui.PhraseEnd();


			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Oh...so I won’t be seeing you ever again, huh?. But, I want to continue talking to you. . .");
			await ui.PhraseEnd();


			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("I’m sorry dear. I’m happy that I was able to meet with you for the last time.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I want you to be able to make this decision yourself, and be sure about it. I’m not here to shame you, but I want you to know that there is more to life than what meets the eye.");
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("You’ve listened to these people’s stories, so now I want you to make a decision that you think is best for yourself.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I love you, my dear, and I’ve always had. I can rest easy knowing that I was able to talk to you for the last time.");
			await ui.PhraseEnd();


			// Train Intercom Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Magen. We have arrived at Magen station number 11.");
			await ui.DisplayLine("Please exit the train from the right.");
			await ui.PhraseEnd();

			// Mother Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("Bye dear.");
			await ui.PhraseEnd();
			
		});

		dialogueEvents["MCDialogue"] = new DialogueEvent(async () =>
		{
			// MC Talking
			ui.PhraseBegin();
			ui.ChangeTextSpeed(12);
			await ui.DisplayLine("Am I sure about this?");
			ui.ChangeTextSpeed(9);
			await ui.DisplayLine("Everyone was so resilient.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("I was able to help two sisters, Hana and Kohana, and a daughter-father duo, Yoru and Hotaru.");
			ui.ChangeTextSpeed(9);
			await ui.DisplayLine("Is there more to life...");
			await ui.DisplayLine("What would I even do?");
			await ui.DisplayLine("Would I travel the world?");
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("Study abroad?");
			ui.ChangeTextSpeed(9);
			await ui.DisplayLine("Do something I love?");
			await ui.DisplayLine("Or...what others want me to do...");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("But...but I want to do something I love. Why should I continue the life that I’m living when I can find hope?");
			await ui.DisplayLine("There is hope out there, somewhere, I just need to find it.");
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("I...I...I have to get off.");
			ui.ChangeTextSpeed(10);
			await ui.DisplayLine("There’s more out there. I want to do what I love to do in life, not what others say I should be doing!");
			await ui.DisplayLine("Yes, I’ll get off at this stop. It won’t be easy to go forward, but the hope in the eyes of even the dead. . . I have to chase it.");
			ui.ChangeTextSpeed(8);
			await ui.DisplayLine("I have to find it.");
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
