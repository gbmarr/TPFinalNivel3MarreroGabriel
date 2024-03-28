"use strict";
// modal que muestra mensaje de aviso de que el articulo seleccionado ya forma parte de los favoritos
const mainContainer = document.querySelector(".main_container");
const btnFavorito = document.getElementById("cardFavorito");

btnFavorito.addEventListener('click', () => {
    mainContainer.classList.add("div_blurr");
})