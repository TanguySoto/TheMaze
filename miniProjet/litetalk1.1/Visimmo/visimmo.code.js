var marcTopic = [
	// CODE INFO
	[["KEY", "_class"],							["VAL", "bot"], ["BOT","marcBot"]],
	[["KEY", "_reference"],					["VAL", ["m","marc","husband","father"]]],
	[["KEY", "_htmlprefix"],				["VAL", "marc"]],
	[["KEY", "_read"],							["VAL", ["userTopic","aurelieTopic","jeremyTopic"]]],
	[["KEY", "_write"],							["VAL", ["userTopic"]]],
	[["KEY", "_exec"],							["VAL", ["userTopic"]]], // try
	
	// BASICS INFOS
	[["KEY", "type"],								["VAL", ["human","adult"]]],
	
	[["KEY", "name"],								["VAL", "Marc"],   				
																	["WHY","my parents gave it to me. Actually, I am very happy about it."]],
																	
	[["KEY", "age"],								["VAL", 35], ["TYPE","INT"],
																	["ONASK", "I am thirty-five year old."], 
																	["WHY","I was born thirty-five years ago. Are you dumb ?"]],
																	
	[["KEY", "gender"],							["VAL", "male"],
																	["ONASK", function(s) { return ((s == "male") ? "I am proud to be a male!" : "Just a female.") }]],
																	
	[["KEY", ["job"]],			        ["VAL", "I am a banker."]],
	[["KEY", ["home","location"]],	["VAL", "We live in Normal Heights, San Diego."]],
	
	// RELATIONS
	[["KEY", "relative"],						["VAL", ["wife","son"]],
																	["ONASK", BOT_printRelativeList]],
																	 
	[["KEY", "wife"],								["VAL", "aurelieTopic"],["CAT","REL"]],
	[["KEY", "son"],								["VAL", "jeremyTopic"],["CAT","REL"]],
	
	// FEELINGS
	[["KEY", "happiness"],		["VAL",  0.8], ["CAT","VAR"], ["TYPE","INT"]], // 7 standard feelings initiated
	[["KEY", "confidence"],		["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "irritability"],	["VAL",  0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "satisfaction"],	["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "respect"],			["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "force"],				["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "excitement"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	
	// PREFS
	[["KEY", "preference"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],			["VAL", []],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]], 
	[["KEY", "suggestion"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printSuggestionList]], 
	[["KEY", "intention"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printIntentionList]],  
];

var aurelieTopic = [
	// CODE INFO
	[["KEY", "_class"],							["VAL", "bot"], ["BOT","aurelieBot"]],
	[["KEY", "_reference"],					["VAL", ["a","aurelie","wife","mother"]]],
	[["KEY", "_htmlprefix"],				["VAL", "aurelie"]], //prefix of HTML elements  
	[["KEY", "_read"],							["VAL", ["userTopic","marcTopic","jeremyTopic"]]],
	[["KEY", "_write"],							["VAL", ["userTopic"]]],
	[["KEY", "_exec"],							["VAL", ["userTopic"]]], // try
	
	// BASICS INFOS
	[["KEY", "type"],								["VAL", ["human","adult"]]],
	
	[["KEY", "name"],								["VAL", "Aurélie"],   				
																	["WHY","my parents gave it to me. Actually, I am very happy about it."]],
																	
	[["KEY", "age"],								["VAL", 37], ["TYPE","INT"],
																	["ONASK", "I am thirty-seven year old."], 
																	["WHY","I was born thirty-seven years ago."]],
																	
	[["KEY", "gender"],							["VAL", "female"],
																	["ONASK", function(s) { return ((s == "male") ? "I am proud to be a male!" : "Just a female.") }]],
																	
	[["KEY", ["job"]],			        ["VAL", "I am a barber."]],
	[["KEY", ["home","location"]],	["VAL", "We live in Normal Heights, San Diego"]],
	
	// RELATIONS
	[["KEY", "relative"],						["VAL", ["husband","son"]],
																	["ONASK", BOT_printRelativeList]],
																	 
	[["KEY", "husband"],						["VAL", "marcTopic"],["CAT","REL"]],
	[["KEY", "son"],								["VAL", "jeremyTopic"],["CAT","REL"]],
	
	// FEELINGS
	[["KEY", "happiness"],		["VAL",  0.8], ["CAT","VAR"], ["TYPE","INT"]], // 7 standard feelings initiated
	[["KEY", "confidence"],		["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "irritability"],	["VAL",  0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "satisfaction"],	["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "respect"],			["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "force"],				["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "excitement"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	
	// PREFS
	[["KEY", "preference"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],			["VAL", []],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]], 
	[["KEY", "suggestion"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printSuggestionList]], 
	[["KEY", "intention"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printIntentionList]],  
];


var jeremyTopic = [
	// CODE INFO
	[["KEY", "_class"],							["VAL", "bot"], ["BOT","jeremyBot"]],
	[["KEY", "_reference"],					["VAL", ["j","jeremy","son","boy"]]],
	[["KEY", "_htmlprefix"],				["VAL", "jeremy"]], //prefix of HTML elements  
	[["KEY", "_read"],							["VAL", ["userTopic","marcTopic","aurelieTopic"]]],
	[["KEY", "_write"],							["VAL", ["userTopic"]]],
	[["KEY", "_exec"],							["VAL", ["userTopic"]]], // try
	
	// BASICS INFOS
	[["KEY", "type"],								["VAL", ["human","child"]]],
	
	[["KEY", "name"],								["VAL", "Jérémy"],   
																	["ONASK", "My name is Jérémy. Best name ever."], 				
																	["WHY","my parents gave it to me. Actually, I am very happy about it."]],
																	
	[["KEY", "age"],								["VAL", 6], ["TYPE","INT"],
																	["ONASK", "I am six year old."], 
																	["WHY","I don't know."]],
																	
	[["KEY", "gender"],							["VAL", "male"],
																	["ONASK", function(s) { return ((s == "male") ? "I am boy!" : "A girl.") }]],
																	
	[["KEY", ["job"]],			        ["VAL", "What ?"]],
	[["KEY", ["home","location"]],	["VAL", "My house is in San Diego"]],
	
	// RELATIONS
	[["KEY", "relative"],						["VAL", ["father","mother"]],
																	["ONASK", BOT_printRelativeList]],
																	 
	[["KEY", "father"],						["VAL", "marcTopic"],["CAT","REL"]],
	[["KEY", "mother"],						["VAL", "aurelieTopic"],["CAT","REL"]],
	
	// FEELINGS
	[["KEY", "happiness"],		["VAL",  0.8], ["CAT","VAR"], ["TYPE","INT"]], // 7 standard feelings initiated
	[["KEY", "confidence"],		["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "irritability"],	["VAL",  0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "satisfaction"],	["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "respect"],			["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "force"],				["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "excitement"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	
	// PREFS
	[["KEY", "preference"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],			["VAL", []],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]], 
	[["KEY", "suggestion"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printSuggestionList]], 
	[["KEY", "intention"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printIntentionList]],  
];


// =========  Initialization of bots and declaration of topics  ==========
var marcBot    	= new BOT_makeBot("marcBot","marcTopic");
var aurelieBot  = new BOT_makeBot("aurelieBot","aurelieTopic");
var jeremyBot   = new BOT_makeBot("jeremyBot","jeremyTopic");

BOT_declareTopics(["marcTopic","aurelieTopic","jeremyTopic"]);

BOT_theBotId		= "marcBot";		// sets current bot id


function BOT_onSwitchBot(oldbotid,newbotid) {
	BOT_standardFrameBot(oldbotid, "visible", "4px solid grey");
	BOT_standardFrameBot(newbotid, "visible","4px solid yellow");
}

