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
(function operation() {
    window.onload = function () {
        var minitodo = document.querySelector('.minitodo');
        var btnadd = document.querySelector('#btnadd');
        // CLICK ADD EVENT //
        btnadd.onclick = function addList() {
            if (document.querySelector('#title').value == '') alert('You must write something to add');
            else {

                var list = createBaseElement('li', 'list', minitodo)
                for (var a = 0; a < list.length; a++) {
                    list[a].setAttribute("id", "idlist")
                }
                var span = createBaseElement('span', "material-symbols-outlined", list)
                var span_text = document.createTextNode('backspace')
                span.appendChild(span_text)
                var text = document.createTextNode(document.querySelector('#title').value)
                list.appendChild(text)
                var span_symbol_new = document.getElementsByClassName("material-symbols-outlined")
                var i;
                for (i = 0; i < span_symbol_new.length; i++) {
                    // CLICK DELETE LIST EVENT AFTER ADD // 
                    span_symbol_new[i].onclick = function () {
                        var div = this.parentElement;
                        div.remove();
                    }
                }
                var input = document.querySelector('#title')
                input.value = ""
                // CHECKED LIST //
                var list_new = document.getElementsByClassName('list')
                for (j = 0; j < list_new.length; j++) {
                    list_new[j].setAttribute("onclick", "this.id='new_id_list'")
                }
            }
        }
        // DELETE FIRST LIST //
        var fisrt_list = document.querySelector(".material-symbols-outlined")
        fisrt_list.onclick = function () {
            fisrt_list.parentElement.style.display = "none"
        }
    }
})();







