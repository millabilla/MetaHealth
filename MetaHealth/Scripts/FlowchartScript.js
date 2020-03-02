﻿var flowchartMap = {
    "start": {
        "text": "Where would you like to begin?",
        "outcomes": {
            "Mind": "Mind",
            "Body": "Body",
            "Soul": "Soul"
        }
    },

    "Mind": {
        "text": "Of these three activities which sounds the best for you?",
        "outcomes": {
            "Maybe I could write?": "Write",
            "I would like to make something": "Creative",
            "I'm feeling overwhelmed and need a break": "None"
        }
    },
    "Body": {
        "text": "What is your immediate need?",
        "outcomes": {
            "I'm thirsty/hungry": "Feed",
            "I've been feeling stagnant": "Exercise",
            "I feel gross": "Bathe"
        }
    },
    "Soul": {
        "text": "How are you feeling",
        "outcomes": {
            "I'm feeling a bit overwhelmed": "None",
            "I'm feeling disconnected and alone": "Connect",
            "I'm feeling anxious/depressed": "Uplift"
        }
    },

    "Write": {
        "text": "Write 5 things you like about yourself."
    },

    "Creative": {
        "text": "Draw a picture of something you loved to eat as a child."
    },

    "None": {
        "text": "Do you want to sit in silence or play some music?",
        "outcomes": {
            "Sit in silence": "Silence",
            "play some music": "Music"
        }
    },

    "Silence": {
        "text": "Meditate for 5 minutes on a problem you've solved in the past."
    },

    "Music": {
        "text": "Go <a href='https://www.youtube.com/watch?v=3FzJHsri8Zw'>here</a> and close your eyes and think happy thoughts"
    },

    "Connect": {
        "text": "Call a loved one."
    },

    "Uplift": {
        "text": "Watch a funny movie/tv show"
    },

    "Feed": {
        "text": "Eat/drink something"
    },
    "Bathe": {
        "text": "A nice hot bath sounds nice to me"
    },

    "Exercise": {
        "text": "Hit the gym."
    }

}
function generateColor(array)
{
    return (array[Math.floor(Math.random() * array.length)]);
}
function startScript() {
    var situation = "start";
    runFlowchart(situation);
}
function runFlowchart(arg) {
    var div = document.getElementById("startFlowchart");//entry point for function
    if (div.style.display != "none") //checks if start button is clicked, if not then hide it
    {
        div.style.display = "none";
    }
    //initializing necessary variables
    var colorArr = [];
    var map = flowchartMap[arg];
    var choices = map.outcomes;
    var prompt = ('<div class="textFlowchart">' + map.text + '</div>');
    $("#chartText").html(prompt);
    $("#buttons").empty();
    for (var choice in choices)
    {
        if (choices.hasOwnProperty(choice))
        {
            var $button = $('<input type="button" button class="btn btn-default" value="' + choice + '"/>');
            //              orange   dark orange  yellow    blue     dark blue    green
            var colors = ['#EE8535', '#ED5441', '#F0C032', '#49C7CA', '#248D83', '#6C984B']
            var randomColor = generateColor(colors);
            while (colorArr.includes(randomColor))
            {
                randomColor = generateColor(colors);
            }
            colorArr.push(randomColor);
            $button.css("background-color", randomColor);
            $button.css("border", "1px solid " + randomColor);
            $button.click({ "nextsit": choices[choice] }, function (evt) {
                situation = evt.data.nextsit;
                colorArr.length = 0;//empty out array after buttons are added
                runFlowchart(situation);
            });
            $("#buttons").append($button);
        }
    }
}