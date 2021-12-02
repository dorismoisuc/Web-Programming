var emptyCell="9";

function loadPuzzle(){
    let pics = new Array(10);
    let found;
    for (i = 1; i < 10; i++) {
        found = true;
        while (found === true) {
            x = 1 + Math.floor(Math.random() * 1000) % 9;
            found = false;
            for (j = 1; j < i; j++)
                if (pics[j] === x) found = true;
        }
        pics[i] = x;
        if (x === 9) emptyCell = i;
    }
    var cell;
    for(i=1;i<10;i++)
    {
        cell=document.getElementById(i);
        if (cell){
            img=document.createElement("img");
            if(i!==emptyCell)
                img.setAttribute("src","lara"+pics[i]+".jpg");
            else
                img.setAttribute("src","empty.png");
            cell.appendChild(img);
        }
    }
}

function moveCell(cellId,cell){
    console.log("this=",this," cell=",cell);
    if(cellId===emptyCell)return;
    let rest = cellId % 3;
    let topPos = (cellId > 3) ? cellId - 3 : -1;
    let bottomPos = (cellId < 7) ? cellId + 3 : -1;
    let leftPos = (rest !== 1) ? cellId - 1 : -1;
    let rightPos = (rest > 0) ? cellId + 1 : -1;
    if(emptyCell!==topPos && emptyCell!==bottomPos && emptyCell!==leftPos && emptyCell !==rightPos)
        return;

    let cell1 = document.getElementById(emptyCell);
    let img1 = cell1.firstChild;
    let img = cell.firstChild;
    cell.removeChild(cell.firstChild);
    cell1.removeChild(cell1.firstChild);
    cell.appendChild(img1);
    cell1.appendChild(img);
    emptyCell=cellId;

    if (isDone()){
        document.getElementById("done").innerText="Puzzle done!";
    }

}

function isDone(){
    let result="";
    let images = document.getElementsByTagName("img");
    for (let image of images)
    {
        result+=image.getAttribute("src")[4]+"";
        /*console.log("Image" + result);*/
    }
    return result==="12345678y";
}

