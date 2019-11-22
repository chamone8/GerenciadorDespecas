
$(".escolhaMes").on("change", function () {
    var mesId = $(".escolhaMes").val();

    $.ajax({
        url: "Despesas/GastosMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastoMes").remove();
            $("div.GraficoGastoMes").append('<canvas id="GraficoGastoMes" style = "width: 400px; height: 400px; " ></canvas >');

            var ctx = document.getElementById("GraficoGastoMes").getContext('2d');
            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: PegarTiposDespesas(dados),
                    datasets: [{

                        label: "Gasto Por Mês",
                        backgroundColor: PegarCores(dados.length),
                        hoverBackGroundColor: PegarCores(dados.length),
                        data: pegarValores(dados)

                    }]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total Gasto no Mes"
                    }
                }


            })
        }

    });


});

function CarregarDadosGastoMes() {


    $.ajax({
        url: "Despesas/GastosMes",
        method: "POST",
        data: { mesId: 1 },//Janeiro
        success: function (dados) {
            $("canvas#GafricoGastoMes").remove();
            $("div.GafricoGastoMes").append('<canvas id="GafricoGastoMes" style = "width: 400px; height: 400px; " ></canvas>');

            var ctx = document.getElementById("GraficoGastoMes").getContext('2d');
            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: PegarTiposDespesas(dados),
                    datasets: [{

                        label: "Gasto Por Mês",
                        backgroundColor: PegarCores(dados.length),
                        hoverBackGroundColor: PegarCores(dados.length),
                        data: pegarValores(dados)

                    }]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total Gasto no Mes"
                    }
                }


            });
        }

    });


}

function CarregarDadosGastoTotais() {
    $.ajax({
        url: 'Despesas/GastosTotais',
        method: 'POST',
        success: function (dados) {
            new Chart(document.getElementById('Gastototais'), {
                type: 'line',
                data: {
                    labels: PegarMeses(dados),

                    datasets: [{
                        label: "Total Gasto",
                        data: pegarValores(dados),
                        backgroundColor: "#ecf0f1",
                        borderColor: "#2980b9",
                        fill: false,
                        spanGaps: false
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: "Total Gasto"
                    }
                }
            });
        }

    });
}

$(".escolhaMes").on("change", function () {
    var mesId = $(".escolhaMes").val();

    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GafricoGastoTotalMes").remove();
            $("div.GafricoGastoTotalMes").append('<canvas id="GafricoGastoTotalMes" style = "width: 400px; height: 400px; " ></canvas >');

            var ctx = document.getElementById("GafricoGastoTotalMes").getContext('2d');
            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets: [{

                        label: "Total Gasto",
                        backgroundColor: ["#27ae60", "#c0392b"],
                        data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]

                    }]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total Gasto no Mes"
                    }
                }


            })
        }

    });


});

function CarregarDadosGastosTotaisMes() {
   

    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { mesId: 1 },//Janeiro
        success: function (dados) {
            $("canvas#GafricoGastoTotalMes").remove();
            $("div.GafricoGastoTotalMes").append('<canvas id="GafricoGastoTotalMes" style = "width: 400px; height: 400px; " ></canvas>');

            var ctx = document.getElementById("GafricoGastoTotalMes").getContext('2d');
            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets: [{

                        label: "Total Gasto",
                        backgroundColor: ["#27ae60", "#c0392b"],
                        data: [(dados.salario - dados.valorTotalGasto) , dados.valorTotalGasto]

                    }]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total Gasto no Mes"
                    }
                }


            })
        }

    });


}
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
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
