function check() {
    var valueCheck = document.querySelector('.id_name_ID').value
    fetch(API_URLS.Check, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(valueCheck)
    })
    //var checkparent = document.querySelector('.inner')
    //var check = createBaseElement('partial', 'check', checkparent)
    //check.innerHTML = "@Model._mess"
}

//function createBaseElement(tagName, className, parrent,) {
//    var theTag = document.createElement(tagName);
//    if (className)
//        theTag.className = className;
//    if (!parrent)
//        document.body.appendChild(theTag);
//    else
//        parrent.appendChild(theTag);
//    return theTag;
//}