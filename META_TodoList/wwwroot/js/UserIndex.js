// JavaScrip for PetProject 
function createBaseElement(tagName, className, parrent,) {
    var theTag = document.createElement(tagName);
    if (className)
        theTag.className = className;
    if (!parrent)
        document.body.appendChild(theTag);
    else
        parrent.appendChild(theTag);
    return theTag;
}
function sliceString(div) {
    var s = '<span class=\"material-symbols-outlined\">backspace</span>'
    var a = div.innerHTML.toString(div).split(s)
    var b = a[1]
    var c = b.toString(b)
    var d = c.trim(c)
    return d
}


var minitodo = document.querySelector('.minitodo');
var btnadd = document.querySelector('#ubtnadd');
// CLICK ADD EVENT //
btnadd.onclick = function addList() {
    if (document.querySelector('#title').value == '') alert('You must write something to add');
    else {
        var list = createBaseElement('li', 'list', minitodo)
        list.setAttribute("id", "id_list")
        var span = createBaseElement('span', "material-symbols-outlined", list)
        var span_text = document.createTextNode('backspace')
        span.appendChild(span_text)
        var text = document.createTextNode(document.querySelector('#title').value)
        var title = text.data
        list.appendChild(text)
        for (var a = 0; a < list.length; a++) {
            list[a].setAttribute("id", "idlist")
        }
        fetch(API_URLS.SaveTitle, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(title)
        })
        // CHECKED LIST //
        var list_new = document.getElementsByClassName('list')
        for (j = 0; j < list_new.length; j++) {
            list_new[j].onclick = function () {
                this.id = 'new_id_list'
                var li = this
                var checktitle = sliceString(li)
                fetch(API_URLS.CheckTitle, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(checktitle)
                })
            }
        }
        var span_symbol_new = document.getElementsByClassName("material-symbols-outlined")
        for (var i = 0; i < span_symbol_new.length; i++) {
            // CLICK DELETE LIST EVENT AFTER ADD // 
            span_symbol_new[i].onclick = function () {

                var div = this.parentElement
                var deletetitle = sliceString(div)
                div.style.display='block'
                div.remove()
                fetch(API_URLS.DeleteTitle, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(deletetitle)
                })
            }
        }
        var input = document.querySelector('#title')
        input.value = ""
    }
}

// CHECKED LIST //
var list_new = document.getElementsByClassName('list')
for (j = 0; j < list_new.length; j++) {
    list_new[j].onclick = function () {
        this.id = 'new_id_list'
        var li = this
        var checktitle = sliceString(li)
        fetch(API_URLS.CheckTitle, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(checktitle)
        })
    }
}

// CLICK DELETE LIST EVENT AFTER ADD // 
var span_symbol_new = document.getElementsByClassName("material-symbols-outlined")
for (var i = 0; i < span_symbol_new.length; i++) {
    span_symbol_new[i].onclick = function () {
        var div = this.parentElement;
        var deletetitle = sliceString(div)
        div.remove()
        fetch(API_URLS.DeleteTitle, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(deletetitle)
        })
    }
}

// DELETE and CHECKED FIRST ELEMENT //
var fisrt_list = document.querySelector(".material-symbols-outlined")
fisrt_list.onclick = function () {
    fisrt_list.parentElement.style.display = "none"
    fisrt_list.parentElement.setAttribute("onclick", "this.id='new_id_list'")
}







