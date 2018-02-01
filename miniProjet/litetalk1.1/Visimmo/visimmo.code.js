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
														["EFFECT","I will look at the elements in the room."]],
	
	// PREFS
	//[["KEY", "preference"],		["VAL", [["houseTopic","exterior"],["houseTopic","kitchen"],["houseTopic","first bedroom"]]], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],  
	//[["KEY", "distaste"],			["VAL", [["houseTopic","livingroom"]]],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]],
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
														["EFFECT","I will look at the elements in the room."]],
	
	// PREFS
	//[["KEY", "preference"],		["VAL", [["houseTopic","first bedroom"],["houseTopic","livingroom"]]], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],
	//[["KEY", "distaste"],			["VAL", [["houseTopic","kitchen"],["houseTopic","exterior"]]],  ["CAT","VAR"],["ONASK",BOT_printDistasteList]],
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
	[["KEY", "action"],				["VAL", ["play","showjoy"]],
									["ONASK",BOT_printActionList]],

	[["KEY", "play"], 				["VAL", "play"], ["CAT", "ACT"],
									["EFFECT","I will play here and be joyful if I liked it."]],
	[["KEY", "showjoy"], 	["VAL", "showJoy"], ["CAT", "ACT"],
							["EFFECT","I will tell you if I am joyful or not."]],														
	
	// FEELINGS
	[["KEY", ["joy","joyful"]],		["VAL",  0], ["CAT","VAR"], ["TYPE","INT"]], // de -10 à 10
	
	// PREFS
	[["KEY", "preference"],		["VAL", [["houseTopic","bedroom2"],["houseTopic","exterior"]]], ["CAT","VAR"], ["ONASK",BOT_printPreferenceList]],
];

var houseTopic = [
	// INFO 
	[["KEY", "_class"],				["VAL", "house"]],
	[["KEY", "_reference"],		["VAL", ["house","domicile"]]],
	[["KEY", "type"],					["VAL", ["place"]]],

	// VAR 
	[["KEY", "name"],			["VAL", "House"], ["CAT","VAR"],
												["WHY", "It is just a house"]],

	[["KEY", "room"],			["VAL", ["bathroom","exterior","first bedroom","kitchen","livingroom","second bedroom"]],["CAT","VAR"],["ONASK",function(){return onAskRoom()}]],
	 
	[["KEY", "kitchen"], ["VAL", ["stove", "dishwasher", "fridge"]], ["CAT","VAR"], ["ONASK",function(){return onAskInRoom("kitchen")}]],
	[["KEY", "livingroom"], ["VAL", ["freespace", "light", "table", "sofas","screen"]], ["CAT","VAR"], ["ONASK",function(){return onAskInRoom("livingroom")}]],
	[["KEY", "exterior"], ["VAL", ["garden", "parking", "tree", "playground"]], ["CAT","VAR"], ["ONASK",function(){return onAskInRoom("exterior")}]],
	[["KEY", "bathroom"], ["VAL", ["bathtub", "shower", "toilet"]], ["CAT","VAR"], ["ONASK",function(){return onAskInRoom("bathroom")}]],
	[["KEY", "bedroom1"], ["VAL", ["wall", "bed", "storage"]], ["CAT","VAR"], ["ONASK",function(){return onAskInRoom("bedroom1")}]],
	[["KEY", "bedroom2"], ["VAL", ["painting", "desk", "bookshelf", "space"]], ["CAT","VAR"], ["ONASK",function(){return onAskInRoom("bedroom2")}]],

	[["KEY", "stove"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "dishwasher"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "fridge"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "freespace"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "light"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "table"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "sofas"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "screen"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "garden"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "parking"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "tree"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "playground"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "bathtub"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "shower"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "toilet"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "wall"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "bed"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "storage"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "painting"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "desk"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "bookshelf"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],
	[["KEY", "space"], ["VAL", "You didn't tell us how it looks like."], ["CAT","VAR"]],

	[["KEY", "price"], ["VAL", "You didn't tell us how much this house costs."], ["CAT","VAR"]],
	[["KEY", "surface"], ["VAL", "Good question, you tell us !"], ["CAT","VAR"]],
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

// FUNCTIONS

function BOT_onSwitchBot(oldbotid,newbotid) {
	BOT_standardFrameBot(oldbotid, "visible", "4px solid #899DA3");
	BOT_standardFrameBot(newbotid, "visible","4px solid #FFB030");
	document.getElementById("litetalkchatbox").focus();
}

function inspect(topic, val){
	if(BOT_theBotId=="marcBot"){
		return inspectMarc(topic,val);
	}
	else if(BOT_theBotId=="aurelieBot"){
		return inspectAurelie(topic,val);
	}
	else {
		return "I don't care about specific object ! I just want to play in cool rooms.";
	}
}

function inspectMarc(topic, val){
	if(val == undefined){
        return "What object are you talking about ?";
    }
    else{
        var roomName = roomNumberToName[currentRoom];
        if (roomName in marcLikes){  // the room is one of marc's favorite
            if (val in marcLikes[roomName]){    // val is an object of the room
                var opinionUser = BOT_get("houseTopic",val,"VAL");
                if (opinionUser == "You didn't tell us how it looks like."){ // user has not set it
                    return opinionUser;
                }
                else{ // can compare
                    var opinionMarc = marcLikes[roomName][val];
                    if (opinionUser == opinionMarc){
                    	if(!objects[val]["used"]){
                        	move("marcBar", 5);
                        	objects[val]["used"]=true;
                    	}
                        return "I like it!";
                    }
                    else{
                    	if(!objects[val]["used"]){
                        	move("marcBar", -5);
                        	return objects[val][opinionMarc]; // return something a tip about what to say
                        }
                        else {
                        	return "It is ok, you told me the "+val+" is "+opinionMarc;
                        }                        
                    }
                }
            }
            else{
                return "I am not sure what you mean. I only want to talk about "+Object.keys(marcLikes[roomName]);
            }
        }
        else{
            return "I don't really like this room. Ask my wife.";
        }
    }
}

function inspectAurelie(topic, val){
    if(val == undefined){
        return "What object are you talking about ?";
    }
    else{
        var roomName = roomNumberToName[currentRoom];

        if (roomName in aurelieLikes){  // the room is one of aurelie's favorite
            if (val in aurelieLikes[roomName]){    // val is an object of the room
                var opinionUser = BOT_get("houseTopic",val,"VAL");
                if (opinionUser == "You didn't tell us how it looks like."){ // user has not set it
                    return opinionUser;
                }
                else{ // can compare
                    var opinionAurelie = aurelieLikes[roomName][val];
                    if (opinionUser == opinionAurelie){
                    	if(!objects[val]["used"]){
                        	move("aurelieBar", 5);
                        	objects[val]["used"]=true;
                    	}
                        return "I like it!";
                    }
                    else{
                    	if(!objects[val]["used"]){
                        	move("aurelieBar", -5);
                        	return objects[val][opinionAurelie]; // return something a tip about what to say
                        }
                        else {
                        	return "It is ok, you told me the "+val+" is "+opinionAurelie;
                        }                        
                    }
                }
            }
            else{
                return "I am not sure what you mean. I only want to talk about "+Object.keys(aurelieLikes[roomName]);
            }
        }
        else{
            return "I don't really like this room. Ask my husband.";
        }
    }
}

// INTELLIGENT ON ASK
function onAskRoom(){
	var mess = "We've seen the ";

	for(var i=0;i<=currentRoom;i++){
		mess=mess + (roomNumberToName[i]+", ");
	}
	return mess;
}

function onAskInRoom(roomName){
	var roomNumber = roomNameToNumber[roomName];
	var mess = "";

	if(roomNumber<currentRoom){
		mess = "I remember seing ";
		objects = BOT_get('houseTopic',roomName,'VAL');
		for(var i in objects){
			mess+= (objects[i]+", ");
		}
	}
	else if(roomNumber == currentRoom){
		mess = "I can see ";
		objects = BOT_get('houseTopic',roomName,'VAL');
		for(var i in objects){
			mess+= (objects[i]+", ");
		}
	}
	else {
		mess = "We have not been there yet, did we ?";
	}

	return mess;
}

// ACTIONS
function sentimentMarc(){
	return "I am convinced at "+marcWidth+" %";
}

function lookMarc(){
    var roomName = roomNumberToName[currentRoom];
    // If Marc likes the room
    if (roomName in marcLikes){
        if(marcRoomLooked[currentRoom] == false){ // to check if already looked
            marcRoomLooked[currentRoom] = true;
            move("marcBar", 5);
        }
        return "I would like to talk about "+Object.keys(marcLikes[roomName]); // lists the things to talk about
    }
    // If Marc doesn't like the room
    else{
        if(marcRoomLooked[currentRoom] == false){
            marcRoomLooked[currentRoom] = true;
            move("marcBar", -5);    // only called once at the moment, but can get out of this if
        }
        return "I don't really like this room.";
    }
}

function sentimentAurelie(){
	return "I am convinced at "+aurelieWidth+" %";
}

function lookAurelie(){
    var roomName = roomNumberToName[currentRoom];
    // If Aurelie likes the room
    if (roomName in aurelieLikes){
        if(aurelieRoomLooked[currentRoom] == false){
            aurelieRoomLooked[currentRoom] = true;
            move("aurelieBar", 5);
        }
        return "I would like to talk about "+Object.keys(aurelieLikes[roomName]); // lists the things to talk about
    }
    // If Aurelie doesn't like the room
    else{
        if(aurelieRoomLooked[currentRoom] == false){
            aurelieRoomLooked[currentRoom] = true;
            move("aurelieBar", -5);     // only called once at the moment, but can get out of this if
        }
        return "I don't really like this room.";
    }
}

function play(){
	var roomName = roomNumberToName[currentRoom];
	var joy = BOT_get("jeremyTopic","joy","VAL");

    // If Jeremy likes the room
    if (jeremyLikes[roomName]['like']){
    	if(!jeremyLikes[roomName]['used']){
	    	joy+=5;
	    	joy = Math.min(10,joy);
	    	joy = Math.max(-10,joy),
	    	BOT_set("jeremyTopic","joy","VAL",joy);
	    	jeremyLikes[roomName]['used']=true;
	    	return "It was cool playing here ! "+showJoy();
    	}
    	else {
    		return "I already played here. It was so cool !";
    	}
    }
    else {
    	if(!jeremyLikes[roomName]['used']){
	    	joy-=5;
	    	joy = Math.min(10,joy);
	    	joy = Math.max(-10,joy),
	    	BOT_set("jeremyTopic","joy","VAL",joy);
	    	jeremyLikes[roomName]['used']=true;
	    	return "It hated playing here ! "+showJoy();
	    }
	    else {
    		return "I already played here. It was horrible !";
    	}

    }
}

function showJoy(){
	var joy = BOT_get("jeremyTopic","joy","VAL");

	if(joy==0){
		return "I am neither joyful nor unhappy.";
	}
	else if(joy>0){
		if(joy<10){
			return "I am joyful but I could be more.";
		}
		else {
			return "I couldn't be more joyful.";
		}
	}
	else {
		if(joy>-10){
			return "I am not joyful, but I could be worse.";
		}
		else {
			return "I couldn't be less joyful.";
		}
	}
}