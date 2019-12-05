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

