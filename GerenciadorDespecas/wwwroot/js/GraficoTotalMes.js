
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