// ========= GAME parameters =========
var timeInRooms = 90;  // s
var currentTime;       // s
var timerInterval;

var roomsCount        = 6;
var currentRoom;

var roomNumberToFile  = new Array(roomsCount);
roomNumberToFile[0]   = 'picts/exterior.jpg';
roomNumberToFile[1]   = 'picts/livingroom.jpg';
roomNumberToFile[2]   = 'picts/kitchen.jpg';
roomNumberToFile[3]   = 'picts/bedroom1.jpg';
roomNumberToFile[4]   = 'picts/bedroom2.jpg';
roomNumberToFile[5]   = 'picts/bathroom.jpg';

var roomNumberToName  = new Array(roomsCount);
roomNumberToName[0]   = 'exterior';
roomNumberToName[1]   = 'livingroom';
roomNumberToName[2]   = 'kitchen';
roomNumberToName[3]   = 'bedroom1';
roomNumberToName[4]   = 'bedroom2';
roomNumberToName[5]   = 'bathroom';

var roomNameToNumber  = {};
roomNameToNumber['exterior']        = 0;
roomNameToNumber['livingroom']      = 1;
roomNameToNumber['kitchen']         = 2;
roomNameToNumber['bedroom1']        = 3;
roomNameToNumber['bedroom2']        = 4;
roomNameToNumber['bathroom']        = 5;


var aurelieLikes = {}
aurelieLikes["bedroom1"] = {"wall": "wallpaper", "bed" : "kingsized", "storage" : "beautiful"}
aurelieLikes["livingroom"] = {"space": "open", "table" : "wooden", "sofas" : "leather", "screen" : "led"}
aurelieLikes["bathroom"] = {"bathtub": "secured", "shower" : "glazed", "toilet" : "blue"}

var marcLikes = {}
marcLikes["kitchen"] = {"stove": "induction", "dishwasher" : "new", "fridge" : "big"}
marcLikes["exterior"] = {"garden": "grass", "parking" : "inside", "playground" : "clean"}

var objects = {}
objects["stove"] = {"induction": "I don't know... an induction stove would be nice.", "unused": "I don't know... an unused stove would be nice."}
objects["dishwasher"] = {"new": "I don't know... a new dishwasher would be nice.", "ecological": "I don't know... an ecological dishwasher would be nice."}
objects["fridge"] = {"big": "I don't know... a big fridge would be nice.", "white": "I don't know... a white fridge would be nice."}

objects["space"] = {"open": "I don't know... an open space would be nice.", "partitionned": "I don't know... a partitionned space would be nice."}
objects["table"] = {"large": "I don't know... a large table would be nice.", "wooden": "I don't know... a wooden table would be nice."}
objects["sofas"] = {"three": "I don't know... three sofas would be nice.", "leather": "I don't know... leather sofas would be nice."}
objects["screen"] = {"big": "I don't know... a big screen would be nice.", "led": "I don't know... a led screen would be nice."}

objects["garden"] = {"grass": "I don't know... grass on the floor would be nice.", "big": "I don't know... a big garden would be nice."}
objects["parking"] = {"two": "I don't know... two parking would be nice.", "inside": "I don't know... a parking inside would be nice."}
objects["playground"] = {"flowered": "I don't know... a flowered playground would be nice.", "clean": "I don't know... a clean playground would be nice."}

objects["bathtub"] = {"secured": "I don't know... a secured bathtub would be nice.", "big": "I don't know... a big bathtub would be nice."}
objects["shower"] = {"italian": "I don't know... an italian shower would be nice.", "glazed": "I don't know... a glazed shower would be nice."}
objects["toilet"] = {"japanese": "I don't know... japanese toilet would be nice.", "blue": "I don't know... blue toilet would be nice."}

objects["wall"] = {"wallpaper": "I don't know... wallpaper on walls would be nice.", "painted": "I don't know... painted walls would be nice."}
objects["bed"] = {"kingsized": "I don't know... a king-sized bed would be nice.", "waterbed": "I don't know... a water-bed would be nice."}
objects["storage"] = {"convenient": "I don't know... convenient storages would be nice.", "beautiful": "I don't know... beautiful storages would be nice."}

var jeremyLikes = {}
jeremyLikes["exterior"]     = {"like":true, "used":false}
jeremyLikes["bedroom2"]     = {"like":true, "used":false}
jeremyLikes["bedroom1"]     = {"like":false, "used":false}
jeremyLikes["kitchen"]      = {"like":false, "used":false}
jeremyLikes["livingroom"]   = {"like":false, "used":false}
jeremyLikes["bathroom"]     = {"like":false, "used":false}

var marcRoomLooked  = new Array(roomsCount);
marcRoomLooked.fill(false);
var aurelieRoomLooked  = new Array(roomsCount);
aurelieRoomLooked.fill(false);


var marcWidth;
var marcBarInterval;
var aurelieWidth;
var aurelieBarInterval;



// ========= FUNCTIONS =========

function updateTimer(){
  if(currentTime==-1){
    nextRoom();
  }
  else {
    document.getElementById("message_div").innerHTML = "Remaining time here: "+currentTime+" s";
    currentTime--;
  }
}

function nextRoom(){
  currentRoom++;

  // Show next room & start timer
  if(currentRoom<roomsCount){
    document.getElementById("room").src=roomNumberToFile[currentRoom];
    document.getElementById("room_name").innerHTML = "<strong>Current step: "+roomNumberToName[currentRoom]+"</strong></br>";

    if(timerInterval!=null){
      window.clearInterval(timerInterval);
    }
    currentTime = timeInRooms;
    updateTimer();
    timerInterval = setInterval(updateTimer,1000);
  } 
  // End of game
  else {
    endGame();
  } 
}

function getRoom(){
  if(currentRoom==-1 || currentRoom>=roomsCount){
    return "None";
  }
  return roomNumberToName[currentRoom];
}

function move(progressBar, diff) {
    // Get moving direction
    var sens = 1;
    if(diff<0){
      sens = -1;
    }

    // Get actual width and update it
    var width;
    if(progressBar=="aurelieBar"){
      if(aurelieBarInterval!=null){
        clearInterval(aurelieBarInterval);
      }
      width = aurelieWidth;
      aurelieWidth+=diff;
      aurelieWidth = Math.min(100,aurelieWidth);
      aurelieWidth = Math.max(0,aurelieWidth);
    }
    else {
      if(marcBarInterval!=null){
        clearInterval(marcBarInterval);
      }
      width = marcWidth;
      marcWidth+=diff;
      marcWidth = Math.min(100,marcWidth);
      marcWidth = Math.max(0,marcWidth);
    }

    // if we were already at extremum -> no need to animate
    if((width<=0 && sens==-1) || (width>=100 && sens==1)){
      return;
    }

    // Update animation
    var id;
    if(progressBar=="aurelieBar"){
      aurelieBarInterval = setInterval(frame, 20);
      id = aurelieBarInterval;
    }
    else {
      marcBarInterval = setInterval(frame, 20);
      id = marcBarInterval;
    }

    var elem = document.getElementById(progressBar);
    function frame() {
        if (width > 100 || width <0 || diff==0) {
            clearInterval(id);
        }
        else {
            width+=sens;
            diff+=sens*-1;
            elem.style.width = width + '%';
        }

        if(progressBar=="aurelieBar"){
          document.getElementById("goal2").checked=(width==100);
        }
        else {
          document.getElementById("goal1").checked=(width==100);
        }
    }
}

function startGame(){
  // Make checkboxs unclickable
  document.getElementById("goal1").disabled = true;
  document.getElementById("goal2").disabled = true;
  document.getElementById("goal1").checked = false;
  document.getElementById("goal2").checked = false;

  // start input
  document.getElementById("litetalkchatbox").disabled = false;

  // Set first room
  currentRoom = -1;
  nextRoom();

  // Set progress bars
  marcWidth    = 50;
  aurelieWidth = 50;
  document.getElementById("aurelieBar").style.width = aurelieWidth+"%";
  document.getElementById("marcBar").style.width = marcWidth+"%";
}

function endGame(){
  // Stop timers
  window.clearInterval(timerInterval);

  // Block input
  document.getElementById("litetalkchatbox").disabled = true;

  // Add Jeremy impact
  var joy = BOT_get("jeremyTopic","joy","VAL");
  move("aurelieBar", joy);
  move("marcBar", joy);
  BOT_reqSay(true,"","SHOWJEREMYJOY",BOT_theReqAttribute,BOT_theReqTopic,BOT_theReqValue);
  BOT_theBotId = "jeremyBot";
  BOT_printStandardChar();

  setTimeout(function(){
    // Won or Lost ?
    var won = document.getElementById("goal1").checked == true;
    won = won && document.getElementById("goal2").checked == true;

    // Message
    var text;
    if(won){
      text = "You won! Play Again ?";
    }
    else {
      text = "You lost! Retry ?";
    }

    // Show dialog
    if (confirm(text)) {
      startGame();
    } else {
      // Nothing
    }
  },3000);
}
