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