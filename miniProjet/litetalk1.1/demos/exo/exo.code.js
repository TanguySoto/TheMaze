var exoTopic = [
	// INFO
	[["KEY", "_class"],						["VAL", "bot"], ["BOT","exoBot"]],
	[["KEY", "_reference"],					["VAL", ["f","fifi","dog"]]],
	[["KEY", "_htmlprefix"],				["VAL", "fifi"]], //prefix of HTML elements  
	[["KEY", "_read"],						["VAL", ["userTopic","daisiTopic","counterTopic"]]],
	[["KEY", "_write"],						["VAL", ["userTopic","counterTopic"]]],
	[["KEY", "_exec"],						["VAL", ["userTopic","counterTopic"]]], // try
	[["KEY", "type"],						["VAL", ["animal","dog"]]],
	[["KEY", "name"],						["VAL", "Fifi"],   				
											["WHY","My master gave it to me. Actually, I am very happy about it"]
	],
	[["KEY", "age"],						["VAL", 3], ["TYPE","INT"],
											["ONASK", "I am three year old"], 
											["WHY","I was born three years ago"]
											],
	[["KEY", "toto"], 						["ONASK", function() {alert("coucou");}]],
	[["KEY", "titi"], 						["ONASK", function() {elem = document.getElementById('test'); elem.innerHTML = "<img src='http://placehold.it/350x150'/>";}]],
	[["KEY", "gender"],						["VAL", "male"],
											["ONASK", function(s) { return ((s == "male") ? "I am proud to be a male!" : "Just a female") }]
											],
	[["KEY", ["job"]],			          	["VAL", "I am a pet"]],
	[["KEY", ["home","location"]],		    ["VAL", "I live in Orsay"]],
	[["KEY", "usage"],						["VAL", "_UN_, I can control the counter for you"]],
	[["KEY", "date"],						["VAL", function(){return new Date()}],
											["WHY","Because I asked JavaScript to calculate it for me"]
											],
	// REL
	[["KEY", "relative"],		["VAL", ["pal"]], // acquaintances with BEINGS(bots): mother,father,son,daughter,brother,sister,pal,boss,pet,...
								["ONASK", BOT_printRelativeList],
								], 
	[["KEY", "pal"],			["VAL", "daisieTopic"],["CAT","REL"]],
	[["KEY", "tool"],			["VAL", "counterTopic"],["CAT","REL"]],
	// FEELINGS
	[["KEY", "happiness"],		["VAL", 0.8], ["CAT","VAR"], ["TYPE","INT"]], // 7 standard feelings iniitated
	[["KEY", "confidence"],		["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "irritability"],	["VAL", 0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "satisfaction"],	["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "respect"],		["VAL", -0.8], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "force"],			["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "excitement"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	// PREFS
	[["KEY", "preference"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	[["KEY", "distaste"],		["VAL", []],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]], 
	[["KEY", "suggestion"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printSuggestionList]], 
	[["KEY", "intention"],		["VAL", []], ["CAT","VAR"], ["ONASK",BOT_printIntentionList]],  
	// FUNC
	[["KEY", "action"],			["VAL", ["compute"]]],
	[["KEY", "compute"],		["VAL", "func_compute"], ["CAT","ACT"],
								["HOW","You must type a valid javascript expression"],
								["EFFECT","compute the expression"]
								],
								
	[["KEY","wow"], ["VAL", "warrior"]]
];



var daisieTopic = [
	// INFO
	[["KEY", "_class"],						["VAL", "bot"], ["BOT","daisieBot"]],
	[["KEY", "_reference"],					["VAL", ["d","daisie","flower"]]],
	[["KEY", "_htmlprefix"],				["VAL", "daisie"]], //prefix of HTML elements  
	[["KEY", "_read"],						["VAL", ["daisieTopic","userTopic"]]],
	[["KEY", "_write"],						["VAL", []]],
	[["KEY", "_exec"],						["VAL", ["userTopic","counterTopic"]]],
	[["KEY", "type"],						["VAL", ["vegetal","flower"]]],
	[["KEY", "name"],						["VAL", "Daisie"],
											["WHY","My gardener gave it to me"]
											],
	[["KEY", "age"],						["VAL", 1],["TYPE","INT"],
											["ONASK","I am one year old"], ["WHY","I was born one years ago"]
											],
	[["KEY", "gender"],						["VAL", "female"],
											["ONASK", function(s) { return ((s == "male") ? "I am proud to be a male!" : "Just a female") }]
											],
	[["KEY", ["job"]],			          	["VAL", "I am a basic component of a bouquet"]],
	[["KEY", ["home","location"]],		    ["VAL", "I live in Paris"]],
	[["KEY", "usage"],						["VAL", "_UN_, I can do mothing"]],
	[["KEY", "date"],						["VAL", "To ask for a date with me type: suggest meeting"],
											["WHY","Because asking is about information not action"]
											],
	// REL
	[["KEY", "relative"],					["VAL", ["pal"]],
											["ONASK", BOT_printRelativeList],
											], 
	[["KEY", "pal"],					["VAL", "fifiTopic"],["CAT","REL"]],
	// FEELINGS
	[["KEY", "happiness"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]], // 7 standard feelings
	[["KEY", "confidence"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "irritability"],	["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "satisfaction"],	["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "respect"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "force"],			["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	[["KEY", "excitement"],		["VAL", 0], ["CAT","VAR"], ["TYPE","INT"]],
	// FUNC
	[["KEY", "action"],						["VAL", ["meeting"]]],
	[["KEY", "meeting"],					["VAL", ""], ["CAT","ACT"],
											["EFFECT","fix a meeting with me"]
											]
];

// =========  Initialization of bots and declaration of topics  ==========
var exoBot    = new BOT_makeBot("exoBot","exoTopic");
var daisieBot  = new BOT_makeBot("daisieBot","daisieTopic");
BOT_declareTopics(["exoTopic","daisieTopic"]);

BOT_theBotId		= "daisieBot";		// sets current bot id


function BOT_onSwitchBot(oldbotid,newbotid) {
	BOT_standardFrameBot(oldbotid, "hidden", "0px");
	BOT_standardFrameBot(newbotid, "visible","4px solid yellow");
}

