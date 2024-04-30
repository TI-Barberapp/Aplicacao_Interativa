const navbar = document.querySelector("[data-navbar]");
const navToggler = document.querySelector("[data-nav-toggler]");
const navLinks = document.querySelectorAll("[data-nav-link]");

const toggleNavbar = () => navbar.classList.toggle("active");

addEventOnElem(navToggler, "click", toggleNavbar);

const closeNavbar = () => navbar.classList.remove("active");

addEventOnElem(navLinks, "click", closeNavbar);


const header = document.querySelector("[data-header]");
const backTopBtn = document.querySelector("[data-back-top-btn]");

const headerActive = function () {
    if (window.scrollY > 100) {
        header.classList.add("active");
        backTopBtn.classList.add("active");
    } else {
        header.classList.remove("active");
        backTopBtn.classList.remove("active");
    }
}

addEventOnElem(window, "scroll", headerActive);

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