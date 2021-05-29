
var msg = {};
var msgValidate = {}

 async function load() {
    let currentLng = 'en';
    if (getCookie('language') != '')
        currentLng = getCookie('language');

    let attributeName = 'label-tag';

    let currentPage = "home";
    if (getCookie('page') != '')
        currentPage = getCookie('page');

    let translate = new Translate(attributeName, currentLng, currentPage, "layout");
    await translate.process();
    msg = translate.msgLabels;
    $('#langClires').val(currentLng);
   // postLanguageVal(currentLng);
}

function changeLanguage(lang) {
    createCookie('language', lang, 1);
    //postLanguageVal(lang)
    load();
}


//function postLanguageVal(langCurrent) {
//    var dataLang = {
//        itemSession: langCurrent
//    };

//    fetch('/home/SetLanguageSession', {
//        method: "POST",
//        body: JSON.stringify(dataLang),
//        headers: {
//            "Content-type": "application/json; charset=UTF-8"
//        }
//    })
//        .then(response => response.json())
//        .then(json => console.log(json))
//        .catch(err => console.log('ERR log:' + err));
//}

async function getLabels() {
    let currentLng = 'en';
    if (getCookie('language') != '')
        currentLng = getCookie('language');

    let attributeName = 'label-tag';

    let currentPage = "home";
    if (getCookie('page') != '')
        currentPage = getCookie('page');

    let translate = new Translate(attributeName, currentLng, currentPage, "layout");
    
    msgValidate = await translate.getLabel();
}

getLabels();