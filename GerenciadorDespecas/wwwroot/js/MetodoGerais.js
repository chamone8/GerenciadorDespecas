function pegarValores(dados) {
    var valores = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {

        valores.push(dados[indice].valores);
        indice++;
    }
    return valores;

}

function PegarTiposDespesas(dados) {
    var labels = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {

        labels.push(dados[indice].tipoDespesas);
        indice++;
    }
    return labels;
}

function PegarCores(dados) {
    var cores = [];

    while (dados > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        cores.push("rgb(" + r + "," + g + "," + b + ")");
        dados--;
    }
    return cores;
}

function PegarMeses(dados) {
    var labels = [];
    var tamanho = dados.length;
    var indice = 0;

    while (indice < tamanho) {
        labels.push(dados[indice].nomeMeses[0]);
        indice++;
    }
    return labels;
}