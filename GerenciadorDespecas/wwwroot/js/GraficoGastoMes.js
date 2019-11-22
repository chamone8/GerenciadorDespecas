
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
