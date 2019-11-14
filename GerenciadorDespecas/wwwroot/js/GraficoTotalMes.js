$(".escolhaMes").on("Change", function () {
    var mesId = $(".escolhaMes").val();

    $.ajax({
        url: "Despesas/GastosTotalMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (data) {
            $(".canvas#GafricoGastoToatlMes").remove();
            $("div.GafricoGastoToatlMes").append('< canvas class="GafricoGastoToatlMes" style = "width: 400px; height: 400px; " ></canvas >');

            var ctx = document.getElementById("GafricoGastoToatlMes").getContext('2d');
            var grafico = new Chart(ctx, {
                type: 'doughnut',
                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets
                }


            })
        }

    })


});