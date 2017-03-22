using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VoiceOverMasterDeprecated: MonoBehaviour {

    [HideInInspector]
    public string key;
	[HideInInspector]
	public SUBTITLE_TYPE subtitleType;
	[HideInInspector]
	public bool subtitlesActive = true;

	public GameObject subtitleTextUI;
	public Text subtitleText;

	[HideInInspector]
	private string script;
	[HideInInspector]
	public float subtitleTime;
	[HideInInspector]
	public bool playVO = false;
	[HideInInspector]
	public AudioSource currentAudio;

    private void Start()
    {
        Text subtitleText = GetComponent<Text>();
    } 

    void Update () 
	{
		if (playVO == true) 
		{
			subtitleTime -= Time.deltaTime;
		}
		if (subtitleTime <= 0 && subtitleType != SUBTITLE_TYPE.NONE)
			EndSubtitle ();
	}

	//called in AddVoiceOver script
	public void PlaySubtitle()
	{
        subtitleText.text = LocalizationManager.instance.GetLocalizedValue(key);
//        subtitleText.text = script;
		//		if (subtitlesActive == true)
		subtitleTextUI.SetActive (true);
	}

	void EndSubtitle()
	{
		playVO = false;
		//		if (subtitlesActive == true)
		subtitleTextUI.SetActive (false);
		subtitleType = SUBTITLE_TYPE.NONE;
	}
	
	//called in AddVoiceOver script
	public void ChooseSubtitle()
	{
		switch (subtitleType)
		{
		case SUBTITLE_TYPE.TEST_OPENING_SUB:
			script = "Look at Ball, gaining its first bit of experience. Wonderful start!";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.TEST_FLOAT_POWER_UP:
			script = "By touching the strange object, Ball gained the ability to float. \n It was truly bizarre.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.ISLAND_BALL_HAD_ENTERED_INTO_A_STRANGE:
			script = "Ball had entered into a bizarre new world.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.ISLAND_AN_ARCHIPELAGO_WITH_THREE_TOWERS:
			script = "An archipelago with three towers.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_WHY_WAS_BALL_HERE_WHAT_WAS_THERE:
			script = "Why did Ball come here? What was there to gain?";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.ISLAND_PERHAPS_BALL_CAME_HERE_TO_PLAY:
			script = "Perhaps Ball came here to play.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_TOSS_A_SNOWBALL_AROUND:
			script = "Toss a snowball around. Frolic in the open.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.ISLAND_BALL_LOVED_EVERYTHING_RED:
			script = "Ball loved everything red. Red switches. Red towers.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.ISLAND_THIS_MIGHT_AS_WELL_BE_HEAVEN:
			script = "This might as well be heaven.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_BALL_LOVED_FINDING_NEW_THINGS:
			script = "Ball loved finding new things.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_THE_ACT_OF_DISCOVERY:
			script = "The act of discovery! What lies in wait around the corner?";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.ISLAND_THESE_TOWERS_THIS_MAZE:
			script = "These towers! This maze! Those triangles! What do they all mean?";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.ISLAND_BUT_IS_IT_REALLY_DISCOVERY:
			script = "But is it really discovery? Or rediscovery? This place isn't exactly untouched.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.ISLAND_MAYBE_BALL_JUST_NEEDED_A_HIKE:
			script = "Maybe ball just needed a hike. To gain some perspective.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.ISLAND_BEAUTIFUL_ISNT_IT:
			script = "Beautiful, isn't it?";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.ISLAND_AT_THE_TOP_WELL_IT_ALL_SEEMS_SO:
			script = "At the top, well, it all seems so small. And it was, in the end.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.ISLAND_BALL_FOUND_AN_ODD_SWITCH:
			script = "Ball found an odd switch on the ground.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_DOORS_WERE_OPENING_WHY:
			script = "Doors were opening? Why? What was the mechanism?";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.ISLAND_WHERE_DID_THE_SWITCHES_GO:
			script = "Where did the switches go? Was there a party for switches?";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.ISLAND_SNOWBALLS_LINED_UP_IN_THIS_PLACE:
			script = "Snowballs lined up. In this place? For throwing? It didn't make sense.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.ISLAND_SPACETIME_WARPS_DID_THEY_BRING_BALL:
			script = "Spacetime warps? Did they bring Ball here?";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.ISLAND_THE_TRUTH_IS_BALL_WAS_A_LEARNER:
			script = "The truth is, Ball was a learner.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_COULD_IT_BE_THAT_SIMPLE:
			script = "Could it be that simple? That Ball was here to learn?";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.ISLAND_CANT_YOU_LEARN_ANYWHERE:
			script = "Can't you learn anywhere?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.ISLAND_WHY_HERE_DOES_IT_EVEN_MATTER:
			script = "Why here? Does it even matter?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_WELL_GOING_TO_MOVE_OR_IS_BALL:
			script = "Well? Going to move? Or is Ball paralyzed with fear?";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.CANYON_WHAT_IS_THERE_TO_BE_SCARED_OF:
			script = "What is there to be scared of? Literally nothing in this world can bite.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_WASDTHEAROOWKEYSTAKEYOURPICK:
			script = "WASD. The arrow keys. Take your pick. \n Geez, make me break the 4th wall, whydoncha?";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.CANYON_OFFTOAGOODSTART:
			script = "Off to a good start.";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.CANYON_BALLCOULDNTGOTHATWAY:
			script = "Ball couldn't go that way. Aside from the invisible wall, there was literally nothing over there. Nothing. Emptiness. 0 instead of a 1.";
			subtitleTime = 10f;
			break;
		case SUBTITLE_TYPE.CANYON_IMEANYOUCANTRYALLYOUWANT:
			script = "I mean, you can try all you want. It won't get you anywhere.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_WHATDOWEHAVEHEREABALLWHOTHINKS:
			script = "What do we have here? A Ball who thinks its a person? How cute.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_BETTERNOTGETAHEADOFYOURSELFBALL:
			script = "Better not get ahead of yourself, Ball.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_THISSTATUELOOKSALITTLEBALD:
			script = "This statue looks a little bald. Because... because... Ball. Bald. *laugh*";
			subtitleTime = 9f;
			break;
		case SUBTITLE_TYPE.CANYON_BUTSERIOUSLYWHATTHEHELLISTHIS:
			script = "But seriously, what the hell is this? Doesn't look like any shape I've ever seen.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.CANYON_ANDTHENBALLSTUMBLEDUPONTHEPILEOFINFINITEBOXES:
			script = "And then Ball stumbled upon the pile of infinite boxes. \n The number of boxes was actually finite, but boy, there were a lot of them.";
			subtitleTime = 9f;
			break;
		case SUBTITLE_TYPE.CANYON_BALLFELTBADWHENITREALIZEDTHATTHEPILEOFBOXES:
			script = "Ball felt bad when it realized that the pile of boxes was actually a cairn.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_LIKESOMEBODYSETTHATTHINGUP:
			script = "Like, somebody set that thing up.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_WHATKINDOFANASSHOLETEARSSOMETHINGDOWN:
			script = "What kind of an asshole tears something down? A circular, red one, apparently.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.CANYON_INSIDEWASACUBEOHTHANKYOUFORSAVINGME:
			script = "Inside was a cube. \"Oh, thank you for saving me,\" the cube said. \"I was a goner.\" ";
			subtitleTime = 6.5f;
			break;
		case SUBTITLE_TYPE.CANYON_WELLIDBESTBEGOINGTHECUBESAID:
			script = "\"Well, I'd best be going,\" the cube said. \n \"Me too,\" replied Ball.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.CANYON_YETBALLKNEWTHATIFITCAMEBACKHERETHECUBEWOULDSTILLBEHERE:
			script = "Yet Ball knew that if it came back here, that cube would still be here. \n Never moving an inch.";
			subtitleTime = 6.5f;
			break;
		case SUBTITLE_TYPE.CANYON_WASTHATREALLYOKAYTOFREETHATCUBE:
			script = "Was that really okay? To free that cube? He was a criminal, right?";
			subtitleTime = 5.5f;
			break;
		case SUBTITLE_TYPE.CANYON_WHATIFBALLJUSTRELEASEDASERIALKILLER:
			script = "What if Ball just released a serial killer? A thief? A loiterer? Heaven forbid!";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.CANYON_THEDAUNTINGTOWERSOFHEAVEN:
			script = "The daunting Towers of Heaven. How high they rise. How phallic their shape.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.CANYON_AHYESCLASSICJUDEOCHRISTIAN:
			script = "Ah, yes. Classic Judeo-Christian buttons on top of large columns.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.CANYON_WHATISTHISAMAZEFORANTS:
			script = "What is this, a maze for ants?";
			subtitleTime = 2.5f;
			break;
		case SUBTITLE_TYPE.CANYON_ACTUALLYITSLIKETHEPERFECTSIZEFORASPHERE:
			script = "Actually, it's like the perfect size for a sphere. A little dirty though.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.CANYON_OHITSEEMSTHEYBUILTONEFORREAL:
			script = "Oh, it seems they built one for real.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_INVISIBLEWALLSCLEVERCLEVER:
			script = "Invisible walls. Clever, clever, maze builder.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_ACTUALLYNOTINVISIBLEATALLVISIBLEVISIBLEAIR:
			script = "Actually, not invisible at all. Visible! Visible air? \n The heck do you call something like that?";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.CANYON_SERIOUSLYWHOEVERBUILTTHATMAZEWASAWESOME:
			script = "Seriously, whoever built that maze was awesome.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_INTERESTINGTHEREWASNOBACKSIDETOTHETOWERSOFHEAVEN:
			script = "Interesting. There was no backside to the Towers of Heaven. \n Could they even be called \"towers\"?";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.CANYON_WHOEVERSETUPTHELIGHTINGITHISTOWERDIDATERRIBLEJOB:
			script = "Whoever set up the lighting in this tower did a terrible job.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_ANDWHATISWITHTHESEFLOATINGPLATFORMS:
			script = "And what is with these floating platforms? \n Who thought that the best way to traverse this was a bunch of platforms?";
			subtitleTime = 7.5f;
			break;
		case SUBTITLE_TYPE.CANYON_ANELEVATORWOULDHAVEBEENNICE:
			script = "An elevator would have been nice.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_THELIGHTSHERESEEMEDMORESTABLEFORWHATEVERTHATWASWORTH:
			script = "The lights here seemed more stable, for whatever that was worth.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.CANYON_BALLDIDNTLIKEBEINGPRESENTEDWITHOPTIONS:
			script = "Ball didn't like being presented with options.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_WITHOPTIONSCAMEMISTAKES:
			script = "With options came mistakes.";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.CANYON_WITHMISTAKESCOMEWELLMISTAKESAREPRETTYBAD:
			script = "With mistakes come... well, mistakes are pretty bad to begin with. \n No need to go deeper.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.CANYON_HMMWERETHESEPLATFORMSSPECIALBECAUSETHEYMOVED:
			script = "Hmm. Were these platforms special, because they moved, or were all the stationary ones just broken? ";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.CANYON_HONESTLYTHEREWASNOSENSETOTHISARCHITECTURE:
			script = "Honestly, there was no sense to this architecture. \n Rhyme? Reason? None of it!";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.CANYON_HEYREMEMBERWHENYOUWEREDOWNTHERE:
			script = "Hey, remember when you were down there? \n Ah, fun times Ball had, eh?";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.CANYON_FINALLYBALLMADEITTOTHETOP:
			script = "Finally, Ball made it to the top.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.CANYON_ANDSOBALLSJOURNEYCONTINUED:
			script = "And so Ball's journey continued.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.OPENING_IDLIKETOSHINEASPOTLIGHT:
			script = "I'd like to shine a spotlight on something that's been bothering me for awhile.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.OPENING_DOYOUKNOWWHOTHISIS:
			script = "Do you know who this?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.OPENING_THISISBALLSELFISHLOSERTRAITOR:
			script = "This... is Ball. \n Selfish? Loser? Traitor? All true.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.OPENING_IWANTYOUTOKNOWTHATBALLHASBEEN:
			script = "I want you to know that Ball has been a real pain in my side for years now.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.OPENING_ALWAYSDIFFERENTTHATONE:
			script = "Always different, that one. Never really fit in.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.OPENING_ANDIMUSTSAYIWASQUITEHAPPY:
			script = "And, I must say, I was quite happy when Ball left.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_BALLLEFTOURCITYOFLOSANGLES:
			script = "Ball left our city of Los Angles sometime in the middle of his education.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_WASNTCONTENTFORWHATEVERREASON:
			script = "Wasn't content, for whatever reason.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L11_THEREWASONLYONEWAYFORBALLTOGO:
			script = "There was only one way for Ball to go. \n Out. \n That single path lay before him.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_DOORSSTOODINTHEWAY:
			script = "Doors stood in the way. But not for long.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_BALLJUMPEDOVERATINYLEDGE:
			script = "Ball jumped over a tiny ledge. The first of many obstacles.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_AHTHETINYLEDGE:
			script = "Ah, the tiny ledge. Ball truly was pathetic. \n Couldn’t even get over that and yet he expected to make it in this world. \n What a disgrace.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_SEEINGBALLSTRUGGLEIWASGLAD:
			script = "Seeing Ball struggle, I was glad he was leaving. \n We didn’t need someone like that weighing our society down.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_BALLWASALWAYSODDDIFFERENT:
			script = "Ball was always odd. Different. \n Too incompetent to be a cube. \n Too intelligent to be a circle.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_NOBODYKNEWWHATTOMAKEOFHIM:
			script = "Nobody knew what to make of him, least not himself.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L11_WEREALLBETTEROFF:
			script = "We’re all better off with that problem out of our walls.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L12_AHTHEHIDDENSHAPEIMSURPRISEDBALLFOUNDIT:
			script = "Ah, the Hidden Shape. I'm surprised Ball could find it.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_SOMETIMESBALLLOOKEDBACKONTHECITY:
			script = "Sometimes Ball looked back on the city that had been his home. \n But he couldn't bring himself to go back.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L12_DIDHEREALLYWANTTHISTOLEAVEOURGREATCITY:
			script = "Did he really want this? To leave our great city?";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.L12_WHY:
			script = "Why?";
			subtitleTime = 1f;
			break;
		case SUBTITLE_TYPE.L12_DOESHEEVENUNDERSTANDWHATHESLEAVINGBEHIND:
			script = "Does he even understand what he's leaving behind?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_WHATWASTHEPROBLEMWHATWASNTTOLOVE:
			script = "What was the problem? What wasn't to love?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L11_CUBESBUILTTHISPARADISE:
			script = "Cubes built this paradise, and yet Ball wanted nothing to do with it.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L12_MAYBETHATWASITRAISEDBYCUBESSURE:
			script = "Maybe that was it. Raised by cubes, sure, but Ball was never really one of us.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L12_WELLIMGLADHELEFTTHEONLYTHINGHEEVERDIDWASMUCK:
			script = "Well I'm glad he left. The only thing he ever did was muck up the waters.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.L12_WOWITHOUGHTTHATWASHIDDENPRETTYWELL:
			script = "Wow. I thought that was hidden pretty well. \n Suppose I could be wrong once in a while.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L12_BALLWOULDROLLAROUNDLIKEACHUMP:
			script = "Ball would roll around like a chump.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_DOYOUKNOWWHYTHEEASTERNROAD:
			script = "Do you know why the Eastern Road is so poorly maintained? \n Because nobody needs it anymore.";
			subtitleTime = 9f;
			break;
		case SUBTITLE_TYPE.L12_LOSANGLESISALLANYONENEEDS:
			script = "Los Angles is all anyone needs. Come here, and there's no reason to leave.";
			subtitleTime = 10f;
			break;
		case SUBTITLE_TYPE.L12_UNLESSYOURETHATONETHATAWFULLITTLECIRCLE:
			script = "Unless you're that one. That awful little circle.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.L12_DONTMINDTHATCUBEHESPROBABLYOUTFORASTROLL:
			script = "Don't mind that cube. He's probably out for a stroll.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L12_DONTBELIEVEMEASKHIM:
			script = "Don't believe me? Ask him!";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.L12_SEEWHOWASRIGHT:
			script = "See? Who was right?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_IVEALWAYSBEENSURPRISED:
			script = "I've always been surprised how few shapes know that \n Cubes were the inventor of the button.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L12_IMSUREBALLISGLADTHECUBESMADETHAT:
			script = "I'm sure Ball is glad the cubes made that. \n Else there was no way to the other side.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L12_BALLCOULDNTSEETHEINIVISIBLEPLATFORM:
			script = "Ball couldn't see the invisible platform. \n If he could, it would be far easier to get the hidden shape.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L12_BALLCOULDCLIMBUPSOMEWALLS:
			script = "Ball could climb up walls as well. \n A cube skill, but one Ball learned to fit in. ";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L11_FORALLTHEGOODTHATDID:
			script = "For all the good that did.";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.L12_GOONBALLGETOUTOFHERE:
			script = "Go on, Ball. Get out of here. Nobody wants you. Nobody likes you.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L12_LOSANGLESWASACITYFORCUBESANYWAY:
			script = "Los Angles was a city for Cubes anyway. Not some Circle like you.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L12_THOSEDIRTYCIRCLESWHOLEFTBALLONOURDOORSTOP:
			script = "Those dirty Circles who left Ball on our doorstop. \n Who pushed their burden on us.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L12_GOONBALLBURDENTHEMAGAIN:
			script = "Go on, Ball! Burden them again!";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_THISISNTYOURHOMEITNEVERWAS:
			script = "This isn't your home. It never was.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_WHEREWASBALLGOINGYOUASK:
			script = "Where was Ball going, you ask?";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.L12_HAVEYOUHEARDOFPYRAMID:
			script = "Have you heard of Pyramid?";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.L12_LANDOFTHETRIANGLES:
			script = "Land of the Triangles. Home of the laziest shapes you've ever met.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.L12_ALLTALKNOACTION:
			script = "All talk, no action, those ones. Knowledge first, work second.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L12_WHYBALLSOUGHTTHEMOUTILLNEVERKNOW:
			script = "Why Ball sought them out, I'll never know.";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE.L12_BUTTHEREHEWENTGONENEVERTORETURN:
			script = "But there he went. Gone. Never to return.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_THANKTESSAHESGONE:
			script = "Thank Tessa, he's gone!";
			subtitleTime = 2f;
			break;
		case SUBTITLE_TYPE. L22_BUTWHYWHYDOICARESOMUCH:
			script = "But why? Why do I care so much?";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L12_IMPRESSIVETOFINDTHISHIDDENOBJECT:
			script = "Impressive. To find this hidden object. I clearly didn't give Ball enough credit.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L22_PYRAMIDONEOFTHEWONDERS:
			script = "Pyramid. \n One of the wonders of the world, \n if such categorization benefits your understanding.";
			subtitleTime = 8f;
			break;
		case SUBTITLE_TYPE.L22_TOUSTETRASTHISPLACEISHOME:
			script = "To us Tetras, this place is home. \n Cubes have their Los Angles, while we have Pyramid.";
			subtitleTime = 7f;
			break;
		case SUBTITLE_TYPE.L22_ISATONTHESECONDRINGWAITINGFORBALL:
			script = "I sat on the second ring, waiting for Ball.";
			subtitleTime = 4f;
			break;
		case SUBTITLE_TYPE.L22_IWASGLADTOBEABLETOINTRODUCETHISWONDER:
			script = "I was glad to be able to introduce this wonder to Ball.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BALLWASVERYINQUISITIVE:
			script = "Ball was very inquisitive, and seemed eager to learn.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THISISARATHERANCIENTCITY:
			script = "This is a rather ancient city. It began construction 3143 years ago. \n It's also the oldest Pyra, which explains why it isn't in the air.";
			subtitleTime = 12f;
			break;
		case SUBTITLE_TYPE.L22_DEPENDINGONYOURINTERLOCUTOR:
			script = "Depending on your interlocutor, you may hear that our lower city is even older.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L22_BUTITHINKYOULLFINDTHATTHEEVIDENCE:
			script = "But, I think you'll find that the evidence doesn't support that theory.";
			subtitleTime = 5f;
			break;
		case SUBTITLE_TYPE.L22_THOUGHIDARENOTRULE:
			script = "Though I... dare not rule it out.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L22_THEEASTERNSIDEOFPYRAMIDSERVEDASTHEGATHERING:
			script = "The eastern side of Pyramid served as the gathering and living spaces for Tetras. \n Here was a place for socializing and learning.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BALLHADSOMEDIFFICULTYTRAVERSINGTHESPACE:
			script = "Ball had some difficulty traversing the space. \n These weren't the simple roads of Los Angles.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_FLOATINGPLATFORMSHADBEENNECESSARY:
			script = "Floating platforms had been necessary as the building material for all Pyramid, lemonstone, was in high demand. ";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THEANCIENTTETRASNEARLYEXHAUSTEDTHEIRSUPPLY:
			script = "The ancient Tetras nearly exhausted their supply building Pyramid.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_SOWITHTHEIRREMAININGSUPPLY:
			script = "So, with their remaining supply, they built smaller platforms to transport passengers longer distances, thereby needing fewer blocks of lemonstone to complete the passageways.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_TODAYLEMONSTONECANBESYNTHESIZZEDWITHEASE:
			script = "Today, lemonstone can be synthesized with ease. \n Due to that innovation, Pyraupper could be built.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_SOMEOFTHEPLATFORMSWEREINDIRENEEDOFREPAIR:
			script = "Some of the platforms were in dire need of repair, \n of course, and were of no use to anyone.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BUTASMOSTTETRASKNEWHOWTOFLOAT:
			script = "But as most Tetras knew how to float, it wasn't a huge problem.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THATANDFEWTETRASWANTTOBOTHERWITHREPAIRS:
			script = "That, and few Tetras want to bother with repairs. \n No sense wasting time with that when you could be learning.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THEWESTERNSIDEOFPYRAMIDONCESERVEDASSOMETHING:
			script = "The western side of Pyramid once served as something of an energy-production factory. The constant motion of the platforms generated a large amount of power, able to light the place during the dark period.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THISPATHAROUNDTHEBACKWASACTUALLYCONSTRUCTED:
			script = "This path around the back was actually constructed as a collaborative effort with cubes a few centuries ago, when Los Angles was still but a small village. ";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BACKINTHOSEDAYSCUBESCAMETOVISITOFTEN:
			script = "Back in those days, cubes came to visit often. Nowadays, not so much. They seem more content building their city higher and higher rather than coming here to learn.";
			subtitleTime = 10f;
			break;
		case SUBTITLE_TYPE.L22_GIVENALLTHEPROBLEMSWITHPYRAMID:
			script = "Given all the problems with Pyramid, and seeing Ball struggle, I attempted to teach her how to float.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_WEHADAGOODTIMETOGETHERBALLANDI:
			script = "We had a good time together, Ball and I. Would have befitted a montage.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_WITHHERNEWFOUNDKNOWLEDGEOFFLOATING:
			script = "With her newfound knowledge of floating, Ball could access the top of Pyramid without much trouble.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BALLWASGLADTOBEABLETOFLOAT:
			script = "Ball was glad to be able to float. Yet I was honestly shocked at how quickly Ball learned.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_FEWSPHERESCOULDPICKUPANABILITY:
			script = "Few spheres could pick up an ability so quickly.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_TRADITIONALKNOWLEDGESAYSTHATFLOATINGWAS:
			script = "Traditional knowledge says that floating was something unique to Tetras.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_MODERNKNOWLEDGENOTESTHATOTHERSHAPES:
			script = "Modern knowledge notes that other shapes can learn to float, but that their ability can't approach a Tetra's.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_SEEINGBALLHOWEVERMADEME:
			script = "Seeing Ball, however, made me return to my books. Perhaps there was more to this than we knew.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_IMETBALLAGAINATTHETOP:
			script = "I met Ball again at the top.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BALLMENTIONEDTHATSHEWASLOOKINGFORHERPARENTS:
			script = "Ball mentioned that she was looking for her parents. I, of course, had no knowledge in this subject.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_HOWEVERTHEREWASONEWHOMAYKNOWTHEANSWER:
			script = "However, there was one who may know the answer. ";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THEENTRUSTEDTHELEADEROFTHETETRAS:
			script = "The Entrusted. The leader of the Tetras.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BUTTHEENTRUSTEDRESIDEDINPYRAUPPER:
			script = "But the Entrusted resided in Pyraupper, and that could be a difficult journey for a non-Tetra.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BALLNEEDEDTOMAKEHERWAY:
			script = "Ball needed to make her way through the Rolling Plains, up the Prettyhigh Steppe, and then across the Suspended Bridge, where one fall could spell doom.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THISDIDNTSEEMTODISSUADEBALL:
			script = "This didn't seem to disuade Ball. The knowledge that someone out there could help seemed to brighten her mood, though I couldn't say for sure.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_ISAIDGOODBYETOBALLCONTENTWITHWHATIDLEARNED:
			script = "I said goodbye to Ball, content with what I'd learned.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BROKENPATHWAYSLAYSTREWNABOUT:
			script = "Broken pathways lay strewn about the ground. They've been there since I was but a child.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_YOUDONTTHINKMUCHABOUTYOURSURROUNDINGS:
			script = "You don't think much about your surroundings until strangers comment. ";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_TETRASOFTENCAMEHERETODANCE:
			script = "Tetras often came here to dance. Disco. Boogie. Waltz.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_IMPRETTYGOODATLINEDANCINGMYSELF:
			script = "I'm pretty good at line dancing myself. It's a style in which you jump up and down on a line.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_VERYFUN:
			script = "Very fun.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_DONTGETMESTARTEDONSQUAREDANCING:
			script = "Don't get me started on square dancing though.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_WHATALOADOFTRASH:
			script = "What a load of trash.";
			subtitleTime = 3f;
			break;
		case SUBTITLE_TYPE.L22_THESEREDOBJECTSWEREONCEACTIVE:
			script = "These red objects were once active. Sometimes all it takes is a small collision to get them going again.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THEREDJETSCOULDTOSSSOMEONESKYWARD:
			script = "The red jets could toss someone skyward. Once activated, of course.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_AHSOMEJETSWAITINGTOBEMADEACTIVE:
			script = "Ah, some jets. Waiting to be made active.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_TETRASHADNONEEDFORTHESEMACHINES:
			script = "Tetras had no need for these machines. But, perhaps Ball could find some use.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THEINVISIBLEPATHIMSURPRISEDBALLFOUNDIT:
			script = "The invisible path. I'm surprised Ball found it. Then again, that sphere was always full of secrets.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_BALLCOULDROLLAROUNDINTHEDESERTFORHOURS:
			script = "Ball could roll around in the desert for hours. I never understood what she enjoyed so much about it.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_THEAIRATTHETOPISMUCHSWEETER:
			script = "The air at the top is much sweeter than the air at the bottom. I wonder why that is.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_AMBERPARTICLESHYDROFORM:
			script = "Amber particles? Hydroform? Both change with elevation, but they shouldn't affect taste.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_ALASTHEREISSOMUCHMORETOUNDERSTAND:
			script = "Alas, there is so much more to understand in this world.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_OHDONTMINDTRITESHESALWAYSFOCUSEDONSTUDYING:
			script = "Oh, don't mind Trite. She's always focused on studying. Even moreso than her peers.";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_HERCOLLEAGUEAMIALWAYSSEEMSTOSTUMBLE:
			script = "Her collegue Ami always seems to stumble on new discoveries faster, but Trite enjoys the act \tof study more than Ami. ";
			subtitleTime = 6f;
			break;
		case SUBTITLE_TYPE.L22_ITSDIFFICULTTHENTOSAYWHOISMORE:
			script = "It's difficult then to say who is more successful.";
			subtitleTime = 6f;
			break;
		}
	}

}

public enum SUBTITLE_TYPE
{
	NONE,
	TEST_OPENING_SUB,
	TEST_FLOAT_POWER_UP,
	ISLAND_BALL_HAD_ENTERED_INTO_A_STRANGE,
	ISLAND_AN_ARCHIPELAGO_WITH_THREE_TOWERS,
	ISLAND_WHY_WAS_BALL_HERE_WHAT_WAS_THERE,
	ISLAND_PERHAPS_BALL_CAME_HERE_TO_PLAY,
	ISLAND_TOSS_A_SNOWBALL_AROUND,
	ISLAND_BALL_LOVED_EVERYTHING_RED,
	ISLAND_THIS_MIGHT_AS_WELL_BE_HEAVEN,
	ISLAND_BALL_LOVED_FINDING_NEW_THINGS,
	ISLAND_THE_ACT_OF_DISCOVERY,
	ISLAND_THESE_TOWERS_THIS_MAZE,
	ISLAND_BUT_IS_IT_REALLY_DISCOVERY,
	ISLAND_MAYBE_BALL_JUST_NEEDED_A_HIKE,
	ISLAND_BEAUTIFUL_ISNT_IT,
	ISLAND_AT_THE_TOP_WELL_IT_ALL_SEEMS_SO,
	ISLAND_BALL_FOUND_AN_ODD_SWITCH,
	ISLAND_DOORS_WERE_OPENING_WHY,
	ISLAND_WHERE_DID_THE_SWITCHES_GO,
	ISLAND_SNOWBALLS_LINED_UP_IN_THIS_PLACE,
	ISLAND_SPACETIME_WARPS_DID_THEY_BRING_BALL,
	ISLAND_THE_TRUTH_IS_BALL_WAS_A_LEARNER,
	ISLAND_COULD_IT_BE_THAT_SIMPLE,
	ISLAND_CANT_YOU_LEARN_ANYWHERE,
	ISLAND_WHY_HERE_DOES_IT_EVEN_MATTER,
	CANYON_WELL_GOING_TO_MOVE_OR_IS_BALL,
	CANYON_WHAT_IS_THERE_TO_BE_SCARED_OF,
	CANYON_WASDTHEAROOWKEYSTAKEYOURPICK,
	CANYON_OFFTOAGOODSTART,
	CANYON_BALLCOULDNTGOTHATWAY,
	CANYON_IMEANYOUCANTRYALLYOUWANT,
	CANYON_WHATDOWEHAVEHEREABALLWHOTHINKS,
	CANYON_BETTERNOTGETAHEADOFYOURSELFBALL,
	CANYON_THISSTATUELOOKSALITTLEBALD,
	CANYON_BUTSERIOUSLYWHATTHEHELLISTHIS,
	CANYON_ANDTHENBALLSTUMBLEDUPONTHEPILEOFINFINITEBOXES,
	CANYON_BALLFELTBADWHENITREALIZEDTHATTHEPILEOFBOXES,
	CANYON_LIKESOMEBODYSETTHATTHINGUP,
	CANYON_WHATKINDOFANASSHOLETEARSSOMETHINGDOWN,
	CANYON_INSIDEWASACUBEOHTHANKYOUFORSAVINGME,
	CANYON_WELLIDBESTBEGOINGTHECUBESAID,
	CANYON_YETBALLKNEWTHATIFITCAMEBACKHERETHECUBEWOULDSTILLBEHERE,
	CANYON_WASTHATREALLYOKAYTOFREETHATCUBE,
	CANYON_WHATIFBALLJUSTRELEASEDASERIALKILLER,
	CANYON_THEDAUNTINGTOWERSOFHEAVEN,
	CANYON_AHYESCLASSICJUDEOCHRISTIAN,
	CANYON_WHATISTHISAMAZEFORANTS,
	CANYON_ACTUALLYITSLIKETHEPERFECTSIZEFORASPHERE,
	CANYON_OHITSEEMSTHEYBUILTONEFORREAL,
	CANYON_INVISIBLEWALLSCLEVERCLEVER,
	CANYON_ACTUALLYNOTINVISIBLEATALLVISIBLEVISIBLEAIR,
	CANYON_SERIOUSLYWHOEVERBUILTTHATMAZEWASAWESOME,
	CANYON_INTERESTINGTHEREWASNOBACKSIDETOTHETOWERSOFHEAVEN,
	CANYON_WHOEVERSETUPTHELIGHTINGITHISTOWERDIDATERRIBLEJOB,
	CANYON_ANDWHATISWITHTHESEFLOATINGPLATFORMS,
	CANYON_ANELEVATORWOULDHAVEBEENNICE,
	CANYON_THELIGHTSHERESEEMEDMORESTABLEFORWHATEVERTHATWASWORTH,
	CANYON_BALLDIDNTLIKEBEINGPRESENTEDWITHOPTIONS,
	CANYON_WITHOPTIONSCAMEMISTAKES,
	CANYON_WITHMISTAKESCOMEWELLMISTAKESAREPRETTYBAD,
	CANYON_HMMWERETHESEPLATFORMSSPECIALBECAUSETHEYMOVED,
	CANYON_HONESTLYTHEREWASNOSENSETOTHISARCHITECTURE,
	CANYON_HEYREMEMBERWHENYOUWEREDOWNTHERE,
	CANYON_FINALLYBALLMADEITTOTHETOP,
	CANYON_ANDSOBALLSJOURNEYCONTINUED,
	OPENING_IDLIKETOSHINEASPOTLIGHT,
	OPENING_DOYOUKNOWWHOTHISIS,
	OPENING_THISISBALLSELFISHLOSERTRAITOR,
	OPENING_IWANTYOUTOKNOWTHATBALLHASBEEN,
	OPENING_ALWAYSDIFFERENTTHATONE,
	OPENING_ANDIMUSTSAYIWASQUITEHAPPY,
	L11_BALLLEFTOURCITYOFLOSANGLES,
	L11_WASNTCONTENTFORWHATEVERREASON,
	L12_SOMETIMESBALLLOOKEDBACKONTHECITY,
	L12_WHATWASTHEPROBLEMWHATWASNTTOLOVE,
	L12_MAYBETHATWASITRAISEDBYCUBESSURE,
	L12_BALLWOULDROLLAROUNDLIKEACHUMP,
	L12_DOYOUKNOWWHYTHEEASTERNROAD,
	L12_LOSANGLESISALLANYONENEEDS,
	L12_UNLESSYOURETHATONETHATAWFULLITTLECIRCLE,
	L12_DONTMINDTHATCUBEHESPROBABLYOUTFORASTROLL,
	L12_DONTBELIEVEMEASKHIM,
	L12_SEEWHOWASRIGHT,
	L12_IVEALWAYSBEENSURPRISED,
	L12_IMSUREBALLISGLADTHECUBESMADETHAT,
	L12_BALLCOULDNTSEETHEINIVISIBLEPLATFORM,
	L12_BALLCOULDCLIMBUPSOMEWALLS,
	L11_THEREWASONLYONEWAYFORBALLTOGO,
	L11_DOORSSTOODINTHEWAY,
	L11_BALLJUMPEDOVERATINYLEDGE,
	L11_AHTHETINYLEDGE,
	L11_SEEINGBALLSTRUGGLEIWASGLAD,
	L11_BALLWASALWAYSODDDIFFERENT,
	L11_NOBODYKNEWWHATTOMAKEOFHIM,
	L11_WEREALLBETTEROFF,
	L11_FORALLTHEGOODTHATDID,
	L12_GOONBALLGETOUTOFHERE,
	L12_LOSANGLESWASACITYFORCUBESANYWAY,
	L12_THISISANOJUMPINGZONE,
	L12_THOSESMALLBOXESSEE,
	L12_THEREALQUESTIONWASWHOLITTERED,
	L12_WELLBETTERHERETHANTHECITY,
	L12_BALLTHOUGHTFORASECONDDIDHEWANTTHIS,
	L12_ITDIDNTTAKEBALLLONGTOCOMETOADECISION,
	L12_THEDESTINATIONPYRAMID,
	L12_WHATSATRIANGLEYOUASK,
	L12_ADMITTEDLYTHEYHAVEAPRETTYIMPRESSIVESOCIETY,
	L12_INSTEADTHEYRESTONTHEIRLAURELS,
	L12_GOONSEEITFORYOURSELF,
	L12_FOLLOWBALLTOTHELANDOFTHELAZY,
	L12_AHTHEHIDDENSHAPEIMSURPRISEDBALLFOUNDIT,
	L12_DIDHEREALLYWANTTHISTOLEAVEOURGREATCITY,
	L12_WHY,
	L12_DOESHEEVENUNDERSTANDWHATHESLEAVINGBEHIND,
	L12_WELLIMGLADHELEFTTHEONLYTHINGHEEVERDIDWASMUCK,
	L12_WOWITHOUGHTTHATWASHIDDENPRETTYWELL,
	L12_miss1, //accidentally double input
	L11_CUBESBUILTTHISPARADISE,
	L12_IMPRESSIVETOFINDTHISHIDDENOBJECT,
	L21_THEROADENDEDANDWITHITTHEEND,
	L21_ITWASTHECUBESTHATHADMADELIFEDIFFICULT,
	L21_HOWBALLMANAGEDTOBREAKFREEILLNEVERKNOW,
	L21_BUTIMGLADITHAPPENED,
	L21_OHMEMYNAMEISSIMONEPLEX,
	L21_IMATEACHERINPYRAMID,
	L21_BALLMADEHERWAYTHROUGHTHEDESERT,
	L21_SANDANDWINDFORMEDWALLSAROUNDBALL,
	L21_WHYDIDISAYHERANDSHEINSTEADOFHIMANDHE,
	L21_WELLACTUALLYITDOESNTREALLYMATTERWHATWORDSYOUUSE,
	L21_USEWHATEVERWORDYOUWANT,
	L21_BALLBEGANTOWONDERIFITWASWORTHITTOLEAVETHECITY,
	L21_TRUETHEDESERTWASWONDERFULAFIRST,
	L21_BALLHAPPENEDUPONWHATLOOKEDLIKETHEROAD,
	L21_ISAIDFOLLOWEDITBALLDIDNTHAVETHETIME,
	L21_THEFREEDOMMADEBALLFASTER,
	L12_THOSEDIRTYCIRCLESWHOLEFTBALLONOURDOORSTOP,
	L12_GOONBALLBURDENTHEMAGAIN,
	L12_THISISNTYOURHOMEITNEVERWAS,
	L12_WHEREWASBALLGOINGYOUASK,
	L12_HAVEYOUHEARDOFPYRAMID,
	L12_LANDOFTHETRIANGLES,
	L12_ALLTALKNOACTION,
	L12_WHYBALLSOUGHTTHEMOUTILLNEVERKNOW,
	L12_BUTTHEREHEWENTGONENEVERTORETURN,
	L22_PYRAMIDONEOFTHEWONDERS,
	L22_TOUSTETRASTHISPLACEISHOME,
	L22_ISATONTHESECONDRINGWAITINGFORBALL,
	L22_IWASGLADTOBEABLETOINTRODUCETHISWONDER,
	L22_BALLWASVERYINQUISITIVE,
	L22_THISISARATHERANCIENTCITY,
	L22_DEPENDINGONYOURINTERLOCUTOR,
	L22_BUTITHINKYOULLFINDTHATTHEEVIDENCE,
	L22_THOUGHIDARENOTRULE,
	L22_THEEASTERNSIDEOFPYRAMIDSERVEDASTHEGATHERING,
	L22_BALLHADSOMEDIFFICULTYTRAVERSINGTHESPACE,
	L22_FLOATINGPLATFORMSHADBEENNECESSARY,
	L22_THEANCIENTTETRASNEARLYEXHAUSTEDTHEIRSUPPLY,
	L22_SOWITHTHEIRREMAININGSUPPLY,
	L22_TODAYLEMONSTONECANBESYNTHESIZZEDWITHEASE,
	L22_SOMEOFTHEPLATFORMSWEREINDIRENEEDOFREPAIR,
	L22_BUTASMOSTTETRASKNEWHOWTOFLOAT,
	L22_THATANDFEWTETRASWANTTOBOTHERWITHREPAIRS,
	L22_THEWESTERNSIDEOFPYRAMIDONCESERVEDASSOMETHING,
	L22_THISPATHAROUNDTHEBACKWASACTUALLYCONSTRUCTED,
	L22_BACKINTHOSEDAYSCUBESCAMETOVISITOFTEN,
	L22_GIVENALLTHEPROBLEMSWITHPYRAMID,
	L22_WEHADAGOODTIMETOGETHERBALLANDI,
	L22_WITHHERNEWFOUNDKNOWLEDGEOFFLOATING,
	L22_BALLWASGLADTOBEABLETOFLOAT,
	L22_FEWSPHERESCOULDPICKUPANABILITY,
	L22_TRADITIONALKNOWLEDGESAYSTHATFLOATINGWAS,
	L22_MODERNKNOWLEDGENOTESTHATOTHERSHAPES,
	L22_SEEINGBALLHOWEVERMADEME,
	L22_IMETBALLAGAINATTHETOP,
	L22_BALLMENTIONEDTHATSHEWASLOOKINGFORHERPARENTS,
	L22_HOWEVERTHEREWASONEWHOMAYKNOWTHEANSWER,
	L22_THEENTRUSTEDTHELEADEROFTHETETRAS,
	L22_BUTTHEENTRUSTEDRESIDEDINPYRAUPPER,
	L22_BALLNEEDEDTOMAKEHERWAY,
	L22_THISDIDNTSEEMTODISSUADEBALL,
	L22_ISAIDGOODBYETOBALLCONTENTWITHWHATIDLEARNED,
	L22_BROKENPATHWAYSLAYSTREWNABOUT,
	L22_YOUDONTTHINKMUCHABOUTYOURSURROUNDINGS,
	L22_TETRASOFTENCAMEHERETODANCE,
	L22_IMPRETTYGOODATLINEDANCINGMYSELF,
	L22_VERYFUN,
	L22_DONTGETMESTARTEDONSQUAREDANCING,
	L22_WHATALOADOFTRASH,
	L22_THESEREDOBJECTSWEREONCEACTIVE,
	L22_THEREDJETSCOULDTOSSSOMEONESKYWARD,
	L22_AHSOMEJETSWAITINGTOBEMADEACTIVE,
	L22_TETRASHADNONEEDFORTHESEMACHINES,
	L22_THEINVISIBLEPATHIMSURPRISEDBALLFOUNDIT,
	L22_BALLCOULDROLLAROUNDINTHEDESERTFORHOURS,
	L22_THEAIRATTHETOPISMUCHSWEETER,
	L22_AMBERPARTICLESHYDROFORM,
	L22_ALASTHEREISSOMUCHMORETOUNDERSTAND,
	L22_OHDONTMINDTRITESHESALWAYSFOCUSEDONSTUDYING,
	L22_HERCOLLEAGUEAMIALWAYSSEEMSTOSTUMBLE,
	L22_ITSDIFFICULTTHENTOSAYWHOISMORE,
	L12_THANKTESSAHESGONE,
	L22_BUTWHYWHYDOICARESOMUCH,
	L22_3, //placeholders
	L22_4, //placeholders
	L22_5, //placeholders
	L22_6, //placeholders
	L22_7, //placeholders
	L22_8, //placeholders
	L22_9, //placeholders
}