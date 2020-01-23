// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var input = document.createElement('input');
var contentMap = "";

var arrLang = {
    'en': {
        'random': 'total random',
        'ABC': 'ABC Method',
        'Oreforwool': 'Oreforwool Method',
        'Download': 'Download',
        'BigMap': 'Large Map'
    },
    'nl': {
        'random': 'totaal random',
        'ABC': 'ABC Methode',
        'Oreforwool': 'Oreforwool Methode',
        'Download': 'Download',
        'BigMap' : 'Grote Map'
    }
};

// Process translation
var lang = sessionStorage.getItem('lang');

$(function () {
    if (sessionStorage.getItem('lang') == null || undefined) {
        sessionStorage.setItem('lang', 'nl');
    }
    Changelanguage();
});

function Changelanguage() {
    lang = sessionStorage.getItem('lang');
    $('.lang').each(function (index, item) {
        $(this).text(arrLang[lang][$(this).attr('key')]);
    })
}

function SetNLlanguage() {
    if (sessionStorage.getItem('lang') != 'nl') {
        sessionStorage.setItem('lang', 'nl');
    }
    Changelanguage();
}

function SetENlanguage() {
    if (sessionStorage.getItem('lang') != 'en') {
        sessionStorage.setItem('lang', 'en');
    }
    Changelanguage();
}

var saveData = (function () {
    var a = document.createElement("a");
    document.body.appendChild(a);
    a.style = "display: none";
    return function (base64string) {
        var today = new Date();
        var time = 'CatanMap'+'_'+ today.toLocaleString();
        url = window.URL.createObjectURL(b64toBlob(base64string));
        a.href = url;
        a.download = time;
        a.click();
        window.URL.revokeObjectURL(url);
    };
}());

function b64toBlob(dataURI) {

    var byteString = atob(dataURI.split(',')[1]);
    var ab = new ArrayBuffer(byteString.length);
    var ia = new Uint8Array(ab);

    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }
    return new Blob([ab], { type: 'image/png' });
}

function exportData(data) {
    var today = new Date();
    var time = 'ExportCatan'+'_'+today.toLocaleString()+'.json';
   
    var a = document.createElement("a");
    var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(data));
    a.href = dataStr;
    a.download = time;
    a.click();
}

//function enableButton() {
//    if (document.getElementById("importFile").files.length > 0) {
//        var nigger = document.getElementById("Import").disabled = false;
//    }
//}
//if (document.getElementById("importFile").files.length == 0) {
//    console.log("no files selected");
//}

//function omegakek() {
//    input.type = 'file';
//    input.onchange = e => {

//        // getting a hold of the file reference
//        var file = e.target.files[0];

//        // setting up the reader
//        var reader = new FileReader();
//        reader.readAsText(file, 'UTF-8');

//        // here we tell the reader what to do when it's done reading...
//        reader.onload = readerEvent => {
//            var content = readerEvent.target.result; // this is the content!
//            console.log(content);
//        }
//    }

//    input.click();
//    contentMap = content

//}
//function getFagget()
//{
//    return contentMap;
//}

