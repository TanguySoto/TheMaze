// ========= TOPICS ==========
var marcTopic = [
	// CODE INFO
	[["KEY", "_class"],							["VAL", "bot"], ["BOT","marcBot"]],
	[["KEY", "_reference"],					["VAL", ["m","marc","husband","father"]]],
	[["KEY", "_htmlprefix"],				["VAL", "marc"]],
	[["KEY", "_read"],							["VAL", ["houseTopic","userTopic","aurelieTopic","jeremyTopic"]]],
	
	// BASICS INFOS
	[["KEY", "type"],								["VAL", ["human","adult"]]],
	
	[["KEY", "name"],								["VAL", "Marc"],   				
																	["WHY","My parents gave it to me. Actually, I am very happy about it."]],
																	
	[["KEY", "age"],								["VAL", 35], ["TYPE","INT"],
																	["ONASK", "35 year old."], 
																	["WHY","I was born thirty-five years ago. Are you dumb ?"]],
																	
	[["KEY", "gender"],							["VAL", "male"],
																	["ONASK", function(s) { return ((s == "male") ? "I am proud to be a male!" : "Just a female.") }]],
																	
	[["KEY", ["job"]],			        ["VAL", "Banker"], ["WHY","I work in a bank..."]],
	[["KEY", ["home","location"]],	["VAL", "Normal Heights, San Diego."]],
	
	// RELATIONS
	[["KEY", "relative"],						["VAL", ["wife","son"]],
																	["ONASK", BOT_printRelativeList]],
																	 
	[["KEY", "wife"],								["VAL", "aurelieTopic"],["CAT","REL"]],
	[["KEY", "son"],								["VAL", "jeremyTopic"],["CAT","REL"]],

	// FUNC
	[["KEY", "action"],				["VAL", ["sentiment","look"]],
														["ONASK",BOT_printActionList]],

	[["KEY", "sentiment"], 		["VAL", "sentimentMarc"], ["CAT", "ACT"],
														["EFFECT","I will give you my sentiment about the house"]],

	[["KEY", "look"], 				["VAL", "lookMarc"], ["CAT", "ACT"],
														["EFFECT","I will look at the elements in the room you talked about."]],
	
	// PREFS
	[["KEY", "preference"],		["VAL", [["houseTopic","exterior"],["houseTopic","kitchen"],["houseTopic","first bedroom"]]], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],			["VAL", [["houseTopic","livingroom"]]],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]],
];

var aurelieTopic = [
	// CODE INFO
	[["KEY", "_class"],							["VAL", "bot"], ["BOT","aurelieBot"]],
	[["KEY", "_reference"],					["VAL", ["a","aurelie","wife","mother"]]],
	[["KEY", "_htmlprefix"],				["VAL", "aurelie"]], //prefix of HTML elements  
	[["KEY", "_read"],							["VAL", ["houseTopic","userTopic","marcTopic","jeremyTopic"]]],
	
	// BASICS INFOS
	[["KEY", "type"],								["VAL", ["human","adult"]]],
	
	[["KEY", "name"],								["VAL", "Aurélie"],   				
																	["WHY","My parents gave it to me. Actually, I am very happy about it."]],
																	
	[["KEY", "age"],								["VAL", 37], ["TYPE","INT"],
																	["ONASK", "37 year old."], 
																	["WHY","I was born thirty-seven years ago."]],
																	
	[["KEY", "gender"],							["VAL", "female"],
																	["ONASK", function(s) { return ((s == "male") ? "I am proud to be a male!" : "Just a female.") }]],
																	
	[["KEY", ["job"]],			        ["VAL", "Barber."]],
	[["KEY", ["home","location"]],	["VAL", "We live in Normal Heights, San Diego"]],
	
	// RELATIONS
	[["KEY", "relative"],						["VAL", ["husband","son"]],
																	["ONASK", BOT_printRelativeList]],
																	 
	[["KEY", "husband"],						["VAL", "marcTopic"],["CAT","REL"]],
	[["KEY", "son"],								["VAL", "jeremyTopic"],["CAT","REL"]],

	// FUNC
	[["KEY", "action"],				["VAL", ["sentiment","look"]],
														["ONASK",BOT_printActionList]],

	[["KEY", "sentiment"], 		["VAL", "sentimentAurelie"], ["CAT", "ACT"],
														["EFFECT","I will give you my sentiment about the house"]],

	[["KEY", "look"], 				["VAL", "lookAurelie"], ["CAT", "ACT"],
														["EFFECT","I will look at the elements in the room you talked about."]],
	
	// PREFS
	[["KEY", "preference"],		["VAL", [["houseTopic","first bedroom"],["houseTopic","livingroom"]]], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],			["VAL", [["houseTopic","kitchen"],["houseTopic","exterior"]]],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]],
];


var jeremyTopic = [
	// CODE INFO
	[["KEY", "_class"],							["VAL", "bot"], ["BOT","jeremyBot"]],
	[["KEY", "_reference"],					["VAL", ["j","jeremy","son","boy"]]],
	[["KEY", "_htmlprefix"],				["VAL", "jeremy"]], //prefix of HTML elements  
	[["KEY", "_read"],							["VAL", ["houseTopic","userTopic","marcTopic","aurelieTopic"]]],
	
	// BASICS INFOS
	[["KEY", "type"],								["VAL", ["human","child"]]],
	
	[["KEY", "name"],								["VAL", "Jérémy"],			
																	["WHY","It's the best name ever"]],
																	
	[["KEY", "age"],								["VAL", 6], ["TYPE","INT"],
																	["ONASK", "I am 6 year old."], 
																	["WHY","I don't know."]],
																	
	[["KEY", "gender"],							["VAL", "male"],
																	["ONASK", function(s) { return ((s == "male") ? "I am boy!" : "A girl.") }]],
																	
	[["KEY", ["job"]],			        ["VAL", "What ?"]],
	[["KEY", ["home","location"]],	["VAL", "USA"]],
	
	// RELATIONS
	[["KEY", "relative"],						["VAL", ["father","mother"]],
																	["ONASK", BOT_printRelativeList]],
																	 
	[["KEY", "father"],						["VAL", "marcTopic"],["CAT","REL"]],
	[["KEY", "mother"],						["VAL", "aurelieTopic"],["CAT","REL"]],

	// FUNC
	[["KEY", "action"],				["VAL", ["play","show_joy_dad","show_joy_mom"]],
														["ONASK",BOT_printActionList]],

	[["KEY", "play"], 											["VAL", "play"], ["CAT", "ACT"],
																					["EFFECT","I will play here and be joyful if I liked it."]],
	[["KEY", ["showdad","show_joy_dad"]], 	["VAL", "showDad"], ["CAT", "ACT"],
																					["EFFECT","I will tell my dad if I am joyful or not."]],
	[["KEY", ["showmom","show_joy_mom"]], 	["VAL", "showMom"], ["CAT", "ACT"],
																					["EFFECT","I will tell my mom if I am joyful or not."]],														
	
	// FEELINGS
	[["KEY", ["joy","joyful"]],		["VAL",  0], ["CAT","VAR"], ["TYPE","INT"]], // de -10 à 10
	
	// PREFS
	[["KEY", "preference"],		["VAL", [["houseTopic","second bedroom"],["houseTopic","exterior"]]], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],			["VAL", [["houseTopic","kitchen"],["houseTopic","bathroom"]]],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]],
];

var houseTopic = [
	// INFO 
	[["KEY", "_class"],				["VAL", "house"]],
	[["KEY", "_reference"],		["VAL", ["house","domicile"]]],
	[["KEY", "type"],					["VAL", ["place"]]],

	// VAR 
	[["KEY", "name"],			["VAL", "House"], ["CAT","VAR"],
												["WHY", "It is just a house"]],

	[["KEY", "room"],		["VAL", ["bathroom","exterior","first bedroom","kitchen","livingroom","second bedroom"]], ["CAT","VAR"]],
];

var userTopic = [
	// INFO 
	[["KEY", "_class"],				["VAL", "user"]],
	[["KEY", "_reference"],		["VAL", ["me","my","user"]]],
	[["KEY", "type"],					["VAL", ["person"]]],
	// VAR 
	[["KEY", "name"],			["VAL", "Vendor"], ["CAT","VAR"],
												["WHY", "I can't tell my real name."]]
];


// =========  Initialization of bots and declaration of topics  ==========
var marcBot    	= new BOT_makeBot("marcBot","marcTopic");
var aurelieBot  = new BOT_makeBot("aurelieBot","aurelieTopic");
var jeremyBot   = new BOT_makeBot("jeremyBot","jeremyTopic");

BOT_declareTopics(["userTopic","houseTopic"]);

BOT_theBotId				= "marcBot";		// sets current bot id
BOT_theTopicId			= "marcTopic";	// sets current topic id
BOT_theUserTopicId	= "userTopic";	// sets topic of current user id

function BOT_onSwitchBot(oldbotid,newbotid) {
	BOT_standardFrameBot(oldbotid, "visible", "4px solid #899DA3");
	BOT_standardFrameBot(newbotid, "visible","4px solid #FFB030");
}

// ACTIONS
function sentimentMarc(){
	return "I am convinced at "+marcWidth+" %";
}

function lookMarc(){
	return "TODO";
}

function sentimentAurelie(){
	return "I am convinced at "+aurelieWidth+" %";
}

function lookAurelie(){
	return "TODO";
}

function play(){

}

function showDad(){
	
}

function showMom(){
	
}