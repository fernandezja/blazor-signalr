window.dotNetObjRef = null;


let mousePositionTrackerCurrentUser = document.getElementById("mousePositionTrackerCurrentUser");
let mousePositionTrackerCurrentUserPosition = document.getElementById("mousePositionTrackerCurrentUserPosition");

window.setDotNetObjRef = function (dotNetObjRef) {
    window.dotNetObjRef = dotNetObjRef;
    console.log(dotNetObjRef);
}


//Detect touch device
function isTouchDevice() {
    try {
        document.createEvent("TouchEvent");
        return true;
    } catch (e) {
        return false;
    }
}

const move = (e) => {
    
    try {
        var x = !isTouchDevice() ? e.pageX : e.touches[0].pageX;
        var y = !isTouchDevice() ? e.pageY : e.touches[0].pageY;
    } catch (e) { }

    
    var mousePosition =
    {
        x: (x + 15),
        y: (y - 15)
    }

    mousePositionTrackerCurrentUser.style.left = mousePosition.x + "px";
    mousePositionTrackerCurrentUser.style.top = mousePosition.y + "px";

    mousePositionTrackerCurrentUserPosition.innerText = 'x:' + mousePosition.x + ' y:' + mousePosition.y;

    window.dotNetObjRef.invokeMethodAsync('SendUserMousePosition', mousePosition);
};


//Mouse
document.addEventListener("mousemove", (e) => {
    move(e);
});

//Touch
document.addEventListener("touchmove", (e) => {
    move(e);
});

