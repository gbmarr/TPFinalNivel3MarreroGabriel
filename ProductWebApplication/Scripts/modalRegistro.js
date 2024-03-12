"use strict";
// muestra del modal de error en la carga de los datos de logueo y blurreo del formulario
const loginContainer = document.querySelector(".login_container");
const btnRegistro = document.getElementById("btnRegistrarse");
btnRegistro.addEventListener('click', () => {
    loginContainer.classList.add("div_blurr");
})