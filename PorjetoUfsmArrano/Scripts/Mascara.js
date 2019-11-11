﻿
function formataMascara(evt, formato) {
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;


    var result = "";
    var maskIdx = formato.length - 1;
    var error = false;
    var valor = campo.value;
    var posFinal = false;
    if (campo.setSelectionRange) {
        if (campo.selectionStart == valor.length)
            posFinal = true;
    }

    valor = valor.replace(/[^0123456789Xx]/g, '');
    for (var valIdx = valor.length - 1; valIdx >= 0 && maskIdx >= 0; --maskIdx) {
        var chr = valor.charAt(valIdx);
        var chrMask = formato.charAt(maskIdx);
        switch (chrMask) {
            case '#':
                if (!(/\d/.test(chr)))
                    error = true;
                result = chr + result;
                --valIdx;
                break;
            case '@':
                result = chr + result;
                --valIdx;
                break;
            default:
                result = chrMask + result;
        }
    }

    campo.value = result;
    campo.style.color = error ? 'red' : '';
    if (posFinal) {
        campo.selectionStart = result.length;
        campo.selectionEnd = result.length;
    }
    return result;
}

// Formata o campo valor monetário
function formataValor(evt) {
    //1.000.000,00
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        vr = parseFloat(vr.toString()).toString();
        tam = vr.length;

        if (tam == 1)
            campo.value = "0,0" + vr;
        if (tam == 2)
            campo.value = "0," + vr;
        if ((tam > 2) && (tam <= 5)) {
            campo.value = vr.substr(0, tam - 2) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 6) && (tam <= 8)) {
            campo.value = vr.substr(0, tam - 5) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 9) && (tam <= 11)) {
            campo.value = vr.substr(0, tam - 8) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 12) && (tam <= 14)) {
            campo.value = vr.substr(0, tam - 11) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 15) && (tam <= 18)) {
            campo.value = vr.substr(0, tam - 14) + '.' + vr.substr(tam - 14, 3) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
    }
    MovimentaCursor(campo, xPos);
}

// Formata o campo valor monetário
function formataValor2(evt) {
    //1.000.000,0000
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        vr = parseFloat(vr.toString()).toString();
        tam = vr.length;

        if (tam == 1)
            campo.value = "0,000" + vr;
        if (tam == 2)
            campo.value = "0,00" + vr;
        if (tam == 3)
            campo.value = "0,0" + vr;
        if (tam == 4)
            campo.value = "0," + vr;

        if ((tam > 4) && (tam <= 7)) {
            campo.value = vr.substr(0, tam - 4) + ',' + vr.substr(tam - 4, tam);
        }
        if ((tam >= 8) && (tam <= 10)) {
            campo.value = vr.substr(0, tam - 7) + '.' + vr.substr(tam - 7, 3) + ',' + vr.substr(tam - 4, tam);
        }
        if ((tam >= 11) && (tam <= 13)) {
            campo.value = vr.substr(0, tam - 10) + '.' + vr.substr(tam - 10, 3) + '.' + vr.substr(tam - 7, 3) +
			    ',' + vr.substr(tam - 4, tam);
        }
        if ((tam >= 14) && (tam <= 16)) {
            campo.value = vr.substr(0, tam - 13) + '.' + vr.substr(tam - 13, 3) + '.' + vr.substr(tam - 10, 3) +
			    '.' + vr.substr(tam - 7, 3) + ',' + vr.substr(tam - 4, tam);
        }
        if ((tam >= 15) && (tam <= 18)) {
            campo.value = vr.substr(0, tam - 16) + '.' + vr.substr(tam - 16, 3) + '.' + vr.substr(tam - 13, 3) +
			    '.' + vr.substr(tam - 10, 3) + '.' + vr.substr(tam - 7, 3) + ',' + vr.substr(tam - 4, tam);
        }

        //		if ((tam > 4) && (tam <= 7))
        //		{
        //			campo.value = vr.substr(0, tam - 4) + ',' + vr.substr(tam - 4, tam);
        //		}
        //		if ((tam >= 8) && (tam <= 10))
        //		{
        //			campo.value = vr.substr(0, tam - 7) + '.' + vr.substr(tam - 7, 5) + ',' + vr.substr(tam - 4, tam);
        //		}
        //		if ((tam >= 11) && (tam <= 13))
        //		{
        //			campo.value = vr.substr(0, tam - 10) + '.' + vr.substr(tam - 10, 5) + '.' + vr.substr(tam - 7, 5) + ',' + vr.substr(tam - 4, tam);
        //		}
        //		if ((tam >= 14) && (tam <= 16))
        //		{
        //			campo.value = vr.substr(0, tam - 13) + '.' + vr.substr(tam - 13, 5) + '.' + vr.substr(tam - 10, 5) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        //		}
        //		if ((tam >= 15) && (tam <= 18))
        //		{
        //			campo.value = vr.substr(0, tam - 14) + '.' + vr.substr(tam - 14, 3) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        //		}
    }
    MovimentaCursor(campo, xPos);
}

// Formata o campo valor monetário
function formataMoeda(evt) {
    //1.000.000,00
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget; //firefox

    var xPos = PosicaoCursor(campo);
    var tamInicial = campo.value.length;

    var tecla = getKeyCode(evt);
    if (!teclaValidaInclusiveAoApagar(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        var numZeros = vr.toString();

        vr = parseFloat(vr) / 100;

        vr = parseFloat(vr).toFixed(2);

        vr = vr.toString().replace('.', ',');

        var aux = filtraNumeros(vr);
        var i = aux.length - 2;

        var numPontos = parseInt(i / 3);

        while ((i - 3) >= 1) {
            i = parseInt(i - 3);
            vr = vr.toString().substr(0, i) + '.' + vr.toString().substr(i, aux.length - i + numPontos);
        }
    }
    campo.value = vr;
    if (xPos > 0) {
        var x = (vr.length - tamInicial);

        xPos = xPos + x;
    }
    MovimentaCursor(campo, xPos);
}

// formata inteiro com milhar
function formataInteiroComMilhar(evt) {
    //1.000.000
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);
    var tamInicial = campo.value.length;

    var tecla = getKeyCode(evt);
    if (!teclaValidaInclusiveAoApagar(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        var numZeros = vr.toString();

        vr = vr.toString().replace('.', ',');

        var aux = filtraNumeros(vr);
        var i = aux.length;

        var numPontos = parseInt(i / 3);

        while ((i - 3) >= 1) {
            i = parseInt(i - 3);
            vr = vr.toString().substr(0, i) + '.' + vr.toString().substr(i, aux.length - i + numPontos);
        }
    }

    campo.value = vr;
    if (xPos > 0) {
        var x = (vr.length - tamInicial);

        xPos = xPos + x;
    }
    MovimentaCursor(campo, xPos);
}

// Formata data no padrão DD/MM/YYYY
function formataData(evt) {
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget; //firefox
    var xPos = PosicaoCursor(campo);
    //dd/MM/yyyy
    //evt = getEvent(evt);

    var tecla = getKeyCode(evt);

    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam >= 2 && tam < 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2);
    if (tam == 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/';
    if (tam > 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4);

    MovimentaCursor(campo, xPos);
}

//descobre qual a posição do cursor no campo
function PosicaoCursor(textarea) {
    var pos = 0;
    if (typeof (document.selection) != 'undefined') {
        //IE
        var range = document.selection.createRange();
        var i = 0;
        for (i = textarea.value.length; i > 0; i--) {
            if (range.moveStart('character', 1) == 0)
                break;
        }
        pos = i;
    }
    if (typeof (textarea.selectionStart) != 'undefined') {
        //FireFox
        pos = textarea.selectionStart;
    }

    if (pos == textarea.value.length)
        return 0; //retorna 0 quando não precisa posicionar o elemento
    else
        return pos; //posição do cursor
}

// move o cursor para a posição pos
function MovimentaCursor(textarea, pos) {
    if (pos <= 0)
        return; //se a posição for 0 não reposiciona

    if (typeof (document.selection) != 'undefined') {
        //IE
        var oRange = textarea.createTextRange();
        var LENGTH = 1;
        var STARTINDEX = pos;

        oRange.moveStart("character", -textarea.value.length);
        oRange.moveEnd("character", -textarea.value.length);
        oRange.moveStart("character", pos);
        //oRange.moveEnd("character", pos);
        oRange.select();
        textarea.focus();
    }
    if (typeof (textarea.selectionStart) != 'undefined') {
        //FireFox
        textarea.selectionStart = pos;
        textarea.selectionEnd = pos;
    }
}

//Formata data e hora no padrão DD/MM/YYYY HH:MM
function formataDataeHora(evt) {
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget; //firefox
    xPos = PosicaoCursor(campo);
    //dd/MM/yyyy

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam >= 2 && tam < 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2);
    if (tam == 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/';
    if (tam > 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4);
    if (tam > 8 && tam < 11)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4, 4) + ' ' + vr.substr(8, 2);
    if (tam >= 11)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4, 4) + ' ' + vr.substr(8, 2) + ':' + vr.substr(10);

    campo.value = campo.value.substr(0, 16);
    //    if(xPos == 2 || xPos == 5)
    //        xPos = xPos +1;
    //    if(xPos == 11 || xPos == 14)
    //        xPos = xPos +2;
    MovimentaCursor(campo, xPos);
}

// Formata só números
function formataInteiro(evt) {
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget; //firefox
    //1234567890
    xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    campo.value = filtraNumeros(filtraCampo(campo));
    MovimentaCursor(campo, xPos);
}

// Formata hora no padrao HH:MM
function formataHora(evt) {
    //HH:mm
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));

    if (tam == 2)
        campo.value = vr.substr(0, 2) + ':';
    if (tam > 2 && tam < 5)
        campo.value = vr.substr(0, 2) + ':' + vr.substr(2);
    //    if(xPos == 2)
    //        xPos = xPos + 1;
    MovimentaCursor(campo, xPos);
}

// Formata hora no padrao HH:MMA - O caracter A indica que o horário pertence ao dia seguinte.
function formataHoraComA(evt) {
    //HH:mm
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    temA = false;
    if (campo.value.length == 6 && campo.value.substr(5).toUpperCase() == 'A')
        temA = true;

    vr = campo.value = filtraNumeros(filtraCampo(campo));

    if (tam == 2)
        campo.value = vr.substr(0, 2) + ':';
    if (tam > 2 && tam < 6) {
        campo.value = vr.substr(0, 2) + ':' + vr.substr(2);
        if (temA)
            campo.value = campo.value + 'A';
        else
            campo.value = campo.value.substr(0, 5);
    }

    MovimentaCursor(campo, xPos);
}

// limpa todos os caracteres especiais do campo solicitado
function filtraCampo(campo) {
    var s = "";
    var cp = "";
    vr = campo.value;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) != "/"
            && vr.substring(i, i + 1) != "-"
            && vr.substring(i, i + 1) != "."
            && vr.substring(i, i + 1) != "("
            && vr.substring(i, i + 1) != ")"
            && vr.substring(i, i + 1) != ":"
            && vr.substring(i, i + 1) != ",") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
    //return campo.value.replace("/", "").replace("-", "").replace(".", "").replace(",", "")
}

// limpa todos caracteres que não são números
function filtraNumeros(campo) {
    var s = "";
    var cp = "";
    vr = campo;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) == "0" ||
            vr.substring(i, i + 1) == "1" ||
            vr.substring(i, i + 1) == "2" ||
            vr.substring(i, i + 1) == "3" ||
            vr.substring(i, i + 1) == "4" ||
            vr.substring(i, i + 1) == "5" ||
            vr.substring(i, i + 1) == "6" ||
            vr.substring(i, i + 1) == "7" ||
            vr.substring(i, i + 1) == "8" ||
            vr.substring(i, i + 1) == "9") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
    //return campo.value.replace("/", "").replace("-", "").replace(".", "").replace(",", "")
}

// limpa todos caracteres que não são letras
function filtraCaracteres(campo) {
    vr = campo;
    for (i = 0; i < tam; i++) {
        //Caracter
        if (vr.charCodeAt(i) != 32 && vr.charCodeAt(i) != 94 && (vr.charCodeAt(i) < 65 ||
        (vr.charCodeAt(i) > 90 && vr.charCodeAt(i) < 96) ||
            vr.charCodeAt(i) > 122) && vr.charCodeAt(i) < 192) {
            vr = vr.replace(vr.substr(i, 1), "");
            i--;
        }
    }
    return vr;
}

// limpa todos caracteres que não são letras
function filtraCaracteresRelatorio(campo) {
    vr = campo;
    for (i = 0; i < tam; i++) {
        //Caracter
        if (vr.charCodeAt(i) != 32 && vr.charCodeAt(i) != 94 && (vr.charCodeAt(i) < 65 ||
        (vr.charCodeAt(i) > 90 && vr.charCodeAt(i) < 96) ||
            vr.charCodeAt(i) > 122) && vr.charCodeAt(i) < 192 && vr.charCodeAt(i) != 37) {
            vr = vr.replace(vr.substr(i, 1), "");
        }
    }
    return vr;
}

// limpa todos caracteres que não são números, menos a vírgula
function filtraNumerosComVirgula(campo) {
    var s = "";
    var cp = "";
    vr = campo;
    tam = vr.length;
    var complemento = 0; //flag paga contar o número de virgulas
    for (i = 0; i < tam; i++) {
        if ((vr.substring(i, i + 1) == "," && complemento == 0 && s != "") ||
            vr.substring(i, i + 1) == "0" ||
            vr.substring(i, i + 1) == "1" ||
            vr.substring(i, i + 1) == "2" ||
            vr.substring(i, i + 1) == "3" ||
            vr.substring(i, i + 1) == "4" ||
            vr.substring(i, i + 1) == "5" ||
            vr.substring(i, i + 1) == "6" ||
            vr.substring(i, i + 1) == "7" ||
            vr.substring(i, i + 1) == "8" ||
            vr.substring(i, i + 1) == "9") {
            if (vr.substring(i, i + 1) == ",")
                complemento = complemento + 1;
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
}

function formataMesAno(evt) {
    //MM/yyyy
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam >= 2)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2);
    MovimentaCursor(campo, xPos);
}

function formataCNPJ(evt) {
    //99.999.999/9999-99
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget; //firefox

    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam >= 2 && tam < 5)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2);
    else if (tam >= 5 && tam < 8)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5);
    else if (tam >= 8 && tam < 12)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5, 3) + '/' + vr.substr(8);
    else if (tam >= 12)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5, 3) + '/' + vr.substr(8, 4) + '-' + vr.substr(12);
    MovimentaCursor(campo, xPos);
}

function formataCPF(evt) {
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget; //firefox
    var xPos = PosicaoCursor(campo);
    //999.999.999-99	
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;
    if (tam >= 3 && tam < 6)
        campo.value = vr.substr(0, 3) + '.' + vr.substr(3);
    else if (tam >= 6 && tam < 9)
        campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(6);
    else if (tam >= 9)
        campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(6, 3) + '-' + vr.substr(9);
    MovimentaCursor(campo, xPos);
}

function formataDouble(evt) {
    //18,53012
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    campo.value = filtraNumerosComVirgula(campo.value);
    MovimentaCursor(campo, xPos);
}

function formataTelefone(evt) {
    //(00) 0000-0000
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam == 1)
        campo.value = '(' + vr;
    else if (tam >= 2 && tam < 6)
        campo.value = '(' + vr.substr(0, 2) + ') ' + vr.substr(2);
    else if (tam >= 6)
        campo.value = '(' + vr.substr(0, 2) + ') ' + vr.substr(2, 4) + '-' + vr.substr(6);

    //(
    //    if(xPos == 1 || xPos == 3 || xPos == 5 || xPos == 9)
    //        xPos = xPos +1
    MovimentaCursor(campo, xPos);
}

function formataTexto(evt, sMascara) {
    //Nome com Inicial Maiuscula.
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    xPos = PosicaoCursor(campo);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraCaracteres(filtraCampo(campo));
    tam = vr.length;

    if (sMascara == "Aa" || sMascara == "Xx") {
        var valor = campo.value.toLowerCase();
        var count = campo.value.split(" ").length - 1;
        var i;
        var pos = 0;
        var valorIni;
        var valorMei;
        var valorFim;
        valor = valor.substring(0, 1).toUpperCase() + valor.substring(1, valor.length);
        for (i = 0; i < count; i++) {
            pos = valor.indexOf(" ", pos + 1);
            valorIni = valor.substring(0, valor.indexOf(" ", pos - 1)) + " ";
            valorMei = valor.substring(valor.indexOf(" ", pos) + 1, valor.indexOf(" ", pos) + 2).toUpperCase();
            valorFim = valor.substring(valor.indexOf(" ", pos) + 2, valor.length);
            valor = valorIni + valorMei + valorFim;
        }
        campo.value = valor;
    }


    if (sMascara == "Aaa" || sMascara == "Xxx") {
        var valor = campo.value.toLowerCase();
        var count = campo.value.split(" ").length - 1;
        var i;
        var pos = 0;
        var valorIni;
        var valorMei;
        var valorFim;
        var ligacao = false;
        var chrLigacao = Array("de", "da", "do", "para", "e")
        valor = valor.substring(0, 1).toUpperCase() + valor.substring(1, valor.length);
        for (i = 0; i < count; i++) {
            ligacao = false;
            pos = valor.indexOf(" ", pos + 1);
            valorIni = valor.substring(0, valor.indexOf(" ", pos - 1)) + " ";
            for (var a = 0; a < chrLigacao.length; a++) {
                if (valor.substring(valorIni.length, valor.indexOf(" ", valorIni.length)).toLowerCase() == chrLigacao[a].toLowerCase()) {
                    ligacao = true;
                    break;
                }
                else if (ligacao == false && valor.indexOf(" ", valorIni.length) == -1) {
                    if (valor.substring(valorIni.length, valor.length).toLowerCase() == chrLigacao[a].toLowerCase()) {
                        ligacao = true;
                        break;
                    }
                }
            }
            if (ligacao == true) {
                valorMei = valor.substring(valor.indexOf(" ", pos) + 1, valor.indexOf(" ", pos) + 2).toLowerCase();
            }
            else {
                valorMei = valor.substring(valor.indexOf(" ", pos) + 1, valor.indexOf(" ", pos) + 2).toUpperCase();
            }
            valorFim = valor.substring(valor.indexOf(" ", pos) + 2, valor.length);
            valor = valorIni + valorMei + valorFim;
        }

        campo.value = valor;
    }
    MovimentaCursor(campo, xPos);
    return true;
}

function formataTextoRelatorio(evt, sMascara) {
    //Nome com Inicial Maiuscula.
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    xPos = PosicaoCursor(campo);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraCaracteresRelatorio(filtraCampo(campo));
    tam = vr.length;

    if (sMascara == "Aa" || sMascara == "Xx") {
        var valor = campo.value.toLowerCase();
        var count = campo.value.split(" ").length - 1;
        var i;
        var pos = 0;
        var valorIni;
        var valorMei;
        var valorFim;
        valor = valor.substring(0, 1).toUpperCase() + valor.substring(1, valor.length);
        for (i = 0; i < count; i++) {
            pos = valor.indexOf(" ", pos + 1);
            valorIni = valor.substring(0, valor.indexOf(" ", pos - 1)) + " ";
            valorMei = valor.substring(valor.indexOf(" ", pos) + 1, valor.indexOf(" ", pos) + 2).toUpperCase();
            valorFim = valor.substring(valor.indexOf(" ", pos) + 2, valor.length);
            valor = valorIni + valorMei + valorFim;
        }
        campo.value = valor;
    }


    if (sMascara == "Aaa" || sMascara == "Xxx") {
        var valor = campo.value.toLowerCase();
        var count = campo.value.split(" ").length - 1;
        var i;
        var pos = 0;
        var valorIni;
        var valorMei;
        var valorFim;
        var ligacao = false;
        var chrLigacao = Array("de", "da", "do", "para", "e")
        valor = valor.substring(0, 1).toUpperCase() + valor.substring(1, valor.length);
        for (i = 0; i < count; i++) {
            ligacao = false;
            pos = valor.indexOf(" ", pos + 1);
            valorIni = valor.substring(0, valor.indexOf(" ", pos - 1)) + " ";
            for (var a = 0; a < chrLigacao.length; a++) {
                if (valor.substring(valorIni.length, valor.indexOf(" ", valorIni.length)).toLowerCase() == chrLigacao[a].toLowerCase()) {
                    ligacao = true;
                    break;
                }
                else if (ligacao == false && valor.indexOf(" ", valorIni.length) == -1) {
                    if (valor.substring(valorIni.length, valor.length).toLowerCase() == chrLigacao[a].toLowerCase()) {
                        ligacao = true;
                        break;
                    }
                }
            }
            if (ligacao == true) {
                valorMei = valor.substring(valor.indexOf(" ", pos) + 1, valor.indexOf(" ", pos) + 2).toLowerCase();
            }
            else {
                valorMei = valor.substring(valor.indexOf(" ", pos) + 1, valor.indexOf(" ", pos) + 2).toUpperCase();
            }
            valorFim = valor.substring(valor.indexOf(" ", pos) + 2, valor.length);
            valor = valorIni + valorMei + valorFim;
        }

        campo.value = valor;
    }
    MovimentaCursor(campo, xPos);
    return true;
}

// Formata o campo CEP
function formataCEP(evt) {
    //312555-650
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam < 5)
        campo.value = vr;
    else if (tam == 5)
        campo.value = vr + '-';
    else if (tam > 5)
        campo.value = vr.substr(0, 5) + '-' + vr.substr(5);
    MovimentaCursor(campo, xPos);
}

function formataCartaoCredito(evt) {
    //0000.0000.0000.0000
    evt = getEvent(evt);
    var campo = evt.srcElement; //IE
    if (typeof (campo) == 'undefined')
        campo = evt.originalTarget;
    var xPos = PosicaoCursor(campo);

    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    var vr = campo.value = filtraNumeros(filtraCampo(campo));
    var tammax = 16;
    var tam = vr.length;

    if (tam < tammax && tecla != 8)
    { tam = vr.length + 1; }

    if (tam < 5)
    { campo.value = vr; }
    if ((tam > 4) && (tam < 9))
    { campo.value = vr.substr(0, 4) + '.' + vr.substr(4, tam - 4); }
    if ((tam > 8) && (tam < 13))
    { campo.value = vr.substr(0, 4) + '.' + vr.substr(4, 4) + '.' + vr.substr(8, tam - 4); }
    if (tam > 12)
    { campo.value = vr.substr(0, 4) + '.' + vr.substr(4, 4) + '.' + vr.substr(8, 4) + '.' + vr.substr(12, tam - 4); }
    MovimentaCursor(campo, xPos);
}


//recupera tecla

//evita criar mascara quando as teclas são pressionadas
function teclaValida(tecla) {
    if (tecla == 8 //backspace
        //Esta evitando o post, quando são pressionadas estas teclas.
        //Foi comentado pois, se for utilizado o evento texchange, é necessario o post.
        || tecla == 9 //TAB
        || tecla == 27 //ESC
        || tecla == 16 //Shif TAB 
        || tecla == 45 //insert
        || tecla == 46 //delete
        || tecla == 35 //home
        || tecla == 36 //end
        || tecla == 37 //esquerda
        || tecla == 38 //cima
        || tecla == 39 //direita
        || tecla == 40)//baixo
        return false;
    else
        return true;
}

//evita criar mascara quando as teclas são pressionadas
function teclaValidaInclusiveAoApagar(tecla) {
    if (
        //Esta evitando o post, quando são pressionadas estas teclas.
        //Foi comentado pois, se for utilizado o evento texchange, é necessario o post.
        tecla == 9 //TAB
        || tecla == 27 //ESC
        || tecla == 16 //Shif TAB 
        || tecla == 45 //insert
        || tecla == 35 //home
        || tecla == 36 //end
        || tecla == 37 //esquerda
        || tecla == 38 //cima
        || tecla == 39 //direita
        || tecla == 40)//baixo
        return false;
    else
        return true;
}

// recupera o evento do form
function getEvent(evt) {
    if (!evt) evt = window.event; //IE
    return evt;
}
//Recupera o código da tecla que foi pressionado
function getKeyCode(evt) {
    var code;
    if (typeof (evt.keyCode) == 'number')
        code = evt.keyCode;
    else if (typeof (evt.which) == 'number')
        code = evt.which;
    else if (typeof (evt.charCode) == 'number')
        code = evt.charCode;
    else
        return 0;

    return code;
}


//validador email
function validacaoEmail(field) {
    usuario = field.value.substring(0, field.value.indexOf("@"));
    dominio = field.value.substring(field.value.indexOf("@") + 1, field.value.length);
    if ((usuario.length >= 1) && (dominio.length >= 3) && (usuario.search("@") == -1) && (dominio.search("@") == -1) && (usuario.search(" ") == -1) && (dominio.search(" ") == -1) && (dominio.search(".") != -1) && (dominio.indexOf(".") >= 1) && (dominio.lastIndexOf(".") < dominio.length - 1)) { document.getElementById("msgemail").innerHTML = "E-mail válido"; alert("E-mail valido"); } else { document.getElementById("msgemail").innerHTML = "<font color='red'>E-mail inválido </font>"; alert("E-mail invalido"); }
}
