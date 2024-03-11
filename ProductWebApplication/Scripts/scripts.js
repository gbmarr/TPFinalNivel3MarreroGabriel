const BtnMostrarModal = document.getElementById("btnEliminar");
const formContainer = document.querySelector(".form_container");

BtnMostrarModal.addEventListener('click', () => {
    formContainer.classList.add("div_blurr");
})