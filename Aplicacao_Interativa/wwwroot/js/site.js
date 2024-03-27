// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
	setTimeout(function () {
		$(".alert").fadeOut("slow", function () {
			$(this).alert('close');
		});
	}, 3000);
});

function validarFormulario() {
    var senha = document.getElementById("NovaSenha").value;
    var confirmarSenha = document.getElementById("ConfirmarSenha").value;
    var erroSenha = document.getElementById("erroSenha");

    if (senha !== confirmarSenha) {
        erroSenha.textContent = "As senhas não coincidem.";
        return false;
    } else {
        erroSenha.textContent = "";
        return true;
    }
}
//Organizar as datas de agendamento em forma de botões
document.addEventListener('DOMContentLoaded', function () {
    var calendario = document.getElementById('calendario');
    var dataAtual = new Date();
    var diasSemana = ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'];

    function criarBotaoDia(data) {
        var diaSemana = diasSemana[data.getDay()];
        var dia = data.getDate();
        var mes = data.getMonth() + 1;
        var ano = data.getFullYear();
        var diaFormatado = dia < 10 ? '0' + dia : dia;
        var mesFormatado = mes < 10 ? '0' + mes : mes;
        var dataFormatada = diaFormatado + '/' + mesFormatado;

        var botaoDia = document.createElement('button');
        botaoDia.innerHTML = '<div class="nome-dia">' + diaSemana + '</div><div class="data">' + dataFormatada + '</div>';
        botaoDia.dataset.data = dataFormatada;
        botaoDia.type = 'button';
        botaoDia.classList.add('btn', 'btn-outline-primary', 'btn-dia', 'm-1');
        if (data.getDay() === 0) {
            botaoDia.classList.add('domingo');
            botaoDia.disabled = true;
        }
        botaoDia.addEventListener('click', function () {
            document.querySelectorAll('#calendario button').forEach(function (botao) {
                botao.classList.remove('selected');
            });
            this.classList.add('selected');
            var dataSelecionada = this.dataset.data;
            document.getElementById('DataAgendamento').value = dataSelecionada;
        });

        return botaoDia;
    }
    for (var i = 0; i < 14; i++) {
        var novaData = new Date(dataAtual);
        novaData.setDate(dataAtual.getDate() + i);
        var botaoDia = criarBotaoDia(novaData);
        calendario.appendChild(botaoDia);
    }
});