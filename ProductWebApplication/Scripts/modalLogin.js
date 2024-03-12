"use strict";
// muestra del modal de error en la carga de los datos de logueo y blurreo del formulario
const loginContainer = document.querySelector(".login_container");
const btnLogin = document.getElementById("btnLogin");
btnLogin.addEventListener('click', () => {
    console.log("clickeaste");
    loginContainer.classList.add("div_blurr");
})