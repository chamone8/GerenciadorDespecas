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