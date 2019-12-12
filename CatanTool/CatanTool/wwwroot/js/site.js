// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var arrLang = {
    'en': {
        'random': 'total random',
        'ABC': 'ABC Method',
        'Oreforwool': 'Oreforwool Method',
        'Download' : 'Download'
    },
    'nl': {
        'random': 'totaal random',
        'ABC': 'ABC Methode',
        'Oreforwool': 'Oreforwool Methode',
        'Dwonload' : 'Download'
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
    if (sessionStorage.getItem('lang') === 'en') {
        sessionStorage.setItem('lang', 'nl');
    }
    Changelanguage();
}

function SetENlanguage() {
    if (sessionStorage.getItem('lang') === 'nl') {
        sessionStorage.setItem('lang', 'en');
    }
    Changelanguage();
}

var saveData = (function () {
    var a = document.createElement("a");
    document.body.appendChild(a);
    a.style = "display: none";
    return function (fileName, base64string) {
        url = window.URL.createObjectURL(b64toBlob(base64string));
        a.href = url;
        a.download = fileName;
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
    //const json = JSON.stringify(data, null, 2)
    //fs = require("fs");

    //Fs.writeFile("ooF.txt", json, (err) => {
    //    if (err) {
    //        console.error(err)
    //        throw err
    //    }

    //    console.log('Saved data to file.')
    //})
    var a = document.createElement("a");
    var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(data));
    a.href = dataStr;
    a.download = "bitchlasanga.json";
    a.click();
    //var dlAnchorElem = document.getElementById('downloadAnchorElem');
    //dlAnchorElem.setAttribute("href", dataStr);
    //dlAnchorElem.setAttribute("download", "scene.json");
    //dlAnchorElem.click();

}
