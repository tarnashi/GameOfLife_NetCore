function DrawField(field) {
    var st = "";
    for (var j = 0; j < field.height; j++) {
        for (var i = 0; i < field.width; i++) {
            st += "<div id='x" + i + "y" + j + "' onclick='ChangeCell(" + i + ", " + j + ")'";
            if (field.currentField[i][j] === true) {
                st += " class='alive" +
                    +String(Math.floor(Math.random() * 3 + 1)) +
                    "'>";
            } else {
                st += " class='dead'>";
            }
            st += "</div>";
        }
        st += "<br>";
    }
    document.getElementById("Field").innerHTML = st;
}

function GetCurrentField() {
    $.ajax
        ({
            dataType: "json",
            url: "/api/game/GetCurrentField",
            type: "GET",
            cashe: false,
            success: function (response) {
                if (response.data) {
                    DrawField(response.data);
                }
            }
        });
}

function ClearField() {
    $.ajax
        ({
            dataType: "json",
            url: "/api/game/ClearField",
            type: "GET",
            cashe: false,
            success: function (response) {
                DrawField(response.data);
            }
        });
}

function ChangeCell(x, y) {
    $.ajax
        ({
            dataType: "json",
            url: "/api/game/ChangeCell",
            type: "POST",
            data: "x=" + x + "&y=" + y,
            cashe: false,
            success: function (response) {
                if (response.success === false) {
                    alert("Произошла ошибка :(");
                }
                else {
                    var elem = document.getElementById("x" + x + "y" + y);
                    if (elem.getAttribute("class") === "dead") {
                        elem.setAttribute("class", "alive" + String(Math.floor(Math.random() * 3 + 1)));
                    } else {
                        elem.setAttribute("class", "dead");
                    }
                }
            }
        });
}

function MakeMove(x, y) {
    $.ajax
        ({
            dataType: "json",
            url: "/api/game/MakeMove",
            type: "GET",
            cashe: false,
            success: function (response) {
                DrawField(response.data);
            }
        });
}

function GetPlaner() {
    $.ajax
        ({
            dataType: "json",
            url: "/api/game/GetPlaner",
            type: "GET",
            cashe: false,
            success: function (response) {
                if (response.success === false) {
                    alert(response.message);
                }
                else {
                    DrawField(response.data);
                }
            }
        });
}