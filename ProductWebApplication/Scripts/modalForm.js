"use strict";
// muestra el modal de error en page formulario y blurrea el formulario de articulo
const btnMostrarModal = document.getElementById("btnEliminar");
const formContainer = document.querySelector(".form_container");

btnMostrarModal.addEventListener("click", (e) => {
    formContainer.classList.add("div_blurr");
})